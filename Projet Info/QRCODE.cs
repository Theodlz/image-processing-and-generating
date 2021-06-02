using System;
using System.Collections.Generic;
using System.Text;

namespace Probleme_Info
{
    /// <summary>
    /// Classe QR Code
    /// </summary>
    public class QRCODE
    {
        /// <summary>
        /// Version du QR Code
        /// </summary>
        public int version { get; private set; }
        /// <summary>
        /// Data transformée sous forme de byte, prête à être dessinée sur une image
        /// </summary>
        public byte[] dataEncoded { get; private set; }

        /// <summary>
        /// Image associée au QR Code
        /// </summary>
        public BMP qrcode { get; private set; }




        /// <summary>
        /// Message associée au QR Code
        /// </summary>
        public string message { get; private set; }

        /// <summary>
        /// Constructeur QR Code
        /// </summary>
        /// <param name="data"> data à écrire dans le QR Code</param>
        public QRCODE(string data)
        {
            this.dataEncoded = dataToEncode(data);
            byte[,] qr = Ecriture_QRCode(dataEncoded, 1);
            this.qrcode = new BMP(qr);
            qrcode.Resize(520, 520);
            Console.WriteLine("done");

        }
        /// <summary>
        /// Constructeur QR Code a partir d'une image, sert a utiliser le decodeur de qrcode
        /// </summary>
        /// <param name="imgqr"> image du QR Code a decoder</param>
        public QRCODE(BMP imgqr)
        {
            if((imgqr.imageHeight!=21)&&(imgqr.imageWidth!=21))
            {
                imgqr.Resize(21, 21);
            }
            this.message = QR_Read(imgqr);
            this.qrcode = imgqr;
            //qrcode.ResizeNoRatio(210, 210);
            Console.WriteLine(this.message);

        }

        /// <summary>
        /// Correspondance char ASCII
        /// </summary>
        /// <param name="c"> char pour lequel on veut connaître la valeur ASCII</param>
        /// <returns>return le code ASCII associé au char</returns>
        public int alphaNum(char c)
        {
            //Correspondance de chaque caractère en ASCII
            int code = 0;
            switch (c)
            {
                case '0':
                    code = 0;
                    break;
                case '1':
                    code = 1;
                    break;
                case '2':
                    code = 2;
                    break;
                case '3':
                    code = 3;
                    break;
                case '4':
                    code = 4;
                    break;
                case '5':
                    code = 5;
                    break;
                case '6':
                    code = 6;
                    break;
                case '7':
                    code = 7;
                    break;
                case '8':
                    code = 8;
                    break;
                case '9':
                    code = 9;
                    break;
                case 'A':
                    code = 10;
                    break;
                case 'B':
                    code = 11;
                    break;
                case 'C':
                    code = 12;
                    break;
                case 'D':
                    code = 13;
                    break;
                case 'E':
                    code = 14;
                    break;
                case 'F':
                    code = 15;
                    break;
                case 'G':
                    code = 16;
                    break;
                case 'H':
                    code = 17;
                    break;
                case 'I':
                    code = 18;
                    break;
                case 'J':
                    code = 19;
                    break;
                case 'K':
                    code = 20;
                    break;
                case 'L':
                    code = 21;
                    break;
                case 'M':
                    code = 22;
                    break;
                case 'N':
                    code = 23;
                    break;
                case 'O':
                    code = 24;
                    break;
                case 'P':
                    code = 25;
                    break;
                case 'Q':
                    code = 26;
                    break;
                case 'R':
                    code = 27;
                    break;
                case 'S':
                    code = 28;
                    break;
                case 'T':
                    code = 29;
                    break;
                case 'U':
                    code = 30;
                    break;
                case 'V':
                    code = 31;
                    break;
                case 'W':
                    code = 32;
                    break;
                case 'X':
                    code = 33;
                    break;
                case 'Y':
                    code = 34;
                    break;
                case 'Z':
                    code = 35;
                    break;
                case ' ':
                    code = 36;
                    break;
                case '$':
                    code = 37;
                    break;
                case '%':
                    code = 38;
                    break;
                case '*':
                    code = 39;
                    break;
                case '+':
                    code = 40;
                    break;
                case '-':
                    code = 41;
                    break;
                case '.':
                    code = 42;
                    break;
                case '/':
                    code = 43;
                    break;
                case ':':
                    code = 44;
                    break;
                default:
                    break;
            }

            return code;
        }

