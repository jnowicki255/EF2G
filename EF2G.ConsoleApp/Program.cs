using System;
using System.Linq;
using ConsoleTables;
using EF2G.Repository;
using EF2G.Repository.Entities;
using EF2G.Repository.Repos;
using EF2G.Repository.Repos.Interfaces;

namespace EF2G.ConsoleApp
{
    internal class Program
    {
        private static EF2GDbContext dbContext;
        private static IRepository repository;

        static void Main(string[] args)
        {
            dbContext = new EF2GDbContext();
            repository = new Repository.Repos.Repository(dbContext);
            ShowMenu();
        }

        private static void ShowMenu()
        {
            Console.WriteLine("TABELE:");
            Console.WriteLine("  [1] Użytkownicy");

            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    ShowTableMenu<DbUser>();
                    break;
            }
        }

        private static void ShowTableMenu<T>()
        {
            Console.Clear();
            Console.WriteLine("OPERACJE:");
            Console.WriteLine("  [1] Dodaj nowy rekord");
            Console.WriteLine("  [2] Wyświetl rekord");
            Console.WriteLine("  [3] Wyświetl tabelę");
            Console.WriteLine("  [4] Modyfikuj rekord");
            Console.WriteLine("  [5] Usuń rekord");

            var key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    AddNewRecord<T>();
                    break;

                case ConsoleKey.D2:
                    ShowRecord<T>();
                    break;

                case ConsoleKey.D3:
                    ShowTable<T>();
                    break;

                case ConsoleKey.D4:
                    ModifyRecord<T>();
                    break;

                case ConsoleKey.D5:
                    DeleteRecord<T>();
                    break;
            }
        }

        private static void AddNewRecord<T>()
        {
            var type = typeof(T);
            var propertyInfo = type.GetProperties();

            Console.Clear();
            foreach(var property in propertyInfo)
            {
                if (property.Name.Contains("Id"))
                    continue;

                if (property.PropertyType == typeof(DateTime))
                    continue;

                Console.WriteLine(property.Name);
            }
        }

        private static void ShowRecord<T>()
        {
            Console.Clear();
            Console.WriteLine("Podaj id rekordu: ");
            var id = Int32.Parse(Console.ReadLine());

            var record = repository.GetUserAsync(id).Result;
            var propertyInfo = typeof(T).GetProperties();

            var table = new ConsoleTable(propertyInfo.Select(x => x.Name).ToArray());
            table.AddRow(propertyInfo.Select(x => x.GetValue(record)).ToArray());
            table.Write();
        }

        private static void ShowTable<T>()
        {
            Console.Clear();
            var data = repository.GetUsersAsync().Result;

            var propertyInfo = typeof(T).GetProperties();
            var table = new ConsoleTable(propertyInfo.Select(x => x.Name).ToArray());

            foreach(var row in data)
            {
                table.AddRow(propertyInfo.Select(x => x.GetValue(row)).ToArray());
            }

            table.Write();
        }

        private static void ModifyRecord<T>()
        {

        }

        private static void DeleteRecord<T>()
        {
        }
    }
}
