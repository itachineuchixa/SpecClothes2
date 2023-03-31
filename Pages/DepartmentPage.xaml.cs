using SpecClothes.Database.DatabaseClasses;
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

namespace SpecClothes
{
    /// <summary>
    /// Логика взаимодействия для DepartmentPage.xaml
    /// </summary>
    public partial class DepartmentPage : Page
    {
        public DepartmentPage()
        {
            InitializeComponent();
            List<Department> del = SpecclotheContext.GetContext().Departments.ToList();
            DGrid.ItemsSource = del;
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new DepartmentAddPage((sender as Button).DataContext as Department));
        }

        private void DGridHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new DepartmentAddPage(null));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new PositionPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new PositionPage());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            {// удаление нескольких пользователей
                var usersForRemoving = DGrid.SelectedItems.Cast<Department>().ToList();
                if (MessageBox.Show($"Удалить {usersForRemoving.Count()} записей?",
                    "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                    try
                    {
                        SpecclotheContext.GetContext().Departments.RemoveRange(usersForRemoving);
                        SpecclotheContext.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены");
                        DGrid.ItemsSource = SpecclotheContext.GetContext().Departments.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }


            }
        }
    }
}

