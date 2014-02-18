﻿using System;
using System.Collections.Generic;

namespace CinemaBookingSystem
{
    class MovieLoader : IMovieLoader
    {
        MovieList movies;
        MovieList premieres;
        Random randomTime;


        public MovieLoader()
        {
            movies = new MovieList();
            premieres = new MovieList();
            movies.Add(CreateHungerGames());
            movies.Add(CreateTheSmurfs());
            movies.Add(CreateThor());
            movies.Add(CreateHobbit());
            movies.Add(CreateKhumba());
            movies.Add(CreateAboutTime());
            movies.Add(CreateRunner());
            movies.Add(CreateFreeBirds());
            movies.Add(CreateCounselor());
            movies.Add(CreateCarrie());
            movies.Add(CreateDespicableMe());
            movies.Add(CreateBattleOfTheYear());

            for (int i = 0; i < movies.Count; i++)
            {
                if (movies[i].IsPremiere)
                {
                    premieres.Add(movies[i]);
                }
            }

            randomTime = new Random(DateTime.Now.Millisecond);
        }

        public MovieList LoadPremieres()
        {
            return premieres;
        }

        private static Movie CreateHungerGames()
        {
            List<string> actors = new List<string>();
            actors.Add("Jennifer Lawrence");
            actors.Add("Josh Hutcherson");
            actors.Add("Liam Hemsworth");
            bool isPremiere = true;
            List<MovieDate> projectionDates = CreateRandomProjectionDays();

            string movieInfo = @"Katniss Everdeen and Peeta Mellark become targets of the Capitol after their victory in the 74th Hunger Games sparks a rebellion in the Districts of Panem.";
            Movie movie = new Movie("Hunger games II", Genre.Action, new Time(2, 26), "Francis Lawrence", actors, movieInfo, isPremiere, projectionDates);
            movie.ImageSource = @"Images\Movies\HungerGames2.jpg";

            return movie;
        }

        private static Movie CreateThor()
        {
            List<string> actors = new List<string>();
            actors.Add("Chris Hemsworth");
            actors.Add("Natalie Portman");
            actors.Add("Tom Hiddleston");
            bool isPremiere = true;
            List<MovieDate> projectionDates = CreateRandomProjectionDays();
            string movieInfo = @"Faced with an enemy that even Odin and Asgard cannot withstand, Thor must embark on his most perilous and personal journey yet, one that will reunite him with Jane Foster and force him to sacrifice everything to save us all.";
            Movie movie = new Movie("Thor: The Dark World", Genre.Fantasy, new Time(1, 53), "Alan Taylor, James Gunn", actors, movieInfo, isPremiere, projectionDates);
            movie.ImageSource = @"Images\Movies\Thor.jpg";

            return movie;
        }

        private static Movie CreateHobbit()
        {
            List<string> actors = new List<string>();
            actors.Add("Martin Freeman");
            actors.Add(" Ian McKellen");
            actors.Add("Richard Armitage");
            bool isPremiere = true;
            List<MovieDate> projectionDates = CreateRandomProjectionDays();
            string movieInfo = @"The dwarves, along with Bilbo Baggins and Gandalf the Grey, continue their quest to reclaim Erebor, their homeland, from Smaug. Bilbo Baggins is in possession of a mysterious and magical ring.";
            Movie movie = new Movie("The Hobbit: The Desolation of Smaug", Genre.Adventure, new Time(2, 41), "Peter Jackson", actors, movieInfo, isPremiere, projectionDates);
            movie.ImageSource = @"Images\Movies\Hobbit.jpg";

            return movie;
        }

        public MovieList LoadAllMovies()
        {
            return movies;
        }

