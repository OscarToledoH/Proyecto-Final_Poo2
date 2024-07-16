using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerAvancePOO2.Models
{
    public class UsuariosListadoViewModel
    {
        public UsuariosListadoViewModel()
        {
          

        }

        public List<UsuarioViewModel> Usuarios { get; set; }

        public string Mensaje { get; set; }

        
    }
}