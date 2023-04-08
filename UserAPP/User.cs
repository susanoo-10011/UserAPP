using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAPP
{
    internal class User //этот класс описывает таблицу в БД
    {
        public int id { get; set; }
        private string login, email, pass;

        public string Login //в верхнем регистре это get set
        {
            get { return login; } // возвращает переменную 
            set { login = value; } // в логин устанавливаем значение которое вводит пользователь
        }
        public string Email 
        {
            get { return email; } 
            set { email = value; } 
        }
        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }
        public User() { }

        public User(string login, string email, string pass)
        {
            this.login = login;
            this.email = email;
            this.pass = pass;
        }
    }
}
