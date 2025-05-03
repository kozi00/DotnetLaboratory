using lab1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace lab1.Helpers
{
    public static class WorkerHelper
    {
        private static Random random = new Random();
        private static string[] names = { "John", "Jane", "Bob", "Alice", "Charlie", "Diana", "Eve", "Frank", "Grace", "Hank" };
        private static string[] surnames = { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor" };
        public static ObservableCollection<Worker> Workers { get; } = new ObservableCollection<Worker>();

        public static Worker GenerateHierarchyTree(int maxLevels = 3, int maxSubordinates = 3)
        {
            return GenerateWorkers(0, 3, 3);
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
        private static Worker GenerateWorkers(int level, int maxNumberOfLevels, int maxNumberOfSubordinatesPerLevel)
        {
            var worker = new Worker(
                names[random.Next(names.Length)],
                surnames[random.Next(surnames.Length)],
                random.Next(2000, 2024),
                level
            );
            Workers.Add(worker);

            if (level < maxNumberOfLevels)
            {
                int childrenCount = random.Next(1, maxNumberOfSubordinatesPerLevel + 1);
                for (int i = 0; i < childrenCount; i++)
                {
                    var child = GenerateWorkers(level + 1, maxNumberOfLevels, maxNumberOfSubordinatesPerLevel);
                    worker.Subordinates.Add(child);
                }
            }

            return worker;
        }
        
    }
}
