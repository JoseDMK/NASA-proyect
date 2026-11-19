using System.ComponentModel.DataAnnotations;

namespace NASA.Models
{
    public class Mision
    {
        private string nombre;
        private int cedulaAstronauta1;
        private int cedulaAstronauta2;
        private int cedulaAstronauta3;
        private int idNave;
        private DateTime fechaLanzamiento;
        private bool tuvoExperimentos;
        private double costoTotal;

        [Key]
        public string Nombre { get => nombre; set => nombre = value; }
        public int CedulaAstronauta1 { get => cedulaAstronauta1; set => cedulaAstronauta1 = value; }
        public int CedulaAstronauta2 { get => cedulaAstronauta2; set => cedulaAstronauta2 = value; }
        public int CedulaAstronauta3 { get => cedulaAstronauta3; set => cedulaAstronauta3 = value; }
        public int IdNave { get => idNave; set => idNave = value; }

        [DataType(DataType.Date)]
        public DateTime FechaLanzamiento { get => fechaLanzamiento; set => fechaLanzamiento = value; }
        public bool TuvoExperimentos { get => tuvoExperimentos; set => tuvoExperimentos = value; }
        public double CostoTotal { get => costoTotal; set => costoTotal = value; }

        public Mision(string nombre, int cedulaAstronauta1, int cedulaAstronauta2, int cedulaAstronauta3, int idNave, DateTime fechaLanzamiento, bool tuvoExperimentos, double costoTotal)
        {
            this.nombre = nombre;
            this.cedulaAstronauta1 = cedulaAstronauta1;
            this.cedulaAstronauta2 = cedulaAstronauta2;
            this.cedulaAstronauta3 = cedulaAstronauta3;
            this.idNave = idNave;
            this.fechaLanzamiento = fechaLanzamiento;
            this.tuvoExperimentos = tuvoExperimentos;
            this.costoTotal = costoTotal;
        }

        public Mision()
        {
            this.nombre = "";
            this.cedulaAstronauta1 = 0;
            this.cedulaAstronauta2 = 0;
            this.cedulaAstronauta3 = 0;
            this.idNave = 0;
            this.fechaLanzamiento = DateTime.Now;
            this.tuvoExperimentos = false;
            this.costoTotal = 0;
        }
    }
}
