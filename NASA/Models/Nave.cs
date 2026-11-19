using System.ComponentModel.DataAnnotations;

namespace NASA.Models
{
    public class Nave
    {
        private int idNave;
        private string nombre;
        private int capacidad;
        private string tipo;
        private DateTime fechaFabricacion;
        private bool aceptabilidad;

        public Nave(int idNave, string nombre, int capacidad, string tipo, DateTime fechaFabricacion, bool aceptabilidad)
        {
            this.idNave = idNave;
            this.nombre = nombre;
            this.capacidad = capacidad;
            this.tipo = tipo;
            this.fechaFabricacion = fechaFabricacion;
            this.aceptabilidad = aceptabilidad;
        }

        public Nave()
        {
            this.idNave = 0;
            this.nombre = "";
            this.capacidad = 0;
            this.tipo = "";
            this.fechaFabricacion = DateTime.Now;
            this.aceptabilidad = false;
        }

        [Key]
        public int IdNave { get => idNave; set => idNave = value; }

        public string Nombre { get => nombre; set => nombre = value; }

        public int Capacidad { get => capacidad; set => capacidad = value; }

        public string Tipo { get => tipo; set => tipo = value; }

        [DataType(DataType.Date)]
        public DateTime FechaFabricacion { get => fechaFabricacion; set => fechaFabricacion = value; }

        public bool Aceptabilidad { get => aceptabilidad; set => aceptabilidad = value; }

        public void calcularAceptabilidad()
        {
            int anios = DateTime.Now.Year - fechaFabricacion.Year;

            if (DateTime.Now < fechaFabricacion.AddYears(anios))
            {
                anios--;
            }

            aceptabilidad = anios <= 5;
        }
    }
}