using lab2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace lab2.Helpers
{
    public static class WorkerHelper
    {
        private static Random random = new Random();
        private static string[] names = { "John", "Jane", "Bob", "Alice", "Charlie", "Diana", "Eve", "Frank", "Grace", "Hank" };
        private static string[] surnames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };
        public static ObservableCollection<Worker> Workers { get; } = new ObservableCollection<Worker>();

        public static Worker GenerateHierarchyTree()
        {
            const int maxLevels = 3;
            const int maxSubordinates = 5; // musi byc wieksze od 3

            return GenerateWorkers(0, maxLevels, maxSubordinates);
        }
        
        public static Worker FindParent(Worker child)
        {
            foreach (var worker in Workers)
            {
                if (worker.Subordinates.Contains(child))
                    return worker;
            }
            return null;
        }
        public static Worker CreateWorkerAndTask(string firstName, string lastName, int yearOfEmployment, int level)//bez dodawania do zbioru rodzica
        {
            Array enumValues = Enum.GetValues(typeof(Status));
            Status randomStatus = (Status)enumValues.GetValue(random.Next(enumValues.Length));

            var task = new WorkerTask(random.Next(1, 11), (random.NextDouble() + 1.0) * 10.0, randomStatus);
            var worker = new Worker(
                firstName,
                lastName,
                yearOfEmployment,
                level,
                task
            );
            Workers.Add(worker);
            return worker;
        }
        private static Worker GenerateWorkers(int level, int numberOfLevels, int numberOfSubordinatesPerLevel)
        {
            var supervisor = CreateWorkerAndTask(
                names[random.Next(names.Length)],
                surnames[random.Next(surnames.Length)],
                random.Next(2000, 2023),
                level
            );

            if (level < numberOfLevels)
            {
                int childrenCount = random.Next(3, numberOfSubordinatesPerLevel + 1);
                for (int i = 0; i < childrenCount; i++)
                {
                    var child = GenerateWorkers(level + 1, numberOfLevels, numberOfSubordinatesPerLevel);
                    supervisor.Subordinates.Add(child);
                }
            }

            return supervisor;
        }
        
    }
}
