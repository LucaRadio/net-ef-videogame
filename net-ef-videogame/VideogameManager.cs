using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net_ef_videogame
{
    internal static class VideogameManager
    {
        
        public static void newGame(string name, string overview,DateTime releaseDate,long softwareHouseId)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try { 
                Videogame videogame1 = new Videogame { Name =name, Overview =overview,ReleaseDate = releaseDate ,SoftwareHouseID = softwareHouseId };
                db.Add(videogame1);
                db.SaveChanges();
                }
                catch (Exception)
                {
                    Console.WriteLine("There was a problem creating this record! Retry.");
                }

            }

            
        }



        public static Videogame searchById(long id)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try { 
                    List<Videogame> videogames = db.Videogames.ToList();
                    Videogame foundVideogame = db.Videogames.Where(item => item.Id == id).First();
                    return foundVideogame;
                }
                catch (Exception)
                {
                    Console.WriteLine("No game found! Retry.");

                    return null;
                }
        }

        }




        public static Videogame SearchByName(string input)
        {
            using (VideogameContext db = new VideogameContext())
            {
                try
                {
                    List<Videogame> videogames = db.Videogames.ToList();
                    Videogame foundVideogame = db.Videogames.Where(m => m.Name.Contains(input)).First();
                    return foundVideogame;
                }
                catch (Exception)
                {
                    Console.WriteLine("No game found! Retry.");
                    return null;
                }
            }

        }



        public static void DeleteGame(long answer)
        {
            using (VideogameContext db = new VideogameContext())
            {
                Videogame foundVideogame = db.Videogames.Where(item => item.Id == answer).First();
                db.Videogames.Remove(foundVideogame);
                db.SaveChanges();

            }

        }




        public static void newSoftwareHouse(string name, string taxId, string city, string country)
        {
            using (VideogameContext db = new VideogameContext())
            {
                SoftwareHouse sh1 = new SoftwareHouse { Name = name,  TaxId= taxId, City = city, Country= country };
                db.Add(sh1);
                db.SaveChanges();

            }


        }

        public static List<SoftwareHouse> getAllSoftwareHouses()
        {
            using (VideogameContext db= new VideogameContext())
            {

                List<SoftwareHouse> softwareHouses = db.SoftwareHouses.ToList();
                return softwareHouses;
            }
        }
        
        public static List<Videogame> getAllVideogamesBySoftwareHouse(long shId)
        {
            using (VideogameContext db= new VideogameContext())
            {
                
                List<Videogame> filteredVideogames = db.Videogames.Where(item => item.SoftwareHouseID == shId).ToList();
                return filteredVideogames;


            }
        }
    }
}
