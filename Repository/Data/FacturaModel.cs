using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class FacturaModel
    {
        public int id { get; set; }

        public int id_cliente { get; set; }

        [Required(ErrorMessage = "El número de factura es obligatorio.")]
        [RegularExpression(@"^\d{3}-\d{3}-\d{6}$", ErrorMessage = "El número de factura debe tener el formato '###-###-######'.")]
        public string nro_factura { get; set; }

        public DateTime fecha_hora { get; set; }

       [Required(ErrorMessage = "El total es obligatorio.")]
        public decimal total { get; set; }

       [Required(ErrorMessage = "El total del IVA al 5% es obligatorio.")]
        public decimal total_iva5 { get; set; }

       [Required(ErrorMessage = "El total del IVA al 10% es obligatorio.")]
        public decimal total_iva10 { get; set; }

       [Required(ErrorMessage = "El total del IVA es obligatorio.")]
        public decimal total_iva { get; set; }

       [Required(ErrorMessage = "El total en letras es obligatorio.")]
       [MinLength(6, ErrorMessage = "El total en letras debe tener al menos 6 caracteres.")]
        public string total_letras { get; set; }

        public string sucursal { get; set; }
    }
}
