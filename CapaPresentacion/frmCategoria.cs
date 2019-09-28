using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class frmCategoria : Form
    {
        private string idcategoria;
        private Boolean editarse = false;

        CE_Categoria objEntidad = new CE_Categoria();
        CN_Categoria objNegocio = new CN_Categoria();
        public frmCategoria()
        {
            InitializeComponent();
        }


        private void frmCategoria_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }

        private void cerrarForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void accionesTabla()
        {
            tablaCategoria.Columns[0].Visible = false;

            tablaCategoria.Columns[1].Width = 65;
            tablaCategoria.Columns[2].Width = 170;

            tablaCategoria.Columns[1].HeaderCell.Value = "Codigo";
            tablaCategoria.Columns[2].HeaderCell.Value = "Nombre";
            tablaCategoria.Columns[3].HeaderCell.Value = "Descripcion";

            tablaCategoria.ClearSelection();
        }

        private void mostrarBuscarTabla(string buscar)
        {
            CN_Categoria objNegocio = new CN_Categoria();

            tablaCategoria.DataSource = objNegocio.listandoCategoria(buscar);

            accionesTabla();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text);
        }

        private void limpiarCajas()
        {
            editarse = false;
            txtCod.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Focus();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCajas(); 
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaCategoria.SelectedRows.Count > 0)
            {
                editarse = true;
                idcategoria = tablaCategoria.CurrentRow.Cells[0].Value.ToString();
                txtCod.Text = tablaCategoria.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tablaCategoria.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = tablaCategoria.CurrentRow.Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desee editar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!editarse)
            {
                try
                {
                    objEntidad.Nombrecategoria = txtNombre.Text.ToUpper();
                    objEntidad.Descripcioncategoria = txtDescripcion.Text.ToUpper();

                    objNegocio.insertandoCategoria(objEntidad);

                    MessageBox.Show("Registro guardado correctamente.");
                    mostrarBuscarTabla("");
                    limpiarCajas();
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error al intentar guardar.");
                }
            }
            else
            {
                try
                {
                    objEntidad.Idcategoria = Convert.ToInt32(idcategoria);
                    objEntidad.Nombrecategoria = txtNombre.Text.ToUpper();
                    objEntidad.Descripcioncategoria = txtDescripcion.Text.ToUpper();

                    objNegocio.editandoCategoria(objEntidad);

                    MessageBox.Show("Registro editado correctamente.");
                    mostrarBuscarTabla("");
                    editarse = false;
                    limpiarCajas();
                }
                catch
                {
                    MessageBox.Show("Ocurrio un error al intentar editar.");
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(tablaCategoria.SelectedRows.Count > 0)
            {
                objEntidad.Idcategoria = Convert.ToInt32(tablaCategoria.CurrentRow.Cells[0].Value.ToString());
                objNegocio.eliminandoCategoria(objEntidad);

                MessageBox.Show("Registro eliminado correctamente.");
            }
            else
            {
                MessageBox.Show("Seleccione la fila que desee eliminar.");
            }
        }
    }
}
