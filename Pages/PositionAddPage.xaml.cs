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
using SpecClothes.Database;
namespace SpecClothes
{
    /// <summary>
    /// Логика взаимодействия для PositionAddPage.xaml
    /// </summary>
    /// 
    public partial class PositionAddPage : Page
    {
        private Position _currentposition = new Position();
        public PositionAddPage(Position currentposition)
        {
            InitializeComponent();

            if (currentposition != null)
                _currentposition = currentposition;
            //создаем контекст
            DataContext = _currentposition;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {


            StringBuilder error = new StringBuilder(); //объект для сообщения об ошибке

            //проверка полей объекта
            if (string.IsNullOrWhiteSpace(_currentposition.Posi))
                error.AppendLine("Укажите имя");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentposition.Idposition == 0)
                SpecclotheContext.GetContext().Positions.Add(_currentposition); //добавить в контекст
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