        private static Movie CreateRunner()
        {
            List<string> actors = new List<string>();
            actors.Add("Justin Timberlake");
            actors.Add("Ben Affleck");
            actors.Add("Gemma Arterton");
            bool isPremiere = false;
            List<MovieDate> projectionDates = CreateRandomProjectionDays();
            string movieInfo = @"When a poor college student who cracks an online poker game goes bust, he arranges a face-to-face with the man he thinks cheated him, a sly offshore entrepreneur.";
            Movie movie = new Movie("Runner Runner", Genre.Action, new Time(1, 31), "Brad Furman", actors, movieInfo, isPremiere, projectionDates);
            movie.ImageSource = @"Images\Movies\Runner Runner.jpg";

            return movie;
        }

        private static Movie CreateCounselor()
        {
            List<string> actors = new List<string>();
            actors.Add("Michael Fassbender");
            actors.Add("Javier Bardem");
            actors.Add("Brad Pitt");
            bool isPremiere = false;
            List<MovieDate> projectionDates = CreateRandomProjectionDays();
            string movieInfo = @"A lawyer finds himself in over his head when he gets involved in drug trafficking.";
            Movie movie = new Movie("The Counselor", Genre.Drama, new Time(1, 53), "Ridley Scott", actors, movieInfo, isPremiere, projectionDates);
            movie.ImageSource = @"Images\Movies\The Counselor.jpg";

            return movie;
        }

        private static Movie CreateCarrie()
        {
            List<string> actors = new List<string>();
            actors.Add("Chloe Grace Moretz");
            actors.Add("Julianne Moore");
            bool isPremiere = false;
            List<MovieDate> projectionDates = CreateRandomProjectionDays();
            string movieInfo = @"A reimagining of the classic horror tale about Carrie White, a shy girl outcast by her peers and sheltered by her deeply religious mother, who unleashes telekinetic terror on her small town after being pushed too far at her senior prom.";
            Movie movie = new Movie("Carrie", Genre.Horror, new Time(1, 33), "Kimberly Peirce", actors, movieInfo, isPremiere, projectionDates);
            movie.ImageSource = @"Images\Movies\Carrie.jpg";

            return movie;
        }

        private static Movie CreateAboutTime()
        {
            List<string> actors = new List<string>();
            actors.Add("Domhnall Gleeson");
            actors.Add("Rachel McAdams");
            actors.Add("Bill Nighy");
            bool isPremiere = true;
            List<MovieDate> projectionDates = CreateRandomProjectionDays();
            string movieInfo = @"At the age of 21, Tim discovers he can travel in time and change what happens and has happened in his own life. His decision to make his world a better place by getting a girlfriend turns out not to be as easy as you might think.";
            Movie movie = new Movie("About Time", Genre.Comedy, new Time(1, 45), "Richard Curtis", actors, movieInfo, isPremiere, projectionDates);
            movie.ImageSource = @"Images\Movies\About Time.jpg";

            return movie;
        }

        private static Movie CreateBattleOfTheYear()
        {
            List<string> actors = new List<string>();
            actors.Add("Josh Holloway");
            actors.Add("Laz Alonso");
            actors.Add("Josh Peck");
            bool isPremiere = false;
            List<MovieDate> projectionDates = CreateRandomProjectionDays();
            string movieInfo = @"Battle of the Year attracts all the best teams from around the world, but the Americans haven't won in fifteen years. Dante enlists Blake to assemble a team of the best dancers and bring the Trophy back to America where it started.";
            Movie movie = new Movie("Battle of the Year", Genre.Musical, new Time(2, 13), "Benson Lee", actors, movieInfo, isPremiere, projectionDates);
            movie.ImageSource = @"Images\Movies\Battle of the Year.jpg";

            return movie;
        }

        private static Movie CreateFreeBirds()
        {
            List<string> actors = new List<string>();
            actors.Add("Woody Harrelson");
            actors.Add("Owen Wilson");
            actors.Add("Dan Fogler");
            bool isPremiere = false;
            List<MovieDate> projectionDates = CreateRandomProjectionDays();
            string movieInfo = @"Two turkeys from opposite sides of the tracks must put aside their differences and team up to travel back in time to change the course of history - and get turkey off the holiday menu for good.";
            Movie movie = new Movie("Free Birds", Genre.Animation, new Time(1, 33), "Jimmy Hayward", actors, movieInfo, isPremiere, projectionDates);
            movie.ImageSource = @"Images\Movies\Free Birds .jpg";

            return movie;
        }

