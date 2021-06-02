using Probleme_Info;
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
    /// Logique d'interaction pour SubWindow.xaml
    /// </summary>
    public partial class SubWindow : Window
    {
        public SubWindow()
        {
            InitializeComponent();
        }
        public double ReValue
        { get { return Convert.ToDouble(Valeur_Réelle.Text); }}
        public double ImValue
        { get { return Convert.ToDouble(Valeur_Imaginaire.Text); } }
        public double Zoomx
        { get { return Convert.ToDouble(Zoom.Text); } }
        public int Itération_max
        { get { return Convert.ToInt32(Nbr_itérations.Text); } }
        public double Rouge
        { get { return Convert.ToDouble(Red.Text); } }
        public double Vert
        { get { return Convert.ToDouble(Green.Text); } }
        public double Bleu
        { get { return Convert.ToDouble(Blue.Text); } }
        public int Type
        { get { return Convert.ToInt32(type.Text); } }
        private void Terminer_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(type.Text) > 6 || Convert.ToInt32(type.Text) < 0)
            { MessageBox.Show("Le type doit être compris entre 0 et 6 inclus.", "Erreur de type", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            { this.DialogResult = true; }
        }

        private void Annuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
