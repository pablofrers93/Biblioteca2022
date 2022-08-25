using Biblioteca2022.ENTIDADES;
using Biblioteca2022.SERVICIOS;
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
    public partial class frmEditoriales : Form
    {
        public frmEditoriales()
        {
            InitializeComponent();
        }

        private EditorialesServicios servicio;
        private List<Editorial> lista;
        public bool Editar = false;
        private void frmEditoriales_Load(object sender, EventArgs e)
        {
            servicio = new EditorialesServicios();
            try
            {
                lista = servicio.GetLista();
                MostrarDatosEnGrilla(DatosDataGridView, lista);

            }
            catch (Exception ex)
            {

            }
        }
        public static void MostrarDatosEnGrilla(DataGridView dataGrid, List<Editorial> lista)
        {
            LimpiarGrilla(dataGrid);
            foreach (var editorial in lista)
            {
                DataGridViewRow r = ConstruirFila(dataGrid);
                SetearFila(r, editorial);
                AgregarFila(dataGrid, r);
            }
        }

        public static void SetearFila(DataGridViewRow r, Editorial editorial)
        {
            r.Cells[0].Value = editorial.NombreEditorial;
            r.Tag = editorial;
        }

        public static void LimpiarGrilla(DataGridView dataGrid)
        {
            dataGrid.Rows.Clear();

        }

        public static DataGridViewRow ConstruirFila(DataGridView dataGrid)
        {
            var r = new DataGridViewRow();
            r.CreateCells(dataGrid);
            return r;
        }


        public static void AgregarFila(DataGridView dataGrid, DataGridViewRow r)
        {
            dataGrid.Rows.Add(r);
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            frmEditorialAE frm = new frmEditorialAE() { Text = "Agregar una Editorial" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Editorial editorial = frm.GetEditorial();
                int registrosAfectados = servicio.Agregar(editorial);
                if (registrosAfectados == 0)
                {
                    MessageBox.Show("No se agregaron registros...",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    //Recargar grilla
                    RecargarGrilla();
                }
                else
                {
                    var r = ConstruirFila(DatosDataGridView);
                    SetearFila(r, editorial);
                    AgregarFila(DatosDataGridView, r);
                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void RecargarGrilla()
        {
            try
            {
                lista = servicio.GetLista();
                MostrarDatosEnGrilla(DatosDataGridView, lista);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BorrarButton_Click(object sender, EventArgs e)
        {
            {
                if (DatosDataGridView.SelectedRows.Count == 0)
                {
                    return;
                }

                try
                {
                    var r = DatosDataGridView.SelectedRows[0];
                    Editorial editorial = (Editorial)r.Tag;
                    DialogResult dr = MessageBox.Show($"¿Desea borrar el registro seleccionado de {editorial.NombreEditorial}?",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.No)
                    {
                        return;
                    }

                    int registrosAfectados = servicio.Borrar(editorial);
                    if (registrosAfectados == 0)
                    {
                        MessageBox.Show("No se borraron registros...",
                            "Advertencia",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        //Recargar grilla
                        RecargarGrilla();

                    }
                    else
                    {
                        DatosDataGridView.Rows.Remove(r);
                        MessageBox.Show("Registro eliminado",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
        }

        private void EditarButton_Click(object sender, EventArgs e)
        {
            if (DatosDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            var r = DatosDataGridView.SelectedRows[0];
            Editorial editorial = (Editorial)r.Tag;
            Editorial editorialAuxiliar = (Editorial)editorial.Clone();
            try
            {
                frmEditorialAE frm = new frmEditorialAE() { Text = "Editar una Editorial" };
                frm.SetEditorial(editorial);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                editorial = frm.GetEditorial();
                int registrosAfectados = servicio.Editar(editorial);
                if (registrosAfectados == 0)
                {
                    MessageBox.Show("No se borraron registros...",
                        "Advertencia",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    //Recargar grilla
                    RecargarGrilla();

                }
                else
                {
                    SetearFila(r, editorial);
                    MessageBox.Show("Registro modificado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                SetearFila(r, editorialAuxiliar);
                MessageBox.Show(exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}