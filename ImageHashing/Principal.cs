using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageHashing
{
    public partial class Principal : Form
    {
        private CheckImageInfo originalImage;

        public Principal()
        {
            InitializeComponent();
            originalImage = new CheckImageInfo("Imagens/Original.bmp");
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string dir = "Imagens";
            string[] files = Directory.GetFiles(dir);
            lstHashes.Items.Add(originalImage.CalculateHash() + " (IMAGEM ORIGINAL)");
            // Calcula os demais itens..
            foreach (string f in files)
            {
                var img = new CheckImageInfo(f);
                lstHashes.Items.Add(img.CalculateHash() + " (" + Path.GetFileNameWithoutExtension(f) + ")" + (img.CalculateHash() == originalImage.CalculateHash()?"Verdadeira":"Falsa"));
            }

        }
    }
}
