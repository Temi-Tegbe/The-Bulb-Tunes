using System;
using System.Collections.Generic;
using TheBulbTunes.EFDataService.Entities;
using TheBulbTunes.EFDataService.Services;

namespace TheBulbTunes
{
    class Program
    {
        static void Main(string[] args)
        {

            SongService songService = new SongService();
           
            //Add songs to the database

            songService.Create("Gone, Gone, Gone", "Philip Philips", "The World from the Side of the Moon", "", "Pop-rock", new DateTime(2013, 2, 11));
            songService.Create("FEEL.", "Kendrick Lamar", "DAMN.", "", "Rap", new DateTime(2017, 4, 17));
            songService.Create("Orphans", "Coldplay", "Everyday Life", "", "softrock", new DateTime(2019, 10, 24));
            songService.Create("Mary's in India", "Dido", "Life for Rent", "", "folk-pop", new DateTime(2003, 9, 29));
            songService.Create("Million Years Ago", "Adele", "25", "", "pop", new DateTime(2015, 11, 25));


            //Fetch All Songs

            List<Song> availableSongs = songService.FetchAll();

            foreach (Song song in availableSongs)
            {
                
                Console.WriteLine($"{song.Title}\n {song.Artist}\n {song.Album}\n  {song.Genre}\n {song.ReleaseDate} \n\n\n");
            }





          


            




                //Fetch songs that meet some search criteria

                List <Song> filteredSong1 = songService.FetchWithFilter("Gone", "pop-rock", "World", "Philip");
            List<Song> filteredSong2 = songService.FetchWithFilter("FEEL.", "rap", "DAMN.", "Kendrick Lamar");

            Console.WriteLine("\n\n FILTERED SONGS\n");
            foreach (Song song in filteredSong1)
            {
                Console.WriteLine($"{song.Title}\t {song.Artist}\t {song.Album}");
            }


            foreach (Song song in filteredSong2)
            {
                Console.WriteLine($"{song.Title}\t {song.Artist}\t {song.Album}");
            }

            //UPDATE

            //Set the ID of song to be updated

            Guid idOfSongToUpdate1 = new Guid("08d962f1b71"); //Nom-existing id
            Guid idOfSongToUpdate2 = new Guid("08d962f1b753"); //Existing id

            //Create a Song object containing new info for the update

            Song songWithNewInfo = new Song()
            {
                Genre = "Hard Rap",

            };

            ////Call the update Method to make the desired changes

            songService.Update(idOfSongToUpdate1, songWithNewInfo);
            songService.Update(idOfSongToUpdate2, songWithNewInfo);

            //Fetch all songs after update

            availableSongs = songService.FetchAll();

            Console.WriteLine("Currently available songs:");

            foreach (Song song in availableSongs)
            {
                Console.WriteLine($"{song.Title}\t {song.Artist}\t {song.Album}\t");
            }


            //Set the id to be deleted

            Guid idOfSongToBeDeleted1 = new Guid("08d962f1b75w"); //non-existing id

            Guid idOfSongToBeDeleted2 = new Guid("08d962f1b753"); //existing id
           

        }
    }
}
