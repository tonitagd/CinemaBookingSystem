﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace CinemaBookingSystem
{
    public partial class ProgramWindow : Window
    {
        ShowList Shows;
        DayOfWeek currentDayOfWeek = DayOfWeek.Saturday;

        public ProgramWindow(ShowList shows)
        {
            InitializeComponent();
            this.Shows = shows;
            PopulateWithCells();
            DayOfWeekLabel.Content = currentDayOfWeek;
            btnForward.IsEnabled = false;
        }

        private void PopulateWithCells()
        {
            List<List<Label>> showsList = new List<List<Label>>();

            for (int i = 0; i < this.Shows.Movies.Count; i++)
            {
                Movie show = this.Shows.Movies[i];

                int index = show.ProjectionTime.FindIndex(item => item.DayOfWeek == currentDayOfWeek);
                if (index < 0)
                {
                    continue;
                }

                Label showNameLabel = CreateMovieLabel(show.Name);
                showNameLabel.Width = 300;
                List<Label> content = new List<Label>();
                content.Add(showNameLabel);
                MovieDate projectionDate = show.ProjectionTime.Find(item => item.DayOfWeek == currentDayOfWeek);


                for (int j = 0; j < projectionDate.ShowTime.Count; j++)
                {
                    Label timeButton = CreateTimeButton(new LabelData { MovieDate = show.Name, time = projectionDate.ShowTime[j] });
                    content.Add(timeButton);
                }

                showsList.Add(content);
            }

            showsButtons.ItemsSource = showsList;
        }

        private static Label CreateMovieLabel(string content)
        {
            Label showNameLabel = CreateBasicLabel();
            showNameLabel.Content = content;

            return showNameLabel;
        }

        private static Label CreateBasicLabel()
        {
            Label showNameLabel = new Label();
            showNameLabel.FontFamily = new FontFamily("Cambria");
            showNameLabel.FontSize = 14;
            showNameLabel.Margin = new Thickness(0, 0, 0, 0);
            BrushConverter bc = new BrushConverter();
            showNameLabel.Foreground = (Brush)bc.ConvertFrom("#FF4DB3C3");
            showNameLabel.Background = Brushes.Transparent;
            return showNameLabel;
        }

        private Label CreateTimeButton(LabelData content)
        {
            Label timeButton = CreateBasicLabel();
            timeButton.Foreground = Brushes.White;
            timeButton.Content = content;
            timeButton.Cursor = Cursors.Hand;
            timeButton.Margin = new Thickness(10, 0, 4, 0);
            timeButton.MouseLeftButtonUp += new MouseButtonEventHandler(ChooseTimeLabelClick);
            return timeButton;
        }

        private void ChooseTimeLabelClick(object sender, MouseEventArgs e)
        {
            Label button = sender as Label;
            LabelData data = (button.Content as LabelData);
            Show show = Shows.FindShow(data.MovieDate, currentDayOfWeek, data.time);

            ReservationWindow window = new ReservationWindow(show);
            window.Show();
            this.Close();
        }

        private void ButtonBackward_Click(object sender, RoutedEventArgs e)
        {
            currentDayOfWeek--;
            PopulateWithCells();
            DayOfWeekLabel.Content = currentDayOfWeek;

            if (currentDayOfWeek <= 0)
            {
                (sender as Button).IsEnabled = false;
            }
            else
            {
                (sender as Button).IsEnabled = true;
            }

            btnForward.IsEnabled = true;
        }

        private void Button_Forward_Click(object sender, RoutedEventArgs e)
        {
            currentDayOfWeek++;
            PopulateWithCells();
            DayOfWeekLabel.Content = currentDayOfWeek;

            if ((int)currentDayOfWeek >= 6)
            {
                (sender as Button).IsEnabled = false;
            }
            else
            {
                (sender as Button).IsEnabled = true;
            }
        }
    }

    class LabelData
    {
        public string MovieDate;
        public Time time;

        public override string ToString()
        {
            return time.ToString();
        }
    }
}
