using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_DataBase.logica
{
    public class Conexion
    {
        private string Provider;  // Variable para el Proveedor
        private string Basededatos;  // Variables de tipo Privada para la Base de Datos
        private static Conexion Con = null; // Variable de Tipo estática para iniciar la Conexion

        private Conexion()   // en esta parte creamos el primer proceso de la conexion 
        {
            this.Provider = "Microsoft.ACE.OLEDB.16.0";  // Controlador - este se pone lara Office 365 - Versiones más Recientes
            this.Basededatos = "./DataBD/DB_cafe.accdb";  // Nombre de la Base de Datos - importante tener la extension .accdb
        }                    // Aquí tenemos (./) es la carpeta del proceso y no vamos a agregarla a otra carpeta

        public OleDbConnection CrearConexion() // Conexion con los procesos de la Base de Datos de Access - Apertura
        {
            OleDbConnection Cadena = new OleDbConnection();  // Creamos una instancia
            try // try y catch para manejo de Errores
            {
                // empezamos a concatenar los datos
                Cadena.ConnectionString = "Provider = " + this.Provider +
                                          ";Data Source = " + this.Basededatos +
                                          ";Persist Security Info = False;";

                // en esta parte creamos la configuracion del Proceso
                // además tenemos la seguridad de los datos
                // ya tenemo definida la conectividad

            }
            catch (Exception ex) //
            {
                Cadena = null; // si el proceso falla retornamos (null)
                throw ex;
            }
            return Cadena;   // retornamos Cadena y si todo ha funcionado bien, el retorno será favorable
        }

        public static Conexion getInstancia()  // en tal caso que no esté definida la coneccion lo cree la instancia
        {
            if (Con == null)  // aquí comprobamos la data
            {
                Con = new Conexion();       // creamos la Instancia
            }
            return Con;
        }
    }
}

