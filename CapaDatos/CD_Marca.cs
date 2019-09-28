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
    public class CD_Marca
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<CE_Marca> listarMarca (string buscar)
        {
            SqlDataReader leerFila;
            SqlCommand cmd = new SqlCommand("SP_BUSCARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);

            leerFila = cmd.ExecuteReader();

            List<CE_Marca> Listar = new List<CE_Marca>();

            while(leerFila.Read())
            {
                Listar.Add(new CE_Marca
                {
                    Idmarca = leerFila.GetInt32(0),
                    Codigomarca = leerFila.GetString(1),
                    Nombremarca = leerFila.GetString(2),
                    Descripcionmarca = leerFila.GetString(3)
                });
            }

            leerFila.Close();
            conexion.Close();

            return Listar;
        }

        public void insertarMarca(CE_Marca Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", Marca.Nombremarca);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Marca.Descripcionmarca);

            cmd.ExecuteNonQuery();

            conexion.Close();

        }

        public void editarMarca (CE_Marca Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDMARCA", Marca.Idmarca);
            cmd.Parameters.AddWithValue("@NOMBRE", Marca.Nombremarca);
            cmd.Parameters.AddWithValue("@DESCRIPCION", Marca.Descripcionmarca);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void eliminarMarca(CE_Marca Marca)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINARMARCA", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@IDMARCA", Marca.Idmarca);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }


    }
}
