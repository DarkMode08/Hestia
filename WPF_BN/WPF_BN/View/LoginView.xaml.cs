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
using System.Windows.Shapes;
using WPF_BN.ViewModels;

namespace WPF_BN.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed){
                DragMove();
            }
        }
        private void btnMinimize_click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnMaximize_click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized){
                this.WindowState = WindowState.Normal;
            }else{
                this.WindowState = WindowState.Maximized;
            }
        }
        private void btnClose_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void btnSignIn_click(object sender, RoutedEventArgs e)
        {
            string username = Email.Text;
            string password = Encrypt.GetSHA256(Password.Password.Trim());

            // Crear una instancia de ConnectDB para llamar al método ValidarLogin
            ConnetDB db = new ConnetDB();

            // Llamar a la función que valida el usuario
            if (db.ValidarLogin(username, password))
            {
                MessageBox.Show("Login exitoso");
                // Aquí puedes abrir la siguiente ventana o continuar con el flujo del sistema.
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }
        }
    }
}
