using System.ComponentModel.DataAnnotations;

namespace NASA.Models
{
    public class Experimento
    {
        private string nombre;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private bool poseePresupuesto;
        private string tipo;
        private bool requiereRobots;
        private bool? resultadoEsperado; 
        private string observaciones;

        public Experimento()
        {
            this.nombre = "";
            this.fechaInicio = DateTime.Now;
            this.fechaFin = DateTime.Now;
            this.poseePresupuesto = false;
            this.tipo = "";
            this.requiereRobots = false;
            this.resultadoEsperado = null; 
            this.observaciones = "";
        }

        [Key]
        public string Nombre { get => nombre; set => nombre = value; }
        [DataType(DataType.Date)]
        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        [DataType(DataType.Date)]
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public bool PoseePresupuesto { get => poseePresupuesto; set => poseePresupuesto = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public bool RequiereRobots { get => requiereRobots; set => requiereRobots = value; }
        public bool? ResultadoEsperado { get => resultadoEsperado; set => resultadoEsperado = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }

        //Cálcular exito 
        public string calcularExito()
        {
            int puntos = 0;

            // Presupuesto
            if (poseePresupuesto)
                puntos += 5;

            // Resultado esperado
            if (resultadoEsperado == true)
                puntos += 5;

            // Diferencia de años
            int anios = fechaFin.Year - fechaInicio.Year;

            if (fechaFin < fechaInicio.AddYears(anios))
                anios--;

            if (anios < 1)
                puntos += 8;
            else if (anios >= 1 && anios <= 3)
                puntos += 5;
            else
                puntos += 3;

            // Robots
            if (requiereRobots)
                puntos += 5;

            // Resultado final
            if (puntos <= 8)
                return "Poco exitoso";
            else if (puntos <= 12)
                return "Medio exitoso";
            else
                return "Muy exitoso";
        }
    }
}