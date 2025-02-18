using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test100.Models;

namespace Test100.Pages.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminMainPage.xaml
    /// </summary>
    public partial class AdminMainPage : Page
    {
        public AdminMainPage()
        {
            InitializeComponent();

            var data = DbConnector.conn.Users.Include(t => t.Role).ToList();
            DgUsers.ItemsSource = data;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
