using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_DataBase.Modelo
{
    internal class M_clientes
    {
        public int cod_cliente { get; set; }
        public int cod_registro { get; set; }
        public string nombre { get; set; }
        public long telefono { get; set; }
        public long identificacion { get; set; }
        public string tipo_cafe { get; set; }
        public string precio { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha_proceso { get; set; }
        public DateTime fecha_registro { get; set; }

    }
}
