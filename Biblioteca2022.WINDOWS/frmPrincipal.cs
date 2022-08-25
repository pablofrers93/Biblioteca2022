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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LibrosButton_Click(object sender, EventArgs e)
        {

            frmLibros frm = new frmLibros() { Text = "Libros" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void UsuariosButton_Click(object sender, EventArgs e)
        {
            frmUsuarios frm = new frmUsuarios() { Text = "Usuarios" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }

        private void AutoresButton_Click(object sender, EventArgs e)
        {
            frmAutores frm = new frmAutores() { Text = "Autores" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }

        private void EditorialesButton_Click(object sender, EventArgs e)
        {
            frmEditoriales frm = new frmEditoriales() { Text = "Editoriales" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
        }
    }
}
