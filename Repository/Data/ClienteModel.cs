using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class ClienteModel
    {
        public int Id { get; set; } 
        public int Id_banco { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio.")]
        [MinLength(3, ErrorMessage = "El apellido debe tener al menos 3 caracteres.")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria.")]
        [MinLength(3, ErrorMessage = "La cédula debe tener al menos 3 caracteres.")]
        public string Documento { get; set; }
        public string Mail { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El celular debe tener 10 dígitos.")]
        public string Celular { get; set; } 
        public string Estado { get; set; } 
    }
}
