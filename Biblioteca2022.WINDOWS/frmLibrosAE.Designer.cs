namespace Biblioteca2022.WINDOWS
{
    partial class frmLibrosAE
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.TituloLibroTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PrecioTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GuadarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.EditorialTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.IdiomaTextBox = new System.Windows.Forms.TextBox();
            this.GeneroTextBox = new System.Windows.Forms.TextBox();
            this.EjemplaresTextBox = new System.Windows.Forms.TextBox();
            this.AutorLibroTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 30;
            this.label6.Text = "Idioma:";
            // 
            // TituloLibroTextBox
            // 
            this.TituloLibroTextBox.Location = new System.Drawing.Point(151, 26);
            this.TituloLibroTextBox.MaxLength = 255;
            this.TituloLibroTextBox.Name = "TituloLibroTextBox";
            this.TituloLibroTextBox.Size = new System.Drawing.Size(440, 20);
            this.TituloLibroTextBox.TabIndex = 36;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Genero:";
            // 
            // PrecioTextBox
            // 
            this.PrecioTextBox.Location = new System.Drawing.Point(151, 234);
            this.PrecioTextBox.MaxLength = 10;
            this.PrecioTextBox.Name = "PrecioTextBox";
            this.PrecioTextBox.Size = new System.Drawing.Size(106, 20);
            this.PrecioTextBox.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Ejemplares:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Titulo Libro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Autor:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Precio:";
            // 
            // GuadarButton
            // 
            this.GuadarButton.Location = new System.Drawing.Point(73, 278);
            this.GuadarButton.Name = "GuadarButton";
            this.GuadarButton.Size = new System.Drawing.Size(140, 76);
            this.GuadarButton.TabIndex = 42;
            this.GuadarButton.Text = "GUARDAR";
            this.GuadarButton.UseVisualStyleBackColor = true;
            this.GuadarButton.Click += new System.EventHandler(this.GuadarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(451, 278);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(140, 76);
            this.CancelarButton.TabIndex = 43;
            this.CancelarButton.Text = "CANCELAR";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // EditorialTextBox
            // 
            this.EditorialTextBox.Location = new System.Drawing.Point(151, 203);
            this.EditorialTextBox.MaxLength = 10;
            this.EditorialTextBox.Name = "EditorialTextBox";
            this.EditorialTextBox.Size = new System.Drawing.Size(106, 20);
            this.EditorialTextBox.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Editorial:";
            // 
            // IdiomaTextBox
            // 
            this.IdiomaTextBox.Location = new System.Drawing.Point(151, 172);
            this.IdiomaTextBox.MaxLength = 255;
            this.IdiomaTextBox.Name = "IdiomaTextBox";
            this.IdiomaTextBox.Size = new System.Drawing.Size(440, 20);
            this.IdiomaTextBox.TabIndex = 46;
            // 
            // GeneroTextBox
            // 
            this.GeneroTextBox.Location = new System.Drawing.Point(151, 136);
            this.GeneroTextBox.MaxLength = 255;
            this.GeneroTextBox.Name = "GeneroTextBox";
            this.GeneroTextBox.Size = new System.Drawing.Size(440, 20);
            this.GeneroTextBox.TabIndex = 48;
            // 
            // EjemplaresTextBox
            // 
            this.EjemplaresTextBox.Location = new System.Drawing.Point(151, 100);
            this.EjemplaresTextBox.MaxLength = 255;
            this.EjemplaresTextBox.Name = "EjemplaresTextBox";
            this.EjemplaresTextBox.Size = new System.Drawing.Size(440, 20);
            this.EjemplaresTextBox.TabIndex = 49;
            // 
            // AutorLibroTextBox
            // 
            this.AutorLibroTextBox.Location = new System.Drawing.Point(151, 64);
            this.AutorLibroTextBox.MaxLength = 255;
            this.AutorLibroTextBox.Name = "AutorLibroTextBox";
            this.AutorLibroTextBox.Size = new System.Drawing.Size(440, 20);
            this.AutorLibroTextBox.TabIndex = 50;
            // 
            // frmLibrosAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 366);
            this.Controls.Add(this.AutorLibroTextBox);
            this.Controls.Add(this.EjemplaresTextBox);
            this.Controls.Add(this.GeneroTextBox);
            this.Controls.Add(this.IdiomaTextBox);
            this.Controls.Add(this.EditorialTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuadarButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TituloLibroTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PrecioTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "frmLibrosAE";
            this.Text = "frmLibrosAE";
            this.Load += new System.EventHandler(this.frmLibrosAE_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TituloLibroTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PrecioTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button GuadarButton;
        private System.Windows.Forms.Button CancelarButton;
        private System.Windows.Forms.TextBox EditorialTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox IdiomaTextBox;
        private System.Windows.Forms.TextBox GeneroTextBox;
        private System.Windows.Forms.TextBox EjemplaresTextBox;
        private System.Windows.Forms.TextBox AutorLibroTextBox;
    }
}