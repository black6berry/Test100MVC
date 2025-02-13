using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using Test100.Models;

namespace Test100.Controllers
{
    internal class AuthentificationController
    {
        public User FindUserByPhonePassword(string phone, string password)
        {
            if (phone == "")
            {
                throw new Exception("Ошибка, номер не может быть пустым");
            }

            if (password == "")
            {
                throw new Exception("Ошибка, пароль не может быть пустым");
            }

            User user;
            try
            {
                user = DbConnector.conn.Users.FirstOrDefault(x => x.Phone == phone && x.Password == password);
            }
            catch 
            {
                throw new Exception("Ошибка соединения с БД");
            }

            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            return user;
        }
    }
}
