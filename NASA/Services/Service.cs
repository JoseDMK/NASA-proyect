using NASA.Models;
using System.Data.Entity;

namespace NASA.Services
{
    public class Service : DbContext
    {
        public DbSet<Astronauta> Astronautas { get; set; } = null!;
        public DbSet<Nave> Naves { get; set; } = null!;
        public DbSet<Experimento> Experimentos { get; set; } = null!;
        public DbSet<Usuario> Usuarios { get; set; } = null!;
        public DbSet<Mision> Misiones { get; set; } = null!;

        public Service() : base("NASA") { }

        #region Métodos Astronauta
        public List<Astronauta> mostrarAstronautas() => Astronautas.ToList();

        public List<Astronauta> buscarAstronautaPorProfesionYNombre(string profesion, string nombre)
        {
            return Astronautas
                .Where(a => a.Profesion.Contains(profesion) && a.Nombre.Contains(nombre))
                .ToList();
        }

        public void agregarAstronauta(Astronauta astronauta)
        {
            Astronautas.Add(astronauta);
            SaveChanges();
        }

        public Astronauta buscarAstronauta(int cedula) => Astronautas.Find(cedula);

        public void editarAstronauta(Astronauta a)
        {
            Entry(a).State = EntityState.Modified;
            SaveChanges();
        }

        public void eliminarAstronauta(int cedula)
        {
            var a = buscarAstronauta(cedula);
            if (a != null)
            {
                Astronautas.Remove(a);
                SaveChanges();
            }
        }
        #endregion

        #region Metodos Misiones

        public void agregarMision(Mision mision)
        {
            // Obtener y validar astronautas
            var astronautas = new List<Astronauta>();
            var a1 = buscarAstronauta(mision.CedulaAstronauta1);
            var a2 = buscarAstronauta(mision.CedulaAstronauta2);
            var a3 = buscarAstronauta(mision.CedulaAstronauta3);

            if (a1 == null || a2 == null || a3 == null)
                throw new Exception("Uno o más astronautas no encontrados");

            astronautas.Add(a1);
            astronautas.Add(a2);
            astronautas.Add(a3);


            var nave = buscarNave(mision.IdNave);
            if (nave == null) throw new Exception("Nave no encontrada");
            if (!nave.Aceptabilidad) throw new Exception("La nave seleccionada no es apta");


            double costo = calcularCostoMision(astronautas, nave, mision);
            mision.CostoTotal = costo;

            Misiones.Add(mision);
            SaveChanges();
        }

        public List<Mision> mostrarMisiones()
        {
            return Misiones.ToList();
        }

        public Mision buscarMision(string nombre)
        {
            var misionBuscada = Misiones.FirstOrDefault(m => m.Nombre == nombre);
            if (misionBuscada != null)
                return misionBuscada;
            else throw new Exception("Mision no encontrada");
        }

        public void actualizarMision(Mision mision)
        {
            var misionAnterior = Misiones.FirstOrDefault(m => m.Nombre == mision.Nombre);
            if (misionAnterior != null)
            {
                misionAnterior.CedulaAstronauta1 = mision.CedulaAstronauta1;
                misionAnterior.CedulaAstronauta2 = mision.CedulaAstronauta2;
                misionAnterior.CedulaAstronauta3 = mision.CedulaAstronauta3;
                misionAnterior.IdNave = mision.IdNave;
                misionAnterior.FechaLanzamiento = mision.FechaLanzamiento;
                misionAnterior.TuvoExperimentos = mision.TuvoExperimentos;

               
        var astronautas = new List<Astronauta>();
        var a1 = buscarAstronauta(mision.CedulaAstronauta1);
        var a2 = buscarAstronauta(mision.CedulaAstronauta2);
        var a3 = buscarAstronauta(mision.CedulaAstronauta3);
        if (a1 != null) astronautas.Add(a1);
        if (a2 != null) astronautas.Add(a2);
        if (a3 != null) astronautas.Add(a3);


        var nave = buscarNave(mision.IdNave);
        if (nave == null) throw new Exception("Nave no encontrada");
        if (!nave.Aceptabilidad) throw new Exception("La nave seleccionada no es apta");


        double costo = calcularCostoMision(astronautas, nave, mision);
        misionAnterior.CostoTotal = costo;

                SaveChanges();
            }
            else throw new Exception("No se pudo actualizar la mision");
        }

