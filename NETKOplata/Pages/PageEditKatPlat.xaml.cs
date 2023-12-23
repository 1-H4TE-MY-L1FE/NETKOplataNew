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
    /// Логика взаимодействия для PageEditKatPlat.xaml
    /// </summary>
    public partial class PageEditKatPlat : Page
    {
        private KatPlat material;
        public PageEditKatPlat(KatPlat selectedKatPlat)
        {
            InitializeComponent();

            this.material = selectedKatPlat;
            // Заполните элементы формы значениями из supplier
            if (material != null)
            {
                TxbTitle.Text = material.Name;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (material != null)
            {
                material.Name = TxbTitle.Text;

                DbConnect.entObj.SaveChanges();
                FrameApp.frmObj.Navigate(new PageKatPlat());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