        /// <summary>
        /// Correspondance ASCII char
        /// </summary>
        /// <param name="val"> valeur ASCII pour laquel on veut connaitre le char correspondant</param>
        /// <returns>return le har associe au code ASCIIc</returns>
        public char IntToalphaNum(int val)
        {
            //Correspondance de chaque caractère en ASCII
            char c;
            switch (val)
            {
                case 0:
                    c = '0';
                    break;
                case 1:
                    c = '1';
                    break;
                case 2:
                    c = '2';
                    break;
                case 3:
                    c = '3';
                    break;
                case 4:
                    c = '4';
                    break;
                case 5:
                    c = '5';
                    break;
                case 6:
                    c = '6';
                    break;
                case 7:
                    c = '7';
                    break;
                case 8:
                    c = '8';
                    break;
                case 9:
                    c = '9';
                    break;
                case 10:
                    c = 'A';
                    break;
                case 11:
                    c = 'B';
                    break;
                case 12:
                    c = 'C';
                    break;
                case 13:
                    c = 'D';
                    break;
                case 14:
                    c = 'E';
                    break;
                case 15:
                    c = 'F';
                    break;
                case 16:
                    c = 'G';
                    break;
                case 17:
                    c = 'H';
                    break;
                case 18:
                    c = 'I';
                    break;
                case 19:
                    c = 'J';
                    break;
                case 20:
                    c = 'K';
                    break;
                case 21:
                    c = 'L';
                    break;
                case 22:
                    c = 'M';
                    break;
                case 23:
                    c = 'N';
                    break;
                case 24:
                    c = 'O';
                    break;
                case 25:
                    c = 'P';
                    break;
                case 26:
                    c = 'Q';
                    break;
                case 27:
                    c = 'R';
                    break;
                case 28:
                    c = 'S';
                    break;
                case 29:
                    c = 'T';
                    break;
                case 30:
                    c = 'U';
                    break;
                case 31:
                    c = 'V';
                    break;
                case 32:
                    c = 'W';
                    break;
                case 33:
                    c = 'X';
                    break;
                case 34:
                    c = 'Y';
                    break;
                case 35:
                    c = 'Z';
                    break;
                case 36:
                    c = ' ';
                    break;
                case 37:
                    c = '$';
                    break;
                case 38:
                    c = '%';
                    break;
                case 39:
                    c = '*';
                    break;
                case 40:
                    c = '+';
                    break;
                case 41:
                    c = '-';
                    break;
                case 42:
                    c = '.';
                    break;
                case 43:
                    c = '/';
                    break;
                case 44:
                    c = ':';
                    break;
                default:
                    c = ' ';
                    break;
            }

            return c;
        }


