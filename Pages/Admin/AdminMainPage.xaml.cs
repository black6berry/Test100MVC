using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        private string _firstname;
        private string _lastname;
        private string _patronymic;
        private string _phone;
        private string _password;
        private string _repeatPassword;
        private int _roleId = 1;


        public AdminMainPage()
        {
            InitializeComponent();
            LoadDataUsers();

            CmbRole.ItemsSource = DbConnector.conn.Roles.ToList();
        }

        private void LoadDataUsers()
        {
            DgUsers.ItemsSource = DbConnector.conn.Users.Include(t => t.Role).ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _firstname = TxbFirstname.Text;
                _lastname = TxbLastname.Text;
                _patronymic = TxbPatronymic.Text;
                _phone = TxbPhone.Text;
                _password = PsbPassword.Password;
                _repeatPassword = PsbPasswordRepeat.Password;
                _roleId = Convert.ToInt32(CmbRole.SelectedValue);

                // ПРоверка данных на null и пустую строку
                bool result = CheckData(_firstname, _lastname, _patronymic, _phone, _password, _roleId);
                // Если результат false ничего не происходит
                if (result == false)
                {
                    return;
                }
                // Создаем объект user
                Models.User user = new Models.User()
                {
                    Firstname = _firstname,
                    Lastname = _lastname,
                    Patronymic = _patronymic,
                    Phone = _phone,
                    Password = _password,
                    RoleId = _roleId
                };

                // Добавляем в таблицу Users объект пользователя 
                DbConnector.conn.Users.Add(user);
                // Сохраняем объект в базе данных
                DbConnector.conn.SaveChanges();

                MessageBox.Show("Запись создана успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);


                // Обновляем таблицу с пользователями
                LoadDataUsers();
            }
            catch
            {
                MessageBox.Show("Ошибка при добавлении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            


        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Я кнопка удаления");
        }

        private bool CheckData(string _firstname, string _lastname, string _patronymic, string _phone, string _password, int _roleId)
        {
            if (_firstname.IsNullOrEmpty())
            {
                MessageBox.Show("Отстутствует значение в таблице имя пользователя");
                return false;
            }

            if (_lastname.IsNullOrEmpty())
            {
                MessageBox.Show("Отстутствует значение в таблице фамилия пользователя");
                return false;
            }

            if (_patronymic.IsNullOrEmpty())
            {
                MessageBox.Show("Отстутствует значение в таблице отчество пользователя");
                return false;
            }

            if (_phone.IsNullOrEmpty())
            {
                MessageBox.Show("Отстутствует значение в таблице телефон пользователя");
                return false;
            }

            if (_password.IsNullOrEmpty())
            {
                MessageBox.Show("Отстутствует значение в таблице пароль пользователя");
                return false;
            }
            return true;
        }
    }
}
