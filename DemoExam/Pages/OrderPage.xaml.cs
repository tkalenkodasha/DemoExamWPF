using DemoExam.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        List<Product> productList = new List<Product>();//создаем пустой лист к которому можно будет обращаться во всех методах
        public OrderPage(List<Product> products, User user)
        {
            InitializeComponent();

            DataContext = this;//привязываем контекст данных к коду
            productList = products;//передаем список с товарами в пустой лист
            LViewOrder.ItemsSource = productList;//выодим список выбранных товаров в макет
            var pickUpPoints = DemoDbContext.GetContext().PickUpPoints
                .Include(p => p.City) // Убедитесь, что вы включаете связанные данные о городе
                .ToList();
            PickUpPointComboBox.ItemsSource = pickUpPoints;//выводим в комбобокс список пунктов выдачи
            if (user != null)
            {
                txtUser.Text = user.Id.ToString();
            }
        }

        private void DuttonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить этот элемент?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                productList.Remove(LViewOrder.SelectedItem as Product);
            }
        }

        public string Total
        {
            get
            {
                var Total = productList.Sum(p => Convert.ToDouble(p.Cost));
                return Total.ToString();
            }
        }

        private void ButtonOrderSave_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
