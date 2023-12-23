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
    /// Логика взаимодействия для Authoriz.xaml
    /// </summary>
    public partial class Authoriz : Page
    {
        public Authoriz()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = DbConnect.entObj.User.FirstOrDefault(x => x.Name == TxbLogin.Text && x.Password == PsbPassword.Password);

                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь не найден.",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            MessageBox.Show("Здравствуйте бухгалтер: " + userObj.Name,
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                            FrameApp.frmObj.Navigate(new Pages.ListStudents());
                            break;
                        case 2:
                            MessageBox.Show("Здравствуйте классный руководитель: " + userObj.Name,
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Information);
                            FrameApp.frmObj.Navigate(new Pages.ListStudents());
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(),
                                "Критический сбой работы приложения",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                throw;
            }
        }
    }
}
