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
            Combo.Items.Add("Виды");
            foreach (var item in SpecclotheContext.GetContext().Clothes.
     Select(x => x.VariableIdVariableNavigation.Variable1).Distinct().ToList())
            {
                Combo.Items.Add(item);
            }
        }


        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Combo.SelectedValue.ToString() == "Виды")
                {
                    List<Clothe> del = SpecclotheContext.GetContext().Clothes.ToList();
                    foreach (var d in del)
                    {
                        d.VariableIdVariableNavigation = SpecclotheContext.GetContext().Variables.Where(x => x.IdVariable == d.VariableIdVariable).ToList()[0];
                    }
                    DGrid.ItemsSource = del;
                    //TxbCountSearchItem.Text = dbISP19AEntities.GetContext().User.Count().ToString();
                }
                else
                {
                    List<Clothe> del = SpecclotheContext.GetContext().Clothes.ToList();
                    foreach (var d in del)
                    {
                        d.VariableIdVariableNavigation = SpecclotheContext.GetContext().Variables.Where(x => x.IdVariable == d.VariableIdVariable).ToList()[0];
                    }
                    DGrid.ItemsSource = del;
                    DGrid.ItemsSource = SpecclotheContext.GetContext().Clothes.
                        Where(x => x.VariableIdVariableNavigation.Variable1 == Combo.SelectedValue.ToString()).ToList();
                    //TxbCountSearchItem.Text = dbISP19AEntities.GetContext().User.
                    //       Where(x => x.LastName == CmbFiltr.SelectedValue.ToString()).Count().ToString();
                }
            }
            catch(Exception ex) { }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new ClotheAddPage((sender as Button).DataContext as Clothe));
        }

        private void DGridHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
