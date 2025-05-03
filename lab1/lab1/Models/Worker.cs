using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace lab1.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearOfEmployment { get; set; }
        public int Level { get; set; }
        public ObservableCollection<Worker> Subordinates { get; set; }

        private static int _idCounter = 0;

        public Worker(string firstName,string lastName, int yearOfEmployment, int level)
        {
            Id = _idCounter++;
            FirstName = firstName;
            LastName = lastName;
            YearOfEmployment = yearOfEmployment;
            Level = level;
            Subordinates = new ObservableCollection<Worker>();
        }


        public override string ToString()
        {
            return $"{FirstName} {LastName} (ID: {Id}, Level: {Level})";
        }
    }
}
