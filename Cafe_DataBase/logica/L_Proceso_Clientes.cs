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
    internal class L_Proceso_Clientes
    {
        public DataTable Listado_Clientes(string cTexto)
        {
            OleDbDataReader Resultado;
            DataTable Tabla = new DataTable();
            OleDbConnection SqlCon = new OleDbConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                cTexto = "%" + cTexto.Trim().ToUpper();
                string sql_Tarea = "SELECT cod_proceso, nombre, identificacion, telefono, tipo_cafe, precio, cantidad, total, fecha_proceso " +
                                  "FROM clientes " +
                                  "where ucase(trim(clientes.nombre)) like '" + cTexto + "'";
                OleDbCommand Comando = new OleDbCommand(sql_Tarea, SqlCon);
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) { SqlCon.Close(); }
            }
        }
        public string guarda_cliente(int nOpcion, M_clientes oPro)
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
                    Sql_tarea = "insert into clientes(nombre, identificacion, telefono, tipo_cafe, precio, cantidad, total, fecha_proceso) " +
                                   " values('" + oPro.nombre + "', '" + oPro.identificacion +
                                   "', '" + oPro.telefono + "','"+ oPro.tipo_cafe +"', '" + oPro.precio +
                                   "', '" + oPro.cantidad + "', '" + oPro.total + "', , '" + oPro.fecha_proceso + "')"
                                   ;
                }
                else // Actulizar Registro
                {

                    Sql_tarea = "update tb_registro set" +
                                                       " nombre = '" + oPro.nombre + "'," +
                                                       " identificacion = val('" + oPro.identificacion + "')," +
                                                       " telefono = val('" + oPro.telefono + "')," +
                                                       " tipo_cafe = '" + oPro.tipo_cafe + "'," +
                                                       " precio = '" + oPro.precio + "'," +
                                                       " cantidad = '" + oPro.cantidad + "'," +
                                                       " total = '" + oPro.total + "'," +
                                                       " fecha_registro = CDate('" + oPro.fecha_proceso + "') " +
                                        " where cod_registro = val('" + oPro.cod_registro + "')";

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

        public string Borrar_Cliente(int nCod_proceso)
        {
            // Rpta --> Respuesta
            string Rpta = "";
            OleDbConnection SqlCon = new OleDbConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                // Con el Explorador de Servidores, obtenemos lo necesario
                string Sql_tarea = "";
                Sql_tarea = "delete from tb_registro where cod_proceso = val('" + nCod_proceso + "') ";

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
