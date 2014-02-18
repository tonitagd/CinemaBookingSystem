﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CinemaBookingSystem
{
    public partial class MainWindow : Window
    {
        MovieList movies;
        MovieLoader loader;
        int page = 1;
        int maxPageNumber = 0;
        Movie firstButtonMovie;
        Movie secondButtonMovie;
        Movie thirdButtonMovie;
        CinemaHallList halls;
        ShowList shows;

        public MainWindow()
        {
            InitializeComponent();
            InitializeWindow();
        }

        private void InitializeWindow()
        {
            loader = new MovieLoader();
            movies = loader.LoadAllMovies();
            halls = new CinemaHallList();
            halls.LoadHalls();
            shows = new ShowList(movies, halls);
            shows.LoadShows();

            movies = loader.LoadPremieres();
            UpdateUI();
        }

        private void UpdateUI()
        {
            CalculateMaxPageNumber();
            PageLabel.Content = page + "-" + maxPageNumber;
            UpdateMovieImages();
            EnableDisableButtons();
        }

        private void CalculateMaxPageNumber()
        {
            maxPageNumber = (int)(movies.Count / 3);
            if (movies.Count % 3 != 0)
            {
                maxPageNumber++;
            }
        }

        private void UpdateMovieImages()
        {
            int count = movies.Count;

            if (movies.Count % 3 != 0 && page * 3 > movies.Count) // If the movies count does not devide without reminder to the images boxes we put the last 3 on the page
            {
                firstButtonMovie = movies[count - 3];
                secondButtonMovie = movies[count - 2];
                thirdButtonMovie = movies[count - 1];
            }
            else
            {
                firstButtonMovie = movies[(page - 1) * 3]; // And here be dragons ;]
                secondButtonMovie = movies[((page - 1) * 3 + 1)];
                thirdButtonMovie = movies[((page - 1) * 3 + 2)];
            }

            MovieImage1.Source = LoadImage(firstButtonMovie.ImageSource);
            MovieImage2.Source = LoadImage(secondButtonMovie.ImageSource);
            MovieImage3.Source = LoadImage(thirdButtonMovie.ImageSource);
        }

        private BitmapImage LoadImage(string source)
        {
            string resource = "pack://application:,,,/" + source;
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(resource);
            image.EndInit();
            return image;
        }

        private void EnableDisableButtons()
        {
            if (page >= maxPageNumber)
            {
                menuScrollRight.IsEnabled = false;
            }
            else
            {
                menuScrollRight.IsEnabled = true;
            }

            if (page <= 1)
            {
                menuScrollLeft.IsEnabled = false;
            }
            else
            {
                menuScrollLeft.IsEnabled = true;
            }
        }

        private void menuButton_Click(object sender, RoutedEventArgs e)
        {
            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;
        }

        private void MenuItemPremiere_Click(object sender, RoutedEventArgs e)
        {
            menuButton.Content = "Premieres";
            movies = loader.LoadPremieres();
            page = 1;
            UpdateUI();
        }

        private void MenuItemAll_Click(object sender, RoutedEventArgs e)
        {
            menuButton.Content = "All Movies";
            movies = loader.LoadAllMovies();
            UpdateUI();
        }

        private void scrollRightButton_Click(object sender, RoutedEventArgs e)
        {
            if (page < maxPageNumber)
            {
                page++;
                UpdateUI();
            }
        }

        private void scrollLeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (page >= 2)
            {
                page--;
                UpdateUI();
            }
        }

        private void SearchTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = "";
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string name = SearchTextBox.Text;

            Movie movie = movies.FindMovie(name);
            if (movie == null)
            {
                MessageBox.Show("Could not find movie with that name.");
            }
            else
            {
                OpenMovieWindow(movie, shows);
            }
        }

        private void Image1Button_Click(object sender, RoutedEventArgs e)
        {
            OpenMovieWindow(firstButtonMovie, shows);
        }

        private void Image2Button_Click(object sender, RoutedEventArgs e)
        {
            OpenMovieWindow(secondButtonMovie, shows);
        }

        private void Image3Button_Click(object sender, RoutedEventArgs e)
        {
            OpenMovieWindow(thirdButtonMovie, shows);
        }

        private static void OpenMovieWindow(Movie movie, ShowList shows)
        {
            MovieWindow window = new MovieWindow(movie, shows);
            window.Show();
        }

        private void ProgramLabel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ProgramWindow window = new ProgramWindow(shows);
            window.Show();
        }
    }
}
