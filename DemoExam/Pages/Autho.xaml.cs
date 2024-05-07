using DemoExam.Models;
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

namespace DemoExam.Pages
{
    /// <summary>
    /// Логика взаимодействия для Autho.xaml
    /// </summary>
    public partial class Autho : Page
    {
        public Autho()
        {
            InitializeComponent();
            var context = DemoDbContext.GetContext();
            RoleComboBox.ItemsSource = context.Roles.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Client(null));//переход на страницу клиента для неавторизованного гостя
        }

       
        //метод для перехода на соответствующую страницу для разных пользователей
        private void LoadForm(string _role, User user)
        {
            switch (_role)
            {
                case "Клиент":
                    NavigationService.Navigate(new Client(user));// если роль пользователья клиент то переходим на страницу клиента
                    break;
                case "Менеджер":
                    NavigationService.Navigate(new Client(user));
                    break;
                case "Администратор":
                    NavigationService.Navigate(new Admin(user));
                    break;
            }
        }
        // Метод для проверки авторизации пользователя
        private void CheckAuthoButton(object sender, RoutedEventArgs e)
        {
            // Получение контекста базы данных
            var context = DemoDbContext.GetContext();

            // Проверка, выбран ли элемент в комбобоксе ролей
            if (RoleComboBox.SelectedItem != null)
            {
                // Получение выбранной роли из комбобокса
                Role selectedRole = (Role)RoleComboBox.SelectedItem;

                // Поиск пользователя в базе данных по логину, паролю и роли
                var user = context.Users.FirstOrDefault(u =>
                    u.Password == PasswordBox.Password && u.Login == LoginTextBox.Text && u.Role == selectedRole);

                // Если пользователь не найден, выводится сообщение об ошибке
                if (user == null)
                {
                    MessageBox.Show("attention!! pls, input your correct login and password");
                }
                else
                {
                    // Если пользователь найден, выводится сообщение с его ролью и загружается форма
                    MessageBox.Show("ur login as:" + user.Role.RoleName.ToString());
                    LoadForm(user.Role.RoleName, user);
                }
            }
            else
            {
                // Если не выбрана роль, выводится сообщение об ошибке
                MessageBox.Show("error!! fill in all the personal data");
            }
        }
    }
    } 
