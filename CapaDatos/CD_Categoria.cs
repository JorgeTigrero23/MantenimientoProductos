using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;
using System.Data;

namespace CapaDatos
{
    public class CD_Categoria
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);
        
        public List<CE_Categoria> listarCategoria(string buscar)
        {
            SqlDataReader leerFila;
            SqlCommand cmd = new SqlCommand("SP_BUSCARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscar", buscar);

            leerFila = cmd.ExecuteReader();

            List<CE_Categoria> Listar = new List<CE_Categoria>();

            while(leerFila.Read())
            {
                Listar.Add(new CE_Categoria
                {
                    Idcategoria = leerFila.GetInt32(0),
                    Codigocategoria = leerFila.GetString(1),
                    Nombrecategoria = leerFila.GetString(2),
                    Descripcioncategoria = leerFila.GetString(3)
                });
            }

            conexion.Close();
            leerFila.Close();

            return Listar;
        }

        public void insertarCategoria(CE_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", Categoria.Nombrecategoria);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.Descripcioncategoria);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void editarCategoria(CE_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.Idcategoria);
            cmd.Parameters.AddWithValue("@NOMBRE", Categoria.Nombrecategoria);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Categoria.Descripcioncategoria);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void eliminarCategoria(CE_Categoria Categoria)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARCATEGORIA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@IDCATEGORIA", Categoria.Idcategoria);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }
    }
}
