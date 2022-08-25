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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private UsuariosServicios servicio;
        private List<Usuario> lista;
        public bool Editar = false;
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            servicio = new UsuariosServicios();
            try
            {
                lista = servicio.GetLista();
                MostrarDatosEnGrilla(DatosDataGridView, lista);

            }
            catch (Exception ex)
            {

            }
        }
        public static void MostrarDatosEnGrilla(DataGridView dataGrid, List<Usuario> lista)
        {
            LimpiarGrilla(dataGrid);
            foreach (var usuario in lista)
            {
                DataGridViewRow r = ConstruirFila(dataGrid);
                SetearFila(r, usuario);
                AgregarFila(dataGrid, r);
            }
        }

        public static void SetearFila(DataGridViewRow r, Usuario usuario)
        {
            r.Cells[0].Value = usuario.Dni;
            r.Cells[1].Value = usuario.Apellido;
            r.Cells[2].Value = usuario.Nombre;
            r.Cells[3].Value = usuario.Direccion;
            r.Cells[4].Value = usuario.Localidad;
            r.Cells[5].Value = usuario.CodPostal;
            r.Cells[6].Value = usuario.Telefono;
            r.Cells[7].Value = usuario.FechaNac;
            r.Cells[8].Value = usuario.Sancionado;
            r.Tag = usuario;
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

