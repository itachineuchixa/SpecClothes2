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
using SpecClothes.Database.DatabaseClasses;

namespace SpecClothes
{
    /// <summary>
    /// Логика взаимодействия для ClotheAddPage.xaml
    /// </summary>
    public partial class ClotheAddPage : Page
    {
        private Clothe _currentclothe = new Clothe();
        public ClotheAddPage(Clothe selectedclothe)
        {
            InitializeComponent();
            CmbLogin.ItemsSource = SpecclotheContext.GetContext().Variables.ToList();
            CmbLogin.SelectedValuePath = "IdVariable";
            CmbLogin.DisplayMemberPath = "Variable1";

            if (selectedclothe != null)
                _currentclothe = selectedclothe;
            //создаем контекст
            DataContext = _currentclothe;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {


            StringBuilder error = new StringBuilder(); //объект для сообщения об ошибке

            //проверка полей объекта
            if (string.IsNullOrWhiteSpace(_currentclothe.Clothe1))
                error.AppendLine("Укажите имя");
            if (string.IsNullOrWhiteSpace(_currentclothe.Term.ToString()))
                error.AppendLine("Укажите фамилию");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            //если пользователь новый
            if (_currentclothe.Idclothes == 0)
                SpecclotheContext.GetContext().Clothes.Add(_currentclothe); //добавить в контекст
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
