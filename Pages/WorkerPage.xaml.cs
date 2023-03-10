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
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DGridHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
