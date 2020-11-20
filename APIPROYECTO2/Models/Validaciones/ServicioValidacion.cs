using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIPROYECTO2.Models
{
    public partial class SERVICIOS
    {
        [MetadataType(typeof(SERVICIOS.MetaData))]
        sealed class MetaData
        {
            [Required]
            public string idServicio;
            [Required]
            public string nombreServicio;
            [Required]
            public string descripcion;
            [Required]
            public Nullable<decimal> costo;
        }
    }
}