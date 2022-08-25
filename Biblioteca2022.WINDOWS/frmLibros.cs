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
    public partial class frmLibros : Form
    {
        public frmLibros()
        {
            InitializeComponent();
        }
        private LibrosServicios servicio;
        private List<Libro> lista;
        public bool Editar = false;
        private void frmLibros_Load(object sender, EventArgs e)
        { 
        servicio = new LibrosServicios();
            try
            {
                lista = servicio.GetLista();
                MostrarDatosEnGrilla(DatosDataGridView, lista);

            }
            catch (Exception ex)
            {

            }
        }

        public static void MostrarDatosEnGrilla(DataGridView dataGrid, List<Libro> lista)
        {
            LimpiarGrilla(dataGrid);
            foreach (var libro in lista)
            {
                DataGridViewRow r = ConstruirFila(dataGrid);
                SetearFila(r, libro);
                AgregarFila(dataGrid, r);
            }
        }

        public static void SetearFila(DataGridViewRow r, Libro libro)
        {
            r.Cells[0].Value = libro.Titulo;
            r.Cells[1].Value = libro.Autor;
            r.Cells[2].Value = libro.Ejemplares;
            r.Cells[3].Value = libro.Genero.ToString(); ;
            r.Cells[4].Value = libro.Idioma.ToString(); ;
            r.Cells[5].Value = libro.Editorial.ToString();
            r.Cells[6].Value = libro.Precio;
            r.Tag = libro;
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
            frmLibrosAE frm = new frmLibrosAE() { Text = "Agregar un Libro" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                Libro libro = frm.GetLibro();
                int registrosAfectados = servicio.Agregar(libro);
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
                    SetearFila(r, libro);
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
                    Libro libro = (Libro)r.Tag;
                    DialogResult dr = MessageBox.Show($"¿Desea borrar el registro seleccionado de {libro.Titulo}?",
                        "Confirmar Eliminación",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (dr == DialogResult.No)
                    {
                        return;
                    }

                    int registrosAfectados = servicio.Borrar(libro);
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
            Libro Libro = (Libro)r.Tag;
            Libro LibroAuxiliar = (Libro)Libro.Clone();
            try
            {
                frmLibrosAE frm = new frmLibrosAE() { Text = "Editar un Libro" };
                frm.SetLibro(Libro);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                Libro = frm.GetLibro();
                int registrosAfectados = servicio.Editar(Libro);
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
                    SetearFila(r, Libro);
                    MessageBox.Show("Registro modificado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                SetearFila(r, LibroAuxiliar);
                MessageBox.Show(exception.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void DatosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
