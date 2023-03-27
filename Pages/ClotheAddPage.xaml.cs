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
            CmbLogin.ItemsSource = dbISP19AEntities.GetContext().Account.ToList();
            CmbLogin.SelectedValuePath = "ID";
            CmbLogin.DisplayMemberPath = "Login";

            if (selectedUser != null)
                _currentUser = selectedUser;
            //создаем контекст
            DataContext = _currentUser;
        }
    }
}
