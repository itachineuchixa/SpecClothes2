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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Office.Interop.Word;
using SpecClothes.Database.DatabaseClasses;

namespace SpecClothes
{
    /// <summary>
    /// Логика взаимодействия для DefaultPage.xaml
    /// </summary>
    public partial class DefaultPage : System.Windows.Controls.Page
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
            manager.MainFrame.Navigate(new DeliveryAddPage((sender as Button).DataContext as Delivery));
        }

        private void DGridHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            manager.MainFrame.Navigate(new DeliveryAddPage(null));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {// удаление нескольких пользователей
            var usersForRemoving = DGrid.SelectedItems.Cast<Delivery>().ToList();
            if (MessageBox.Show($"Удалить {usersForRemoving.Count()} записей?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)

                try
                {
                    SpecclotheContext.GetContext().Deliveries.RemoveRange(usersForRemoving);
                    SpecclotheContext.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                    DGrid.ItemsSource = SpecclotheContext.GetContext().Deliveries.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


        }

        private void Ochjet_click(object sender, RoutedEventArgs e)
        {
            List<Delivery> rem = DGrid.ItemsSource as List<Delivery>;

            var application = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document document = application.Documents.Add();
            Microsoft.Office.Interop.Word.Paragraph p = document.Paragraphs.Add();
            p.Range.Text += "";
            p.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
            Microsoft.Office.Interop.Word.Paragraph paragraph2 = document.Paragraphs.Add();
            // Add report header
            paragraph2.Range.Text = "Типовая межотраслевая форма № МБ-7\nУтверждена постановлением Госкомстата России\nот 30.10.97 №71а";
            paragraph2.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            Microsoft.Office.Interop.Word.Paragraph paragraph = document.Paragraphs.Add();
            paragraph.Range.Text = "Код \r\nпо ОКУД \r\n";
            paragraph.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            paragraph.Range.Bold = 1;
            Microsoft.Office.Interop.Word.Paragraph paragraph3 = document.Paragraphs.Add();
            paragraph3.Range.Text = "ВЕДОМОСТЬ УЧЕТА ВЫДАЧИ (ВОЗВРАТА) СПЕЦОДЕЖДЫ, СПЕЦОБУВИ И  \r\nПРЕДОХРАНИТЕЛЬНЫХ ПРИСПОСОБЛЕНИЙ \r\n";
            paragraph3.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            paragraph3.Range.Bold = 0;

            Microsoft.Office.Interop.Word.Paragraph tableparagraph2 = document.Paragraphs.Add();
            Microsoft.Office.Interop.Word.Range tableRange2 = tableparagraph2.Range;
            Microsoft.Office.Interop.Word.Table infoTable2 = document.Tables.Add(tableRange2, 2, 4);
            infoTable2.Borders.InsideLineStyle = infoTable2.Borders.OutsideLineStyle
                    = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            /*            infoTable.Range.Cells.VerticalAlignment
                                = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;*/
            Microsoft.Office.Interop.Word.Range cellRange2;
            cellRange2 = infoTable2.Cell(1, 1).Range;
            cellRange2.Text = "Номер документа";
            cellRange2 = infoTable2.Cell(1, 2).Range;
            cellRange2.Text = "Месяц, год";
            cellRange2 = infoTable2.Cell(1, 3).Range;
            cellRange2.Text = "Код вида операции";
            cellRange2 = infoTable2.Cell(1, 4).Range;
            cellRange2.Text = "Предприятие";

            infoTable2.Rows[1].Range.Bold = 1;
            tableRange2.Borders.Enable = 1;
            tableRange2.Columns.AutoFit();

            Microsoft.Office.Interop.Word.Paragraph p2 = document.Paragraphs.Add();
            p2.Range.Text += "";

            Microsoft.Office.Interop.Word.Paragraph tableparagraph = document.Paragraphs.Add();
            Microsoft.Office.Interop.Word.Range tableRange = tableparagraph.Range;
            Microsoft.Office.Interop.Word.Table infoTable = document.Tables.Add(tableRange, rem.Count+1, 5);
            infoTable.Borders.InsideLineStyle = infoTable.Borders.OutsideLineStyle
                    = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
            infoTable.Range.Cells.VerticalAlignment
                    = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            Microsoft.Office.Interop.Word.Range cellRange;
            cellRange = infoTable.Cell(1, 1).Range;
            cellRange.Text = "Дата выдачи";
            cellRange = infoTable.Cell(1, 2).Range;
            cellRange.Text = "Дата замены";
            cellRange = infoTable.Cell(1, 3).Range;
            cellRange.Text = "Наименование";
            cellRange = infoTable.Cell(1, 4).Range;
            cellRange.Text = "Сумма";
            cellRange = infoTable.Cell(1, 5).Range;
            cellRange.Text = "Фамилия, имя, отчество";

            infoTable.Rows[1].Range.Bold = 1;

            for (int i = 0; i < rem.Count; i++)
            {
                cellRange = infoTable.Cell(i + 2, 1).Range;
                cellRange.Text = rem[i].Datato.ToString();
                cellRange = infoTable.Cell(i + 2, 2).Range;
                cellRange.Text = rem[i].Datatrade.ToString();
                cellRange = infoTable.Cell(i + 2, 3).Range;
                cellRange.Text = rem[i].ClothesIdclothesNavigation.Clothe1.ToString();
                cellRange = infoTable.Cell(i + 2, 4).Range;
                cellRange.Text = rem[i].Price.ToString();
                cellRange = infoTable.Cell(i + 2, 5).Range;
                cellRange.Text = rem[i].EmployeesIdEmployeesNavigation.Fio.ToString();
            }
            tableRange.Borders.Enable = 1;
            tableRange.Columns.AutoFit();
            Microsoft.Office.Interop.Word.Paragraph p3 = document.Paragraphs.Add();
            p3.Range.Text += "Материально ответственное лицо __________________________________";
            Microsoft.Office.Interop.Word.Paragraph p4 = document.Paragraphs.Add();
            p4.Range.Text += "Печатать с оборотом без заголовочной части. Подпись печатать на  обороте.";

            application.Visible = true;
        }

        }
}
