using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Probleme_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "./Images/cc.bmp";
            //string path2 = "./Images/coco.bmp";
            BMP img = new BMP(path);
            //RGB color_white = new RGB(255, 255, 255);
            //RGB color_black = new RGB(0, 0, 0);
            //BMP img = new BMP(path);
            //BMP img1 = new BMP(path2);
            //Console.WriteLine(img.ShowBMP());
            //BMP img = new BMP(1400, 1920, color_black);
            //img.Fill(img.imageRGB, new RGB(0, 0, 0));
            //BMP img1 = new BMP(path);
            //double[,] conv = { { -1, 0, 1 }, { -2, 0, 2}, { -1, 0, 1 } };
            //double[,] conv1 = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            //double[,] conv2 = { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };
            //double[,] nette = { { -1,-1,-1 }, { -1,8,-1}, { -1,-1,-1 } };
            //double[,] compr = { { 1,1,1 }, { 1,1,1 }, { 1,1,1 } };
            //double[,] nette = { { 0, -1, 0 }, { -1, 5, -1 }, { 0, -1, 0 } };
            //img.Filtre(conv2, 1);
            //img.MirrorVertical();
            //img.RotationTeta(230);
            //img1.RotationTeta(230);
            //img.MandelbrotV2();
            //int largeur_triangle = Convert.ToInt32(2 * img.imageWidth/3);
            //int hauteur_triangle = Convert.ToInt32(2 * img.imageHeight/3);
            //int taille = Math.Min(hauteur_triangle, largeur_triangle);
            //img.TriangleDeSierpinski (Convert.ToInt32((img.imageWidth / 2) - (taille / 2)), Convert.ToInt32((img.imageHeight/2) + (Math.Sqrt(3)/2)*3), Convert.ToInt32((img.imageWidth / 2) + (taille / 2)), Convert.ToInt32((img.imageHeight / 2) + (Math.Sqrt(3) / 2)*3), Convert.ToInt32(img.imageWidth / 2), Convert.ToInt32((img.imageHeight / 2) - Math.Sqrt(3) / 3), 5);
            //img.TriangleDeSierpinski (400, 100, 400, 500, 100, 300, 20);
            //img.Negatif();

            //BMP histogramme = new BMP(2550, img.imageWidth, new RGB(0, 0, 0));
            //BMP histogramme = img.Histogramme();
            //img.EnsembleDeJulia();
            //img2.EnsembleDeJulia2();
            //img.Merge(img2);

            //img.Filtre(conv,1);
            //img1.Filtre(conv,1);
            //img.Merge(img1);
            //img.BW();
            //img.RotationTeta(30);
            //Console.WriteLine(Math.Cos(40));

            //Console.WriteLine(img.ShowBMP());
            //RGB yellow = new RGB(255, 255, 0);
            //img.Fill(yellow);
            //Console.WriteLine(img.ShowBMP());
            //RGB violet = new RGB(247, 0, 255);
            //img.SetPixel(0, 0, violet);
            //byte[] nb = img.IntToEndian(4500);
            //Console.WriteLine(img.GetPixel(0, 0).toString());
            //int[] tab = { 1, 0, 1, 0, 0, 1, 1, 0 };
            //Console.WriteLine(img.BinaryToInt(tab));
            //BMP img2 = img.Hide(img1);
            //BMP img3 = img.Find();
            //img3.Save("cocoagain");
            //img.Filtre(conv,1);
            //img.ResizeNoRatio(1080, 1920);
            //img2.Save("coco&montagne");
            //img.OverSimplifiedJulia(400, 250, 0.285, 0.01, 50, 100, 20, true, false, false, 5);

            //Console.WriteLine(img.ToString());

            //QRCODE Bob = new QRCODE("THE WORLD");            
            //Bob.qrcode.Save("firstqrcode");
            // bobReadimg = new BMP("./Images/firstqrcode.bmp");
            //QRCODE BobRead = new QRCODE(bobReadimg);
            //BobRead.qrcode.Save("downsizeqr");
            //Console.WriteLine(BobRead.message);
            img.Resize(640,500);
            img.Save("TestResize");
            //img.EnsembleDeJulia(-0.8,0.146,4,0.5,0,true,false,false, 2);
            //img.Save("FractaleColoringFctTest");
            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
