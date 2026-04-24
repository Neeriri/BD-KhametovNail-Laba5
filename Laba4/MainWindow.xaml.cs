using System;
using System.Windows;
using Laba4.Views;

namespace Laba4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonClients_Click(object sender, RoutedEventArgs e)
        {
            var clientsWindow = new ClientsWindow();
            clientsWindow.Show();
            this.Close();
        }

        private void ButtonEmployees_Click(object sender, RoutedEventArgs e)
        {
            var employeesWindow = new EmployeesWindow();
            employeesWindow.Show();
            this.Close();
        }

        private void ButtonCampaigns_Click(object sender, RoutedEventArgs e)
        {
            var campaignsWindow = new CampaignsWindow();
            campaignsWindow.Show();
            this.Close();
        }
    }
}
