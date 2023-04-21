using Microsoft.EntityFrameworkCore;
using net_ef_videogame;
using System.Diagnostics;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("|| Welcome to game's tournament manager ||");
            Console.WriteLine("==========================================");
            Console.WriteLine("Insert a number to select an option:");
            Console.WriteLine("0- Insert a videogame");
            Console.WriteLine("1- Search a videogame by ID");
            Console.WriteLine("2- Search a vidogames by name");
            Console.WriteLine("3- Delete a videogame");
            Console.WriteLine("4- Insert a software house");
            Console.WriteLine("5- Search all videogames created by a software house");
            Console.WriteLine("6- Exit");
            int answer = Convert.ToInt32(Console.ReadLine());

            switch (answer)
            {
                case 0:
                    Console.Write("Videogame's name: ");
                    string? name = Console.ReadLine();
                    while (String.IsNullOrWhiteSpace(name))
                    {
                        new ExceptionTitle();
                        name = Console.ReadLine();
                    }
                    Console.Write("Videogame's overview: ");
                    string? overview = Console.ReadLine();
                    while (String.IsNullOrWhiteSpace(overview))
                    {
                        new ExceptionTitle();
                        overview = Console.ReadLine();
                    }

                    Console.Write("Videogame's release date(dd/mm/yyyy): ");
                    DateTime release_date;
                    while (!DateTime.TryParse(Console.ReadLine(), out release_date))
                    {
                        new ExceptionDate();

                    }


                    List<SoftwareHouse> softwareHouses = VideogameManager.getAllSoftwareHouses();
                    for (int i= 0; i < softwareHouses.Count; i++)
                    {
                        if (i == softwareHouses.Count-1)
                        {
                            Console.WriteLine($"{softwareHouses[i].Id}. {softwareHouses[i].Name}\t");
                        }
                        else
                        {
                        Console.Write($"{softwareHouses[i].Id}. {softwareHouses[i].Name}\t");

                        }
                        
                    }
                    Console.WriteLine("Videogame's software house(id): ");
                    long softwareHouseId;
                    while (!long.TryParse(Console.ReadLine(), out softwareHouseId))
                    {
                        new ExceptionNumber();
                    };
                    
                    VideogameManager.newGame(name, overview, release_date, softwareHouseId);
                    break;
                case 1:
                    Console.Write("Insert an ID to search: ");

                    long idToSearch;
                    while (!long.TryParse(Console.ReadLine(), out idToSearch))
                    {
                        new ExceptionNumber();
                    };
                    Videogame resultById = VideogameManager.searchById(idToSearch);
                    if (resultById != null)
                    {
                        Console.WriteLine($"Name: {resultById.Name}\t Overview: {resultById.Overview}\t Release Date: {resultById.ReleaseDate}\t Software house id: {resultById.SoftwareHouseID}");

                    }
                    else
                    {
                        Console.WriteLine($"No videogame with id = {idToSearch}");
                    }
                    break;
                case 2:
                    Console.Write("Insert a name: ");
                    string? input = Console.ReadLine();
                    while (String.IsNullOrWhiteSpace(input))
                    {
                        new ExceptionTitle();
                        input = Console.ReadLine();
                    }
                    Videogame resultByName = VideogameManager.SearchByName(input);
                    if (resultByName != null)
                    {
                        Console.WriteLine($"Name: {resultByName.Name}\t Overview: {resultByName.Overview}\t Release Date: {resultByName.ReleaseDate}\t Software house id: {resultByName.SoftwareHouseID}");

                    }
                    else
                    {
                        Console.WriteLine($"No videogame with {input} as name");
                    }
                    break;
                case 3:
                    Console.WriteLine("Which game do you want to delete?(ID)");

                    long a;
                    while (!long.TryParse(Console.ReadLine(), out a))
                    {
                        new ExceptionNumber();
                    };
                    VideogameManager.DeleteGame(a);


                    break;
                case 4:
                    Console.Write("Software house's name: ");
                    string? shName = Console.ReadLine();
                    while (String.IsNullOrWhiteSpace(shName))
                    {
                        new ExceptionTitle();
                        name = Console.ReadLine();
                    }

                    Console.Write("Software house's tax id: ");
                    string? shTaxId = Console.ReadLine();
                    while (String.IsNullOrWhiteSpace(shTaxId))
                    {
                        new ExceptionTitle();
                        shTaxId = Console.ReadLine();
                    }
                    
                    Console.Write("Software house's city: ");
                    string? shCity = Console.ReadLine();
                    while (String.IsNullOrWhiteSpace(shCity))
                    {
                        new ExceptionTitle();
                        shCity = Console.ReadLine();
                    }

                    Console.Write("Software house's country: ");
                    string? shCountry = Console.ReadLine();
                    while (String.IsNullOrWhiteSpace(shCountry))
                    {
                        new ExceptionTitle();
                        shCountry = Console.ReadLine();
                    }
                    VideogameManager.newSoftwareHouse(shName, shTaxId, shCity, shCountry);
                    break;
                case 5:
                    Console.WriteLine("Videogame's software house(id): ");
                    long shId;
                    while (!long.TryParse(Console.ReadLine(), out shId))
                    {
                        new ExceptionNumber();
                    };

                    List<Videogame> filteredBySoftwareHouse =VideogameManager.getAllVideogamesBySoftwareHouse(shId);

                    if(filteredBySoftwareHouse.Count <= 0)
                    {
                        Console.WriteLine("No games found with that software house's id! Retry.");
                    }
                    else
                    {
                        foreach (var item in filteredBySoftwareHouse)
                        {
                            Console.WriteLine($"\tId: {item.Id}\t Name:{item.Name}");
                        }
                    }

                    break;
                case 6: break;
            }
        }
    }
}
