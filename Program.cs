// See https://aka.ms/new-console-template for more information

using System.Net;
using System.Runtime.CompilerServices;
using static SayaMusicUser;

var track = new SayaMusicTrack("Lagu 1");
var track2 = new SayaMusicTrack("Lagu 2");
var user = new SayaMusicUser("user");
var user2 = new SayaMusicUser("User 2");

track.IncreasePlayCount(2368);
track.PrintTrackDetails();
track2.IncreasePlayCount(1234);
track2.PrintTrackDetails();

user.AddTrack(track);
user.PrintAllTracks();
user2.AddTrack(track2);
user2.PrintAllTracks();
public class SayaMusicUser
    {
        private int id;
        private string Username;
        private List<SayaMusicTrack> uploadedTracks = new();
        private static Random rd = new Random();


        public SayaMusicUser(string Username)
        {
            if(Username.Length > 100)
            {
                throw new ArgumentNullException("Username tdk boleh lebih dari 100");
            }
            if(Username is null)
            {
                throw new ArgumentNullException("username tidak boleh kosong");
            }
            this.id = rd.Next(10000,100000);
            this.Username = Username;
        }

        public int GetTotalPlayCount()
        {
            int playcount = 0;
            for (int i = 0; i < uploadedTracks.Count; i++)
            {
                playcount += uploadedTracks[i].playCount;
            }
            return playcount;
        }

        public void AddTrack(SayaMusicTrack track)
        {
            if (track is null)
            {
                throw new ArgumentNullException("Track yang di tambah tidak boleh null");
            }
            uploadedTracks.Add(track);
        }

        public void PrintAllTracks()
        {
            for (int i = 0; i < uploadedTracks.Count; i++)
            {
                Console.WriteLine($"Username : {Username} | Track {i + 1} Judul: {uploadedTracks[i].title}");
            }
        }

        public class SayaMusicTrack
        {
            private int id;
            public string title;
            public int playCount { get; private set;  }
            private static Random rd = new Random();

            public SayaMusicTrack(string tittle)
            {
                if (tittle is  null)
                {
                    throw new ArgumentNullException("tittle tidak boleh null");
                }
                if (tittle.Length > 200)
                {
                    throw new ArgumentException("tittle mask 200 karakter");
                }
                this.title = title;
                id = rd.Next(10000, 1000000);
                playCount = 0;
            }

            public void IncreasePlayCount(int count)
            {
                if (count > 25_000_000)
                {
                    throw new ArgumentOutOfRangeException(nameof(count), "maks 25 juta playcount");
                }
                if (count < 0)
                {
                    throw new Exception("Tidak boleh negatif");
                }
                checked
                {
                    playCount += count;
                }
            }

            public void  PrintTrackDetails()
            {
                Console.WriteLine($"ID : {id} | Title : {title} | Play count {playCount}");
            }

        }
    }
