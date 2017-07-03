using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ImageHashing
{
    public class CheckImageInfo
    {

        public int Width { get; private set; }
        public int Height { get; private set; }
        public byte[, ,] ImageContent { get; private set; }

        public CheckImageInfo(string path)
        {
            using (Bitmap img = Bitmap.FromFile(path) as Bitmap)
            {
                Width = img.Width;
                Height = img.Height;
                ImageContent = new byte[Height, Width, 3];
                ReadPixels(img);
            }
        }

        /// <summary>
        /// Carrega os pixels da imagem em uma matriz.
        /// </summary>
        private void ReadPixels(Bitmap img)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Color pixel = img.GetPixel(j, i);
                    ImageContent[i, j, 0] = pixel.R;
                    ImageContent[i, j, 1] = pixel.G;
                    ImageContent[i, j, 2] = pixel.B;
                }
            }
        }
        

        public string CalculateHash()
        {
            string solucao = "";
            int i, j,k;
            int x=0;
            for (i = 0; i < Height;i++ )
            {
                for(j = 0; j < Width; j++)
                {
                    for (k = 0; k < 3; k++)
                    {
                        x += ImageContent[i, j, k];
                    }
                }
            }
            x = x % 50;
            solucao = x.ToString();
            return solucao;
        }
  
        /*

        public string CalculateHash()
        {
            return "2131";
        }
        */





/*
        /// <summary>
        /// Calcula o hash da imagem.
        /// </summary>
        /// <returns></returns>
        public string CalculateHash()
        {
            long sum = 0;
            for (int i = 0; i < Height; i++)
            {
                int row = 0;
                for (int j = 0; j < Width; j++)
                {
                    // Calcula a media dos pixels (tons de cinza)
                    int c = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        c += ImageContent[i, j, k];
                    }
                    c /= 255;
                    row += c;
                }
                // Soma os pixels da linha..
                sum += row;
            }
            double code = Math.Sqrt(sum);
            return code.ToString("F8").Replace(".", "").Replace(",", "");
        }
        */
    }
}
