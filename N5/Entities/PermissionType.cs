using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class PermissionType
    {
        
        public int Id { get; set; }
        [Required]
        public string Descripcion { get; set; }

    }
}
