using System;
using System.Windows;
using Laba4.Models;

namespace Laba4
{
    public partial class ClientEditWindow : Window
    {
        private Client _client;
        private bool _isNew;
          
      
        public ClientEditWindow(Client client)
        {

  InitializeComponent();
            _isNew = client == null;
            _client = _isNew ? new Client() : client;

            DataContext = this;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_client.FullName))
                {
                    MessageBox.Show("ФИО обязательно для заполнения!", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                using var context = new MarketingDBContext();

                if (_isNew)
                {
                    context.Clients.Add(_client);
                }
                else
                {
                    context.Clients.Attach(_client);
                    context.Entry(_client).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

                context.SaveChanges();
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
