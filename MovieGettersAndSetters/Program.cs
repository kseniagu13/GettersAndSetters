using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace MovieGettersAndSetters
{
    class Program
    {
        class Movie
        {
            string title;
            string director;
            string ratings;
            int userRating;

            //G, PG, PG-13, R, undefined
            //userRating not higher than 10 and no lower than 0


            public Movie(string _title, string _director, string _ratings, int _userRating)
            {
                title = _title; // kui Setterit ei ole, siis väikse tähega
                director = _director;
                Ratings = _ratings;
                UserRating = _userRating;
            }

            public string Title
            {
                get { return title; }
             
            }

            public string Director
            {
                get { return director; }
                
            }

            public string Ratings
            {
                get { return ratings; }
                set
                {
                    if (value == "G" || value == "PG" || value == "PG-13" || value == "R")
                    {
                        ratings = value;
                    }
                    else
                    {
                        ratings = "undefined";
                    }
                }
            }

            public int UserRating
            {
                get { return userRating; }
                set
                {
                    if(value >=0 && value<=10)
                    {
                        userRating = value;
                    }
                    else
                    {
                        UserRating = 0;
                    }
                }
            }


        }

        static void Main(string[] args)
        {
            Movie eatPrayLove = new Movie("Eat, Pray, Love", "Ryan Murphy", "PG-13", 6); //loome objekti
            Console.WriteLine($"Title: {eatPrayLove.Title}");
            Console.WriteLine($"Ratings: {eatPrayLove.Ratings}");
            Console.WriteLine($"Director: {eatPrayLove.Director}");
            Console.WriteLine($"UserRating: {eatPrayLove.UserRating}");

            string filePath = @"/Users/kseniagustsenko/Desktop/NewYearResolution/Movies.txt";
            List<string> listFromFile = File.ReadAllLines(filePath).ToList(); //konverteerime to List
            //teeme uue listi(MOvie klassi) kuhu salvestame objektid
            List<Movie> listOfMovies = new List<Movie>();


            foreach (string line in listFromFile) //loeme andmed listist(andmed hetkel vahemälus, ei ole kuskile salvestatud)
            {
                string[] tempArray = line.Split('/'); //lisab andmed tekstist ridu mida ma savestasime txt
                string tempTitle = tempArray[0]; //ajutine title massiivist kohast 0
                string tempDir = tempArray[1];
                string tempRating = tempArray[2];
                int tempUserRating = int.Parse(tempArray[3]); //kuna meil int on vaja stringiks teha

                Movie tempMovieObject = new Movie(tempTitle, tempDir, tempRating, tempUserRating); //ajutine uus objekt, foreach jaoks nii kaua kui tsükkel käib pärast kustutakse
                listOfMovies.Add(tempMovieObject);


               /* for (int i = 0; i < tempArray.Length; i++)
                {
                    Console.WriteLine($"Item {i} in the temporary array {tempArray[i]}");
                }*/
            }

            int i = 1;
            foreach (Movie movieObject in listOfMovies)
            {
                Console.WriteLine($"Item {i}: {movieObject.Title} directed by {movieObject.Director}.");
                i++;
            }

            Console.WriteLine("Enter the key word: "); //küsime key mille järgi otsime filmi listist
            string userSearch = Console.ReadLine().ToLower();

            List<Movie> searchResultList = new List<Movie>(); //selle jaoks et salvestada siia filmid mida kasutaja otsib

            //int searchResult = 0;
            foreach (Movie movieObject in listOfMovies) //iga Movie objektis listist otsime
            {
                if (movieObject.Title.ToLower().Contains(userSearch)) //otsime filmi pealkirjast seda key
                {
                    searchResultList.Add(movieObject);
                    //Console.WriteLine($"{movieObject.Title} directed by {movieObject.Director}");
                    //searchResult++;
                }

            }
            Console.WriteLine($"{searchResultList.Count} movies found");
            foreach (Movie movieObject in searchResultList)
            {
                Console.WriteLine($"{movieObject.Title} directed by {movieObject.Director}.");
            }

       
            
           
            Console.ReadLine();
        }
    }
}