        /// <summary>
        /// Transforme les données à mettre dans le QR Code en byte
        /// </summary>
        /// <param name="data"> chaine de caractères à encoder</param>
        /// <returns>return un tableau de byte correspondant aux données à écrire dans le QR Code</returns>
        public byte[] dataToEncode(string data)
        {
            string dataBits = "0010";
            dataBits += IntToEndian(data.Length, 9);
            //On crée la chaine de 0 et de 1 qvec la methode donnee sur internet et la feuille de TD
            for (int i = 0; i < data.Length; i += 2) //On code notre message par groupe de 2 caractères d'où l'incrémentation de 2 à chaque appel du for
            {
                int nbLettres = 1;
                int n = 0;
                if (i + 1 < data.Length)
                {
                    n = 45 * alphaNum(data[i]);
                    n += alphaNum(data[i + 1]);
                    nbLettres++;
                }
                else
                {
                    n = alphaNum(data[i]);
                }

                if (nbLettres == 1)
                {
                    dataBits += IntToEndian(n, 6);
                    Console.WriteLine(IntToEndian(n, 6));

                }
                else
                {
                    dataBits += IntToEndian(n, 11);
                    Console.WriteLine(IntToEndian(n, 11));
                }

            }
            //On ajoute les 4 zéros de fin de chaine signifiant que le message est terminé
            dataBits += "0000";

            //On fait le padding pour avoir une chaines composees de groupes de 8 bits soit 1 octet
            int reste;
            int padding = 8 - dataBits.Length % 8;
            for (int i = 0; i < padding; i++)
            {
                dataBits += "0";
            }
            int k = 0;
            //On ajoute successivement ces 2 octets pour atteindre la taille max du qrcode de version 1 avec correction 1
            //En effet on doit toujours avoir une chaine qui fait la taille max de ce qui est écrit sur la feuille de TD ou internet
            while (dataBits.Length < 152)
            {
                if (k == 0)
                {
                    dataBits += "11101100";
                    k++;
                }
                else
                {
                    dataBits += "00010001";
                    k--;
                }
            }

            //On converti le string en tableau de Bytes pour utiliser l'algorithme Reed-Salomon


            byte[] dataToEncode = new byte[dataBits.Length];
            for (int i = 0; i < dataToEncode.Length; i++)
            {
                dataToEncode[i] = Convert.ToByte(Convert.ToByte(dataBits[i]) - 48);
            }
            byte[] dataRS = new byte[19];
            for (int i = 0; i < dataRS.Length; i++)
            {
                byte[] dataRStemp = new byte[8];
                int l = 0;
                for (int j = i * 8; j < ((i + 1) * 8); j++)
                {
                    dataRStemp[l] = dataToEncode[j];
                    l++;

                }
                byte dataTempOctet = Convert.ToByte(EndianToInt(dataRStemp));
                dataRS[i] = dataTempOctet;
            }

            byte[] RSbytes = ReedSolomon.ReedSolomonAlgorithm.Encode(dataRS, 7, ReedSolomon.ErrorCorrectionCodeType.QRCode);
            string RSbitString = "";
            foreach (byte nb in RSbytes)
            {
                RSbitString += IntToEndian(nb, 8);
            }
            byte[] RSbits = new byte[RSbitString.Length];
            for (int i = 0; i < RSbits.Length; i++)
            {
                RSbits[i] = Convert.ToByte(Convert.ToByte(RSbitString[i]) - 48);
            }


            byte[] dataEncoded = new byte[(dataToEncode.Length + RSbytes.Length * 8)];

            for (int i = 0; i < dataEncoded.Length; i++)
            {

                {
                    if (i >= 0 && i < dataToEncode.Length)
                    {
                        dataEncoded[i] = dataToEncode[i];

                    }
                    else
                    {
                        dataEncoded[i] = RSbits[i - dataToEncode.Length];
                    }
                }

            }


            for (int i = 0; i < dataEncoded.Length; i++)
            {
                Console.Write(dataEncoded[i]);
            }
            Console.WriteLine();

            Console.Write("DONE");
            return dataEncoded;

            //Puis créer l image de QR CODE en prenant bien en compte les masques.

        }

        public string IntToEndian(int nombre, int nbBits)
        {
            string nb = "";
            int i = 0;

            while (i < nbBits)
            {
                int reste;
                int quotient = Math.DivRem(nombre, 2, out reste);
                nb += reste;
                nombre = quotient;
                i++;

            }
            string nbReverse = "";
            for (int j = nb.Length - 1; j >= 0; j--)
            {
                nbReverse += nb[j];
            }


            return nbReverse;
        }

        public int EndianToInt(byte[] tab)
        {
            int compteur = tab.Length - 1;
            int nb = 0;
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                nb += Convert.ToInt32(tab[i] * (Math.Pow(2, compteur)));
                compteur--;
            }
            return nb;
        }

        public int EndianToIntTab(byte[] tab, int highIndex, int lowIndex)
        {
            int compteur = highIndex - lowIndex;
            int nb = 0;
            for (int i = lowIndex; i <= highIndex; i++)
            {
                nb += Convert.ToInt32(tab[i] * (Math.Pow(2, compteur)));
                compteur--;
            }
            return nb;
        }

        /// <summary>
        /// Écriture du pattern fixe (carrés dans les coins) sur le QR Code
        /// </summary>
        /// <param name="qr"> QR Code</param>
        /// <param name="i"> coordonnées ligne du coin en haut à gauche du carré à dessiner</param>
        /// <param name="j"> coordonnées colonne du coin en haut à gauche du carré à dessiner</param>
        public void Ecriture_PatternFixe(byte[,] qr, byte i, byte j)
        {
            for (byte i2 = i; i2 < i + 7; i2++)
            {
                for (byte j2 = j; j2 < j + 7; j2++)
                {
                    if (i2 == i || j2 == j || i2 == i + 6 || j2 == j + 6 || (i2 == i + 2 && j2 == j + 2) || (i2 == i + 2 && j2 == j + 3) || (i2 == i + 2 && j2 == j + 4) || (i2 == i + 3 && j2 == j + 3) ||
                        (i2 == i + 3 && j2 == j + 2) || (i2 == i + 3 && j2 == j + 3) || (i2 == i + 3 && j2 == j + 4) || (i2 == i + 4 && j2 == j + 2) || (i2 == i + 4 && j2 == j + 3) ||
                        (i2 == i + 4 && j2 == j + 4))
                        qr[i2, j2] = 1;
                }
            }
        }

