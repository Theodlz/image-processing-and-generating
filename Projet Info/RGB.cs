using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_Info
{
    public class RGB
    {
        /// <summary>
        /// Tableau contenant les valeurs RGB d'un pixel
        /// </summary>
        public int[] rgb { get; private set; }

        /// <summary>
        /// Constrcteur d'un pixel RGB
        /// </summary>
        /// <param name="red"> valeur rouge du pixel</param>
        /// <param name="green"> valeur verte du pixel</param>
        /// <param name="blue"> valeur bleue du pixel</param>
        public RGB(int red, int green, int blue)
        {
            this.rgb = new int[] { red, green, blue };
        }

        /// <summary>
        /// Donne le résumé des infos principales d'un pixl RGB
        /// </summary>
        /// <returns>return un string contenant toutes ces infos</returns>
        public string toString()
        {
            string chaine = Convert.ToString(rgb[0]) + " " + Convert.ToString(rgb[1]) + " " + Convert.ToString(rgb[2]) + " ";
            return chaine;
        }

        /// <summary>
        /// Réalise le négatif de chaque pixel RGB 
        /// </summary>
        public void Negatif()
        {
            rgb[0] = 255 - rgb[0];
            rgb[1] = 255 - rgb[1];
            rgb[2] = 255 - rgb[2];
        }

        /// <summary>
        /// Attribution d'un coefficient noir et blanc à chaque pixel en fonction de sa couleur de base
        /// </summary>
        public void BW()
        {
            int bw = Convert.ToInt32((0.21 * rgb[0]) + (0.71 * rgb[1]) + (0.08 * rgb[2]));

            rgb[0] = bw;
            rgb[1] = bw;
            rgb[2] = bw;
        }

        /// <summary>
        /// Éclaircit une image par un coef
        /// </summary>
        /// <param name="value"> coef d'éclaircissement</param>
        public void Brightness(double value)
        {
            rgb[0] = Convert.ToInt32(value * rgb[0]);
            rgb[1] = Convert.ToInt32(value * rgb[1]);
            rgb[2] = Convert.ToInt32(value * rgb[2]);
        }

        /// <summary>
        /// Colorisation pour fractales ensemble de Juila/Manselbrot
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static RGB EscapeColoring(int n,double redValue,double greenValue, double blueValue)
        {
            int R = 0;          
            int G = 0;
            int B = 0;
            double x = Math.Log(n + 1);

            if (redValue != 0)
            {
                double a = (1 / redValue);
                a = a * (1 / Math.Log(2));
                R = Convert.ToInt32(255 * ((1 - Math.Cos(a * x)) / 2));
            }
            if (greenValue != 0)
            {
                double b = (1 / greenValue);
                b = b * (1 / Math.Log(2));
                G = Convert.ToInt32(255 * ((1 - Math.Cos(b * x)) / 2));
            }
            if (blueValue != 0)
            {
                double c = (1 / blueValue);
                c = c * (1 / Math.Log(2));
                B = Convert.ToInt32(255 * ((1 - Math.Cos(c * x)) / 2));
            }            
            return new RGB(R, G, B);
        }

        /// <summary>
        /// Colorisation pour fractales ensemble de Julia/Mandelbrot
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static RGB EscapeColoringBW(int n, double bwValue)
        {
            double x = Math.Log(n + 1);
            double a = (1 / bwValue);
            a = a * (1 / Math.Log(2));
            int BW = Convert.ToInt32(255 - (255 * ((1 + Math.Sin(a*2*Math.PI*x)) / 2)));

            return new RGB(BW, BW, BW);

        }

        public static RGB Neon(Complexe z,double redValue, double greenValue, double blueValue)
        {
            int R = 0;
            int G = 0;
            int B = 0;
            if(redValue!=0)
            {
                R = Convert.ToInt32((Math.Pow(2, redValue) * 255 / Math.Pow(z.mod(), redValue)));
                if (R > 255)
                    R = 255;
            }
            
            if(greenValue!=0)
            {
                G = Convert.ToInt32((Math.Pow(2, greenValue) * 255 / Math.Pow(z.mod(), greenValue)));
                if (G > 255)
                    G = 255;
            }
            if(blueValue!=0)
            {
                B = Convert.ToInt32((Math.Pow(2, blueValue) * 255 / Math.Pow(z.mod(), blueValue)));
                if (B > 255)
                    B = 255;
            }
            
            return new RGB(R, G, B);
        }
        public static RGB NeonBW(Complexe z, double bwValue)
        {
            int BW = Convert.ToInt32((Math.Pow(2, bwValue) * 255 / Math.Pow(z.mod(), bwValue)));
            if (BW > 255)
                BW = 255;
           
            return new RGB(BW, BW, BW);
        }

        public static RGB IndexFade(int i, int j, int height,int width)
        {
            return new RGB(Math.Abs((2 * height / 3 - Math.Abs(i + j))) * 255 / height, Convert.ToInt32((height - Math.Abs(i) * 2) * 255 / height), Convert.ToInt32((height - Math.Abs(j) * 2) * 255 / height));
        }

        public static RGB FractaleColoring(int iteration,int iteMax,Complexe z,int i,int j, int height, int width, double redValue, double greenValue, double blueValue,bool redN,bool greenN,bool blueN,int type)
        {
            RGB coloring = new RGB(0, 0, 0);
            //par defaut les fct noir et blanc prennent la valeur de la couleur rouge (redValue)
            switch (type)
            {
                case 0:
                    //Coloring par defaut si aucune valeur n'est donnee
                    if (iteration == iteMax)
                    {
                        coloring = new RGB(Convert.ToInt16(255), Convert.ToInt16(255), Convert.ToInt16(255));
                        NegatifByColor(coloring, redN, greenN, blueN);

                    }
                    break;
                case 1:
                    //Coloring par defaut, les pixels appartenant a la fractale sont colores dans la couleur correspondant aux 3 valeurs red, green et blue 
                    //Ces valeurs sont situees entre 0 et 255 (0,0,0 n'as pas d'interet le fond est deja noir)
                    //Le pixel coloré est un poixel appartenant a la fractale
                    if (iteration == iteMax)
                    {
                        coloring = new RGB(Convert.ToInt16(redValue), Convert.ToInt16(greenValue), Convert.ToInt16(blueValue));
                        NegatifByColor(coloring, redN, greenN, blueN);

                    }
                    break;
                case 2:
                    //Coloring via EscapeColoring, les points sortant de la fractale sont colores avec une certe fonction (pouvant etre cos,sin ou autre) prenant en parametre l'iteration de sortie
                    //De plus avec les valeurs red, green et blue on peut faire varier la part de chaque couleur dans le coloring
                    //Les valeurs interessantes pour les couleurs sont entre 0 exclu et 10 (on peut aller plus haut mais la couleur devient presque invisible)
                    //Plus la valeur de couleur diminue plus celle ci est visible
                    if (iteration < iteMax)
                    {
                        coloring = EscapeColoring(iteration, redValue, greenValue, blueValue);
                        NegatifByColor(coloring, redN, greenN, blueN);
                    }
                    break;
                case 3:
                    //De meme que le coloring precedent mais en noir et blanc
                    if (iteration < iteMax)
                    {
                        coloring = EscapeColoringBW(iteration, redValue);
                        NegatifByColor(coloring, redN, greenN, blueN);
                    }
                    break;
                case 4:
                    //Coloring dit "neon", nous l'avons invente par nous meme. Un pixel sortant de la fractale est colore en fonction du module de z calcule a la derniere iteration (iteration de sortie ou z depasse le module max impose)
                    //Les valeurs de red, green et blue permettent de varier la part de chaque couleur dans le coloring
                    //Les valeurs interessantes pour les couleurs sont entre 0 exclu et 100 (on peut aller plus haut mais la couleur devient presque invisible)
                    //Plus la valeur de couleur diminue plus celle ci est visible. En dessous de 0.5 la couleur devient presque uniforme, la valeur minimale pour garder un effet interessant est 0.5
                    if (iteration < iteMax)
                    {
                        coloring = Neon(z, redValue, greenValue, blueValue);
                        NegatifByColor(coloring, redN, greenN, blueN);
                    }
                    break;
                case 5:
                    //Meme coloring que le precedent mais en noir et blanc
                    if (iteration < iteMax)
                    {
                        coloring = NeonBW(z, redValue);
                        NegatifByColor(coloring, redN, greenN, blueN);
                    }
                    break;
                case 6:
                    //Ce coloring est un degrade observable surtout entre le bleu et le vert en fonction de la position du pixel a colorer dans l'image
                    //Le pixel colore est un pixel appartenant a la fractale
                    if (iteration == iteMax)
                    {
                        coloring = IndexFade(i, j, height, width);
                        NegatifByColor(coloring, redN, greenN, blueN);
                    }
                    break;                   
                default:
                    break;

            }
            

            return coloring;
        }

        public static RGB NeonOSJ(Complexe z, double redValue, double greenValue, double blueValue)
        {
            int R = 0;
            int G = 0;
            int B = 0;
            if (redValue != 0)
            {
                R = Convert.ToInt32((Math.Pow(0.80, redValue) * 255 / Math.Pow(z.mod(), redValue)));
                if (R > 255)
                    R = 255;
            }

            if (greenValue != 0)
            {
                G = Convert.ToInt32((Math.Pow(0.80, greenValue) * 255 / Math.Pow(z.mod(), greenValue)));
                if (G > 255)
                    G = 255;
            }
            if (blueValue != 0)
            {
                B = Convert.ToInt32((Math.Pow(0.80, blueValue) * 255 / Math.Pow(z.mod(), blueValue)));
                if (B > 255)
                    B = 255;
            }

            return new RGB(R, G, B);
        }
        public static RGB NeonBWOSJ(Complexe z, double bwValue)
        {
            int BW = Convert.ToInt32((Math.Pow(0.80, bwValue) * 255 / Math.Pow(z.mod(), bwValue)));
            if (BW > 255)
                BW = 255;

            return new RGB(BW, BW, BW);
        }

        public static RGB FractaleColoringOSJ(int iteration, int iteMax, Complexe z, int i, int j, int height, int width, double redValue, double greenValue, double blueValue, bool redN, bool greenN, bool blueN, int type)
        {
            RGB coloring = new RGB(0, 0, 0);
            //par defaut les fct noir et blanc prennent la valeur de la couleur rouge (redValue)
            switch (type)
            {
                case 0:
                    //Coloring par defaut si aucune valeur n'est donnee
                    if (iteration == iteMax)
                    {
                        coloring = new RGB(Convert.ToInt16(255), Convert.ToInt16(255), Convert.ToInt16(255));
                        NegatifByColor(coloring, redN, greenN, blueN);

                    }
                    break;
                case 1:
                    //Coloring par defaut, les pixels appartenant a la fractale sont colores dans la couleur correspondant aux 3 valeurs red, green et blue 
                    //Ces valeurs sont situees entre 0 et 255 (0,0,0 n'as pas d'interet le fond est deja noir)
                    //Le pixel coloré est un poixel appartenant a la fractale
                    if (iteration == iteMax)
                    {
                        coloring = new RGB(Convert.ToInt16(redValue), Convert.ToInt16(greenValue), Convert.ToInt16(blueValue));
                        NegatifByColor(coloring, redN, greenN, blueN);

                    }
                    break;
                case 2:
                    //Coloring via EscapeColoring, les points sortant de la fractale sont colores avec une certe fonction (pouvant etre cos,sin ou autre) prenant en parametre l'iteration de sortie
                    //De plus avec les valeurs red, green et blue on peut faire varier la part de chaque couleur dans le coloring
                    //Les valeurs interessantes pour les couleurs sont entre 0 exclu et 10 (on peut aller plus haut mais la couleur devient presque invisible)
                    //Plus la valeur de couleur diminue plus celle ci est visible
                    if (iteration < iteMax)
                    {
                        coloring = EscapeColoring(iteration, redValue, greenValue, blueValue);
                        NegatifByColor(coloring, redN, greenN, blueN);
                    }
                    break;
                case 3:
                    //De meme que le coloring precedent mais en noir et blanc
                    if (iteration < iteMax)
                    {
                        coloring = EscapeColoringBW(iteration, redValue);
                        NegatifByColor(coloring, redN, greenN, blueN);
                    }
                    break;
                case 4:
                    //Coloring dit "neon", nous l'avons invente par nous meme. Un pixel sortant de la fractale est colore en fonction du module de z calcule a la derniere iteration (iteration de sortie ou z depasse le module max impose)
                    //Les valeurs de red, green et blue permettent de varier la part de chaque couleur dans le coloring
                    //Les valeurs interessantes pour les couleurs sont entre 0 exclu et 100 (on peut aller plus haut mais la couleur devient presque invisible)
                    //Plus la valeur de couleur diminue plus celle ci est visible. En dessous de 0.5 la couleur devient presque uniforme, la valeur minimale pour garder un effet interessant est 0.5
                    if (iteration < iteMax)
                    {
                        coloring = NeonOSJ(z, redValue, greenValue, blueValue);
                        NegatifByColor(coloring, redN, greenN, blueN);
                    }
                    break;
                case 5:
                    //Meme coloring que le precedent mais en noir et blanc
                    if (iteration < iteMax)
                    {
                        coloring = NeonBWOSJ(z, redValue);
                        NegatifByColor(coloring, redN, greenN, blueN);
                    }
                    break;
                case 6:
                    //Ce coloring est un degrade observable surtout entre le bleu et le vert en fonction de la position du pixel a colorer dans l'image
                    //Le pixel colore est un pixel appartenant a la fractale
                    if (iteration == iteMax)
                    {
                        coloring = IndexFade(i, j, height, width);
                        NegatifByColor(coloring, redN, greenN, blueN);
                    }
                    break;
                default:
                    break;
            }
            return coloring;
        }





        public static void NegatifByColor(RGB coloring,bool redN,bool greenN, bool blueN)
        {
            if (redN == true)
                coloring.rgb[0] = 255 - coloring.rgb[0];
            if (greenN == true)
                coloring.rgb[1] = 255 - coloring.rgb[1];
            if (blueN == true)
                coloring.rgb[2] = 255 - coloring.rgb[2];
        }
    }
}
