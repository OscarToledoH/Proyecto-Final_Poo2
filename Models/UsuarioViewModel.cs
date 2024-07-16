using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerAvancePOO2.Models
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            
        }

        public string? User { get; set; }

        public string? Email { get; set;}

        public bool Confirmed { get; set; }

        public bool IsAdmin { get; set; }
    }
}