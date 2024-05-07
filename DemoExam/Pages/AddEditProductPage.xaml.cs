using DemoExam.Models;
using Microsoft.Win32;
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
    /// Логика взаимодействия для AddEditProductPage.xaml
    /// </summary>
    public partial class AddEditProductPage : Page
    {
        Product product = new Product();
        public AddEditProductPage(Product currentProduct)
        {
            InitializeComponent();
            if (currentProduct != null)
            {
                //если переданный объект с прошлой страницы не пустой, тогда добавляем его в созданный
                product = currentProduct;
                //показываем кнопку удаления
                buttonDeleteProduct.Visibility = Visibility.Visible;
                //запрещаем редактиирования  артикула
                txtArticle.IsEnabled = false;
            }
            DataContext = product;
            //Передаем список всех категорий в комбобокс   
            cmbCategory.ItemsSource = DemoDbContext.GetContext().Categories.ToList();
        }

        private void ButtonEnterImage_Click(object sender, RoutedEventArgs e)
        {
            //открываем диалоговое окно
            OpenFileDialog GetImageDialog = new OpenFileDialog();
            //ставим фильтр видимости файлов
            GetImageDialog.Filter = "Файлы изображений: (*.png, *.jpg, *.jpeg)| *.png; *.jpg; *.jpeg";
            //прописываем путь к папке ресурсов проекта
            GetImageDialog.InitialDirectory = "C:\\Users\\krasa\\Desktop\\УЧЕБА\\ГАЙД ДЛЯ ДЕМ_ЭКЗАМЕНА\\ГАЙД СДАЧИ ДЭ БОЖЕ СПАСИ И СОХРАНИ\\DemoExamWPF\\DemoExam\\Resources";
            if (GetImageDialog.ShowDialog() == true)
            {
                product.ImageName = GetImageDialog.SafeFileName;//добавляем имя выбранного фото в Бд
            }

        }

        private void buttonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы действительно хотите удалить{product.Name}?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                    var context = DemoDbContext.GetContext();
                    context.Products.Remove(product);
                    context.SaveChanges();
                    MessageBox.Show("Запись удалена", "Информация", MessageBoxButton.YesNo, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void buttonSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            var context = DemoDbContext.GetContext();
            StringBuilder errors = new StringBuilder();
            if (product.Cost < 0)
            {
                errors.AppendLine("Цена не может быть отрицательной");
            }
            if (product.Count < 0)
            {
                errors.AppendLine("Количество на складе не может быть отрицательным");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());//выводим ошибки
                return;
            }
            // Установка CategoryId для товара
            if (cmbCategory.SelectedValue != null)
            {
                product.CategoryId = (int)cmbCategory.SelectedValue;
            }
            if (txtArticle != null && txtCost != null && txtCount != null && txttitle != null)
            {
                // Установка CategoryId для товара
                context.Products.Add(product);//добавляем объект в бд
            }
            try
            {
                context.SaveChanges();
                MessageBox.Show("Запись сохранена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();//переход на предыдущую страницу
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ошибка", MessageBoxButton.OK, MessageBoxImage.Error);//выводим ошибки
            }
        }
    }
}
