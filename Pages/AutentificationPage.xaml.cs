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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test100.Controllers;
using Test100.Models;

namespace Test100.Pages
{
    /// <summary>
    /// Логика взаимодействия для AutentificationPage.xaml
    /// </summary>
    public partial class AutentificationPage : Page
    {
        private AuthentificationController _authentificationController;
        private string _login;
        private string _password;

        public AutentificationPage()
        {
            InitializeComponent();
            _authentificationController = new AuthentificationController();
                

            //var user = _authentificationController.FindUserByPhonePassword();
        }

        private void BtnAutentification_Click(object sender, RoutedEventArgs e)
        {
            _login = TxbPhone.Text;
            _password = PsbPass.Password;

            var user = DbConnector.conn.Users.FirstOrDefault(x => x.Phone == _login && x.Password == _password);

            if (user != null) 
            {
                switch (user.RoleId)
                {
                    // Роль
                    case 1:
                        // Код для перехода на следующую страницу
                        break;
                    case 2:
                        // Код для перехода на следующую страницу
                        break;
                    default:

                        break;
                }
                MessageBox.Show($"Здравствуйте {user.Firstname}\nВы вошли как {user.RoleId}");
            }
            else
            {
                MessageBox.Show(
                "Пользователь с такой связкой логин и пароль не найден",
                "Уведомление",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
            }

           

            

        }
    }
}
