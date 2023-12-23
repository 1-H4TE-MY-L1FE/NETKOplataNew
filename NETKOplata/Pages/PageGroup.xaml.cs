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
    /// Логика взаимодействия для PageGroup.xaml
    /// </summary>
    public partial class PageGroup : Page
    {
        private List<Group> allItems;
        private Group selectedGroup;
        List<Group> materials = DbConnect.entObj.Group.ToList();
        public ObservableCollection<Group> material { get; set; }
        public PageGroup()
        {
            InitializeComponent();

            allItems = DbConnect.entObj.Group.ToList();

            try
            {
                CmbFilter.ItemsSource = DbConnect.entObj.Group.ToList();
                CmbFilter.DisplayMemberPath = "Name";
                CmbSort.SelectedIndex = 0;
                CmbFilter.SelectedIndex = 0;

                DgrGroup.ItemsSource = DbConnect.entObj.Group.Take(100).ToList();
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
                DgrGroup.ItemsSource = DbConnect.entObj.Group.ToList();
            }
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CmbSort.SelectedIndex == 0)
            {
                List<Group> sortMaterials = allItems.OrderBy(x => x.Name).ToList();
                DgrGroup.ItemsSource = sortMaterials;
            }
            else if (CmbSort.SelectedIndex == 1)
            {
                List<Group> sortMaterials = allItems.OrderByDescending(x => x.Name).ToList();
                DgrGroup.ItemsSource = sortMaterials;
            }
        }

        private void CmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var select = CmbFilter.SelectedItem as Group;
            var items = (select != null) ? allItems.Where(x => x.Id == select.Id) : allItems;
            DgrGroup.ItemsSource = items;
        }

        private void DgrGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedGroup = (Group)DgrGroup.SelectedItem;
        }

        private void DgrGroup_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            selectedGroup = (Group)DgrGroup.SelectedItem;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            PageEditGroup editPage = new PageEditGroup(selectedGroup);
            FrameApp.frmObj.Navigate(editPage);
        }

        private void BtnAddGroup_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Pages.PageAddGroup());
        }

        private void BtnDelitedGroup_Click(object sender, RoutedEventArgs e)
        {
            var recipeForRemoving = DgrGroup.SelectedItems.Cast<Group>().ToList();

            try
            {
                var result = MessageBox.Show("Вы уверены?",
                            "Уведомление",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    DbConnect.entObj.Group.RemoveRange(recipeForRemoving);
                    DbConnect.entObj.SaveChanges();

                    MessageBox.Show("Данные удалены.",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);

                    DgrGroup.ItemsSource = DbConnect.entObj.Group.ToList();
                }
                else
                {
                    DgrGroup.ItemsSource = DbConnect.entObj.Group.ToList();
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
