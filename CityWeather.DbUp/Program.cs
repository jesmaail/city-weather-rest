using DbUp;
using System;
using System.Reflection;

namespace CityWeather.DbUp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Should be in a config of some kind.
            var dbString = "Server=localhost,1433; Database=Cities; User Id=sa; Password=Letmein123!";
            EnsureDatabase.For.SqlDatabase(dbString);

            var upgrader = DeployChanges.To
                .SqlDatabase(dbString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            var x = Console.ReadLine();
        }
    }
}
