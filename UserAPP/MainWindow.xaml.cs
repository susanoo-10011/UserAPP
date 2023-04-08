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
using System.Windows.Media.Animation; //нужен для работы с анимацией

namespace UserAPP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ApplicationContext db;
        public MainWindow()
        {
            InitializeComponent();
            // TextOptions.SetTextRenderingMode(this, TextRenderingMode.Aliased);
            // TextOptions.SetTextFormattingMode(this, TextFormattingMode.Display);

            db = new ApplicationContext(); //объект, который уже подключен к БД и с ним уже можно работать.

            DoubleAnimation bthAnnumation = new DoubleAnimation();
            bthAnnumation.From = 0;
            bthAnnumation.To = 450;
            bthAnnumation.Duration = TimeSpan.FromSeconds(3);
            regButton.BeginAnimation(Button.WidthProperty,bthAnnumation);

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim(); //Trim() убирает лишние пробелы
            string pass = passBox.Password.Trim();
            string pass2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower(); //ToLower приводит к нижнему регистру

            if(login.Length < 5)
            {
                textBoxLogin.ToolTip = "Это поле введено некорректно!"; //добавляет подсказку при наведении мышкой на объект
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if(pass.Length < 5) 
            {
                passBox.ToolTip = "Это поле введено некорректно!"; 
                passBox.Background = Brushes.DarkRed;
            }
            else if (pass != pass2)
            {
                passBox_2.ToolTip = "Пароли не совпадают";
                passBox_2.Background = Brushes.DarkRed;
            }
            else if (!email.Contains("@") || email.Length <5 || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Это поле введено некорректно!";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = ""; //убирает подсказку
                textBoxLogin.Background = Brushes.Transparent; //делает фон прозрачным
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("Все работает!");

                User user = new User(login, email, pass);

                db.Users.Add(user);
                db.SaveChanges(); //добавляет новую запись в БД

                AuthWindow authWindow = new AuthWindow(); //создаем объект того окна, на которое надо перейти
                authWindow.Show();
                this.Hide();

            }
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow(); //создаем объект того окна, на которое надо перейти
            authWindow.Show();
            this.Hide();
        }
    }
}
