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
    /// Логика взаимодействия для PageEditPriceLife.xaml
    /// </summary>
    public partial class PageEditPriceLife : Page
    {
        private PriceLife material;
        public PageEditPriceLife(PriceLife selectedPriceLife)
        {
            InitializeComponent();

            CmdKatPlat.SelectedValuePath = "Id";

            CmdKatPlat.DisplayMemberPath = "Name";

            CmdKatPlat.ItemsSource = DbConnect.entObj.KatPlat.ToList();

            this.material = selectedPriceLife;
            // Заполните элементы формы значениями из supplier
            if (material != null)
            {
                TxbObshejit.Text = material.Obshejit;
                TxbFormLearn.Text = material.FormLearn;
                CmdKatPlat.SelectedItem = material.IdKatPlat;
                TxbSeptember.Text = material.September.ToString();
                TxbOctober.Text = material.October.ToString();
                TxbNovember.Text = material.November.ToString();
                TxbDecember.Text = material.December.ToString();
                TxbJanuary.Text = material.January.ToString();
                TxbFebruary.Text = material.February.ToString();
                TxbMarch.Text = material.March.ToString();
                TxbApril.Text = material.April.ToString();
                TxbMay.Text = material.May.ToString();
                TxbJune.Text = material.June.ToString();
                TxbJuly.Text = material.July.ToString();
                TxbAugust.Text = material.August.ToString();
            }
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (material != null)
            {
                material.Obshejit = TxbObshejit.Text;
                material.FormLearn = TxbFormLearn.Text;
                material.IdKatPlat = ((DataBaseApp.KatPlat)CmdKatPlat.SelectedItem).Id;
                material.September = int.Parse(TxbSeptember.Text);
                material.October = int.Parse(TxbOctober.Text);
                material.November = int.Parse(TxbNovember.Text);
                material.December = int.Parse(TxbDecember.Text);
                material.January = int.Parse(TxbJanuary.Text);
                material.February = int.Parse(TxbFebruary.Text);
                material.March = int.Parse(TxbMarch.Text);
                material.April = int.Parse(TxbApril.Text);
                material.May = int.Parse(TxbMay.Text);
                material.June = int.Parse(TxbJune.Text);
                material.July = int.Parse(TxbJuly.Text);
                material.August = int.Parse(TxbAugust.Text);

                DbConnect.entObj.SaveChanges();
                FrameApp.frmObj.Navigate(new ListStudents());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
