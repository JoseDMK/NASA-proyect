using System;
using System.ComponentModel.DataAnnotations;

namespace NASA.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        [Display(Name = "Cédula")]
        public int Cedula { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Género")]
        public string Genero { get; set; } = string.Empty;

        [Display(Name = "Fecha de Registro")]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Usuario")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Activo")]
        public bool Activo { get; set; } = true; // por defecto activo
    }
}