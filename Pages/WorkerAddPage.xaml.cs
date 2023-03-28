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
    /// Логика взаимодействия для WorkerAddPage.xaml
    /// </summary>
    public partial class WorkerAddPage : Page
    {
        private Employee _currentemployee = new Employee();
        public WorkerAddPage(Employee selectedemployee)
        {
            InitializeComponent();
            CmbPos.ItemsSource = SpecclotheContext.GetContext().Positions.ToList();
            CmbPos.SelectedValuePath = "Idposition";
            CmbPos.DisplayMemberPath = "Posi";
            CmbDep.ItemsSource = SpecclotheContext.GetContext().Departments.ToList();
            CmbDep.SelectedValuePath = "Iddepartment";
            CmbDep.DisplayMemberPath = "Department1";

            if (selectedemployee != null)
                _currentemployee = selectedemployee;
            //создаем контекст
            DataContext = _currentemployee;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {


            StringBuilder error = new StringBuilder(); //объект для сообщения об ошибке

            //проверка полей объекта
            if (string.IsNullOrWhiteSpace(_currentemployee.Fio))
                error.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(_currentemployee.PositionIdposition.ToString()))
                error.AppendLine("Укажите фамилию");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentemployee.IdEmployees == 0)
                SpecclotheContext.GetContext().Employees.Add(_currentemployee); //добавить в контекст
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
    }
}
