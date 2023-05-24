using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Permission 
    {
        public int Id { get; set; }
        public string NombreEmpleado { get;set; }
        public string ApellidoEmpleado { get; set;}
        public  int TipoPermiso { get; set;}

        public DateTime? FechaPermiso { get; set; }
       
    }
}
