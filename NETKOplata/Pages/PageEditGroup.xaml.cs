using System;
using NETKOplata.DataBaseApp;
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
    /// Логика взаимодействия для PageEditGroup.xaml
    /// </summary>
    public partial class PageEditGroup : Page
    {
        private Group material;
        public PageEditGroup(Group selectedGroup)
        {
            InitializeComponent();

            this.material = selectedGroup;
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
                FrameApp.frmObj.Navigate(new PageGroup());
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.GoBack();
        }
    }
}
