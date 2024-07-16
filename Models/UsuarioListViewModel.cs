using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerAvancePOO2.Models
{
    public class UsuarioListViewModel
    {
        public UsuarioListViewModel()
        {
            UserList = new List<UsuarioViewModel>();
            MessageConfirmed = string.Empty;
            MessageRemoved = string.Empty;
        }
        
        public List<UsuarioViewModel> UserList { get; set; }
        public string MessageConfirmed { get; set; }
        public string MessageRemoved { get; set; }

    }
}