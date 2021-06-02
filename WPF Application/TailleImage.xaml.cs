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

namespace WPF_Application
{
    /// <summary>
    /// Logique d'interaction pour TailleImage.xaml
    /// </summary>
    public partial class TailleImage : Window
    {
        public int Hauteur
        { get { return Convert.ToInt32(height.Text); } }
        public int Largeur
        { get { return Convert.ToInt32(width.Text); } }
        public TailleImage()
        {
            InitializeComponent();
        }
        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Terminer_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(Hauteur) < 1 || Convert.ToInt32(Hauteur) > 10000 || Convert.ToInt32(Largeur) < 1 || Convert.ToInt32(Largeur) > 10000)
            { MessageBox.Show("Les tailles choisies ne sont pas correctes.", "Erreur de taille", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            { this.DialogResult = true; }
        }
    }
}
