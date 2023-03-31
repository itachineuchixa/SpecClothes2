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
    /// Логика взаимодействия для PositionPage.xaml
    /// </summary>
    public partial class PositionPage : Page
    {
        public PositionPage()
        {
            InitializeComponent();
            List<Position> del = SpecclotheContext.GetContext().Positions.ToList();
            DGrid.ItemsSource = del;
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new PositionAddPage((sender as Button).DataContext as Position));
        }

        private void DGridHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new PositionAddPage(null));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new PositionPage());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            {// удаление нескольких пользователей
                var usersForRemoving = DGrid.SelectedItems.Cast<Position>().ToList();
                if (MessageBox.Show($"Удалить {usersForRemoving.Count()} записей?",
                    "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                    try
                    {
                        SpecclotheContext.GetContext().Positions.RemoveRange(usersForRemoving);
                        SpecclotheContext.GetContext().SaveChanges();
                        MessageBox.Show("Данные удалены");
                        DGrid.ItemsSource = SpecclotheContext.GetContext().Positions.ToList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }


            }
        }
    }
}
