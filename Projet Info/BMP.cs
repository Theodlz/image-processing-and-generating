using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
//using System.Drawings;
//using System.Drawing.Imaging;


namespace Probleme_Info
{
    /// <summary>
    /// Classe image BMP
    /// </summary>
    public class BMP
    {
        /// <summary>
        /// Largeur de l'image
        /// </summary>
        public int imageWidth { get; private set; }
        /// <summary>
        /// Hauteur de l'image
        /// </summary>
        public int imageHeight { get; private set; }
        private int bpp;
        private int totalColors;
        /// <summary>
        /// Matrice de pixel RGB = Image couleur
        /// </summary>
        public RGB[,] imageRGB { get; private set; }

        //Constructeurs

        /// <summary>
        /// Constructeur qui lit une image format BMP
        /// </summary>
        /// <param name="path"> che min d'accès de l'image</param>
        public BMP(string path)
        {
            byte[] bmpFile = File.ReadAllBytes(path);

            this.imageWidth = Convert.ToInt32(EndianToInt(bmpFile, 21, 18));

            this.imageHeight = Convert.ToInt32(EndianToInt(bmpFile, 25, 22));

            this.bpp = Convert.ToInt32(EndianToInt(bmpFile, 29, 28));

            this.totalColors = Convert.ToInt32(EndianToInt(bmpFile, 49, 46));

            int padding = 0;

            if ((((bpp / 8) * imageWidth) % 4) != 0)
                padding = 4 - (((bpp / 8) * imageWidth) % 4);

            RGB[,] img = new RGB[imageHeight, imageWidth];
            int k = bmpFile.Length - 1;
            for (int i = 0; i < img.GetLength(0); i++)
            {
                k -= padding;
                for (int j = img.GetLength(1) - 1; j >= 0; j--)
                {

                    img[i, j] = new RGB(bmpFile[k], bmpFile[k - 1], bmpFile[k - 2]);
                    k -= bpp / 8;
                }

            }
            this.imageRGB = img;


        }

        /// <summary>
        /// Constructeur qui permet la création d'une image pour laquelle chaque pixel possède la même couleur RGB (image couleur unie)
        /// </summary>
        /// <param name="height"> hauteur de l'image souhaitée</param>
        /// <param name="width"> largeur de l'image souhaitée</param>
        /// <param name="rgb"> couleur RGB de chaque pixel</param>
        public BMP(int height, int width, RGB rgb)
        {
            this.bpp = 24;
            this.imageHeight = height;
            this.imageWidth = width;
            this.totalColors = 0;
            this.imageRGB = new RGB[height, width];
            Fill(imageRGB, rgb);

        }

        /// <summary>
        /// Constructeur qui permet la création d'une image noire de taille choisie
        /// </summary>
        /// <param name="height"> hauteur de l'image souhaitée</param>
        /// <param name="width"> largeur de l'image souhaitée</param>
        public BMP(int height, int width)
        {
            this.bpp = 24;
            this.imageHeight = height;
            this.imageWidth = width;
            this.totalColors = 0;
            this.imageRGB = new RGB[height, width];
            RGB color = new RGB(0, 0, 0);
            Fill(imageRGB, color);
        }

        /// <summary>
        /// Constructeur qui dessine un QR Code
        /// </summary>
        /// <param name="qr">matrice de byte contenant les infos du qr code à dessiner</param>
        public BMP(byte[,] qr)
        {
            RGB black = new RGB(0, 0, 0);
            RGB white = new RGB(255, 255, 255);
            this.bpp = 24;
            this.imageHeight = qr.GetLength(0);
            this.imageWidth = qr.GetLength(1);
            this.totalColors = 0;
            this.imageRGB = new RGB[qr.GetLength(0), qr.GetLength(1)];
            for (int i = 0; i < imageHeight; i++)
            {
                for (int j = 0; j < imageWidth; j++)
                {
                    if (qr[i, j] == 0)
                        imageRGB[i, j] = white;
                    else
                        imageRGB[i, j] = black;
                }
            }

        }

        /// <summary>
        /// Création d'un string contenant les infos principales à propos de l'image
        /// </summary>
        /// <returns> return la chaîne d'infos</returns>
        public override string ToString()
        {
            string chaine = "Largeur : " + imageWidth + " ; Hauteur : " + imageHeight + " ; bpp : " + bpp + " ; totalColors : " + totalColors;
            return chaine;
        }

        /// <summary>
        /// Réalise un résumé des infos de chaque pixel composant l'image
        /// </summary>
        /// <returns>return le résumé de tous les pixels</returns>
        public string ShowBMP()
        {
            string chaine = "";
            for (int i = 0; i < imageRGB.GetLength(0); i++)
            {
                for (int j = 0; j < imageRGB.GetLength(1); j++)
                {
                    chaine += imageRGB[i, j].toString();
                }
                chaine += "\n";
            }
            return chaine;
        }

        /// <summary>
        /// Retourne les valeurs RGB du pixel placé aux coordonnées en entrée
        /// </summary>
        /// <param name="x"> coordonnée ligne</param>
        /// <param name="y"> coordonnée colonne</param>
        /// <returns></returns>
        public RGB GetPixel(int x, int y)
        {
            return imageRGB[x, y];
        }

        /// <summary>
        /// Set les valeurs RGB du pixel placé aux coordonnées en entrée
        /// </summary>
        /// <param name="x"> coordonnée ligne</param>
        /// <param name="y"> coordonnée colonne</param>
        /// <param name="color"> couleur RGB</param>
        public void SetPixel(int x, int y, RGB color)
        {
            imageRGB[x, y] = color;
        }

        /// <summary>
        /// Set les valeurs RGB de tous les pixels de l'image en entrée
        /// </summary>
        /// <param name="img"> tableu de pixel RGB (image)</param>
        /// <param name="color"> couleur RGB</param>
        public void Fill(RGB[,] img, RGB color)
        {
            for (int i = 0; i < img.GetLength(0); i++)
            {
                for (int j = 0; j < img.GetLength(1); j++)
                {
                    img[i, j] = color;
                }
            }
        }

