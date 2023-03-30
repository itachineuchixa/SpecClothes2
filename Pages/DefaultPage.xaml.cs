﻿using System;
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
    /// Логика взаимодействия для DefaultPage.xaml
    /// </summary>
    public partial class DefaultPage : Page
    {
        public DefaultPage()
        {
            InitializeComponent();
            List<Delivery> del = SpecclotheContext.GetContext().Deliveries.ToList();
            foreach (var d in del)
            {
                d.ClothesIdclothesNavigation = SpecclotheContext.GetContext().Clothes.Where(x => x.Idclothes == d.ClothesIdclothes).ToList()[0];
                d.EmployeesIdEmployeesNavigation = SpecclotheContext.GetContext().Employees.Where(x => x.IdEmployees == d.EmployeesIdEmployees).ToList()[0];
            }
            DGrid.ItemsSource = del;

        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //поиск
            string search = Search.Text;
            if (Search.Text != null)
            {
                List<Delivery> del = SpecclotheContext.GetContext().Deliveries.ToList();
                foreach (var d in del)
                {
                    d.ClothesIdclothesNavigation = SpecclotheContext.GetContext().Clothes.Where(x => x.Idclothes == d.ClothesIdclothes).ToList()[0];
                    d.EmployeesIdEmployeesNavigation = SpecclotheContext.GetContext().Employees.Where(x => x.IdEmployees == d.EmployeesIdEmployees).ToList()[0];
                }
                DGrid.ItemsSource = del.
                    Where(x => x.ClothesIdclothesNavigation.Clothe1.Contains(search)
                    || x.EmployeesIdEmployeesNavigation.Fio.Contains(search)
                    || x.Datato.Contains(search)
                    || x.Datatrade.ToString().Contains(search)).ToList();
            }
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DGridHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new DeliveryAddPage(null));
        }
    }
}
