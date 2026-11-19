using System.ComponentModel.DataAnnotations;

namespace NASA.Models
{
    public class Astronauta
    {
        private int cedula;
        private string nombre;
        private string profesion;   // quimico, fisico, ingeniero
        private string correo;
        private string genero;      // femenino, masculino
        private string telefono;
        private int aniosExperiencia;
        private double salario;

        public Astronauta(int cedula, string nombre, string profesion, string correo, string genero, string telefono, int aniosExperiencia, double salario)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.profesion = profesion;
            this.correo = correo;
            this.genero = genero;
            this.telefono = telefono;
            this.aniosExperiencia = aniosExperiencia;
            this.salario = salario;
        }

        public Astronauta()
        {
            this.cedula = 0;
            this.nombre = "";
            this.profesion = "";
            this.correo = "";
            this.genero = "";
            this.telefono = "";
            this.aniosExperiencia = 0;
            this.salario = 0;
        }
        [Key]
        [Display(Name = "Cédula")]
        public int Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        [Display(Name = "Profesión")]
        public string Profesion { get => profesion; set => profesion = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Genero { get => genero; set => genero = value; }

        [Display(Name = "Teléfono")]
        public string Telefono { get => telefono; set => telefono = value; }

        [Display(Name = "Años de Experiencia")]
        public int AniosExperiencia { get => aniosExperiencia; set => aniosExperiencia = value; }
        public double Salario { get => salario; set => salario = value; }

        // ── Cálculo de salario ──────────────────────────────────────
        public void calcularSalario()
        {
            double salarioBase = 0;

            switch (profesion.ToLower())
            {
                case "quimico": salarioBase = 6000; break;
                case "fisico": salarioBase = 8000; break;
                case "ingeniero": salarioBase = 10000; break;
            }

            double porcentajeExperiencia = aniosExperiencia * 0.03;
            salario = salarioBase + (salarioBase * porcentajeExperiencia);
        }
    }
}