        /// <summary>
        /// Réalise le négatif de l'image en appliquant la fonction négatif à chaque pixel de  l'image
        /// </summary>
        public void Negatif()
        {
            for (int i = 0; i < imageRGB.GetLength(0); i++)
            {
                for (int j = 0; j < imageRGB.GetLength(1); j++)
                {
                    imageRGB[i, j].Negatif();
                }
            }
        }

        public void Brightness(double coef)
        {
            coef = Math.Abs(coef); //Mise à la valeur absolue car la fonction ne prend pas de coef négatif
            int valueMax = imageRGB[0, 0].rgb[0];
            for (int i = 0; i < imageRGB.GetLength(0); i++)
            {
                for (int j = 0; j < imageRGB.GetLength(1); j++)
                {
                    if (imageRGB[i, j].rgb[0] > valueMax)
                        valueMax = imageRGB[i, j].rgb[0];
                    if (imageRGB[i, j].rgb[1] > valueMax)
                        valueMax = imageRGB[i, j].rgb[1];
                    if (imageRGB[i, j].rgb[2] > valueMax)
                        valueMax = imageRGB[i, j].rgb[2];
                }
            }
            int coefBrightness = 1 + (1 - (valueMax / 255));
            if (coef > coefBrightness)
                coef = coefBrightness;
            for (int i = 0; i < imageRGB.GetLength(0); i++)
            {
                for (int j = 0; j < imageRGB.GetLength(1); j++)
                {
                    imageRGB[i, j].Brightness(coef);
                }
            }
        }

        /// <summary>
        /// Passe l'image en noir et blanc en appliquant la fonction bw, qui attribue une valeur de noir et blanc, à chaque pixel de l'image
        /// </summary>
        public void BW()
        {
            for (int i = 0; i < imageRGB.GetLength(0); i++)
            {
                for (int j = 0; j < imageRGB.GetLength(1); j++)
                {
                    imageRGB[i, j].BW();
                }
            }
        }

        /// <summary>
        /// Sauvegarde l'image avec le nom de fichier en paramètre
        /// </summary>
        /// <param name="fileName"> nom d'enregistrement du fichier</param>
        public void Save(string fileName)
        {
            string pathSave = "./Images/" + fileName + ".bmp";

            int tailleTab = 54;
            int padding = 0;
            //Pour l'instant on ne fait que le constructeur pour des bitmap sans palette 
            if ((((bpp / 8) * imageWidth) % 4) != 0)
                Math.DivRem(imageWidth, 4, out padding);
            Console.WriteLine(padding);
            tailleTab += (((imageWidth * 3) + padding) * imageHeight);
            Byte[] imgTab = new Byte[tailleTab];
            for (int i = 0; i < imgTab.Length; i++)
                imgTab[i] = 0;
            imgTab[0] = 66;  //File Type
            imgTab[1] = 77;  //File Type
            imgTab[10] = 54; //Pixel data offset
            imgTab[14] = 40; //Header size
            imgTab[26] = 1;  //planes
            imgTab[28] = 24; //bpp
            byte[] nb = IntToEndian(tailleTab);
            for (int i = 0; i < nb.Length; i++)
                imgTab[2 + i] = nb[i];
            nb = IntToEndian(imageWidth);
            for (int i = 0; i < nb.Length; i++)
                imgTab[18 + i] = nb[i];
            nb = IntToEndian(imageHeight);
            for (int i = 0; i < nb.Length; i++)
                imgTab[22 + i] = nb[i];
            nb = IntToEndian(imageHeight * imageWidth);
            for (int i = 0; i < nb.Length; i++)
                imgTab[34 + i] = nb[i];

            int k = 54;
            for (int i = imageRGB.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < imageRGB.GetLength(1); j++)
                {
                    //Passage de RGB en BGR 
                    imgTab[k + 2] = Convert.ToByte(imageRGB[i, j].rgb[0]);

                    imgTab[k + 1] = Convert.ToByte(imageRGB[i, j].rgb[1]);

                    imgTab[k] = Convert.ToByte(imageRGB[i, j].rgb[2]);

                    k += 3;
                }
                k += padding;
            }

            File.WriteAllBytes(pathSave, imgTab);


        }

        public byte[] IntToEndian(int nombre)
        {
            byte[] nb = new byte[4];
            int i = 0;
            while (nombre != 0 && i < 4)
            {
                int reste;
                int quotient = Math.DivRem(nombre, 256, out reste);
                nb[i] = Convert.ToByte(reste);
                nombre = quotient;
                i++;

            }
            return nb;
        }

        /// <summary>
        /// Convertit un tableau de byte (little endian) en int
        /// </summary>
        /// <param name="tab"> tableau de byte à convertir</param>
        /// <param name="highIndex"> index de départ des données à convertir</param>
        /// <param name="lowIndex"> index d'arrivée des données à convertir</param>
        /// <returns></returns>
        public int EndianToInt(byte[] tab, int highIndex, int lowIndex)
        {
            int compteur = highIndex - lowIndex;
            int nb = 0;
            for (int i = highIndex; i >= lowIndex; i--)
            {
                nb += Convert.ToInt32(tab[i] * (Math.Pow(256, compteur)));
                compteur--;
            }
            return nb;
        }

        /// <summary>
        /// Convertit un int en byte
        /// </summary>
        /// <param name="nombre"> int à convertir</param>
        /// <returns> return la conversion du nombre sous forme d'un tableau de byte  </returns>
        public int[] IntToBinary(int nombre)
        {
            int[] nb = new int[8];
            int i = 0;
            while (nombre != 0 && i < 8)
            {
                int reste;
                int quotient = Math.DivRem(nombre, 2, out reste);
                nb[7 - i] = Convert.ToInt32(reste);
                nombre = quotient;
                i++;

            }
            return nb;
        }