        /// <summary>
        /// Lecture du pattern fixe (carrés dans les coins) sur le QR Code pour verifier si l'image est bien un QR Code
        /// </summary>
        /// <param name="qr"> QR Code</param>
        /// <param name="i"> coordonnées ligne du coin en haut à gauche du carré à lire</param>
        /// <param name="j"> coordonnées colonne du coin en haut à gauche du carré à lire</param>
        public bool Lecture_PatternFixe(byte[,] qr, byte i, byte j)
        {
            bool patternCarre = true;
            for (byte i2 = i; i2 < i + 7; i2++)
            {
                for (byte j2 = j; j2 < j + 7; j2++)
                {
                    if (((i2 == i || j2 == j || i2 == i + 6 || j2 == j + 6 || (i2 == i + 2 && j2 == j + 2) || (i2 == i + 2 && j2 == j + 3) || (i2 == i + 2 && j2 == j + 4) || (i2 == i + 3 && j2 == j + 3) ||
                        (i2 == i + 3 && j2 == j + 2) || (i2 == i + 3 && j2 == j + 3) || (i2 == i + 3 && j2 == j + 4) || (i2 == i + 4 && j2 == j + 2) || (i2 == i + 4 && j2 == j + 3) ||
                        (i2 == i + 4 && j2 == j + 4))))
                    {
                        if (qr[i2, j2] == 0)
                            patternCarre = false;                        
                    }                                      
                    else
                    {
                        if (qr[i2, j2] == 1)
                            patternCarre = false;
                    }
                        


                }
            }
            return patternCarre;
        }

        /// <summary>
        /// Écrit un QR code
        /// </summary>
        /// <param name="message"> données en byte à dessiner dans le QR Code</param>
        /// <param name="version"> version du QR Code souhaitée</param>
        /// <returns>return le QR Code dessiné</returns>
        public byte[,] Ecriture_QRCode(byte[] message, int version)
        {
            byte[,] qr;
            if (version < 1 || version > 2)
            { return null; }
            if (version == 1)
            { qr = new byte[21, 21]; }
            else
            { qr = new byte[25, 25]; }

            //Remplissage du qrcode en blanc
            for (int i = 0; i < qr.GetLength(0); i++)
            {
                for (int j = 0; j < qr.GetLength(1); j++)
                    qr[i, j] = 0;
            }

            //Remplissage du qrcode avec les patterns fixes
            Ecriture_PatternFixe(qr, 0, 0);
            Ecriture_PatternFixe(qr, 0, Convert.ToByte(qr.GetLength(1) - 6 - 1));
            Ecriture_PatternFixe(qr, Convert.ToByte(qr.GetLength(0) - 6 - 1), 0);


            //Écriture pattern format bit
            string format_info = "111011111000100";
            byte[] info = new byte[15];
            for (int i = 0; i < 15; i++)
                info[i] = Convert.ToByte(format_info[i]);

            int compteur = 0;
            for (int j = 0; j < 9; j++)
            {
                if (j != 6)
                {
                    qr[8, j] = Convert.ToByte(info[compteur] - 48);
                    compteur++;

                }
            }
            for (int i = 7; i >= 0; i--)
            {
                if (i != 6)
                {
                    qr[i, 8] = Convert.ToByte(info[compteur] - 48);
                    compteur++;

                }
            }
            compteur = 0;

            for (int i = qr.GetLength(0) - 1; i > qr.GetLength(0) - 7 - 1; i--)
            {
                qr[i, 8] = Convert.ToByte(info[compteur] - 48);
                compteur++;

            }
            for (int j = qr.GetLength(1) - 7 - 1; j < qr.GetLength(1); j++)
            {
                qr[8, j] = Convert.ToByte(info[compteur] - 48);
                compteur++;

            }
            qr[qr.GetLength(0) - 7 - 1, 8] = 1; //Dark Mode

            //Remplissage de certains pixels fixes (ligne et colonne fixes)
            qr[6, 8] = 1;
            qr[6, 10] = 1;
            qr[6, 12] = 1;
            qr[8, 6] = 1;
            qr[10, 6] = 1;
            qr[12, 6] = 1;



            //remplissage dataBits
            bool way = true; //true : vers le haut , false : vers le bas                       
            int l = qr.GetLength(0) - 1; // index i matrice
            int m = qr.GetLength(1) - 1; //index j matrice
            int n = 0;

            while (n < 208)
            {
                while (way == true && n < 208)
                {
                    DataPattern(1, qr, l, m, message, n);
                    if (l > 3 && l < 9)
                        l -= 5;
                    else
                        l -= 4;
                    n += 8;
                    if (((l < 9) && ((m < 9) || (m > 12))) || (l < 0))
                    {
                        way = false;
                        if (m != 8)
                            m -= 2;
                        else
                            m -= 3;
                        l++;
                    }
                }
                while (way == false && n < 208)
                {
                    DataPattern(2, qr, l, m, message, n);
                    if (l > 3 && l < 9)
                        l += 5;
                    else
                        l += 4;
                    n += 8;
                    if ((l > qr.GetLength(0) - 1) || ((l > 11) && (m < 9)))
                    {
                        way = true;
                        if (m != 6)
                            m -= 2;
                        else
                            m -= 3;
                        if ((l > qr.GetLength(0) - 1) && (m < 12))
                            l -= 8;
                        l--;

                    }
                }
            }
            for (int i = 0; i < qr.GetLength(0); i++)
            {
                for (int j = 0; j < qr.GetLength(1); j++)
                {
                    Console.Write(qr[i, j]);
                }
                Console.WriteLine();
            }

            return qr;
        }

