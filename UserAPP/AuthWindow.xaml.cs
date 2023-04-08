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
using System.Windows.Shapes;

namespace UserAPP
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim(); //Trim() убирает лишние пробелы
            string pass = passBox.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено некорректно!"; //добавляет подсказку при наведении мышкой на объект
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Это поле введено некорректно!";
                passBox.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = ""; //убирает подсказку
                textBoxLogin.Background = Brushes.Transparent; //делает фон прозрачным
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null;
                using (ApplicationContext db = new ApplicationContext())
                //создает закрытое окружение, в котором выполняется код подключения к БД 
                {
                    authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
                }
                if (authUser != null)
                    MessageBox.Show("Все работает!");
                else MessageBox.Show("Такого пользователя не существует!");

            }
        }
    }
}