        private static Movie CreateKhumba()
        {
            List<string> actors = new List<string>();
            actors.Add("Jake T. Austin");
            actors.Add("Liam Neeson");
            actors.Add("Steve Buscemir");
            bool isPremiere = true;
            List<MovieDate> projectionDates = CreateRandomProjectionDays();
            string movieInfo = @"Rejected by his superstitious herd, a half-striped zebra embarks on a daring quest to earn his stripes but finds the courage and self-acceptance to save all the animals of the Great Karoo.";
            Movie movie = new Movie("Khumba", Genre.Animation, new Time(2, 15), "Anthony Silverston", actors, movieInfo, isPremiere, projectionDates);
            movie.ImageSource = @"Images\Movies\Khumba.jpg";

            return movie;
        }

        private static Movie CreateTheSmurfs()
        {
            List<string> actors = new List<string>();
            actors.Add("Neil Patrick Harris");
            actors.Add("Jayma Mays");
            actors.Add("Katy Perry");
            bool isPremiere = true;
            List<MovieDate> projectionDates = CreateRandomProjectionDays();
            string movieInfo = @"The Smurfs team up with their human friends to rescue Smurfette, who has been kidnapped by Gargamel since she knows a secret spell that can turn the evil sorcerer's newest creation - creatures called the Naughties - into real Smurfs.";
            Movie movie = new Movie("The Smurfs II", Genre.Animation, new Time(2, 15), "Raja Gosnell", actors, movieInfo, isPremiere, projectionDates);
            movie.ImageSource = @"Images\Movies\The Smurfs.jpg";

            return movie;
        }

        private static Movie CreateDespicableMe()
        {
            List<string> actors = new List<string>();
            actors.Add("Steve Carell");
            actors.Add("Kristen Wiig");
            actors.Add("Benjamin Bratt");
            bool isPremiere = false;
            List<MovieDate> projectionDates = CreateRandomProjectionDays();
            string movieInfo = @"Gru is recruited by the Anti-Villain League to help deal with a powerful new super criminal.";
            Movie movie = new Movie("Despicable Me II", Genre.Animation, new Time(2, 15), "Pierre Coffin, Chris Renaud", actors, movieInfo, isPremiere, projectionDates);
            movie.ImageSource = @"Images\Movies\Despicable me.jpg";

            return movie;
        }

        private static List<MovieDate> CreateRandomProjectionDays()
        {
            List<MovieDate> movieShowTime = new List<MovieDate>();

            Random randomTime = new Random(DateTime.Now.Millisecond);

            List<Time> times = CreateRandomTime();
            movieShowTime.Add(new MovieDate { DayOfWeek = (DayOfWeek)randomTime.Next(0, 2), ShowTime = times });
            times = CreateRandomTime();
            movieShowTime.Add(new MovieDate { DayOfWeek = (DayOfWeek)randomTime.Next(2, 4), ShowTime = times });
            times = CreateRandomTime();
            movieShowTime.Add(new MovieDate { DayOfWeek = (DayOfWeek)randomTime.Next(4, 6), ShowTime = times });
            movieShowTime.Add(new MovieDate { DayOfWeek = DayOfWeek.Saturday, ShowTime = times = CreateRandomTime() });
            return movieShowTime;
        }

        private static List<Time> CreateRandomTime()
        {
            Random randomTime = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int timeCount = randomTime.Next(1, 5);
            List<Time> times = new List<Time>();

            for (int i = 0; i < 5; i++)
            {
                times.Add(new Time((uint)randomTime.Next(9, 22), ((uint)randomTime.Next(0, 11) * 5)));
            }
           
            times.Sort((x, y) =>
            {
                var comp = x.Hours.CompareTo(y.Hours);
                if (comp == 0) comp = x.Minutes.CompareTo(y.Minutes);
                return comp;
            });

            return times;
        }
    }
}
