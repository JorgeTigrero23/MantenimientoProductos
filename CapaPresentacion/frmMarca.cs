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
    public partial class frmMarca : Form
    {
        private string idmarca;
        private Boolean editarse = false;

        CE_Marca objEntidad = new CE_Marca();
        CN_Marca objNegocio = new CN_Marca();
        public frmMarca()
        {
            InitializeComponent();
        }

        private void frmMarca_Load(object sender, EventArgs e)
        {
            mostrarBuscarTabla("");
        }

        private void accionesTabla()
        {
            tablaMarca.Columns[0].Visible = false;

            tablaMarca.Columns[1].Width = 65;
            tablaMarca.Columns[2].Width = 170;

            tablaMarca.Columns[1].HeaderText = "COD";
            tablaMarca.Columns[2].HeaderText = "NOMBRE";
            tablaMarca.Columns[3].HeaderText = "DESCRIPCION";

            tablaMarca.ClearSelection();
        }

        private void mostrarBuscarTabla(string buscar)
        {
            CN_Marca objNegocio = new CN_Marca();

            tablaMarca.DataSource = objNegocio.listandoMarcas(buscar);

            accionesTabla();
        }

        private void limpiarCajas()
        {
            editarse = false;
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtNombre.Focus();
        }

        private void cerrarForm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCajas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (tablaMarca.SelectedRows.Count > 0)
            {
                editarse = true;
                idmarca = tablaMarca.CurrentRow.Cells[0].Value.ToString();
                txtCodigo.Text = tablaMarca.CurrentRow.Cells[1].Value.ToString();
                txtNombre.Text = tablaMarca.CurrentRow.Cells[2].Value.ToString();
                txtDescripcion.Text = tablaMarca.CurrentRow.Cells[3].Value.ToString();
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
                    objEntidad.Codigomarca = txtCodigo.Text.ToUpper();
                    objEntidad.Nombremarca = txtNombre.Text.ToUpper();
                    objEntidad.Descripcionmarca = txtDescripcion.Text.ToUpper();

                    objNegocio.insertandoMarca(objEntidad);

                    //MessageBox.Show("Registro guardado correctamente.");
                    frmSuccess.confirmationForm("GUARDADO");
                    mostrarBuscarTabla("");
                    limpiarCajas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error al intentar guardar.");
                }
            }
            else
            {
                try
                {
                    objEntidad.Idmarca = Convert.ToInt32(idmarca);
                    objEntidad.Codigomarca = txtCodigo.Text.ToUpper();
                    objEntidad.Nombremarca = txtNombre.Text.ToUpper();
                    objEntidad.Descripcionmarca = txtDescripcion.Text.ToUpper();

                    objNegocio.editandoMarca(objEntidad);

                    //MessageBox.Show("Registro editado correctamente.");
                    frmSuccess.confirmationForm("EDITADO");
                    mostrarBuscarTabla("");
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
            try
            {
                DialogResult result = new DialogResult();
                frmInformation frmInf = new frmInformation("¿ESTAS SEGURO DE ELIMINAR EL REGISTRO?");
                result  = frmInf.ShowDialog();

                if(result == DialogResult.OK)
                {
                    objEntidad.Idmarca = Convert.ToInt32(tablaMarca.CurrentRow.Cells[0].Value.ToString());
                    objNegocio.eliminandoMarca(objEntidad);

                    //MessageBox.Show("Registro eliminado correctamente.");
                    frmSuccess.confirmationForm("ELIMINADO");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Seleccione la fila que desee editar");
            }

            //if (tablaMarca.SelectedRows.Count > 0)
            //{
            //    objEntidad.Idmarca = Convert.ToInt32(tablaMarca.CurrentRow.Cells[0].Value.ToString());
            //    objNegocio.eliminandoMarca(objEntidad);

            //    //MessageBox.Show("Registro eliminado correctamente.");
            //    frmSuccess.confirmationForm("ELIMINADO");
            //}
            //else
            //{
            //    MessageBox.Show("Seleccione la fila que desee editar");
            //}
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            mostrarBuscarTabla(txtBuscar.Text.Trim());
        }

        private void topFormulario_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
