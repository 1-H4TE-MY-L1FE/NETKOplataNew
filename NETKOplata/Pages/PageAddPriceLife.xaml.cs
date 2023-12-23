using NETKOplata.DataBaseApp;
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

namespace NETKOplata.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAddPriceLife.xaml
    /// </summary>
    public partial class PageAddPriceLife : Page
    {
        public PageAddPriceLife()
        {
            InitializeComponent();

            CmdKatPlat.SelectedValuePath = "Id";

            CmdKatPlat.DisplayMemberPath = "Name";

            CmdKatPlat.ItemsSource = DbConnect.entObj.KatPlat.ToList();
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PriceLife materialObj = new PriceLife()
                {
                    Obshejit = TxbObshejit.Text,
                    FormLearn = TxbFormLearn.Text,
                    IdKatPlat = CmdKatPlat.SelectedIndex + 1,
                    September = Convert.ToInt32(TxbSeptember.Text),
                    October = Convert.ToInt32(TxbOctober.Text),
                    November = Convert.ToInt32(TxbNovember.Text),
                    December = Convert.ToInt32(TxbDecember.Text),
                    January = Convert.ToInt32(TxbJanuary.Text),
                    February = Convert.ToInt32(TxbFebruary.Text),
                    March = Convert.ToInt32(TxbMarch.Text),
                    April = Convert.ToInt32(TxbApril.Text),
                    May = Convert.ToInt32(TxbMay.Text),
                    June = Convert.ToInt32(TxbJune.Text),
                    July = Convert.ToInt32(TxbJuly.Text),
                    August = Convert.ToInt32(TxbAugust.Text),
                };

                DbConnect.entObj.PriceLife.Add(materialObj);
                DbConnect.entObj.SaveChanges();

                MessageBox.Show("Оплата добавлен",
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(),
                                "Критический сбой работы приложения",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
