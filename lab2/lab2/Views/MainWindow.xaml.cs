using System.Windows;
using lab2.Models;
using lab2.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace lab2.Views
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<Worker> _workers = new ObservableCollection<Worker>();
        private Worker? _boss;

        public MainWindow()
        {
            InitializeComponent();
            WorkerListView.ItemsSource = null;
            WorkerTreeView.ItemsSource = null;
            ResultsGrid.ItemsSource = null;
        }

        private void GenerateData_Click(object sender, RoutedEventArgs e)
        {
            _workers.Clear();
            _boss = WorkerHelper.GenerateHierarchyTree();
            _workers = WorkerHelper.Workers;

            WorkerListView.ItemsSource = _workers;
            WorkerTreeView.ItemsSource = new ObservableCollection<Worker>() { _boss };

        }

        private void ShowVersion_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Version: 0b00000001 from 10.02.2025", "Version");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Create_Click(object sender, RoutedEventArgs e) 
        {
            if (WorkerTreeView.SelectedItem is Worker parent)
            {
                var form = new CreateWorkerWindow(parent);
                if(form.ShowDialog() == true)
                {
                    parent.Subordinates.Add(form.NewWorker);
                    MessageBox.Show($"Worker {form.NewWorker} added");
                }
            }
        }
        public void Query1_Click(object sender, RoutedEventArgs e)
        {
            var result = QueryHelper.Query1(_workers);
            ResultsGrid.ItemsSource = result;
        }
        public void Query2_Click(object sender, RoutedEventArgs e)
        {
            var result = QueryHelper.Query2(_workers);
            ResultsGrid.ItemsSource = result;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (WorkerTreeView.SelectedItem is Worker toDelete)
            {
                Worker parent = WorkerHelper.FindParent(toDelete);
                if (parent != null)
                {
                    parent.Subordinates.Remove(toDelete);
                    DeleteRecursively(toDelete);
                }
                else
                {
                    _workers.Remove(toDelete);
                    DeleteRecursively(toDelete);
                    WorkerTreeView.ItemsSource = null;
                    WorkerListView.ItemsSource = null;

                }
            }
        }
        private void DeleteRecursively(Worker worker)
        {
            foreach (var subordinate in worker.Subordinates)
            {
                DeleteRecursively(subordinate);
            }
            _workers.Remove(worker);
        }


    }
}
