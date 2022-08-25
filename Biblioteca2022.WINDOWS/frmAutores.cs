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
    public partial class frmAutores : Form
    {
        public frmAutores()
        {
            InitializeComponent();
        }
        private AutoresServicios servicio;
        private List<Autor> lista;
        public bool Editar = false;
        private void frmAutores_Load(object sender, EventArgs e)
        {
            servicio = new AutoresServicios();
            try
            {
                lista = servicio.GetLista();
                MostrarDatosEnGrilla(DatosDataGridView, lista);

            }
            catch (Exception ex)
            {

            }
        }
        public static void MostrarDatosEnGrilla(DataGridView dataGrid, List<Autor> lista)
        {
            LimpiarGrilla(dataGrid);
            foreach (var autor in lista)
            {
                DataGridViewRow r = ConstruirFila(dataGrid);
                SetearFila(r, autor);
                AgregarFila(dataGrid, r);
            }
        }

        public static void SetearFila(DataGridViewRow r, Autor autor)
        {
            r.Cells[0].Value = autor.Apellido;
            r.Cells[1].Value = autor.Nombre;
            r.Cells[2].Value = autor.Nacionalidad;
            r.Tag = autor;
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
    }
}