        /// <summary>
        /// Sens d'écriture des données dans le QR Code
        /// </summary>
        /// <param name="nbPattern"></param>
        /// <param name="qr"> qr Code</param>
        /// <param name="i"> coo ligne du début de l'encodage</param>
        /// <param name="j"> coo colonne du début de l'encodage</param>
        /// <param name="message"> data à encoder</param>
        /// <param name="k"> avancement de l'index dans les données</param>
        public void DataPattern(int nbPattern, byte[,] qr, int i, int j, byte[] message, int k)
        {
            switch (nbPattern)
            {
                case 1:
                    for (int m = i; m > i - 4; m--)
                    {
                        for (int n = j; n > j - 2; n--)
                        {
                            if (m == 6 || n == 6)
                            {
                                i--;
                                n--;
                            }
                            else
                            {
                                if ((n + m) % 2 == 0)
                                {
                                    qr[m, n] = Convert.ToByte(1 - message[k]);
                                }
                                else
                                {
                                    qr[m, n] = Convert.ToByte(message[k]);
                                }
                                k++;
                            }

                        }
                    }
                    break;

                case 2:
                    for (int m = i; m < i + 4; m++)
                    {
                        for (int n = j; n > j - 2; n--)
                        {
                            if (m == 6 || n == 6)
                            {
                                i++;
                                n--;
                            }
                            else
                            {
                                if ((n + m) % 2 == 0)
                                {
                                    qr[m, n] = Convert.ToByte(1 - message[k]);
                                }
                                else
                                {
                                    qr[m, n] = Convert.ToByte(message[k]);
                                }

                                k++;
                            }
                        }
                    }
                    break;
            }

        }


        /// <summary>
        /// Lit un QR code
        /// </summary>
        /// <param name="qrcode"> image du QR Code a decoder pour en retrouver le message</param>
        /// <returns>return le message inscrit dans le Qr Code</returns>

