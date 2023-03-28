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
    /// Логика взаимодействия для WorkerPage.xaml
    /// </summary>
    public partial class WorkerPage : Page
    {
        public WorkerPage()
        {
            InitializeComponent();
            List<Employee> del = SpecclotheContext.GetContext().Employees.ToList();
            foreach (var d in del)
            {
                d.PositionIdpositionNavigation = SpecclotheContext.GetContext().Positions.Where(x => x.Idposition == d.PositionIdposition).ToList()[0];
                d.DepartmentsIddepartmentNavigation = SpecclotheContext.GetContext().Departments.Where(x => x.Iddepartment == d.DepartmentsIddepartment).ToList()[0];
            }
            DGrid.ItemsSource = del;
            Combo.Items.Add("Виды");
            foreach (var item in SpecclotheContext.GetContext().Employees.
     Select(x => x.DepartmentsIddepartmentNavigation.Department1).Distinct().ToList())
            {
                Combo.Items.Add(item);
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new WorkerAddPage((sender as Button).DataContext as Employee));
        }

        private void DGridHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //поиск
            string search = Search.Text;
            if (Search.Text != null)
            {
                DGrid.ItemsSource = SpecclotheContext.GetContext().Employees.
                    Where(x => x.Fio.Contains(search)
                    || x.DepartmentsIddepartmentNavigation.Department1.Contains(search)
                    || x.PositionIdpositionNavigation.Posi.Contains(search)
                    || x.IdEmployees.ToString().Contains(search)).ToList();
            }
        }

        private void Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (Combo.SelectedValue.ToString() == "Виды")
                {
                    List<Employee> del = SpecclotheContext.GetContext().Employees.ToList();
                    foreach (var d in del)
                    {
                        d.DepartmentsIddepartmentNavigation = SpecclotheContext.GetContext().Departments.Where(x => x.Iddepartment == d.DepartmentsIddepartment).ToList()[0];
                    }
                    DGrid.ItemsSource = del;
                    //TxbCountSearchItem.Text = dbISP19AEntities.GetContext().User.Count().ToString();
                }
                else
                {
                    List<Employee> del = SpecclotheContext.GetContext().Employees.ToList();
                    foreach (var d in del)
                    {
                        d.DepartmentsIddepartmentNavigation = SpecclotheContext.GetContext().Departments.Where(x => x.Iddepartment == d.DepartmentsIddepartment).ToList()[0];
                    }
                    DGrid.ItemsSource = del;
                    DGrid.ItemsSource = SpecclotheContext.GetContext().Employees.
                        Where(x => x.DepartmentsIddepartmentNavigation.Department1 == Combo.SelectedValue.ToString()).ToList();
                    //TxbCountSearchItem.Text = dbISP19AEntities.GetContext().User.
                    //       Where(x => x.LastName == CmbFiltr.SelectedValue.ToString()).Count().ToString();
                }
            }
            catch (Exception ex) { }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new WorkerAddPage(null));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new PositionPage());
        }
    }
}
