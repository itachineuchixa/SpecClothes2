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
    /// Логика взаимодействия для DepartmentAddPage.xaml
    /// </summary>
    public partial class DepartmentAddPage : Page
    {
        private Department _currentdepartment = new Department();
        public DepartmentAddPage(Department  currentdepartment)
        {
            InitializeComponent();

            if (currentdepartment != null)
                _currentdepartment = currentdepartment;
            //создаем контекст
            DataContext = _currentdepartment;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {


            StringBuilder error = new StringBuilder(); //объект для сообщения об ошибке

            //проверка полей объекта
            if (string.IsNullOrWhiteSpace(_currentdepartment.Department1))
                error.AppendLine("Укажите имя");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentdepartment.Iddepartment == 0)
                SpecclotheContext.GetContext().Departments.Add(_currentdepartment); //добавить в контекст
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
