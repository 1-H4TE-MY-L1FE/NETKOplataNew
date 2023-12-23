using Microsoft.Win32;
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
    /// Логика взаимодействия для PageAddStudent.xaml
    /// </summary>
    public partial class PageAddStudent : Page
    {
        public PageAddStudent()
        {
            InitializeComponent();

            CmdGroup.SelectedValuePath = "Id";

            CmdGroup.DisplayMemberPath = "Name";

            CmdGroup.ItemsSource = DbConnect.entObj.Group.ToList();

            CmbObshejit.SelectedValuePath = "Id";

            CmbObshejit.DisplayMemberPath = "Obshejit";

            CmbObshejit.ItemsSource = DbConnect.entObj.PriceLife.ToList();

            CmdKatPlat.SelectedValuePath = "Id";

            CmdKatPlat.DisplayMemberPath = "Name";

            CmdKatPlat.ItemsSource = DbConnect.entObj.KatPlat.ToList();
        }

        private void BtnAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Выберите фото";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";

            if (op.ShowDialog() == true)
            {
                FotoMaterial.Source = new BitmapImage(new Uri(op.FileName));
            }
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                CardStudent materialObj = new CardStudent()
                {
                    FIO = TxbFIO.Text,
                    IdGroup = CmdGroup.SelectedIndex + 1,
                    IdObshejit = CmbObshejit.SelectedIndex + 1,
                    IdKatPlat = CmdKatPlat.SelectedIndex + 1,
                    YearStar = Convert.ToDateTime(DateYearStart.SelectedDate),
                    YearFinal = Convert.ToDateTime(DateYearStart.SelectedDate),
                    Otchis = int.TryParse(TxbOtchis.Text, out int otchisResult) ? (int?)otchisResult : null,
                    Note = TxbNote.Text,
                    Room = int.TryParse(TxbRoom.Text, out int roomResult) ? (int?)roomResult : null,
                };

                DbConnect.entObj.CardStudent.Add(materialObj);
                DbConnect.entObj.SaveChanges();

                MessageBox.Show("Студент добавлен",
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