        public int BinaryToInt(int[] tab)
        {
            int compteur = 7;
            int nb = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                nb += Convert.ToInt32(tab[i] * (Math.Pow(2, compteur)));
                compteur--;
            }
            return nb;
        }

        /// <summary>
        /// Réalise le miroir vertical de l'image
        /// </summary>
        public void MirrorVertical()

        {
            RGB RGBtemp = new RGB(0, 0, 0);
            for (int i = 0; i < imageRGB.GetLength(0); i++)
            {
                for (int j = 0; j < (imageRGB.GetLength(1) / 2); j++)
                {
                    RGBtemp = imageRGB[i, j];
                    imageRGB[i, j] = imageRGB[i, imageRGB.GetLength(1) - 1 - j];
                    imageRGB[i, imageRGB.GetLength(1) - 1 - j] = RGBtemp;

                }
            }
        }

        /// <summary>
        /// Réalise le miroir horizontal de l'image
        /// </summary>
        public void MirrorHorizontal()

        {
            RGB RGBtemp = new RGB(0, 0, 0);
            for (int i = 0; i < (imageRGB.GetLength(0) / 2); i++)
            {
                for (int j = 0; j < imageRGB.GetLength(1); j++)
                {
                    RGBtemp = imageRGB[i, j];
                    imageRGB[i, j] = imageRGB[imageRGB.GetLength(0) - 1 - i, j];
                    imageRGB[imageRGB.GetLength(0) - 1 - i, j] = RGBtemp;
                }
            }
        }

        /// <summary>
        /// Réalise la rotation d'une image pour un angle de 90, 180 ou 270 degré
        /// </summary>
        /// <param name="degre"> angle de rotation parmi 90/180/270</param>
        public void Rotation(double degre)
        {
            //Rotation d'angle : 90, 180 ou 270
            switch (degre)
            {

                case 90:
                    RGB[,] imgTemp = new RGB[imageRGB.GetLength(1), imageRGB.GetLength(0)];
                    for (int i = 0; i < imageRGB.GetLength(0); i++)
                    {
                        for (int j = 0; j < (imageRGB.GetLength(1)); j++)
                        {
                            imgTemp[j, imgTemp.GetLength(1) - 1 - i] = imageRGB[i, j];
                        }
                    }
                    this.imageRGB = imgTemp;
                    this.imageHeight = imgTemp.GetLength(0);
                    this.imageWidth = imgTemp.GetLength(1);


                    break;
                case 180:
                    RGB[,] imgTemp1 = new RGB[imageRGB.GetLength(0), imageRGB.GetLength(1)];
                    for (int i = 0; i < imageRGB.GetLength(0); i++)
                    {
                        for (int j = 0; j < (imageRGB.GetLength(1)); j++)
                        {
                            imgTemp1[imgTemp1.GetLength(0) - 1 - i, imgTemp1.GetLength(1) - 1 - j] = imageRGB[i, j];
                        }
                    }
                    this.imageRGB = imgTemp1;
                    this.imageHeight = imgTemp1.GetLength(0);
                    this.imageWidth = imgTemp1.GetLength(1);

                    break;
                case 270:
                    RGB[,] imgTemp2 = new RGB[imageRGB.GetLength(1), imageRGB.GetLength(0)];
                    for (int i = 0; i < imageRGB.GetLength(0); i++)
                    {
                        for (int j = 0; j < (imageRGB.GetLength(1)); j++)
                        {
                            imgTemp2[imgTemp2.GetLength(0) - 1 - j, i] = imageRGB[i, j];
                        }
                    }
                    this.imageRGB = imgTemp2;
                    this.imageHeight = imgTemp2.GetLength(0);
                    this.imageWidth = imgTemp2.GetLength(1);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Choix du filtre de convolutiom
        /// </summary>
        /// <param name="choix"> numero correspondant a un filtre de convolution choisi / filtre</param>

        public double[,] ChoixFiltre(int choix)
        {
            switch (choix)
            {
                case 1:
                    //identite
                    double[,] id = { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
                    return id;
                    break;
                case 2:
                    //premiere matrice de detection des contours
                    double[,] contour1 = { { 1, 0, -1 }, { 0, 0, 0 }, { -1, 0, 1 } };
                    return contour1;
                    break;
                case 3:
                    //deuxieme matrice de detection des contours
                    double[,] contour2 = { { 0, 1, 0 }, { 1, -4, 1 }, { 0, 1, 0 } };
                    return contour2;
                    break;
                case 4:
                    //troisieme matrice de detectection des contours
                    double[,] contour3 = { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
                    return contour3;
                    break;
                case 5:
                    //matrice de nettete
                    double[,] net = { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
                    return net;
                    break;
                case 6:
                    //matrice de flou
                    double[,] boxblur = { { 1.0/9,1.0/9,1.0/9 }, { 1.0 / 9, 1.0 / 9, 1.0 / 9 }, { 1.0 / 9, 1.0 / 9, 1.0 / 9 } };
                    return boxblur;
                    break;
                case 7:
                    //matrice de flou gaussien 3x3
                    double[,] gaussblur3x3 = { { 1.0 / 16, 1.0 / 8, 1.0 / 16 }, { 1.0 / 8, 1.0 / 4, 1.0 / 8 }, { 1.0 / 16, 1.0 / 8, 1.0 / 16 } };
                    return gaussblur3x3;
                    break;
                case 8:
                    //matrice de flou gaussien 5x5
                    double[,] gaussblur5x5 = { { 1, 4, 6, 4, 1 }, { 4, 16, 24, 16, 4 }, { 6, 24, -476, 24, 6 }, { 4, 16, 24, 16, 4 }, { 1, 4, 6, 4, 1 } };
                    for (int i = 0; i < gaussblur5x5.GetLength(0); i++)
                        for (int j = 0; j < gaussblur5x5.GetLength(1); j++)
                            gaussblur5x5[i, j] = (-1.0 / 256) * gaussblur5x5[i, j];
                    return gaussblur5x5;
                    break;
                default:
                    //matrice identite par defaut comme le cas 1
                    double[,] idbydefault = { { 0, 0, 0 }, { 0, 1, 0 }, { 0, 0, 0 } };
                    return idbydefault;
                    break;
            }
        }

        /// <summary>
        /// Application du filtre (matrice de convolution) entré en paramètre sur l'image
        /// </summary>
        /// <param name="choix"> choix de la matrice de convolution / filtre parmi une sélection</param>
        /// <param name="pas"></param>

        public void Filtre2(int choix, int pas)
        {
            double[,] conv = ChoixFiltre(choix);
            RGB[,] img_temp = new RGB[imageRGB.GetLength(0) / pas, imageRGB.GetLength(1) / pas];
            //Parcours de l'image
            int i2 = 0;
            for (int i = 0; i < imageRGB.GetLength(0); i += pas)
            {
                int j2 = 0;
                for (int j = 0; j < imageRGB.GetLength(1); j += pas)
                {
                    int i_temp;
                    int j_temp;
                    if (conv.GetLength(0) % 2 == 0)
                    {
                        i_temp = i - (conv.GetLength(0) / 2) + 1;
                        j_temp = j - (conv.GetLength(1) / 2) + 1;
                    }
                    else
                    {
                        i_temp = i - (Math.DivRem(conv.GetLength(0), 2, out int reste));
                        j_temp = j - (Math.DivRem(conv.GetLength(1), 2, out reste));
                    }

                    double R = 0;
                    double G = 0;
                    double B = 0;
                    double FP = 0; //Facteur de normalisation positif
                    double FN = 0; //Facteur de normalisation négatif

                    //Parcours de la matrice de convolution
                    for (int k = 0; k < conv.GetLength(0); k++)
                    {
                        for (int l = 0; l < conv.GetLength(1); l++)
                        {
                            //Vérification des index
                            if (i_temp >= 0 && j_temp >= 0 && i_temp < imageRGB.GetLength(0) && j_temp < imageRGB.GetLength(1))
                            {
                                R += conv[k, l] * imageRGB[i_temp, j_temp].rgb[0];
                                G += conv[k, l] * imageRGB[i_temp, j_temp].rgb[1];
                                B += conv[k, l] * imageRGB[i_temp, j_temp].rgb[2];
                                if (conv[k, l] > 0)
                                    FP += conv[k, l];
                                else
                                    FN += conv[k, l];
                            }
                            j_temp++;
                        }
                        j_temp = j - (Math.DivRem(conv.GetLength(1), 2, out int reste));
                        i_temp++;
                    }
                    //Normalisation
                    double F = Math.Max(FP, Math.Abs(FN)); //Facteur de normalisation maximal
                    if (F > 0)
                    {
                        R = Math.Abs(R / F);
                        G = Math.Abs(G / F);
                        B = Math.Abs(B / F);
                    }
                    if (i2 >= 0 && i2 < img_temp.GetLength(0) && j2 >= 0 && j2 < img_temp.GetLength(1))
                        img_temp[i2, j2] = new RGB(Convert.ToInt16(R), Convert.ToInt16(G), Convert.ToInt16(B));
                    j2++;
                }
                i2++;
            }
            this.imageRGB = img_temp;
            this.imageHeight = imageRGB.GetLength(0);
            this.imageWidth = imageRGB.GetLength(1);
        }
        /// <summary>
        /// 2e version de l'Application du filtre (matrice de convolution) entré en paramètre sur l'image
        ///  Cette version est celle utilisee dans le WPF, sa normalisation a ete modifiee
        /// </summary>
        /// <param name="choix"> choix de la matrice de convolution / filtre parmi une sélection</param>
        /// <param name="pas"></param>
        public void Filtre(int choix, int pas)
        {
            double[,] conv = ChoixFiltre(choix);
            RGB[,] img_temp = new RGB[imageRGB.GetLength(0) / pas, imageRGB.GetLength(1) / pas];
            //Parcours de l'image
            int i2 = 0;
            double FPR = 0;
            double FNR = 0;
            double FPG = 0;
            double FNG = 0;
            double FPB = 0;
            double FNB = 0;
            for (int i = 0; i < imageRGB.GetLength(0); i += pas)
            {
                int j2 = 0;
                for (int j = 0; j < imageRGB.GetLength(1); j += pas)
                {
                    int i_temp;
                    int j_temp;
                    if (conv.GetLength(0) % 2 == 0)
                    {
                        i_temp = i - (conv.GetLength(0) / 2) + 1;
                        j_temp = j - (conv.GetLength(1) / 2) + 1;
                    }
                    else
                    {
                        i_temp = i - (Math.DivRem(conv.GetLength(0), 2, out int reste));
                        j_temp = j - (Math.DivRem(conv.GetLength(1), 2, out reste));
                    }

                    double R = 0;
                    double G = 0;
                    double B = 0;


                    //Parcours de la matrice de convolution
                    for (int k = 0; k < conv.GetLength(0); k++)
                    {
                        for (int l = 0; l < conv.GetLength(1); l++)
                        {
                            //Vérification des index
                            if (i_temp >= 0 && j_temp >= 0 && i_temp < imageRGB.GetLength(0) && j_temp < imageRGB.GetLength(1))
                            {
                                R += conv[k, l] * imageRGB[i_temp, j_temp].rgb[0];
                                G += conv[k, l] * imageRGB[i_temp, j_temp].rgb[1];
                                B += conv[k, l] * imageRGB[i_temp, j_temp].rgb[2];

                            }
                            j_temp++;
                        }
                        j_temp = j - (Math.DivRem(conv.GetLength(1), 2, out int reste));
                        i_temp++;

                    }
                    if (R > FPR)
                    {
                        FPR = R;
                    }


                    if (R < FNR)
                    {
                        FNR = R;
                    }


                    if (G > FPG)
                    {
                        FPG = G;
                    }


                    if (G < FNG)
                    {
                        FNG = G;
                    }


                    if (B > FPB)
                    {
                        FPB = B;
                    }


                    if (B < FNB)
                    {
                        FNB = B;
                    }

                    //Normalisation                    
                    img_temp[i2, j2] = new RGB(Convert.ToInt32(R), Convert.ToInt32(G), Convert.ToInt32(B));
                    j2++;
                }
                i2++;
            }

            double maxFP = Math.Max(FPR, Math.Max(FPG, FPB));
            double minFN = Math.Min(FNR, Math.Min(FNG, FNB));


            for (int m = 0; m < img_temp.GetLength(0); m++)
            {
                for (int n = 0; n < img_temp.GetLength(1); n++)
                {
                    if (img_temp[m, n].rgb[0] >= 0)
                        img_temp[m, n].rgb[0] = Convert.ToInt16(Math.Abs(img_temp[m, n].rgb[0] / (maxFP / 255.0)));
                    else
                        img_temp[m, n].rgb[0] = Convert.ToInt16(Math.Abs(img_temp[m, n].rgb[0] / (minFN / 255.0)));

                    if (img_temp[m, n].rgb[1] >= 0)
                        img_temp[m, n].rgb[1] = Convert.ToInt16(Math.Abs(img_temp[m, n].rgb[1] / (maxFP / 255.0)));
                    else
                        img_temp[m, n].rgb[1] = Convert.ToInt16(Math.Abs(img_temp[m, n].rgb[1] / (minFN / 255.0)));

                    if (img_temp[m, n].rgb[2] >= 0)
                        img_temp[m, n].rgb[2] = Convert.ToInt16(Math.Abs(img_temp[m, n].rgb[2] / (maxFP / 255.0)));
                    else
                        img_temp[m, n].rgb[2] = Convert.ToInt16(Math.Abs(img_temp[m, n].rgb[2] / (minFN / 255.0)));

                    if (img_temp[m, n].rgb[0] > 255)
                        img_temp[m, n].rgb[0] = 255;
                    if (img_temp[m, n].rgb[1] > 255)
                        img_temp[m, n].rgb[1] = 255;
                    if (img_temp[m, n].rgb[2] > 255)
                        img_temp[m, n].rgb[2] = 255;

                }
            }
            this.imageRGB = img_temp;
            this.imageHeight = imageRGB.GetLength(0);
            this.imageWidth = imageRGB.GetLength(1);
        }
        /// <summary>
        /// Réalise la fusion de deux courbes pour la fonction Histogramme
        /// </summary>
        /// <param name="img1"></param>
        public void MergeHist(BMP img1)
        {

            for (int i = 0; i < img1.imageHeight; i++)
            {
                for (int j = 0; j < img1.imageWidth; j++)
                {
                    if ((img1.imageRGB[i, j].rgb[0] == 0) && (img1.imageRGB[i, j].rgb[1] == 255) && (img1.imageRGB[i, j].rgb[2] == 0))
                        imageRGB[i, j] = new RGB(0, 255, 0);
                    if ((img1.imageRGB[i, j].rgb[0] == 0) && (img1.imageRGB[i, j].rgb[1] == 0) && (img1.imageRGB[i, j].rgb[2] == 255))
                        imageRGB[i, j] = new RGB(0, 0, 255);
                }
            }
        }
        /// <summary>
        /// Réalise la fusion de deux images de même taille en prenant la moyenne de chaque pixel
        /// </summary>
        /// <param name="img1"></param>
        public void MergeMoyenne(BMP img1)
        {
            for (int i = 0; i < img1.imageHeight; i++)
            {
                for (int j = 0; j < img1.imageWidth; j++)
                {
                    double R = ((imageRGB[i, j].rgb[0]) + (img1.imageRGB[i, j].rgb[0])) / 2;
                    double G = ((imageRGB[i, j].rgb[1]) + (img1.imageRGB[i, j].rgb[1])) / 2;
                    double B = ((imageRGB[i, j].rgb[2]) + (img1.imageRGB[i, j].rgb[2])) / 2;
                    imageRGB[i, j] = new RGB(Convert.ToInt16(R), Convert.ToInt16(G), Convert.ToInt16(B));
                }
            }
        }

        /// <summary>
        /// Réalise la rotation d'une image pour un angle quelconque
        /// </summary>
        /// <param name="teta"> angle de rotation quelconque</param>
        public void RotationTeta(double teta)
        {
            //Pour chaque cas, on calcule la nouvelle taille de l'image pivotée 

            int width = imageWidth;
            int height = imageHeight;
            double tetaRad = teta * (Math.PI / 180);
            bool rot = true;
            if ((teta > 0 && teta < 90) || (teta > 180 && teta < 270))
            {
                width = Math.Abs(Convert.ToInt32((imageWidth * Math.Cos(tetaRad) + imageHeight * Math.Sin(tetaRad))));
                height = Math.Abs(Convert.ToInt32((imageWidth * Math.Sin(tetaRad) + imageHeight * Math.Cos(tetaRad))));
            }
            else
            {
                if ((teta > 90 && teta < 180) || (teta > 270 && teta < 360))
                {
                    tetaRad = tetaRad - Math.PI / 2;
                    width = Math.Abs(Convert.ToInt32((imageHeight * Math.Cos(tetaRad) + imageWidth * Math.Sin(tetaRad))));
                    height = Math.Abs(Convert.ToInt32((imageHeight * Math.Sin(tetaRad) + imageWidth * Math.Cos(tetaRad))));
                    if (teta > 270 && teta < 360)
                        MirrorHorizontal();
                }
                else
                {
                    //Si l'angle est 90, 180 ou 270, on appelle la fonction rotation qui permet de faire une rotation sur ces angles

                    Rotation(Convert.ToInt32(teta));
                    rot = false;
                }
            }
            teta = teta * (Math.PI / 180);
            if (rot == true)
            {
                RGB[,] img_temp = new RGB[height, width];
                RGB black = new RGB(0, 0, 0);
                Fill(img_temp, black);

                for (int k = 0; k < img_temp.GetLength(0); k++)
                {
                    for (int l = 0; l < img_temp.GetLength(1); l++)
                    {
                        int i = Convert.ToInt32(Math.Round((img_temp.GetLength(0) / 2) - (img_temp.GetLength(0) - imageRGB.GetLength(0)) / 2 + Math.Cos(teta) * (k - (img_temp.GetLength(0) / 2)) - Math.Sin(teta) * (l - (img_temp.GetLength(1) / 2))));
                        int j = Convert.ToInt32(Math.Round((img_temp.GetLength(1) / 2) - (img_temp.GetLength(1) - imageRGB.GetLength(1)) / 2 + Math.Sin(teta) * (k - (img_temp.GetLength(0) / 2)) + Math.Cos(teta) * (l - (img_temp.GetLength(1) / 2))));
                        if (i >= 0 && i < imageRGB.GetLength(0) && j >= 0 && j < imageRGB.GetLength(1))
                            img_temp[k, l] = imageRGB[i, j];
                    }
                }
                this.imageWidth = width;
                this.imageHeight = height;
                this.imageRGB = img_temp;
            }
        }

        /// <summary>
        /// Fractale ensemble de Mandelbrot
        /// </summary>
        public void Mandelbrot(double zoom, int itération_max, double redValue, double greenValue, double blueValue, bool redN, bool greenN, bool blueN, int type = 0)
        {           
            int height = imageHeight;
            int width = imageWidth;

            for (int i = -height / 2; i < height / 2; i++)
            {
                for (int j = -width / 2; j < width / 2; j++)
                {
                    Complexe c = new Complexe(i / (zoom), j / (zoom));
                    Complexe z = new Complexe(0, 0);
                    int compteurItérations = 0;

                    while (compteurItérations < itération_max && z.mod() < 2)
                    {
                        z = Complexe.add(z.carré(), c);
                        compteurItérations++;
                    }
                    //ici je calcule juste les index d'arrivees, mais j'aurais tres bien pu juste add apres la hauteur ou largueur divisee par 2 
                    int indexi = i + (height / 2);
                    int indexj = j + (width / 2);
                    imageRGB[indexi, indexj] = RGB.FractaleColoring(compteurItérations, itération_max, z, i, j, height, width, redValue, greenValue, blueValue, redN, greenN, blueN, type);

                }
            }
        }

        public void FractalTest()
        {

            double zoom = 400;
            int itération_max = 2500;
            int height = imageHeight;
            int width = imageWidth;

            for (int i = -height / 2; i < height / 2; i++)
            {
                for (int j = -width / 2; j < width / 2; j++)
                {
                    Complexe c = new Complexe(i / (zoom), j / (zoom));
                    Complexe z = new Complexe(0, 0);
                    Complexe z2 = new Complexe(0, 0);
                    Complexe delta = new Complexe(-1.401155, 0);
                    int compteurItérations = 0;

                    while (compteurItérations < itération_max && z2.mod() < 2)
                    {
                        z = Complexe.add(z.carré(), c.carré().carré());
                        z2 = Complexe.add(z, delta);
                        compteurItérations++;

                    }
                    int indexi = i + (height / 2);
                    int indexj = j + (width / 2);
                    if (compteurItérations == itération_max)
                    {
                        imageRGB[indexi, indexj] = new RGB(Math.Abs((2 * height / 3 - Math.Abs(i + j))) * 255 / height, Convert.ToInt32((height - Math.Abs(i) * 2) * 255 / height), Convert.ToInt32((height - Math.Abs(j) * 2) * 255 / height));
                    }
                }
            }
        }

        /// <summary>
        /// Fractale ensemble de Julia
        /// </summary>
        public void EnsembleDeJulia(double zoom, int itération_max, double ReValue, double ImValue, double redValue,double greenValue, double blueValue,bool redN,bool greenN,bool blueN,int type=0)
        {
            //int itération_max = 50;
            int height = imageHeight;
            int width = imageWidth;

            for (int i = -height / 2; i < height / 2; i++)
            {
                for (int j = -width / 2; j < width / 2; j++)
                {
                    Complexe c = new Complexe(ReValue, ImValue);
                    Complexe z = new Complexe(i / (zoom), j / (zoom));
                    int compteurItérations = 0;

                    while (compteurItérations < itération_max && z.mod() < 2)
                    {
                        z = Complexe.add(z.carré(), c);
                        compteurItérations++;
                    }
                    int indexi = i + (height / 2);
                    int indexj = j + (width / 2);
                    imageRGB[indexi, indexj] = RGB.FractaleColoring(compteurItérations, itération_max, z,i,j,height,width, redValue, greenValue, blueValue, redN,greenN,blueN,type);
                }
            }
        }

        /// <summary>
        /// Fractale ensemble de Julia version 2
        /// </summary>
        public void EnsembleDeJulia2()
        {

            double zoom = 5000;
            int itération_max = 1500;
            int height = imageHeight;
            int width = imageWidth;

            for (int i = -height / 2; i < height / 2; i++)
            {
                for (int j = -width / 2; j < width / 2; j++)
                {
                    Complexe c = new Complexe(-1.476, 0);
                    Complexe z = new Complexe(i / (zoom), j / (zoom));
                    int compteurItérations = 0;

                    while (compteurItérations < itération_max && z.mod() < 2)
                    {
                        z = Complexe.add(z.carré(), c);
                        compteurItérations++;
                    }
                    int indexi = i + (height / 2);
                    int indexj = j + (width / 2);
                    if (compteurItérations == itération_max)
                        imageRGB[indexi, indexj] = new RGB(Convert.ToInt32((height - Math.Abs(j) * 2) * 255 / height), Math.Abs((2 * height / 3 - Math.Abs(i + j))) * 255 / height, Convert.ToInt32((height - Math.Abs(i) * 2) * 255 / height));
                }
            }
        }

        /// <summary>
        /// Une version simplifiée et artistique des ensembles de Julia avec un coloring particulier, c'est une innovation artistique selon nous
        /// </summary>
        public void OverSimplifiedJulia(double zoom, int itération_max, double ReValue, double ImValue, double redValue, double greenValue, double blueValue, bool redN, bool greenN, bool blueN, int type = 0)
        {
            zoom = 2.0*zoom;
            
            int height = imageHeight;
            int width = imageWidth;

            for (int i = -height / 2; i < height / 2; i++)
            {
                for (int j = -width / 2; j < width / 2; j++)
                {
                    Complexe c = new Complexe(ReValue, ImValue);
                    Complexe z = new Complexe(i / (zoom), j / (zoom));
                    int compteurItérations = 0;

                    while (compteurItérations < itération_max && z.mod() < 0.80)
                    {
                        z = Complexe.add(z.carré(), c);
                        compteurItérations++;
                    }
                    int indexi = i + (height / 2);
                    int indexj = j + (width / 2);
                    imageRGB[indexi, indexj] = RGB.FractaleColoringOSJ(compteurItérations, itération_max, z, i, j, height, width, redValue, greenValue, blueValue, redN, greenN, blueN, type);
                }

            
            }
        }

        /// <summary>
        /// Fractale Buddhabrot
        /// </summary>
        public void BuddhaBrot()
        {
            double zoom = 400;
            int itération_max = 250;
            int height = imageHeight;
            int width = imageWidth;

            for (int i = -height / 2; i < height / 2; i++)
            {
                for (int j = -width / 2; j < width / 2; j++)
                {
                    Complexe c = new Complexe(i / (zoom), j / (zoom));
                    Complexe z = new Complexe(0, 0);
                    Complexe z2 = new Complexe(0, 0);
                    int compteurItérations = 0;
                    while (compteurItérations < itération_max && z.mod() < 2)
                    {
                        z = Complexe.add(z.carré(), c);
                        compteurItérations++;
                    }
                    //ici je calcule juste les index d'arrivees, mais j'aurais tres bien pu juste add apres la hauteur ou largueur divisee par 2 
                    int indexi = i + (height / 2);
                    int indexj = j + (width / 2);
                    if (compteurItérations == itération_max)
                    {

                    }
                    else
                    {
                        int ite = 0;
                        while (ite <= compteurItérations)
                        {
                            z2 = Complexe.add(z.carré(), c);
                            int i2 = Convert.ToInt32((z2.Re * zoom) + (height / 2));
                            int j2 = Convert.ToInt32((z2.Im * zoom) + (height / 2));
                            ite++;
                            if (i2 >= 0 && i2 < imageRGB.GetLength(0) && j2 >= 0 && j2 < imageRGB.GetLength(0))
                            {
                                if (imageRGB[i, j].rgb[0] < 255)
                                {
                                    imageRGB[i, j] = new RGB(imageRGB[i, j].rgb[0] + 1, imageRGB[i, j].rgb[0] + 1, imageRGB[i, j].rgb[0] + 1);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Fractale triangle de Sierpinski (non fonctionnelle)
        /// </summary>
        /// <param name="xA"></param>
        /// <param name="yA"></param>
        /// <param name="xB"></param>
        /// <param name="yB"></param>
        /// <param name="xC"></param>
        /// <param name="yC"></param>
        /// <param name="n"></param>
        /// <returns>return la fractale du triangle de Sierpinski</returns>
        public RGB[,] TriangleDeSierpinski(int xA, int yA, int xB, int yB, int xC, int yC, int n)
        {
            if (n > 0)
            {
                int xE = (xA + xB) / 2;
                int yE = (yA + yB) / 2;
                int xF = (xC + xB) / 2;
                int yF = (yC + yB) / 2;
                int xG = (xA + xC) / 2;
                int yG = (yA + yC) / 2;
                int k = 0;
                for (int i = xG; i < xF; i++)
                {
                    for (int j = yG + k; j < yE - k; j++)
                    {
                        imageRGB[i, j] = new RGB(255, 255, 255);
                    }
                    k++;
                }

                TriangleDeSierpinski(xA, yA, xE, yE, xG, yG, n - 1);
                TriangleDeSierpinski(xE, yE, xB, yB, xF, yF, n - 1);
                TriangleDeSierpinski(xG, yG, xF, yF, xC, yC, n - 1);

            }
            return imageRGB;
        }

        /// <summary>
        /// Crée un histogramme
        /// </summary>
        /// <returns> return l'histogramme créé</returns>
        public BMP Histogramme()
        {
            int height = imageHeight;
            int width = imageWidth;
            double sommeRouge = 0;
            double sommeVert = 0;
            double sommeBleu = 0;
            Queue<double> valeursRouges = new Queue<double>();
            Queue<double> valeursVertes = new Queue<double>();
            Queue<double> valeursBleues = new Queue<double>();
            for (int j = 0; j < width; j++)
            {
                for (int i = 0; i < height; i++)
                {
                    sommeRouge += imageRGB[i, j].rgb[0];
                    sommeVert += imageRGB[i, j].rgb[1];
                    sommeBleu += imageRGB[i, j].rgb[2];
                }
                valeursRouges.Enqueue(sommeRouge / height);
                valeursVertes.Enqueue(sommeVert / height);
                valeursBleues.Enqueue(sommeBleu / height);
                sommeRouge = 0;
                sommeBleu = 0;
                sommeVert = 0;
            }
            RGB couleur = new RGB(255, 255, 255);
            BMP histogrammeR = new BMP(255, width, couleur);
            BMP histogrammeV = new BMP(255, width, couleur);
            BMP histogrammeB = new BMP(255, width, couleur);
            for (int i = 0; i < width; i++)
            {
                double r = valeursRouges.Dequeue();
                double v = valeursVertes.Dequeue();
                double b = valeursBleues.Dequeue();
                for (int j = Convert.ToInt32(255 - (r)); j < 255; j++)
                {
                    histogrammeR.imageRGB[j, i] = new RGB(255, 0, 0);
                }
                for (int j = Convert.ToInt32(255 - (v)); j < 255; j++)
                {
                    histogrammeV.imageRGB[j, i] = new RGB(0, 255, 0);
                }
                for (int j = Convert.ToInt32(255 - (b)); j < 255; j++)
                {
                    histogrammeB.imageRGB[j, i] = new RGB(0, 0, 255);
                }
            }
            histogrammeR.MergeMoyenne(histogrammeV);
            histogrammeR.MergeMoyenne(histogrammeB);
            return histogrammeR;
        }

        /// <summary>
        /// Cache l'image entrée en paramètre dans l'image
        /// </summary>
        /// <param name="img1"> image que l'on souhaite cacher</param>
        /// <returns> l'image cachée dans l'autre</returns>
        public BMP Hide(BMP img1)
        {
            BMP newImg = new BMP(imageHeight, imageWidth);
            for (int i = 0; i < imageHeight; i++)
            {
                for (int j = 0; j < imageWidth; j++)
                {
                    int[] Rimg = IntToBinary(imageRGB[i, j].rgb[0]);
                    int[] Rimg1 = IntToBinary(img1.imageRGB[i, j].rgb[0]);
                    int[] tab_temp0 = new int[8];
                    for (int l = 0; l < 8; l++)
                    {
                        if (l < 4)
                            tab_temp0[l] = Rimg[l];
                        else
                            tab_temp0[l] = Rimg1[l - 4];
                    }

                    int R = BinaryToInt(tab_temp0);

                    int[] Gimg = IntToBinary(imageRGB[i, j].rgb[1]);
                    int[] Gimg1 = IntToBinary(img1.imageRGB[i, j].rgb[1]);
                    int[] tab_temp1 = new int[8];
                    for (int l = 0; l < 8; l++)
                    {
                        if (l < 4)
                            tab_temp1[l] = Gimg[l];
                        else
                            tab_temp1[l] = Gimg1[l - 4];
                    }
                    int G = BinaryToInt(tab_temp1);
                    int[] Bimg = IntToBinary(imageRGB[i, j].rgb[2]);
                    int[] Bimg1 = IntToBinary(img1.imageRGB[i, j].rgb[2]);
                    int[] tab_temp2 = new int[8];
                    for (int l = 0; l < 8; l++)
                    {
                        if (l < 4)
                            tab_temp2[l] = Bimg[l];
                        else
                            tab_temp2[l] = Bimg1[l - 4];
                    }
                    int B = BinaryToInt(tab_temp2);
                    newImg.imageRGB[i, j] = new RGB(R, G, B);
                }
            }
            return newImg;
        }

        /// <summary>
        /// Permet de trouver une image cachée dans une autre
        /// </summary>
        /// <returns>return l'image retrouvée</returns>
        public BMP Find()
        {

            BMP foundImg = new BMP(imageHeight, imageWidth);
            for (int i = 0; i < imageHeight; i++)
            {
                for (int j = 0; j < imageWidth; j++)
                {
                    int[] Rimg = IntToBinary(imageRGB[i, j].rgb[0]);
                    int[] tab_temp0 = { 0, 0, 0, 0, 0, 0, 0, 0 };
                    for (int l = 0; l < 4; l++)
                    {
                        tab_temp0[l] = Rimg[l + 4];
                    }

                    int R = BinaryToInt(tab_temp0);

                    int[] Gimg = IntToBinary(imageRGB[i, j].rgb[1]);
                    int[] tab_temp1 = { 0, 0, 0, 0, 0, 0, 0, 0 };
                    for (int l = 0; l < 4; l++)
                    {
                        tab_temp1[l] = Gimg[l + 4];
                    }
                    int G = BinaryToInt(tab_temp1);

                    int[] Bimg = IntToBinary(imageRGB[i, j].rgb[2]);
                    int[] tab_temp2 = { 0, 0, 0, 0, 0, 0, 0, 0 };
                    for (int l = 0; l < 4; l++)
                    {
                        tab_temp2[l] = Bimg[l + 4];
                    }
                    int B = BinaryToInt(tab_temp2);
                    foundImg.imageRGB[i, j] = new RGB(R, G, B);
                }
            }
            return foundImg;
        }
        /// <summary>
        /// Permet de redimensionner une image a une taille inferieure ou superieure, mais il faut garder le meme ratio qu'au depart
        /// </summary>
        /// <returns>return l'image retrouvée</returns>
        public void Resize(int height, int width)
        {
            BMP temp = new BMP(height, width);
            double ratioHeight = Convert.ToDouble(imageHeight) / Convert.ToDouble(height);
            double ratioWidth = Convert.ToDouble(imageWidth) / Convert.ToDouble(width);
            if((width>imageWidth)&&(height>imageHeight))
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        int newI = Convert.ToInt16(Math.Floor((i * ratioHeight)));
                        int newJ = Convert.ToInt16(Math.Floor((j * ratioWidth)));
                        if (newI >= imageHeight)
                            newI = imageHeight - 1;
                        if (newJ >= imageWidth)
                            newJ = imageWidth - 1;
                        temp.imageRGB[i, j] = new RGB(imageRGB[newI, newJ].rgb[0], imageRGB[newI, newJ].rgb[1], imageRGB[newI, newJ].rgb[2]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        int newI = Convert.ToInt16(Math.Ceiling((i * ratioHeight)));
                        int newJ = Convert.ToInt16(Math.Ceiling((j * ratioWidth)));
                        if (newI >= imageHeight)
                            newI = imageHeight - 1;
                        if (newJ >= imageWidth)
                            newJ = imageWidth - 1;
                        temp.imageRGB[i, j] = new RGB(imageRGB[newI, newJ].rgb[0], imageRGB[newI, newJ].rgb[1], imageRGB[newI, newJ].rgb[2]);
                    }
                }
            }
            
            imageRGB = temp.imageRGB;
            imageHeight = height;
            imageWidth = width;
        }
    }
}

