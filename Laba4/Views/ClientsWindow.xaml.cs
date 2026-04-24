using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Laba4.Models;

namespace Laba4.Views
{
    public partial class ClientsWindow : Window
    {
        private MarketingDBContext _context;

        public ClientsWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _context = new MarketingDBContext();
                DataGridClients.ItemsSource = _context.Clients.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var editWindow = new ClientEditWindow(null);
            editWindow.ShowDialog();
            LoadData();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var client = button?.DataContext as Client;
            if (client != null)
            {
                var editWindow = new ClientEditWindow(client);
                editWindow.ShowDialog();
                LoadData();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var client = button?.DataContext as Client;
            
            if (client != null)
            {
                var result = MessageBox.Show(
                    $"Вы уверены, что хотите удалить клиента {client.FullName}?",
                    "Подтверждение удаления",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);
                
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        _context = new MarketingDBContext();
                        var existingClient = _context.Clients.Find(client.ClientID);
                        if (existingClient != null)
                        {
                            _context.Clients.Remove(existingClient);
                            _context.SaveChanges();
                            MessageBox.Show("Клиент успешно удален!", "Успех",
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