        public void eliminarMision(Mision mision)
        {
            Misiones.Remove(mision);
            SaveChanges();
        }

        public double calcularCostoMision(List<Astronauta> astronautas, Nave nave, Mision mision)
        {
            double costoTotal = 0;
            foreach (var a in astronautas)
                {
                costoTotal += a.Salario;
            }
            if (nave.Tipo == "Automática")
            {
                costoTotal += 150000; 
            }else
            {
                costoTotal += 85000; 
            }
            if (mision.TuvoExperimentos == true)
            {
                costoTotal += 20000; 
            }
            
            return costoTotal;
        }
        #endregion

        #region Métodos Naves
        public List<Nave> mostrarNaves() => Naves.ToList();

        public List<Nave> buscarNavePorTipoYCapacidad(string tipo, string capacidad)
        {
            int capacidadNumero;
            bool capacidadValida = int.TryParse(capacidad, out capacidadNumero);

            return Naves
                .Where(n =>
                    (string.IsNullOrEmpty(tipo) || n.Tipo.Contains(tipo)) &&
                    (!capacidadValida || n.Capacidad == capacidadNumero))
                .ToList();
        }

        public void agregarNave(Nave nave)
        {
            Naves.Add(nave);
            SaveChanges();
        }

        public Nave buscarNave(int idNave) => Naves.Find(idNave);

        public void editarNave(Nave nave)
        {
            Entry(nave).State = EntityState.Modified;
            SaveChanges();
        }

        public void eliminarNave(int idNave)
        {
            var nave = buscarNave(idNave);
            if (nave != null)
            {
                Naves.Remove(nave);
                SaveChanges();
            }
        }
        #endregion

        #region Métodos Experimentos
        public List<Experimento> mostrarExperimentos() => Experimentos.ToList();

        public void agregarExperimento(Experimento experimento)
        {
            Experimentos.Add(experimento);
            SaveChanges();
        }

        public Experimento buscarExperimento(string nombre) => Experimentos.Find(nombre);

        public void editarExperimento(Experimento experimento)
        {
            Entry(experimento).State = EntityState.Modified;
            SaveChanges();
        }

        public void eliminarExperimento(string nombre)
        {
            var e = buscarExperimento(nombre);
            if (e != null)
            {
                Experimentos.Remove(e);
                SaveChanges();
            }
        }
        #endregion

        #region Métodos Usuarios
        public List<Usuario> mostrarUsuarios() => Usuarios.ToList();

        public void agregarUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
            SaveChanges();
        }

        public Usuario buscarUsuario(int cedula) => Usuarios.Find(cedula);

        public void editarUsuario(Usuario usuario)
        {
            Entry(usuario).State = EntityState.Modified;
            SaveChanges();
        }

        public void eliminarUsuario(int cedula)
        {
            var u = buscarUsuario(cedula);
            if (u != null)
            {
                Usuarios.Remove(u);
                SaveChanges();
            }
        }

        public bool validarLogin(string username, string password)
        {
            return Usuarios.Any(u => u.Username == username
                                  && u.Password == password
                                  && u.Activo);
        }

        public void actualizarPassword(int cedula, string nuevoPassword)
        {
            var u = buscarUsuario(cedula);
            if (u != null)
            {
                u.Password = nuevoPassword;
                Entry(u).State = EntityState.Modified;
                SaveChanges();
            }
        }

        public Usuario login(Usuario user)
        {
            var usuarioLogueado = Usuarios.FirstOrDefault(u => u.Username == user.Username
                && u.Password == user.Password && u.Activo == true);
            if (usuarioLogueado != null)
                return usuarioLogueado;
            else throw new Exception("Datos de inicio de sesión incorrectos");
        }
        #endregion
    }
}
