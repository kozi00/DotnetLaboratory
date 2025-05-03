using lab2.Helpers;
using lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace lab2.Views
{

    public partial class CreateWorkerWindow : Window
    {
        private Worker _parent;
        public Worker? NewWorker { get; set; }
        public CreateWorkerWindow(Worker parent)
        {
            _parent = parent;
            InitializeComponent();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstNameBox.Text) ||
                 string.IsNullOrWhiteSpace(LastNameBox.Text) ||
                 !int.TryParse(YearBox.Text, out int year))
            {
                MessageBox.Show("Invalid input. Please check all fields.");
                return;
            }

            NewWorker = WorkerHelper.CreateWorkerAndTask(FirstNameBox.Text, LastNameBox.Text, year, _parent.Level + 1);
            DialogResult = true;
            Close();
        }
    }
    
}
