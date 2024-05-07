using DemoExam.Models;
using DemoExam.Windows;
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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        User user = new User();   //создаем пустой объект пользователя
        public Admin(User currentUser)
        {
            // Инициализируем компоненты пользовательского интерфейса
            InitializeComponent();

            // Получаем контекст базы данных
            var context = DemoDbContext.GetContext();

            // Загружаем все продукты из базы данных, включая связанные категории
            var product = context.Products.Include(p => p.Category).ToList();

            // Устанавливаем источник данных для списка продуктов
            LViewProduct.ItemsSource = product;

            // Устанавливаем источник данных для комбобокса сортировки
            SortingComboBox.ItemsSource = SortingList;

            // Устанавливаем источник данных для комбобокса фильтрации
            FilterComboBox.ItemsSource = context.Categories.ToList();

            // Привязываем контекст данных к текущему объекту, чтобы обратиться к массивам
            DataContext = this;

            // Отображаем общее количество продуктов в текстовом поле
            txtAllAmount.Text = product.Count().ToString();

            user = currentUser;

            // Вызываем метод фильтрации
            Filtration();


        }




        public string[] SortingList { get; set; } =
        {
            "Без сортировки",
            "Стоимость по возрастанию",
            "Стоимость по убыванию"
        };
        void Filtration()
        {
            var allProducts = DemoDbContext.GetContext().Products.ToArray();
            if (FilterComboBox.SelectedItem != null)
            {
                //принудительно конвертируем выбранный элемент в нужный нам тип (тот, который туда был выгружен ранее)
                Category selectedCategory = (Category)FilterComboBox.SelectedItem;
                //и подменяем содержимое allStudents, дофильтровывая его (не забывая опять конвертнуть в массив, иначе будет ошибка типов)

                allProducts = allProducts.Where(p => p.Category.CategoryName == selectedCategory.CategoryName).ToArray();
            }

            if (SortingComboBox.SelectedItem != null)
            {
                if (SortingComboBox.SelectedIndex == 1)
                {
                    allProducts = allProducts.OrderBy(p => p.Cost).ToArray();
                }
                if (SortingComboBox.SelectedIndex == 2)
                {
                    allProducts = allProducts.OrderByDescending(p => p.Cost).ToArray();
                }

            }
            allProducts = allProducts.Where((p) => p.Name.ToLower().Contains(txtSearch.Text.ToLower())).ToArray();
            LViewProduct.ItemsSource = allProducts;


            txtResultAmount.Text = allProducts.Count().ToString();//передаем количество записей после применения поиска сортировки и фильтрации

        }
        private void cmbSorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtration();

        }

        private void cmdFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtration();
        }

        // Создаем список для хранения продуктов, которые будут добавлены в заказ
        List<Product> orderProducts = new List<Product>();

        // Обработчик события нажатия кнопки для добавления продукта в заказ
        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Добавляем выбранный продукт из ListView в список orderProducts
            orderProducts.Add(LViewProduct.SelectedItem as Product);

            // Проверяем, есть ли в списке orderProducts хотя бы один продукт
            if (orderProducts.Count > 0)
            {
                // Если продукты есть, делаем кнопку Order видимой
                ButtonOrder.Visibility = Visibility.Visible;
            }
        }

        private void ButtonOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow order = new OrderWindow(orderProducts, user);
            order.ShowDialog();


        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            var context = DemoDbContext.GetContext();
            var allProducts = context.Products
                .Include(p => p.Category).ToList();
            LViewProduct.ItemsSource = allProducts;
            txtResultAmount.Text = allProducts.Count().ToString();
        }



        private void LViewProduct_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AddEditProductPage(LViewProduct.SelectedItem as Product));//если хотим перейти к редакьтированию товара,
                                                                                                     //то передаем на страницу данные об этом товаре
        }
        private void ButtonAddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditProductPage(null));//если хотим добавить новый товар,
                                                                     //то передаем пустое значение на следующую страницу
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DemoDbContext.GetContext().ChangeTracker.Entries().ToList().ForEach(P=>P.Reload());
                LViewProduct.ItemsSource=DemoDbContext.GetContext().Products.ToList();
            }
        }
    }
}

