
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ocr
{
    public partial class MainForm : Form
    {
        private Point startLocation; // Ponto inicial da seleção
        private Rectangle selectionRect; // Retângulo de seleção
        private bool isSelecting; // Indica se a seleção está sendo feita
        private ImagemCapturada capturedImageForm; // Referência para o formulário "ImagemCapturada"

        public MainForm()
        {
            InitializeComponent();
            this.Opacity = 1.0; // Define a opacidade inicial como 0.9 (90%)

            // Adiciona os eventos de clique no formulário
            this.MouseDown += MainForm_MouseDown;
            this.MouseMove += MainForm_MouseMove;
            this.MouseUp += MainForm_MouseUp;
            this.MouseClick += MainForm_MouseClick;

            // Adiciona os eventos de alteração nos radiobuttons
            radioButtonSelect.CheckedChanged += radioButtonSelect_CheckedChanged;
            radioButtonSelectNone.CheckedChanged += radioButtonSelectNone_CheckedChanged;

            trackBarOpacity.Minimum = 0;
            trackBarOpacity.Maximum = 100;
            trackBarOpacity.TickFrequency = 5; // Define a frequência dos ticks para 5
            trackBarOpacity.Value = (int)(this.Opacity * 100); // Define o valor inicial do trackbar com base na opacidade atual

            // Adiciona um manipulador de eventos para o evento ValueChanged
            trackBarOpacity.ValueChanged += trackBarOpacity_ValueChanged;
        }

        private void trackBarOpacity_ValueChanged(object sender, EventArgs e)
        {
            int opacityValue = trackBarOpacity.Value;
            this.Opacity = (double)opacityValue / 100;
        }


        private void numericUpDownOpacity_ValueChanged(object sender, EventArgs e)
        {
            decimal opacityValue = numericUpDownOpacity.Value;
            this.Opacity = (double)opacityValue / 100;
        }




        /*
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            selectedValue = numericUpDownOpacity.Value; // Armazena o valor selecionado na variável
            double valor = (double)selectedValue / 100;
            this.Opacity = valor;
        }
        */

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (radioButtonSelectNone.Checked)
                {
                    // Não permite fazer uma nova seleção quando radioButtonSelectNone estiver selecionado
                    return;
                }

                if (isSelecting)
                {
                    // Finaliza a seleção existente
                    isSelecting = false;
                }
                else
                {
                    // Inicia uma nova seleção
                    startLocation = e.Location;
                    isSelecting = true;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                // Apaga a caixa de seleção
                isSelecting = false;
                selectionRect = Rectangle.Empty;
            }

            // Redesenha o formulário para exibir a seleção
            this.Refresh();
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                // Atualiza o retângulo de seleção à medida que o mouse se move
                selectionRect = new Rectangle(
                    Math.Min(startLocation.X, e.X),
                    Math.Min(startLocation.Y, e.Y),
                    Math.Abs(startLocation.X - e.X),
                    Math.Abs(startLocation.Y - e.Y));

                // Redesenha o formulário para exibir a seleção
                this.Refresh();
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (isSelecting)
            {
                // Finaliza a seleção
                isSelecting = false;

                // Redesenha o formulário para exibir a seleção finalizada
                this.Refresh();
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Apaga a caixa de seleção
                selectionRect = Rectangle.Empty;
                this.Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Desenha o retângulo de seleção no formulário
            using (Pen pen = new Pen(Color.Red, 2))
            {
                if (isSelecting || !selectionRect.IsEmpty)
                {
                    e.Graphics.DrawRectangle(pen, selectionRect);
                }
            }
        }            

        
        private void capturedImageForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Mostra o formulário "MainForm" novamente quando o formulário "ImagemCapturada" for fechado
            this.Show();
        }

        private void radioButtonSelectNone_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSelectNone.Checked)
            {
                isSelecting = false;
                selectionRect = Rectangle.Empty;
                this.Refresh();
            }
        }

        private void radioButtonSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSelect.Checked)
            {
                isSelecting = true;
                selectionRect = Rectangle.Empty;
                this.Refresh();
            }
        }


        /*
        private void buttonCapturaTela_Click(object sender, EventArgs e)
        {
            if (selectionRect.Width > 0 && selectionRect.Height > 0)
            {
                // Oculta o formulário durante a captura de tela
                this.Hide();

                // Cria uma imagem com o tamanho da seleção
                Bitmap screenshot = new Bitmap(selectionRect.Width, selectionRect.Height);

                // Captura a área de trabalho dentro da seleção
                using (Graphics graphics = Graphics.FromImage(screenshot))
                {
                    graphics.CopyFromScreen(selectionRect.Location, Point.Empty, selectionRect.Size);
                }

                // Verifica se o formulário "ImagemCapturada" já foi criado
                if (capturedImageForm == null)
                {
                    // Cria um novo formulário para exibir a área capturada
                    capturedImageForm = new ImagemCapturada();
                    capturedImageForm.FormClosed += capturedImageForm_FormClosed; // Adiciona um manipulador de evento para quando o formulário "ImagemCapturada" for fechado
                }

                capturedImageForm.SetCapturedImage(screenshot);

                // Exibe o formulário "ImagemCapturada" de forma não modal
                capturedImageForm.Show();

                // Redesenha o formulário para exibir a seleção finalizada
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Nenhuma área de trabalho selecionada.");
            }
        }
        */

        private void buttonCapturaTela_Click(object sender, EventArgs e)
        {
            if (selectionRect.Width > 0 && selectionRect.Height > 0)
            {
                // Oculta o formulário durante a captura de tela
                this.Hide();

                // Cria uma imagem com o tamanho da seleção
                Bitmap screenshot = new Bitmap(selectionRect.Width, selectionRect.Height);

                // Captura a área de trabalho dentro da seleção
                using (Graphics graphics = Graphics.FromImage(screenshot))
                {
                    graphics.CopyFromScreen(selectionRect.Location, Point.Empty, selectionRect.Size);
                }

                // Verifica se o formulário "ImagemCapturada" já foi criado
                if (capturedImageForm == null)
                {
                    // Cria um novo formulário para exibir a área capturada
                    capturedImageForm = new ImagemCapturada();
                    capturedImageForm.FormClosed += capturedImageForm_FormClosed; // Adiciona um manipulador de evento para quando o formulário "ImagemCapturada" for fechado
                }

                capturedImageForm.SetCapturedImage(screenshot);

                // Exibe o formulário "ImagemCapturada" de forma não modal
                capturedImageForm.Show();

                // Redesenha o formulário para exibir a seleção finalizada
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Nenhuma área de trabalho selecionada.");
            }
        }




    }
}