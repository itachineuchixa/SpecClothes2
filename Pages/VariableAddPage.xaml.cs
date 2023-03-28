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
    /// Логика взаимодействия для VariableAddPage.xaml
    /// </summary>
    public partial class VariableAddPage : Page
    {
        private Variable _currentvariable = new Variable();
        public VariableAddPage(Variable selectedvariable)
        {
            InitializeComponent();

            if (selectedvariable != null)
                _currentvariable = selectedvariable;
            //создаем контекст
            DataContext = _currentvariable;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {


            StringBuilder error = new StringBuilder(); //объект для сообщения об ошибке

            //проверка полей объекта
            if (string.IsNullOrWhiteSpace(_currentvariable.Variable1))
                error.AppendLine("Укажите имя");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentvariable.IdVariable == 0)
                SpecclotheContext.GetContext().Variables.Add(_currentvariable); //добавить в контекст
            try
            {
                SpecclotheContext.GetContext().SaveChanges(); // сохранить изменения
                                                              // dbISP19AEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MessageBox.Show("Данные сохранены");
                manager.MainFrame.Navigate(new ClothesPage());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

