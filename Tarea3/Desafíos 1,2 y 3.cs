using System;

namespace MiProyecto
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\nSeleccione una opción:");
                Console.WriteLine("1. Calcular promedio de ingresos");
                Console.WriteLine("2. Realizar operaciones matemáticas");
                Console.WriteLine("3. Sumar dos valores");
                Console.WriteLine("4. Salir");
                Console.Write("Ingrese su opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CalcularPromedio();
                        break;
                    case "2":
                        RealizarOperaciones();
                        break;
                    case "3":
                        RealizarSuma();
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intente nuevamente.");
                        break;
                }
            }
        }

        // Función para calcular promedio de ingresos
        static void CalcularPromedio()
        {
            Console.WriteLine("\nIngrese su nombre:");
            string nombreIngresado = Console.ReadLine();

            int numero1, numero2, numero3;

            Console.WriteLine("\nIngrese el primer ingreso:");
            numero1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el segundo ingreso:");
            numero2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el tercer ingreso:");
            numero3 = int.Parse(Console.ReadLine());

            double suma = numero1 + numero2 + numero3;
            double promedio = suma / 3;

            Console.WriteLine($"\nNombre: {nombreIngresado}\nSuma: {suma}\nPromedio: {promedio}");
        }

        // Función para realizar operaciones matemáticas
        static void RealizarOperaciones()
        {
            int num1, num2, resSuma, resResta, resMulti, resDivi;

            Console.WriteLine("\nIngresa el primer número:");
            num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ingresa el segundo número:");
            num2 = Convert.ToInt32(Console.ReadLine());

            resSuma = num1 + num2;
            resResta = num1 - num2;
            resMulti = num1 * num2;
            resDivi = (num2 != 0) ? num1 / num2 : 0;

            Console.WriteLine($"\nSuma: {resSuma}\nResta: {resResta}\nMultiplicación: {resMulti}\nDivisión: {resDivi}");
        }

        // Función para sumar dos valores con validación
        static void RealizarSuma()
        {
            try
            {
                int resultado = SumarDosValores();
                Console.WriteLine($"La suma de los dos valores es: {resultado}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Operación completada.");
            }
        }

        // Función auxiliar para la suma con validaciones
        static int SumarDosValores()
        {
            int valor1, valor2;

            Console.WriteLine("\nIngrese el primer valor:");
            string input1 = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input1))
                throw new ArgumentException("El valor ingresado no puede estar en blanco.");

            Console.WriteLine("Ingrese el segundo valor:");
            string input2 = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input2))
                throw new ArgumentException("El valor ingresado no puede estar en blanco.");

            try
            {
                valor1 = Convert.ToInt32(input1);
                valor2 = Convert.ToInt32(input2);
                return valor1 + valor2;
            }
            catch (FormatException)
            {
                throw new ArgumentException("Los valores ingresados deben ser números enteros.");
            }
        }
    }
}
