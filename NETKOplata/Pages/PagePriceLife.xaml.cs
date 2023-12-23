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
    /// Логика взаимодействия для PagePriceLife.xaml
    /// </summary>
    public partial class PagePriceLife : Page
    {
        private List<PriceLife> allItems;
        private PriceLife selectedPriceLife;
        List<PriceLife> materials = DbConnect.entObj.PriceLife.ToList();
        public ObservableCollection<PriceLife> material { get; set; }
        public PagePriceLife()
        {
            InitializeComponent();

            allItems = DbConnect.entObj.PriceLife.ToList();

            try
            {
                CmbFilter.ItemsSource = DbConnect.entObj.KatPlat.ToList();
                CmbFilter.DisplayMemberPath = "Name";
                CmbSort.SelectedIndex = 0;
                CmbFilter.SelectedIndex = 0;

                DgrPriceLife.ItemsSource = DbConnect.entObj.PriceLife.Take(100).ToList();
                TxbResult.Text = DgrPriceLife.Items.Count + "/" + DbConnect.entObj.PriceLife.Count().ToString();
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
                DgrPriceLife.ItemsSource = DbConnect.entObj.PriceLife.ToList();
            }
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            DgrPriceLife.ItemsSource = DbConnect.entObj.PriceLife
    .Where(x => x.Obshejit.ToString().Contains(TxbSearch.Text))
    .Take(15)
    .ToList();
            TxbResult.Text = DgrPriceLife.Items.Count + "/" + DbConnect.entObj.PriceLife
                .Where(x => x.Obshejit.ToString().Contains(TxbSearch.Text))
                .Count()
                .ToString();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbSort.SelectedIndex == 0)
            {
                List<PriceLife> sortMaterials = allItems.OrderBy(x => x.Obshejit).ToList();
                DgrPriceLife.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 1)
            {
                List<PriceLife> sortMaterials = allItems.OrderByDescending(x => x.Obshejit).ToList();
                DgrPriceLife.ItemsSource = sortMaterials;
            }
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbFilter.SelectedItem as DataBaseApp.PriceLife;
            var items = (select != null) ? allItems.Where(x => x.IdKatPlat == select.Id) : allItems;
            DgrPriceLife.ItemsSource = items;
        }

        private void DgrPriceLife_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPriceLife = (PriceLife)DgrPriceLife.SelectedItem;
        }

        private void DgrPriceLife_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            selectedPriceLife = (PriceLife)DgrPriceLife.SelectedItem;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            PageEditPriceLife editPage = new PageEditPriceLife(selectedPriceLife);
            FrameApp.frmObj.Navigate(editPage);
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Pages.PageAddPriceLife());
        }

        private void BtnDelitedStudent_Click(object sender, RoutedEventArgs e)
        {
            var recipeForRemoving = DgrPriceLife.SelectedItems.Cast<PriceLife>().ToList();

            try
            {
                var result = MessageBox.Show("Вы уверены?",
                            "Уведомление",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DbConnect.entObj.PriceLife.RemoveRange(recipeForRemoving);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Данные удалены.",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    DgrPriceLife.ItemsSource = DbConnect.entObj.PriceLife.ToList();
                }
                else
                {
                    DgrPriceLife.ItemsSource = DbConnect.entObj.PriceLife.ToList();
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
