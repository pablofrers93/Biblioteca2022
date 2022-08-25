namespace Biblioteca2022.WINDOWS
{
    partial class frmEditorialAE
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
            this.NombreEditorialTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GuardarButton = new System.Windows.Forms.Button();
            this.CancelarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NombreEditorialTextBox
            // 
            this.NombreEditorialTextBox.Location = new System.Drawing.Point(106, 46);
            this.NombreEditorialTextBox.MaxLength = 255;
            this.NombreEditorialTextBox.Name = "NombreEditorialTextBox";
            this.NombreEditorialTextBox.Size = new System.Drawing.Size(178, 20);
            this.NombreEditorialTextBox.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Nombre Editorial:";
            // 
            // GuardarButton
            // 
            this.GuardarButton.Location = new System.Drawing.Point(58, 131);
            this.GuardarButton.Name = "GuardarButton";
            this.GuardarButton.Size = new System.Drawing.Size(75, 47);
            this.GuardarButton.TabIndex = 27;
            this.GuardarButton.Text = "GUARDAR";
            this.GuardarButton.UseVisualStyleBackColor = true;
            this.GuardarButton.Click += new System.EventHandler(this.GuardarButton_Click);
            // 
            // CancelarButton
            // 
            this.CancelarButton.Location = new System.Drawing.Point(169, 131);
            this.CancelarButton.Name = "CancelarButton";
            this.CancelarButton.Size = new System.Drawing.Size(75, 47);
            this.CancelarButton.TabIndex = 28;
            this.CancelarButton.Text = "CANCELAR";
            this.CancelarButton.UseVisualStyleBackColor = true;
            this.CancelarButton.Click += new System.EventHandler(this.CancelarButton_Click);
            // 
            // frmEditorialAE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 236);
            this.Controls.Add(this.CancelarButton);
            this.Controls.Add(this.GuardarButton);
            this.Controls.Add(this.NombreEditorialTextBox);
            this.Controls.Add(this.label4);
            this.Name = "frmEditorialAE";
            this.Text = "frmEditorialAE";
            this.Load += new System.EventHandler(this.frmEditorialAE_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NombreEditorialTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button GuardarButton;
        private System.Windows.Forms.Button CancelarButton;
    }
}