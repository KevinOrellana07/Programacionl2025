using System;
using System.Collections.Generic;

namespace MiProyecto
{
    class Program
    {
        static Dictionary<string, string> usuarios = new Dictionary<string, string>();
        static Juego juego = new Juego();

        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Sistema de inicio de sesión");
                Console.WriteLine("2. Registrar puntuación de un juego");
                Console.WriteLine("3. Salir");
                Console.Write("Ingrese su opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuAutenticacion();
                        break;
                    case "2":
                        RegistrarPuntuacion();
                        break;
                    case "3":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intente nuevamente.");
                        break;
                }
            }
        }

        // Menú del sistema de autenticación
        static void MenuAutenticacion()
        {
            bool volver = false;

            while (!volver)
            {
                Console.WriteLine("\nSistema de autenticación:");
                Console.WriteLine("1. Registrarse");
                Console.WriteLine("2. Iniciar sesión");
                Console.WriteLine("3. Volver al menú principal");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        RegistrarUsuario();
                        break;
                    case "2":
                        IniciarSesion();
                        break;
                    case "3":
                        volver = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        // Función para registrar un usuario
        static void RegistrarUsuario()
        {
            Console.WriteLine("\nIngrese un nombre de usuario:");
            string nombreUsuario = Console.ReadLine();

            if (usuarios.ContainsKey(nombreUsuario))
            {
                Console.WriteLine("El nombre de usuario ya existe. Por favor, elija otro.");
                return;
            }

            Console.WriteLine("Ingrese una contraseña:");
            string contraseña = Console.ReadLine();

            usuarios.Add(nombreUsuario, contraseña);
            Console.WriteLine("Usuario registrado exitosamente.");
        }

        // Función para iniciar sesión
        static void IniciarSesion()
        {
            Console.WriteLine("\nIngrese su nombre de usuario:");
            string nombreUsuario = Console.ReadLine();

            if (!usuarios.ContainsKey(nombreUsuario))
            {
                Console.WriteLine("Usuario no encontrado. Regístrese primero.");
                return;
            }

            Console.WriteLine("Ingrese su contraseña:");
            string contraseña = Console.ReadLine();

            if (usuarios[nombreUsuario] == contraseña)
            {
                Console.WriteLine("Inicio de sesión exitoso. ¡Bienvenido!");
            }
            else
            {
                Console.WriteLine("Contraseña incorrecta.");
            }
        }

        // Función para registrar puntuaciones en el juego
        static void RegistrarPuntuacion()
        {
            Console.WriteLine("\nIngrese el nombre del jugador:");
            string nombreJugador = Console.ReadLine();

            Console.WriteLine("Ingrese la puntuación:");
            if (int.TryParse(Console.ReadLine(), out int puntaje))
            {
                juego.RegistrarPuntaje(puntaje, nombreJugador);
            }
            else
            {
                Console.WriteLine("Puntuación no válida.");
            }
        }
    }

    // Clase para el juego y puntuaciones
    class Juego
    {
        private int puntajeMaximo;
        private string jugadorRecord;

        public Juego()
        {
            puntajeMaximo = 0;
            jugadorRecord = "Nadie";
        }

        public void RegistrarPuntaje(int puntaje, string nombreJugador)
        {
            if (puntaje > puntajeMaximo)
            {
                Console.WriteLine($"\nNueva puntuación más alta: {puntaje}");
                Console.WriteLine($"Lograda por: {nombreJugador}");
                puntajeMaximo = puntaje;
                jugadorRecord = nombreJugador;
            }
            else
            {
                Console.WriteLine($"\nLa puntuación más alta sigue siendo {puntajeMaximo}, lograda por {jugadorRecord}.");
            }
        }
    }
}
