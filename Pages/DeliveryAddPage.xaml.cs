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
    /// Логика взаимодействия для DeliveryAddPage.xaml
    /// </summary>
    public partial class DeliveryAddPage : Page
    {
        private Delivery _currentdelivery = new Delivery();
        public DeliveryAddPage(Delivery selecteddelivery)
        {
            InitializeComponent();
            clothe.ItemsSource = SpecclotheContext.GetContext().Clothes.ToList();
            clothe.SelectedValuePath = "Idclothes";
            clothe.DisplayMemberPath = "Clothe1";
            employee.ItemsSource = SpecclotheContext.GetContext().Employees.ToList();
            employee.SelectedValuePath = "IdEmployees";
            employee.DisplayMemberPath = "Fio";

            if (selecteddelivery != null)
                _currentdelivery = selecteddelivery;
            //создаем контекст
            DataContext = _currentdelivery;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentdelivery.ClothesIdclothesNavigation = SpecclotheContext.GetContext().Clothes.Where(x => x.Idclothes == int.Parse(clothe.SelectedValue.ToString())).ToList()[0];
                _currentdelivery.EmployeesIdEmployeesNavigation = SpecclotheContext.GetContext().Employees.Where(x => x.IdEmployees == int.Parse(employee.SelectedValue.ToString())).ToList()[0];
                _currentdelivery.EmployeesIdEmployeesNavigation.PositionIdpositionNavigation = SpecclotheContext.GetContext().Positions.Where(x => x.Idposition == _currentdelivery.EmployeesIdEmployeesNavigation.PositionIdposition).ToList()[0];
                StringBuilder error = new StringBuilder(); //объект для сообщения об ошибке
                _currentdelivery.Price = _currentdelivery.ClothesIdclothesNavigation.Price - (_currentdelivery.ClothesIdclothesNavigation.Price * (_currentdelivery.EmployeesIdEmployeesNavigation.PositionIdpositionNavigation.Discount / 100));
                _currentdelivery.Datatrade = Convert.ToDateTime(_currentdelivery.Datato).AddMonths(Convert.ToInt32(_currentdelivery.ClothesIdclothesNavigation.Term)).Date.ToString("dd.MM.yyyy");
                //проверка полей объекта
                if (string.IsNullOrWhiteSpace(_currentdelivery.Datato))
                    error.AppendLine("Укажите Дату выдачи");
                if (string.IsNullOrWhiteSpace(_currentdelivery.Datatrade.ToString()))
                    error.AppendLine("Укажите Дату замены");
                if (error.Length > 0)
                {
                    MessageBox.Show(error.ToString());
                    return;
                }
                //если пользователь новый
                if (_currentdelivery.Iddelivery == 0)
                    SpecclotheContext.GetContext().Deliveries.Add(_currentdelivery); //добавить в контекст
                try
                {
                    SpecclotheContext.GetContext().SaveChanges(); // сохранить изменения
                                                                  // dbISP19AEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                    MessageBox.Show("Данные сохранены");
                    manager.MainFrame.Navigate(new WorkerPage());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            catch
            {
                MessageBox.Show($"Введите данные!",
                "Внимание", MessageBoxButton.OK);

            }
        }
    }
}
