using System;
using System.Windows;
using Laba4.Models;

namespace Laba4.Views
{
    public partial class EmployeeEditWindow : Window
    {
        private Employee _employee;
        private bool _isNew;
        private MarketingDBContext _context;

        public string Title => _isNew ? "Добавление сотрудника" : "Редактирование сотрудника";

        public Employee CurrentEmployee => _employee;

        public EmployeeEditWindow(Employee employee)
        {
            InitializeComponent();
            
            if (employee == null)
            {
                _isNew = true;
                _employee = new Employee();
            }
            else
            {
                _isNew = false;
                _employee = employee;
            }
            
            DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            TextBoxFullName.Text = _employee.FullName ?? "";
            TextBoxPosition.Text = _employee.Position ?? "";
            TextBoxEmail.Text = _employee.Email ?? "";
            TextBoxHourlyRate.Text = _employee.HourlyRate?.ToString() ?? "";
        }

        private void SaveData()
        {
            _employee.FullName = TextBoxFullName.Text.Trim();
            _employee.Position = TextBoxPosition.Text.Trim();
            _employee.Email = TextBoxEmail.Text.Trim();
            decimal rate;
            _employee.HourlyRate = decimal.TryParse(TextBoxHourlyRate.Text, out rate) ? rate : (decimal?)null;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveData();

                if (string.IsNullOrEmpty(_employee.FullName))
                {
                    MessageBox.Show("ФИО обязательно для заполнения!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                _context = new MarketingDBContext();

                if (_isNew)
                {
                    _context.Employees.Add(_employee);
                    MessageBox.Show("Сотрудник успешно добавлен!", "Успех",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    var existingEmployee = _context.Employees.Find(_employee.EmployeeID);
                    if (existingEmployee != null)
                    {
                        existingEmployee.FullName = _employee.FullName;
                        existingEmployee.Position = _employee.Position;
                        existingEmployee.Email = _employee.Email;
                        existingEmployee.HourlyRate = _employee.HourlyRate;
                        MessageBox.Show("Данные сотрудника успешно обновлены!", "Успех",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                _context.SaveChanges();
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
