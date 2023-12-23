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
    /// Логика взаимодействия для PageEditStudent.xaml
    /// </summary>
    public partial class PageEditStudent : Page
    {
        private CardStudent material;
        public PageEditStudent(CardStudent selectedStudent)
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

            this.material = selectedStudent;
            // Заполните элементы формы значениями из supplier
            if (material != null)
            {
                TxbFIO.Text = material.FIO;
                CmdGroup.SelectedItem = material.IdGroup;
                CmbObshejit.SelectedItem = material.IdObshejit;
                CmdKatPlat.SelectedItem = material.IdKatPlat;
                DateYearStart.Text = material.YearStar.HasValue ? material.YearStar.Value.ToString() : null;
                DateYearFinal.Text = material.YearFinal.HasValue ? material.YearFinal.Value.ToString() : null;
                TxbOtchis.Text = material.Otchis?.ToString();
                TxbNote.Text = material.Note;
                TxbRoom.Text = material.Room?.ToString();

                if (material.Image != null)
                {
                    var imageSource = new BitmapImage(new Uri(material.Image, UriKind.RelativeOrAbsolute));
                    FotoMaterial.Source = imageSource;
                }
                else
                {
                    FotoMaterial.Source = null;
                }
            }

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
            if (material != null)
            {
                material.FIO = TxbFIO.Text;
                material.IdGroup = ((DataBaseApp.Group)CmdGroup.SelectedItem).Id;
                material.IdObshejit = ((DataBaseApp.PriceLife)CmbObshejit.SelectedItem).Id;
                material.IdKatPlat = ((DataBaseApp.KatPlat)CmdKatPlat.SelectedItem).Id;
                material.YearStar = DateYearStart.SelectedDate;
                material.YearFinal = DateYearFinal.SelectedDate;

                if (int.TryParse(TxbOtchis.Text, out int otchisResult))
                {
                    material.Otchis = otchisResult;
                }
                else
                {
                    // Если ввод не является корректным числом, устанавливаем Otchis в null
                    material.Otchis = null;
                    // или другая логика обработки ошибки
                }

                material.Note = TxbNote.Text;

                if (int.TryParse(TxbRoom.Text, out int roomResult))
                {
                    material.Room = roomResult;
                }
                else
                {
                    // Если ввод не является корректным числом, устанавливаем Room в null
                    material.Room = null;
                    // или другая логика обработки ошибки
                }

                if (FotoMaterial.Source is BitmapImage bitmapImage)
                {
                    material.Image = bitmapImage.UriSource.AbsolutePath;
                }

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
