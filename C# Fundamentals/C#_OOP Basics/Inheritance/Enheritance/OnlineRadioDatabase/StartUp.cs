using System;
using System.Globalization;

namespace OnlineRadioDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int songs = int.Parse(Console.ReadLine());

            InvalidSongException ex = new InvalidSongException();
            InvalidArtistNameException exA = new InvalidArtistNameException();
            InvalidSongNameException exN = new InvalidSongNameException();
            InvalidSongLengthException exL = new InvalidSongLengthException();
            InvalidSongMinutesException exSM = new InvalidSongMinutesException();
            InvalidSongSecondsException exSE = new InvalidSongSecondsException();

            for (int i = 0; i < songs; i++)
            {
                string[] tokens = Console.ReadLine().Split(';');

                if(tokens.Length != 3)
                {
                    Console.WriteLine(ex.Message);
                }

                string artist = tokens[0];
                string songName = tokens[1];
                TimeSpan ts = TimeSpan.ParseExact(tokens[2], @"hh\:mm", CultureInfo.CurrentCulture);
            }
        }
    }
}
