using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_Info
{
    /// <summary>
    /// Classe nombre complexe
    /// </summary>
    public class Complexe
    {
        /// <summary>
        /// Partie réelle du nombre complexe
        /// </summary>
        public double Re { get; set; }

        /// <summary>
        /// Partie imaginaire du nombre complexe
        /// </summary>
        public double Im { get; set; }

        //Constructeur

        /// <summary>
        /// Constructeur d'un complexe à partir de sa partie réelle et imaginaire
        /// </summary>
        /// <param name="Re"> partie réelle</param>
        /// <param name="Im"> partie imaginaire</param>
        public Complexe(double Re, double Im)
        {
            this.Re = Re;
            this.Im = Im;
        }

        /// <summary>
        /// Multiplication de 2 nbr complexes
        /// </summary>
        /// <param name="a"> premier nombre complexe</param>
        /// <param name="b"> second nombre complexe</param>
        /// <returns>return un nouveau nombre complexe avec les deux nouvelles parties réelles et imaginaires</returns>
        public static Complexe mult(Complexe a, Complexe b)
        {
            double re = a.Re * b.Re - (a.Im * b.Im);
            double im = (a.Re * b.Im) + (a.Im * b.Re);
            return new Complexe(re, im);
        }

        /// <summary>
        /// Carré d'un nombre complexe
        /// </summary>
        /// <returns>return un nouveau nombre complexe avec les deux nouvelles parties réelles et imaginaires</returns>
        public Complexe carré()
        {
            double re = Re * Re - (Im * Im);
            double im = (Re * Im) + (Im * Re);
            return new Complexe(re, im);

        }

        /// <summary>
        /// Addition de deux nombres complexes
        /// </summary>
        /// <param name="a"> premier nombre complexe</param>
        /// <param name="b"> second nombre complexe</param>
        /// <returns>return un nouveau nombre complexe avec les deux nouvelles parties réelles et imaginaires</returns>
        public static Complexe add(Complexe a, Complexe b)
        {
            return new Complexe((a.Re + b.Re), (a.Im + b.Im));
        }

        /// <summary>
        /// Soustraction d'un nombre complexe par un autre
        /// </summary>
        /// <param name="a"> premier nombre complexe</param>
        /// <param name="b"> second nombre complexe</param>
        /// <returns>return un nouveau nombre complexe avec les deux nouvelles parties réelles et imaginaires</returns>
        public static Complexe minus(Complexe a, Complexe b)
        {
            return new Complexe((a.Re - b.Re), (a.Im - b.Im));
        }

        /// <summary>
        /// Donne la norme d'un nombre complexe
        /// </summary>
        /// <returns>return un int</returns>
        public double mod()
        {
            return Math.Sqrt(Math.Pow(Re, 2) + Math.Pow(Im, 2));
        }

        /// <summary>
        /// Addition d'un scalaire à un nombre complexe
        /// </summary>
        /// <param name="scal"> scalaire à ajouter au complexe</param>
        /// <returns>return un nouveau nombre complexe avec la nouvelle partie réelle</returns>
        public Complexe addScal(double scal)
        {
            return new Complexe(Re + scal, Im);
        }

        /// <summary>
        /// Multiplication d'un nombre complexe par un scalaire
        /// </summary>
        /// <param name="scal"> scalaire qui multiplie le nbr complexe</param>
        /// <returns>return un nouveau nombre complexe avec les deux nouvelles parties réelles et imaginaires</returns>
        public Complexe multScal(double scal)
        {
            return new Complexe(scal * Re, scal * Im);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Complexe div(Complexe a, Complexe b)
        {
            Complexe conj = new Complexe(b.Re, -b.Im);
            Complexe N = Complexe.mult(a, conj);
            Complexe D = Complexe.mult(b, conj);
            return new Complexe(N.Re / D.Re, N.Im / D.Re);
        }

    }
}
