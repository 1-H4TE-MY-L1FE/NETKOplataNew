using NETKOplata.DataBaseApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ListStudents.xaml
    /// </summary>
    public partial class ListStudents : Page
    {
        private List<CardStudent> allItems;
        private CardStudent selectedMaterial;
        List<CardStudent> materials = DbConnect.entObj.CardStudent.ToList();
        public ObservableCollection<CardStudent> material { get; set; }
        public ListStudents()
        {
            InitializeComponent();

            allItems = DbConnect.entObj.CardStudent.ToList();

            try
            {
                CmbFilter.ItemsSource = DbConnect.entObj.KatPlat.ToList();
                CmbFilter.DisplayMemberPath = "Name";
                CmbSort.SelectedIndex = 0;
                CmbFilter.SelectedIndex = 0;

                DgrStudents.ItemsSource = DbConnect.entObj.CardStudent.Take(100).ToList();
                TxbResult.Text = DgrStudents.Items.Count + "/" + DbConnect.entObj.CardStudent.Count().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                                "Что-то пошло не так!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Exclamation);
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DgrStudents.ItemsSource = DbConnect.entObj.CardStudent.ToList();
            }
        }

        private void BtnGroup_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Pages.PageGroup());
        }

        private void BtnKatPlat_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Pages.PageKatPlat());
        }

        private void BtnPriceLife_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Pages.PagePriceLife());
        }

        private void BtnInputPrice_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Pages.PageInputPrice());
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgrStudents.ItemsSource = DbConnect.entObj.CardStudent
    .Where(x => x.FIO.ToString().Contains(TxbSearch.Text))
    .Take(15)
    .ToList();
            TxbResult.Text = DgrStudents.Items.Count + "/" + DbConnect.entObj.CardStudent
                .Where(x => x.FIO.ToString().Contains(TxbSearch.Text))
                .Count()
                .ToString();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbSort.SelectedIndex == 0)
            {
                List<CardStudent> sortMaterials = allItems.OrderBy(x => x.FIO).ToList();
                DgrStudents.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 1)
            {
                List<CardStudent> sortMaterials = allItems.OrderByDescending(x => x.FIO).ToList();
                DgrStudents.ItemsSource = sortMaterials;
            }
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbFilter.SelectedItem as DataBaseApp.KatPlat;
            var items = (select != null) ? allItems.Where(x => x.IdKatPlat == select.Id) : allItems;
            DgrStudents.ItemsSource = items;
        }

        private void DgrStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedMaterial = (CardStudent)DgrStudents.SelectedItem;
        }

        private void DgrStudents_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            selectedMaterial = (CardStudent)DgrStudents.SelectedItem;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            PageEditStudent editPage = new PageEditStudent(selectedMaterial);
            FrameApp.frmObj.Navigate(editPage);
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Pages.PageAddStudent());
        }

        private void BtnDelitedStudent_Click(object sender, RoutedEventArgs e)
        {
            var recipeForRemoving = DgrStudents.SelectedItems.Cast<CardStudent>().ToList();

            try
            {
                var result = MessageBox.Show("Вы уверены?",
                            "Уведомление",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DbConnect.entObj.CardStudent.RemoveRange(recipeForRemoving);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Данные удалены.",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    DgrStudents.ItemsSource = DbConnect.entObj.CardStudent.ToList();
                }
                else
                {
                    DgrStudents.ItemsSource = DbConnect.entObj.CardStudent.ToList();
                }
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
            FrameApp.frmObj.Navigate(new Pages.Authoriz());
        }
    }
}
