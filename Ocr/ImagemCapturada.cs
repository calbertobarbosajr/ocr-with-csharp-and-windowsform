using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Tesseract;

namespace Ocr
{
    public partial class ImagemCapturada : Form
    {
        private static int openFormCount = 0; // Contador de janelas abertas

        public ImagemCapturada()
        {
            InitializeComponent();
            openFormCount++; // Incrementa o contador de janelas abertas
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            openFormCount--; // Decrementa o contador de janelas abertas

            if (openFormCount <= 0)
            {
                // Se não houver mais nenhuma janela aberta, encerra a aplicação
                Application.Exit();
            }
        }

        private void buttonVoltar_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();

            this.Hide();
        }

        public void SetCapturedImage(Bitmap image)
        {
            pictureBoxImagemCapturada.Image = image;

            // Redimensiona a imagem capturada para uma escala adequada para OCR
            Bitmap resizedImage = ResizeImage(image, 2); // Ajuste o fator de escala conforme necessário

            // Restante do código para o OCR...
            string tessdataPath = @"C:\Program Files\Tesseract-OCR\tessdata";

            using (var engine = new TesseractEngine(tessdataPath, "por", EngineMode.Default))
            {
                engine.DefaultPageSegMode = PageSegMode.Auto; // Configura o PageSegMode para Auto

                // Define o PSM desejado de acordo com o tipo de imagem
                engine.SetVariable("tessedit_pageseg_mode", "psm"); // Substitua "psm" pelo valor apropriado

                using (var pix = PixConverter.ToPix(resizedImage))
                {
                    using (var page = engine.Process(pix))
                    {
                        var text = page.GetText();

                        textBox.Text = text;

                        // Salva o resultado em um arquivo de texto
                        SaveTextToFile(text, "C:\\Users\\Carlos_Alberto\\Documents\\resultado.txt");
                    }
                }
            }
        }

        private Bitmap ResizeImage(Image image, int scaleFactor)
        {
            int newWidth = image.Width * scaleFactor;
            int newHeight = image.Height * scaleFactor;

            Bitmap resizedImage = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            return resizedImage;
        }

        private void SaveTextToFile(string text, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(text);
            }
        }
    }
}
