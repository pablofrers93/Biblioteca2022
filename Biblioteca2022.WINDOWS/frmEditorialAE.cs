using Biblioteca2022.ENTIDADES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Biblioteca2022.WINDOWS
{
    public partial class frmEditorialAE : Form
    {
        public frmEditorialAE()
        {
            InitializeComponent();
        }

        private Editorial editorial;
        public void SetEditorial(Editorial editorial)
        {
            this.editorial = editorial;
        }
        public Editorial GetEditorial()
        {
            return editorial;
        }

        private void frmEditorialAE_Load(object sender, EventArgs e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (editorial != null)
            {
                NombreEditorialTextBox.Text = editorial.NombreEditorial;
            }
        }
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            if (editorial == null)
            {
                editorial = new Editorial();
            }

            editorial.NombreEditorial = NombreEditorialTextBox.Text;
            DialogResult = DialogResult.OK;
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
