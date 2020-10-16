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

namespace ReservTechLSRGames
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window1 Calendrier = new Window1();
        public MainWindow()
        {
            InitializeComponent();
            
            lbl_erreur.Foreground = Brushes.Red;
            lbl_erreur.Visibility = Visibility.Hidden;
        }

        private void btn_connexion_Click(object sender, RoutedEventArgs e)
        {
            if (txt_identifiant.Text=="")
            {
                lbl_erreur.Visibility = Visibility.Visible;
                lbl_erreur.Content = "Vous n'avez pas saisie un identifiant.";
            }
            if (pswbx_mot_de_passe.Password == "")
            {
                lbl_erreur.Visibility = Visibility.Visible;
                lbl_erreur.Content = "Vous n'avez pas saisie de mot de passe.";
            }
            if(txt_identifiant.Text == "" & pswbx_mot_de_passe.Password == "")
            {
                lbl_erreur.Visibility = Visibility.Visible;
                lbl_erreur.Content = "Vous avez saisie ni identifiant ni mot de passe.";
            }
            if(txt_identifiant.Text != "" & pswbx_mot_de_passe.Password != "")
            {
                Calendrier.Show();
                this.Hide();
            }
            
        }
    }
}
