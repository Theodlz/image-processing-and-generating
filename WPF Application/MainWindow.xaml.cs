using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Microsoft.Win32;
using Probleme_Info;

namespace WPF_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string path { get; private set; }
        public int compteur { get; private set; }
        public int compteur2 { get; private set; }
        public int compteurQR { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            compteur = 0;
            compteur2 = 0;
            compteurQR = 0;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "./Images";
            openFileDialog.Filter = "Image bitmap (*.bmp)|*.bmp";
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imgDynamic.Source = new BitmapImage(fileUri);
                path = openFileDialog.FileName;
            }
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (this.path == null)
            { MessageBox.Show("Aucune image n'a été sélectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            {
                string fileSrc = Convert.ToString(imgDynamic.Source); //Accès au dossier de l'image
                string fileName = System.IO.Path.GetFileName(fileSrc); //Accès au nom de l'image
                path = "./Images/" + fileName; //Chemin d'accès à l'image
                BMP BobRoss = new BMP(path);
                BobRoss.BW();

                //Enregistrement de l'image sous une copie
                #region
                int k = 0;
                int i = 0;
                string name = "";
                while (fileName[i] != '.')
                {
                    name += fileName[i];
                    i++;
                }
                string nameTemp = "Images\\" + fileName;
                while (File.Exists(nameTemp))
                {
                    nameTemp = "Images\\" + fileName + k;
                    k++;
                }
                BobRoss.Save(name + k);
                #endregion

                //Affichage de l'image
                #region
                path = "./Images/" + name + k + ".bmp";
                string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + path; //Chemin d'accès à l'application
                Uri resourceUri = new Uri(basePath);
                imgDynamic.Source = new BitmapImage(resourceUri);
                #endregion
            }
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {

            if (this.path == null)
            { MessageBox.Show("Aucune image n'a été sélectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            {
                string fileSrc = Convert.ToString(imgDynamic.Source); //Accès au dossier de l'image
                string fileName = System.IO.Path.GetFileName(fileSrc); //Accès au nom de l'image
                string path = "./Images/" + fileName; //Chemin d'accès à l'image
                BMP BobRoss = new BMP(path);
                BobRoss.MirrorVertical();

                //Enregistrement de l'image sous une copie
                #region
                int k = 0;
                int i = 0;
                string name = "";
                while (fileName[i] != '.')
                {
                    name += fileName[i];
                    i++;
                }
                string nameTemp = "Images\\" + fileName;
                while (File.Exists(nameTemp))
                {
                    nameTemp = "Images\\" + fileName + k;
                    k++;
                }
                BobRoss.Save(name + k);
                #endregion

                //Affichage de l'image
                #region
                path = "./Images/" + name + k + ".bmp";
                string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + path; //Chemin d'accès à l'application
                Uri resourceUri = new Uri(basePath);
                imgDynamic.Source = new BitmapImage(resourceUri);
                #endregion
            }
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

            if (this.path == null)
            { MessageBox.Show("Aucune image n'a été sélectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            {
                string fileSrc = Convert.ToString(imgDynamic.Source); //Accès au dossier de l'image
                string fileName = System.IO.Path.GetFileName(fileSrc); //Accès au nom de l'image
                string path = "./Images/" + fileName; //Chemin d'accès à l'image
                BMP BobRoss = new BMP(path);
                BobRoss.MirrorHorizontal();

                //Enregistrement de l'image sous une copie
                #region
                int k = 0;
                int i = 0;
                string name = "";
                while (fileName[i] != '.')
                {
                    name += fileName[i];
                    i++;
                }
                string nameTemp = "Images\\" + fileName;
                while (File.Exists(nameTemp))
                {
                    nameTemp = "Images\\" + fileName + k;
                    k++;
                }
                BobRoss.Save(name + k);
                #endregion

                //Affichage de l'image
                #region
                path = "./Images/" + name + k + ".bmp";
                string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + path; //Chemin d'accès à l'application
                Uri resourceUri = new Uri(basePath);
                imgDynamic.Source = new BitmapImage(resourceUri);
                #endregion
            }
        }

        private void MenuItem_Click_5(object sender, RoutedEventArgs e)
        {
            if (this.path == null)
            { MessageBox.Show("Aucune image n'a été sélectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            {
                string fileSrc = Convert.ToString(imgDynamic.Source); //Accès au dossier de l'image
                string fileName = System.IO.Path.GetFileName(fileSrc); //Accès au nom de l'image
                string path = "./Images/" + fileName; //Chemin d'accès à l'image
                BMP BobRoss = new BMP(path);
                BMP histo = BobRoss.Histogramme();

                //Enregistrement de l'image sous une copie
                #region
                int k = 0;
                int i = 0;
                string name = "";
                fileName = "histo.bmp";
                while (fileName[i] != '.')
                {
                    name += fileName[i];
                    i++;
                }
                string nameTemp = "Images\\" + fileName;
                while (File.Exists(nameTemp))
                {
                    nameTemp = "Images\\" + fileName + k;
                    k++;
                }
                histo.Save(name + k);
                #endregion

                //Affichage de l'image
                #region
                path = "./Images/" + name + k + ".bmp";
                string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + path; //Chemin d'accès à l'application
                Uri resourceUri = new Uri(basePath);
                imgDynamic.Source = new BitmapImage(resourceUri);
                #endregion
            }
        }

        private void MenuItem_Click_6(object sender, RoutedEventArgs e)
        {
            if (this.path == null)
            { MessageBox.Show("Aucune image n'a été sélectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            {
                string fileSrc = Convert.ToString(imgDynamic.Source); //Accès au dossier de l'image
                string fileName = System.IO.Path.GetFileName(fileSrc); //Accès au nom de l'image
                path = "./Images/" + fileName; //Chemin d'accès à l'image
                BMP BobRoss = new BMP(path);
                BobRoss.Negatif();

                //Enregistrement de l'image sous une copie
                #region
                int k = 0;
                int i = 0;
                string name = "";
                while (fileName[i] != '.')
                {
                    name = name + fileName[i];
                    i++;
                }
                string nameTemp = "Images\\" + fileName;
                while (File.Exists(nameTemp))
                {
                    nameTemp = "Images\\" + fileName + k;
                    k++;
                }
                BobRoss.Save(name + k);
                #endregion

                //Affichage de l'image
                #region
                path = "./Images/" + name + k + ".bmp";
                string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + path; //Chemin d'accès à l'application
                Uri resourceUri = new Uri(basePath);
                imgDynamic.Source = new BitmapImage(resourceUri);
                #endregion
            }
        }

        private void MenuItem_Click_7(object sender, RoutedEventArgs e)

        {
            if (this.path == null)
            { MessageBox.Show("Aucune image n'a été sélectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            {
                if (Convert.ToString(txtEditor.Text) == "")
                { MessageBox.Show("Entrez un angle valide dans la texte box.", "Erreur de valeur d'angle", MessageBoxButton.OK, MessageBoxImage.Warning); }
                else
                {
                    if (Convert.ToInt32(txtEditor.Text) == 90 || Convert.ToInt32(txtEditor.Text) == 180 || Convert.ToInt32(txtEditor.Text) == 270)
                    {
                        int angle = Convert.ToInt32(txtEditor.Text);
                        string fileSrc = Convert.ToString(imgDynamic.Source); //Accès au dossier de l'image
                        string fileName = System.IO.Path.GetFileName(fileSrc); //Accès au nom de l'image
                        path = "./Images/" + fileName; //Chemin d'accès à l'image
                        BMP BobRoss = new BMP(path);
                        BobRoss.Rotation(angle);

                        //Enregistrement de l'image sous une copie
                        #region
                        int k = 0;
                        int i = 0;
                        string name = "";
                        while (fileName[i] != '.')
                        {
                            name = name + fileName[i];
                            i++;
                        }
                        string nameTemp = "Images\\" + fileName;
                        while (File.Exists(nameTemp))
                        {
                            nameTemp = "Images\\" + fileName + k;
                            k++;
                        }
                        BobRoss.Save(name + k);
                        #endregion

                        //Affichage de l'image
                        #region
                        path = "./Images/" + name + k + ".bmp";
                        string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + path; //Chemin d'accès à l'image
                        Uri resourceUri = new Uri(basePath);
                        imgDynamic.Source = new BitmapImage(resourceUri);
                        #endregion
                    }
                    else
                    {
                        double angle = Convert.ToDouble(txtEditor.Text);

                        string fileSrc = Convert.ToString(imgDynamic.Source); //Accès au dossier de l'image
                        string fileName = System.IO.Path.GetFileName(fileSrc); //Accès au nom de l'image
                        path = "./Images/" + fileName; //Chemin d'accès à l'image
                        BMP BobRoss = new BMP(path);
                        BobRoss.RotationTeta(angle);

                        //Enregistrement de l'image sous une copie
                        #region
                        int k = 0;
                        int i = 0;
                        string name = "";
                        while (fileName[i] != '.')
                        {
                            name = name + fileName[i];
                            i++;
                        }
                        string nameTemp = "Images\\" + fileName;
                        while (File.Exists(nameTemp))
                        {
                            nameTemp = "Images\\" + fileName + k;
                            k++;
                        }
                        BobRoss.Save(name + k);
                        #endregion

                        //Affichage de l'image
                        #region
                        path = "./Images/" + name + k + ".bmp";
                        string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + path; //Chemin d'accès à l'image
                        Uri resourceUri = new Uri(basePath);
                        imgDynamic.Source = new BitmapImage(resourceUri);
                        #endregion
                    }
                }
            }
        }

        private void MenuItem_Click_8(object sender, RoutedEventArgs e)
        {
            QRCODE QR;
            if (Convert.ToString(txtEditor.Text) != "")
            { QR = new QRCODE(txtEditor.Text); }
            else
            {
                MessageBox.Show("Vous n'avez pas écrit de texte.", "QRCode", MessageBoxButton.OK, MessageBoxImage.Warning);
                QR = new QRCODE("NULL");
            }
            QR.qrcode.Save("QRCode" + compteurQR);

            string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase); //Chemin d'accès à l'application
            path = basePath + "/Images/QRCode" + compteurQR + ".bmp"; //Chemin d'accès à l'image
            Uri resourceUri = new Uri(path);
            imgDynamic.Source = new BitmapImage(resourceUri);
            compteurQR++;
        }

        private void MenuItem_Click_9(object sender, RoutedEventArgs e)
        {
            if (this.path == null)
            { MessageBox.Show("Aucune image n'a été sélectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            {
                string fileSrc = Convert.ToString(imgDynamic.Source); //Accès au dossier de l'image
                string fileName = System.IO.Path.GetFileName(fileSrc); //Accès au nom de l'image
                string path = "./Images/" + fileName; //Chemin d'accès à l'image
                BMP BobRoss = new BMP(path);

                MessageBox.Show("Veuillez sélectionner l'image dans laquelle votre première image sera cachée", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                //img1 = image qu'on veut cacher

                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == true)
                {
                    Uri fileUri = new Uri(openFileDialog.FileName);
                    imgDynamic2.Source = new BitmapImage(fileUri);
                    string path2 = Convert.ToString(fileUri);
                    string fileName2 = System.IO.Path.GetFileName(path2);
                    BMP Cachette = new BMP("Images\\" + fileName2);
                    int k2 = 0;
                    int i2 = 0;
                    string name2 = "";
                    while (fileName2[i2] != '.')
                    {
                        name2 = name2 + fileName2[i2];
                        i2++;
                    }
                    string nameTemp2 = "Images\\" + fileName2;
                    while (File.Exists(nameTemp2))
                    {
                        nameTemp2 = "Images\\" + fileName + k2;
                        k2++;
                    }
                    Cachette.Save(name2 + k2); //Enregistrement d'une copie en cas d'image déjà existante avec le même nom


                    BMP img_caché = Cachette.Hide(BobRoss);

                    //Enregistrement de l'image sous une copie
                    #region
                    int k = 0;
                    int i = 0;
                    string name = "";
                    fileName = "img_cachée.bmp";
                    while (fileName[i] != '.')
                    {
                        name = name + fileName[i];
                        i++;
                    }
                    string nameTemp = "Images\\" + fileName;
                    while (File.Exists(nameTemp))
                    {
                        nameTemp = "Images\\" + fileName + k;
                        k++;
                    }
                    img_caché.Save(name + k);
                    #endregion

                    //Affichage de l'image
                    #region
                    path = "./Images/" + name + k + ".bmp";
                    string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + path; //Chemin d'accès à l'application
                    Uri resourceUri = new Uri(basePath);
                    imgDynamic2.Source = new BitmapImage(resourceUri);
                    #endregion
                }
            }
        }

        private void MenuItem_Click_10(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Choisir l'image à décoder", "Décodeur d'image", MessageBoxButton.OK, MessageBoxImage.Information);
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                imgDynamic.Source = new BitmapImage(fileUri);
                string path = Convert.ToString(fileUri);
                string fileName = System.IO.Path.GetFileName(path);
                BMP BobRoss = new BMP("Images\\" + fileName);


                BMP img_found = BobRoss.Find();

                //Enregistrement de l'image sous une copie
                #region
                int k = 0;
                int i = 0;
                string name = "";
                fileName = "img_retrouvée.bmp";
                while (fileName[i] != '.')
                {
                    name = name + fileName[i];
                    i++;
                }
                string nameTemp = "Images\\" + fileName;
                while (File.Exists(nameTemp))
                {
                    nameTemp = "Images\\" + fileName + k;
                    k++;
                }
                img_found.Save(name + k);
                #endregion

                //Affichage de l'image
                #region
                path = "./Images/" + name + k + ".bmp";
                string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + path; //Chemin d'accès à l'application
                Uri resourceUri = new Uri(basePath);
                imgDynamic2.Source = new BitmapImage(resourceUri);
                #endregion
            }
        }

        private void MenuItem_Click_11(object sender, RoutedEventArgs e)
        {
            if (this.path == null)
            { MessageBox.Show("Aucune image n'a été sélectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            {
                int filtre = 1;
                BoiteDialog b_dlg = new BoiteDialog();
                if (b_dlg.ShowDialog() == true)
                { filtre = b_dlg.Answer; }
                string fileSrc = Convert.ToString(imgDynamic.Source); //Accès au dossier de l'image
                string fileName = System.IO.Path.GetFileName(fileSrc); //Accès au nom de l'image
                string path = "./Images/" + fileName; //Chemin d'accès à l'image
                BMP BobRoss = new BMP(path);
                BobRoss.Filtre(filtre, 1);

                //Enregistrement de l'image sous une copie
                #region
                int k = 0;
                int i = 0;
                string name = "";
                while (fileName[i] != '.')
                {
                    name += fileName[i];
                    i++;
                }
                string nameTemp = "Images\\" + fileName;
                while (File.Exists(nameTemp))
                {
                    nameTemp = "Images\\" + fileName + k;
                    k++;
                }
                BobRoss.Save(name + k);
                #endregion

                //Affichage de l'image
                #region
                path = "./Images/" + name + k + ".bmp";
                string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + path; //Chemin d'accès à l'application
                Uri resourceUri = new Uri(basePath);
                imgDynamic.Source = new BitmapImage(resourceUri);
                #endregion

            }
        }

        private void MenuItem_Click_12(object sender, RoutedEventArgs e)
        {
            SubWindow sub = new SubWindow();
            double Zoom = 100;
            double ReValue = 0.02;
            double ImValue = 0.8;
            int itération_max = 50;
            double Rouge = 150;
            double Vert = 150;
            double Bleu = 100;

            

            bool négatif = false;
            int type = 4;

            if (sub.ShowDialog() == true)
            {
                ReValue = sub.ReValue;
                ImValue = sub.ImValue;
                Zoom = sub.Zoomx;
                itération_max = sub.Itération_max;
                Rouge = sub.Rouge;
                Vert = sub.Vert;
                Bleu = sub.Bleu;
                type = sub.Type;
                BMP fractal = new BMP(1400, 1920);
                fractal.EnsembleDeJulia(Zoom, itération_max, ReValue, ImValue, Rouge, Vert, Bleu, négatif, négatif, négatif, type);
                fractal.Save("Fractal" + compteur);
                string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase); //Chemin d'accès à l'application
                path = basePath + "/Images/Fractal" + compteur + ".bmp"; //Chemin d'accès à l'image
                Uri resourceUri = new Uri(path);
                Fractal.Source = new BitmapImage(resourceUri);
                compteur++;
             }
        }

        private void txtEditor_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click_13(object sender, RoutedEventArgs e)
        {
            Coloring mandelbrot = new Coloring();
            double Zoom = 100;
            int itération_max = 50;
            double Rouge = 150;
            double Vert = 150;
            double Bleu = 100;

            string fileSrc = Convert.ToString(imgDynamic.Source); //Accès au dossier de l'image
            string fileName = System.IO.Path.GetFileName(fileSrc); //Accès au nom de l'image
            path = "./Images/" + fileName; //Chemin d'accès à l'image

            bool négatif = false;
            int type = 4;

            if (mandelbrot.ShowDialog() == true)
            {
                Zoom = mandelbrot.Zoomx;
                itération_max = mandelbrot.Itération_max;
                Rouge = mandelbrot.Rouge;
                Vert = mandelbrot.Vert;
                Bleu = mandelbrot.Bleu;
                type = mandelbrot.Type;
                BMP fractal = new BMP(1400, 1920);
                fractal.Mandelbrot(Zoom, itération_max, Rouge, Vert, Bleu, négatif, négatif, négatif, type);
                fractal.Save("Mandelbrot" + compteur2);

                string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase); //Chemin d'accès à l'application
                path = basePath + "/Images/Mandelbrot" + compteur2 + ".bmp"; //Chemin d'accès à l'image
                Uri resourceUri = new Uri(path);
                Fractal.Source = new BitmapImage(resourceUri);
                compteur2++;
            }
        }

        private void MenuItem_Click_14(object sender, RoutedEventArgs e)
        {
            SubWindow sub = new SubWindow();
            double Zoom = 100;
            double ReValue = 0.02;
            double ImValue = 0.8;
            int itération_max = 50;
            double Rouge = 150;
            double Vert = 150;
            double Bleu = 100;

            bool négatif = false;
            int type = 4;

            if (sub.ShowDialog() == true)
            {
                double reValue = sub.ReValue;
                double imValue = sub.ImValue;
                //double reValue = 0.285;
                //double imValue = 0.01;
                Zoom = sub.Zoomx;
                itération_max = sub.Itération_max;
                Rouge = sub.Rouge;
                Vert = sub.Vert;
                Bleu = sub.Bleu;
                type = sub.Type;
                RGB black = new RGB(0, 0, 0);
                BMP fractal = new BMP(1400, 1920,black);
                fractal.OverSimplifiedJulia(Zoom, itération_max, reValue, imValue, Rouge, Vert, Bleu, false, false, false, type);
                fractal.Save("Fractal" + compteur);

                string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase); //Chemin d'accès à l'application
                path = basePath + "/Images/Fractal" + compteur + ".bmp"; //Chemin d'accès à l'image
                Uri resourceUri = new Uri(path);
                Fractal.Source = new BitmapImage(resourceUri);
                compteur++;
            }
        }

        private void MenuItem_Click_15(object sender, RoutedEventArgs e)
        {
            if(this.path ==null)
            { MessageBox.Show("Aucune image n'a été sélectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            {
                string fileSrc = Convert.ToString(imgDynamic.Source); //Accès au dossier de l'image
                string fileName = System.IO.Path.GetFileName(fileSrc); //Accès au nom de l'image
                string path = "./Images/" + fileName; //Chemin d'accès à l'image
                BMP QRCode = new BMP(path);
                QRCODE QR = new QRCODE(QRCode);
                txtBlock.Text = "Message décodé du QRCode : " + QR.message;
            }
        }

        private void MenuItem_Click_16(object sender, RoutedEventArgs e)
        {
            if (this.path == null)
            { MessageBox.Show("Aucune image n'a été sélectionnée", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error); }
            else
            {
                TailleImage Modif_Taille = new TailleImage();
                int height = 1080;
                int width = 1920;
                if (Modif_Taille.ShowDialog() == true)
                {
                    height = Modif_Taille.Hauteur;
                    width = Modif_Taille.Largeur;
                }
                string fileSrc = Convert.ToString(imgDynamic.Source); //Accès au dossier de l'image
                string fileName = System.IO.Path.GetFileName(fileSrc); //Accès au nom de l'image
                string path = "./Images/" + fileName; //Chemin d'accès à l'image
                BMP Image = new BMP(path);
                Image.Resize(height, width);

                //Enregistrement de l'image sous une copie
                #region
                int k = 0;
                int i = 0;
                string name = "";
                while (fileName[i] != '.')
                {
                    name += fileName[i];
                    i++;
                }
                string nameTemp = "Images\\" + fileName;
                while (File.Exists(nameTemp))
                {
                    nameTemp = "Images\\" + fileName + k;
                    k++;
                }
                Image.Save(name + k);
                #endregion

                //Affichage de l'image
                #region
                path = "./Images/" + name + k + ".bmp";
                string basePath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + path; //Chemin d'accès à l'application
                Uri resourceUri = new Uri(basePath);
                imgDynamic.Source = new BitmapImage(resourceUri);
                #endregion
            }
        }
    }
}
