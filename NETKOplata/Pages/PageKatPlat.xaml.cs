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
    /// Логика взаимодействия для PageKatPlat.xaml
    /// </summary>
    public partial class PageKatPlat : Page
    {
        private List<KatPlat> allItems;
        private KatPlat selectedKatPlat;
        List<KatPlat> materials = DbConnect.entObj.KatPlat.ToList();
        public ObservableCollection<KatPlat> material { get; set; }
        public PageKatPlat()
        {
            InitializeComponent();

            allItems = DbConnect.entObj.KatPlat.ToList();

            try
            {
                CmbFilter.ItemsSource = DbConnect.entObj.KatPlat.ToList();
                CmbFilter.DisplayMemberPath = "Name";
                CmbSort.SelectedIndex = 0;
                CmbFilter.SelectedIndex = 0;

                DgrKatPlat.ItemsSource = DbConnect.entObj.KatPlat.Take(100).ToList();
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
                DgrKatPlat.ItemsSource = DbConnect.entObj.KatPlat.ToList();
            }
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbSort.SelectedIndex == 0)
            {
                List<KatPlat> sortMaterials = allItems.OrderBy(x => x.Name).ToList();
                DgrKatPlat.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 1)
            {
                List<KatPlat> sortMaterials = allItems.OrderByDescending(x => x.Name).ToList();
                DgrKatPlat.ItemsSource = sortMaterials;
            }
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbFilter.SelectedItem as KatPlat;
            var items = (select != null) ? allItems.Where(x => x.Id == select.Id) : allItems;
            DgrKatPlat.ItemsSource = items;
        }

        private void DgrGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedKatPlat = (KatPlat)DgrKatPlat.SelectedItem;
        }

        private void DgrGroup_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            selectedKatPlat = (KatPlat)DgrKatPlat.SelectedItem;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            PageEditKatPlat editPage = new PageEditKatPlat(selectedKatPlat);
            FrameApp.frmObj.Navigate(editPage);
        }

        private void BtnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Pages.PageAddKatPlat());

        }

        private void BtnDelitedGroup_Click(object sender, RoutedEventArgs e)
        {
            var recipeForRemoving = DgrKatPlat.SelectedItems.Cast<KatPlat>().ToList();

            try
            {
                var result = MessageBox.Show("Вы уверены?",
                            "Уведомление",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DbConnect.entObj.KatPlat.RemoveRange(recipeForRemoving);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Данные удалены.",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    DgrKatPlat.ItemsSource = DbConnect.entObj.KatPlat.ToList();
                }
                else
                {
                    DgrKatPlat.ItemsSource = DbConnect.entObj.KatPlat.ToList();
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
            FrameApp.frmObj.Navigate(new Pages.ListStudents());
        }
    }
}
