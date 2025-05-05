using lab2.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.Helpers
{
    public static class QueryHelper
    {
        public static IEnumerable<dynamic> Query1(ObservableCollection<Worker> workers)
        {
            var result = workers
            .Where(x => x.Id % 2 != 0)
            .Select(x => new
            {
                SUM_OF = x.CurrentTask.DifficultyLevel + x.CurrentTask.Reward,
                UPPERCASE = x.CurrentTask.Code.ToUpper()
            })
            .ToList();
            
            Console.WriteLine("Projection result:");
            foreach (var el in result)
            {
                Console.WriteLine($"SUM_OF: {el.SUM_OF}, UPPERCASE: {el.UPPERCASE}");
            }
            return result;
        }
        public static IEnumerable<dynamic> Query2(ObservableCollection<Worker> workers)
        {
           var collection = Query1(workers);

            var result = collection
                .GroupBy(x => x.UPPERCASE)
                .Select(g => new
                {
                    Nazwa = g.Key,
                    Srednia = g.Average(x => x.SUM_OF)
                });

            Console.WriteLine("Grupy według UPPERCASE i średnia SUM_OF:");
            foreach (var grupa in result)
            {
                Console.WriteLine($"Grupa: {grupa.Nazwa}, Średnia SUM_OF: {grupa.Srednia:F2}");
            }
            return result;
        }
    }
}