        public string QR_Read(BMP qrcode)
        {
            byte[,] qr = new byte[qrcode.imageHeight, qrcode.imageWidth];
            for (int i = 0; i < qrcode.imageHeight; i++)
            {
                for (int j = 0; j < qrcode.imageWidth; j++)
                {
                    if (qrcode.imageRGB[i, j].rgb[0] == 255)
                        qr[i, j] = 0;
                    else
                        qr[i, j] = 1;

                }
            }
            bool patternCarres = false;
            if (Lecture_PatternFixe(qr, 0, 0) == true && Lecture_PatternFixe(qr, 0, Convert.ToByte(qr.GetLength(1) - 6 - 1)) == true && Lecture_PatternFixe(qr, Convert.ToByte(qr.GetLength(0) - 6 - 1), 0) == true)
                patternCarres = true;
            if (patternCarres == true)
            {
                byte[] message = new byte[208];
                bool way = true; //true : vers le haut , false : vers le bas                       
                int l = qr.GetLength(0) - 1; // index i matrice
                int m = qr.GetLength(1) - 1; //index j matrice
                int n = 0;
                while (n < 208)
                {
                    while (way == true && n < 208)
                    {
                        DataPatternReader(1, qr, l, m, message, n);
                        if (l > 3 && l < 9)
                            l -= 5;
                        else
                            l -= 4;
                        n += 8;
                        if (((l < 9) && ((m < 9) || (m > 12))) || (l < 0))
                        {
                            way = false;
                            if (m != 8)
                                m -= 2;
                            else
                                m -= 3;
                            l++;
                        }
                    }
                    while (way == false && n < 208)
                    {
                        DataPatternReader(2, qr, l, m, message, n);
                        if (l > 3 && l < 9)
                            l += 5;
                        else
                            l += 4;
                        n += 8;
                        if ((l > qr.GetLength(0) - 1) || ((l > 11) && (m < 9)))
                        {
                            way = true;
                            if (m != 6)
                                m -= 2;
                            else
                                m -= 3;
                            if ((l > qr.GetLength(0) - 1) && (m < 12))
                                l -= 8;
                            l--;

                        }
                    }
                }
                string messageDecoded = "";
                int messageLength = EndianToIntTab(message, 12, 4);
                int q = 13;
                for (int i = 0; i < messageLength; i += 2) //On decode notre message par groupe de 2 caractères d'où l'incrémentation de 2 à chaque appel du for
                {
                    int nbLettres = 1;
                    
                    if (i + 1 < messageLength)
                    {
                        byte[] lettresTemp = new byte[11];
                        int r = 0;
                        for (int j = q; j < q + 11; j++)
                        {
                            lettresTemp[r] = message[j];
                            r++;
                        }

                        int lettresCode = EndianToInt(lettresTemp);
                        int l1 = Math.DivRem(lettresCode, 45, out int l2);

                        messageDecoded += IntToalphaNum(l1);
                        messageDecoded += IntToalphaNum(l2);

                        nbLettres++;
                        q += 11;
                    }
                    else
                    {
                        byte[] lettresTemp = new byte[6];

                        int r = 0;
                        for (int j = q; j < q + 6; j++)
                        {
                            lettresTemp[r] = message[j];
                            r++;
                        }
                        int lettresCode = EndianToInt(lettresTemp);
                        messageDecoded += IntToalphaNum(lettresCode);

                        q += 6;
                    }

                }

                return messageDecoded;

            }
            else
            {
                return "erreur lors du decodage";
            }

        }

        /// <summary>
        /// Sens de lecture des données dans le QR Code
        /// </summary>
        /// <param name="nbPattern"></param>
        /// <param name="qr"> qr Code</param>
        /// <param name="i"> coo ligne du début du decodage</param>
        /// <param name="j"> coo colonne du début du decodage</param>
        /// <param name="message"> tableau de byte de la chaine de donnees du qrcode qui sera remplie par cette methode de lecture</param>
        /// <param name="k"> avancement de l'index dans les données</param>

        public void DataPatternReader(int nbPattern, byte[,] qr, int i, int j, byte[] message, int k)
        {
            switch (nbPattern)
            {
                case 1:
                    for (int m = i; m > i - 4; m--)
                    {
                        for (int n = j; n > j - 2; n--)
                        {
                            if (m == 6 || n == 6)
                            {
                                i--;
                                n--;
                            }
                            else
                            {
                                if ((n + m) % 2 == 0)
                                {
                                    message[k] = Convert.ToByte(1 - qr[m, n]);
                                }
                                else
                                {
                                    message[k] = qr[m, n];
                                }
                                k++;
                            }

                        }
                    }
                    break;

                case 2:
                    for (int m = i; m < i + 4; m++)
                    {
                        for (int n = j; n > j - 2; n--)
                        {
                            if (m == 6 || n == 6)
                            {
                                i++;
                                n--;
                            }
                            else
                            {
                                if ((n + m) % 2 == 0)
                                {
                                    message[k] = Convert.ToByte(1 - qr[m, n]);
                                }
                                else
                                {
                                    message[k] = qr[m, n];
                                }
                                k++;
                            }
                        }
                    }
                    break;
            }

        }


    }
}
