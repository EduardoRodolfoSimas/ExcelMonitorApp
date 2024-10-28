namespace ExcelMonitorApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelResultado = new Label();
            pictureBox1 = new PictureBox();
            labelContador = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // labelResultado
            // 
            labelResultado.BackColor = Color.Transparent;
            labelResultado.Dock = DockStyle.Fill;
            labelResultado.Font = new Font("Segoe UI Black", 50F, FontStyle.Bold);
            labelResultado.ForeColor = Color.FromArgb(174, 247, 99);
            labelResultado.ImageAlign = ContentAlignment.MiddleRight;
            labelResultado.Location = new Point(0, 0);
            labelResultado.Name = "labelResultado";
            labelResultado.Size = new Size(800, 450);
            labelResultado.TabIndex = 0;
            labelResultado.Text = "labelResultado";
            labelResultado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Dock = DockStyle.Bottom;
            pictureBox1.Image = Properties.Resources.ICASA__1_;
            pictureBox1.Location = new Point(0, 308);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Padding = new Padding(0, 0, 0, 10);
            pictureBox1.Size = new Size(800, 142);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // labelContador
            // 
            labelContador.BackColor = Color.Transparent;
            labelContador.Dock = DockStyle.Top;
            labelContador.Font = new Font("Segoe UI Black", 30F);
            labelContador.ForeColor = Color.FromArgb(82, 157, 69);
            labelContador.Location = new Point(0, 0);
            labelContador.Name = "labelContador";
            labelContador.Padding = new Padding(0, 10, 0, 0);
            labelContador.Size = new Size(800, 81);
            labelContador.TabIndex = 0;
            labelContador.Text = "Contador: 0";
            labelContador.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.backGroundICASA__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(labelContador);
            Controls.Add(pictureBox1);
            Controls.Add(labelResultado);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            KeyUp += Form1_KeyUp;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelResultado;
        private PictureBox pictureBox1;
        private Label labelContador;
    }
}
