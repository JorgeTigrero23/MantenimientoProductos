using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Marca
    {
        CD_Marca objDato = new CD_Marca();

        public List<CE_Marca> listandoMarcas (string buscar)
        {
            return objDato.listarMarca(buscar);
        }

        public void insertandoMarca(CE_Marca Marca)
        {
            objDato.insertarMarca(Marca);
        }

        public void editandoMarca(CE_Marca Marca)
        {
            objDato.editarMarca(Marca);
        }

        public void eliminandoMarca(CE_Marca Marca)
        {
            objDato.eliminarMarca(Marca);
        }

    }
}
