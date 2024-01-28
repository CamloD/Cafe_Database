using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cafe_DataBase.logica;
using Cafe_DataBase.Modelo;

namespace Cafe_DataBase.logica
{
    internal class L_Proceso_Registro
    {
        public DataTable Listado_registro(string cTexto)
        {
            OleDbDataReader Resultado;
            DataTable Tabla = new DataTable();
            OleDbConnection SqlCon = new OleDbConnection();

            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion(); // Llamar Recursos
                cTexto = "%" + cTexto.Trim().ToUpper();
                string Sql_tarea = "SELECT cod_cliente, nombre, identificacion, telefono, fecha_registro " +
                                   "FROM tb_registro " +
                                   "where ucase(trim(tb_registro.nombre)) like '" + cTexto + "'";

                OleDbCommand Comando = new OleDbCommand(Sql_tarea, SqlCon);
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)  // en esta zona ubicamos errores con el fin de comporobar si la coneccion está abierta, cerrarla
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }

        }

        public string guarda_registro(int nOpcion, M_clientes oPro)
        {
            // Rpta --> Respuesta
            string Rpta = "";
            OleDbConnection SqlCon = new OleDbConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Con el Explorador de Servidores, obtenemos lo necesario
                string Sql_tarea = "";

                if (nOpcion == 1) // Nuevo Registro
                {
                    Sql_tarea = "insert into tb_registro(nombre, identificacion, telefono, fecha_registro) " +
                                   " values('" + oPro.nombre + "', '" + oPro.identificacion +
                                   "', '" + oPro.telefono + "', '" + oPro.fecha_registro + "')";
                }
                else // Actulizar Registro
                {
                    
                    Sql_tarea = "update tb_registro set" +
                                                       " nombre = '" + oPro.nombre + "'," +
                                                       " identificacion = val('" + oPro.identificacion + "')," +
                                                       " telefono = val('" + oPro.telefono + "')," +
                                                       " fecha_registro = CDate('" + oPro.fecha_registro + "') " +
                                        " where cod_cliente = val('" + oPro.cod_cliente + "')";

                    /* http://www.coninteres.es/access_avan/material/Funciones%20de%20Access%20en%20SQL.htm  */
                }
                OleDbCommand Comando = new OleDbCommand(Sql_tarea, SqlCon);
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se puso ingresar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;

        }

        public string Borrar_registro(int nCod_cliente)
        {
            // Rpta --> Respuesta
            string Rpta = "";
            OleDbConnection SqlCon = new OleDbConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Con el Explorador de Servidores, obtenemos lo necesario
                string Sql_tarea = "";
                Sql_tarea = "delete from tb_registro where cod_cliente = val('" + nCod_cliente + "') ";

                OleDbCommand Comando = new OleDbCommand(Sql_tarea, SqlCon);
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se puso Eliminar el Registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
    }
}
