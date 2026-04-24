using System;
using System.Windows;
using Laba4.Models;

namespace Laba4.Views
{
    public partial class ClientEditWindow : Window
    {
        private Client _client;
        private bool _isNew;
        private MarketingDBContext _context;

        public string Title => _isNew ? "Добавление клиента" : "Редактирование клиента";

        public Client CurrentClient => _client;

        public ClientEditWindow(Client client)
        {
            InitializeComponent();
            
            if (client == null)
            {
                _isNew = true;
                _client = new Client();
            }
            else
            {
                _isNew = false;
                _client = client;
            }
            
            DataContext = this;
            LoadData();
        }

        private void LoadData()
        {
            TextBoxFullName.Text = _client.FullName ?? "";
            TextBoxEmail.Text = _client.Email ?? "";
            TextBoxPhone.Text = _client.Phone ?? "";
            TextBoxAddress.Text = _client.Address ?? "";
        }

        private void SaveData()
        {
            _client.FullName = TextBoxFullName.Text.Trim();
            _client.Email = TextBoxEmail.Text.Trim();
            _client.Phone = TextBoxPhone.Text.Trim();
            _client.Address = TextBoxAddress.Text.Trim();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveData();

                if (string.IsNullOrEmpty(_client.FullName))
                {
                    MessageBox.Show("ФИО обязательно для заполнения!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                _context = new MarketingDBContext();

                if (_isNew)
                {
                    _context.Clients.Add(_client);
                    MessageBox.Show("Клиент успешно добавлен!", "Успех",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    var existingClient = _context.Clients.Find(_client.ClientID);
                    if (existingClient != null)
                    {
                        existingClient.FullName = _client.FullName;
                        existingClient.Email = _client.Email;
                        existingClient.Phone = _client.Phone;
                        existingClient.Address = _client.Address;
                        MessageBox.Show("Данные клиента успешно обновлены!", "Успех",
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
