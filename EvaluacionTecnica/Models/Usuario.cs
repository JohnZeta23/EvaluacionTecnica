using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace EvaluacionTecnica.Models
{
    public class Usuario
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role role { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        [Index(IsUnique = true, Order = 1)]
        public string Cedula { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(16)]
        [Index(IsUnique = true, Order = 2)]
        public string Usuario_Nombre { get; set; }
        public string Contraseña { get; set; }
        [Index]
        public DateTime Fecha_Nacimiento { get; set; }
        [DefaultValueAttribute("USER")]
        public string Usuario_Transaccion { get; set; } = "USER";
        public DateTime Fecha_Transaccion { get; set; } = DateTime.Now;
    }
}