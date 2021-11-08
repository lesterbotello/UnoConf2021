using System;
using System.Net.Mail;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestableUnoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            PasswordContainer.Visibility = Visibility.Collapsed;
        }

        private void ValidateUserName_Click(object sender, RoutedEventArgs e)
        {
            if(!IsEmailValid(UsernameTextBox.Text))
            {
                ErrorMessage.Text = "Please enter a valid email address";
                PasswordContainer.Visibility = Visibility.Collapsed;
                return;
            }

            PasswordContainer.Visibility = Visibility.Visible;
            ErrorMessage.Text = string.Empty;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e) { }

        private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            ErrorMessage.Text = "";
        }

        private bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
