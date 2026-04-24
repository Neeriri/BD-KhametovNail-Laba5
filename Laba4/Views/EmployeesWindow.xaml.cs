using System;
using System.Linq;
using System.Windows;
using Laba4.Models;

namespace Laba4.Views
{
    public partial class EmployeesWindow : Window
    {
        private MarketingDBContext _context;

        public EmployeesWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _context = new MarketingDBContext();
                DataGridEmployees.ItemsSource = _context.Employees.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new EmployeeEditWindow(null);
            editWindow.ShowDialog();
            LoadData();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employee = button?.DataContext as Employee;
            if (employee != null)
            {
                var editWindow = new EmployeeEditWindow(employee);
                editWindow.ShowDialog();
                LoadData();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var employee = button?.DataContext as Employee;
            
            if (employee != null)
            {
                var result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить сотрудника {employee.FullName}?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _context = new MarketingDBContext();
                        var existingEmployee = _context.Employees.Find(employee.EmployeeID);
                        if (existingEmployee != null)
                        {
                            _context.Employees.Remove(existingEmployee);
                            _context.SaveChanges();
                            MessageBox.Show("Сотрудник успешно удален!", "Успех",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
