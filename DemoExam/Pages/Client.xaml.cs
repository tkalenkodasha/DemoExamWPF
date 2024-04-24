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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        public Client()
        {
            InitializeComponent();
            var context = DemoDbContext.GetContext();
            var product = context.Products.Include(p => p.Category).ToList();
            LViewProduct.ItemsSource = product;
            SortingComboBox.ItemsSource = SortingList;
            FilterComboBox.ItemsSource = context.Categories.ToList();
            DataContext=this;
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
                //allStudents = allStudents.Where(student => student.Group.GroupId == selectedGroup.GroupId).ToArray();
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
        }
        private void cmbSorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtration();

        }

        private void cmdFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filtration();
        }
    }
}
