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
    /// Логика взаимодействия для ClothesPage.xaml
    /// </summary>
    public partial class ClothesPage : Page
    {
        public ClothesPage()
        {
            InitializeComponent();
            List<Clothe> del = SpecclotheContext.GetContext().Clothes.ToList();
            foreach (var d in del)
            {
                d.VariableIdVariableNavigation = SpecclotheContext.GetContext().Variables.Where(x => x.IdVariable == d.VariableIdVariable).ToList()[0];
            }
            DGrid.ItemsSource = del;

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DGridHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
