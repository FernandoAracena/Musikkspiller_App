using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musikkspiller_App
{
    internal class Bibliotek
    {
        List<Musik> musikList = new List<Musik> 
        {
            new Musik("Shape of You", "Ed Sheeran", 2017, "Pop"),
            new Musik("Bohemian Rhapsody", "Queen", 1975, "Rock"),
            new Musik("Uptown Funk", "Mark Ronson ft. Bruno Mars", 2014, "Funk"),
            new Musik("Rolling in the Deep", "Adele", 2010, "Soul"),
            new Musik("Billie Jean", "Michael Jackson", 1982, "Pop"),
            new Musik("Smells Like Teen Spirit", "Nirvana", 1991, "Grunge"),
            new Musik("Hotel California", "Eagles", 1977, "Rock"),
            new Musik("Thriller", "Michael Jackson", 1982, "Pop"),
            new Musik("Stairway to Heaven", "Led Zeppelin", 1971, "Rock"),
            new Musik("Wonderwall", "Oasis", 1995, "Rock")
        };
        public static void Run()
        {
            Menu();
        }

        private static void Menu()
        {
            var minBibliotek = new Bibliotek();
            bool exit = false;
            var customBibliotek = new List<Musik>();
            string userNamedList = "";

            while (!exit)
            {
                Console.WriteLine("1 - AddArtist");
                Console.WriteLine("2 - RemoveArtist");
                Console.WriteLine("3 - ShowAll");
                Console.WriteLine("4 - CustomList");
                Console.WriteLine("5 - SavedLists");
                Console.WriteLine("6 - Exit");
                Console.WriteLine();
                minBibliotek.PlayingNow();
                Console.WriteLine();

                string choice = Console.ReadLine();
                 
                switch (choice)
                {
                    case "1":
                        Console.WriteLine();
                        Console.WriteLine("Input SongName :");
                        string songname = Console.ReadLine();
                        Console.WriteLine("Input Artist :");
                        string artist = Console.ReadLine();
                        Console.WriteLine("Input Year :");
                        int year = int.Parse(Console.ReadLine());
                        Console.WriteLine("Input Category :");
                        string category = Console.ReadLine();
                        minBibliotek.AddArtist(new Musik(songname, artist, year, category));
                        Console.WriteLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Select an artist of the list :");
                        minBibliotek.ShowAll();
                        int songToDelete = int.Parse(Console.ReadLine());
                        minBibliotek.RemoveArtist(songToDelete);
                        Console.WriteLine();
                        break;
                    case "3":
                        Console.WriteLine();
                        minBibliotek.ShowAll();
                        Console.WriteLine();
                        break;
                    case "4":
                        Console.WriteLine();
                        Console.WriteLine("Input the name for the new List :");
                        userNamedList = Console.ReadLine();

                        bool inputSong = true;
                        while (inputSong)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"1 - Add a new song to the {userNamedList} List :");
                            Console.WriteLine("2 - Exit");
                            int selected = int.Parse(Console.ReadLine());
                            if (selected == 1)
                            {
                                bool finishList = true;
                                while (finishList)
                                {
                                    Console.WriteLine("Select from list :");
                                    Console.WriteLine("1 - Favorites");
                                    Console.WriteLine("2 - No Favorites");
                                    Console.WriteLine("3 - All");
                                    Console.WriteLine("4 - Back to Menu");
                                    int choiced = int.Parse(Console.ReadLine());
                                    if (choiced == 1)
                                    {
                                        Console.WriteLine();
                                        var favorites = ShowFavorites(minBibliotek);
                                        Console.WriteLine("Input the Song Name you want to add :");
                                        string selectedSongName = Console.ReadLine();
                                        var selectedTitle = favorites.Where(s => s.SongName == selectedSongName).FirstOrDefault();
                                        AddToCustomList(customBibliotek, selectedTitle);
                                        Console.WriteLine();
                                        Console.WriteLine($"Songs in the {userNamedList} List :");
                                        ShowCustomList(customBibliotek);
                                        Console.WriteLine();
                                    }
                                    else if (choiced == 2)
                                    {
                                        Console.WriteLine();
                                        var noFavorites = ShowNoFavorites(minBibliotek);
                                        Console.WriteLine("Input the Song Name you want to add :");
                                        string selectedSongName = Console.ReadLine();
                                        var selectedTitle = noFavorites.Where(s => s.SongName == selectedSongName).FirstOrDefault();
                                        AddToCustomList(customBibliotek, selectedTitle);
                                        Console.WriteLine();
                                        Console.WriteLine($"Songs in the {userNamedList} List :");
                                        ShowCustomList(customBibliotek);
                                        Console.WriteLine();
                                    }
                                    else if (choiced == 3)
                                    {
                                        Console.WriteLine();
                                        minBibliotek.ShowAll();
                                        Console.WriteLine("Input the Song Name you want to add :");
                                        string selectedSongName = Console.ReadLine();
                                        var selectedTitle = minBibliotek.musikList.Where(s => s.SongName == selectedSongName).FirstOrDefault();
                                        AddToCustomList(customBibliotek, selectedTitle);
                                        Console.WriteLine();
                                        Console.WriteLine($"Songs in the {userNamedList} List :");
                                        ShowCustomList(customBibliotek);
                                        Console.WriteLine();
                                    }
                                    else if (choiced == 4)
                                    {
                                        finishList = false;
                                    }
                                }                              
                            }
                            else if (selected == 2)
                            {
                                inputSong = false;
                            }
                        }
                        Console.WriteLine();
                        break;
                    case "5":
                        Console.WriteLine();
                        Console.WriteLine($"Songs in the {userNamedList} List :");
                        ShowCustomList(customBibliotek);
                        Console.WriteLine();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Try Again.");
                        break;
                }
            }         
        }

        private static void AddToCustomList(List<Musik> customBibliotek, Musik? selectedTitle)
        {
            if (selectedTitle != null)
            {
                customBibliotek.Add(selectedTitle);
            }
            else
            {
                Console.WriteLine("Please input a valid Name Song from the List.");
            }
        }

        private static void ShowCustomList(List<Musik> customBibliotek)
        {
            if (customBibliotek.Count > 0)
            {
                for (int i = 0; i < customBibliotek.Count; i++)
                {
                    Console.WriteLine($"{i} - {customBibliotek[i].SongName} - {customBibliotek[i].Artist} - {customBibliotek[i].Year} - {customBibliotek[i].Category}");
                }
            }
            else
            {
                Console.WriteLine("There is no songs in this List.");
            }
           
        }

        private static List<Musik> ShowNoFavorites(Bibliotek minBibliotek)
        {
            var noFavorites = minBibliotek.musikList.Where(m => m.IsFavorite == false).ToList();

            noFavorites.ForEach(x => Console.WriteLine($"{x.SongName} - {x.Artist} - {x.Year} - {x.Category}"));
            return noFavorites;
        }

        private static List<Musik> ShowFavorites(Bibliotek minBibliotek)
        {
            var favorites = minBibliotek.musikList.Where(m => m.IsFavorite == true).ToList();
            favorites.ForEach(x => Console.WriteLine($"{x.SongName} - {x.Artist} - {x.Year} - {x.Category}"));
            return favorites;
        }

        private void ShowAll()
        {
            if (musikList.Count > 0)
            {
                for (int i = 0; i < musikList.Count; i++)
                {
                    Console.WriteLine($"{i} - {musikList[i].SongName} - {musikList[i].Artist} - {musikList[i].Year} - {musikList[i].Category}");
                }
            }
            else
            {
                Console.WriteLine("The list is empty.");
            }
            
        }

        private void PlayingNow()
        {
            var rand = new Random();
            int musikListIndex = rand.Next(0, musikList.Count);
            Musik randomMusik = musikList[musikListIndex];
            Console.WriteLine($"Playing Now : - {musikList[musikListIndex].SongName} - {musikList[musikListIndex].Artist} - {musikList[musikListIndex].Year} - {musikList[musikListIndex].Category}");
            AddToFavoriteList(randomMusik);
        }

        private void AddToFavoriteList(Musik musik)
        {
            Console.WriteLine("Do you want to add this song to your 'Favorites' List Y/N ?");
            char favorite = char.Parse(Console.ReadLine());
            if (favorite == 'y')
            {
                musik.IsFavorite = true;
                Console.WriteLine($"{musik.SongName} was added to favorites.");
                Console.WriteLine("Select an option from Menu to continue.");
            }
            else
            {
                Console.WriteLine("Select an option from Menu to continue.");
            }
        }

        private void AddArtist(Musik musik)
        {
            musikList.Add(musik);
            Console.WriteLine($"The song : {musik.SongName} - {musik.Artist} - {musik.Year} - {musik.Category}, was successfully added.");
        }

        private void RemoveArtist(int songToDelete)
        {
            Console.WriteLine($"The song : {musikList[songToDelete].SongName} - {musikList[songToDelete].Artist} - {musikList[songToDelete].Year} - {musikList[songToDelete].Category}, was successfully removed.");
            musikList.RemoveAt(songToDelete);
        }
    }
}
