using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        CD_Categoria objDato = new CD_Categoria();

        public List<CE_Categoria> listandoCategoria(string buscar)
        {
            return objDato.listarCategoria(buscar);
        }

        public void insertandoCategoria(CE_Categoria Categoria)
        {
            objDato.insertarCategoria(Categoria);
        }

        public void editandoCategoria(CE_Categoria Categoria)
        {
            objDato.editarCategoria(Categoria);
        }

        public void eliminandoCategoria(CE_Categoria Categoria)
        {
            objDato.eliminarCategoria(Categoria);
        }

    }
}
