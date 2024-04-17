using System.Globalization;
using ConsoleTables;


namespace Ejercicio02Practico8.Consola
{
    internal class Program
    {
        const double Min_Velocidad = 100;
        const double Max_Velocidad = 300;
        static void Main(string[] args)
        {
            double[] velocidades = new double[5];
            bool seguir = true;
            do
            {
                MostrarMenu();
                int OpcionSeleccionada = PedirIntEnRango("Seleccione:", 1, 7);
                switch (OpcionSeleccionada)
                {
                    case 1:
                        GenerarVelocidades(velocidades);
                        break;
                    case 2:
                        ListadoMillas(velocidades);
                        break;
                    case 3:
                        InfVelocidadMayorMenor(velocidades);
                        break;
                    case 4:
                        ModificarDatos(velocidades);
                        break;
                    case 5:
                        MayoresAlPromedio(velocidades);
                        break;
                    case 6:
                        MostrarInferioresAlPromedio(velocidades);
                        break;
                    case 7:
                        seguir = false;
                        break;
                }
            } while (seguir);
            Console.WriteLine("Fin de la Aplicacion");
        }

        private static void MostrarInferioresAlPromedio(double[] velocidades)
        {
            var promedio = HallarVelocidadMedia(velocidades);
            Console.Clear();
            Console.WriteLine("Mostrar Inferiores al Promedio");
            Console.WriteLine($"Promedio={promedio.ToString("N2")}");
            var tabla = new ConsoleTable("Velocidades");
            foreach (var velEnArray in velocidades)
            {
                if (velEnArray < promedio)
                {
                    tabla.AddRow(velEnArray);
                }
            }
            Console.WriteLine(tabla.ToString());
            TareaFinalizada("Inferiores al promedio...");

        }

        private static void MayoresAlPromedio(double[] velocidades)
        {
            var promedio = HallarVelocidadMedia(velocidades);
            Console.Clear();
            Console.WriteLine("Marcar superiores al Promedio");
            Console.WriteLine($"Promedio= {promedio.ToString("N2")}");
            var tabla = new ConsoleTable("Velocidades", "Sup. al Prom?");
            foreach (var velEnArray in velocidades)
            {
                if (velEnArray > promedio)
                {
                    tabla.AddRow(velEnArray, "*");
                }
                else
                {
                    tabla.AddRow(velEnArray, "");
                }
            }
            Console.WriteLine(tabla.ToString());
            TareaFinalizada("Superiores al promedio...");
        }

        private static void InfVelocidadMayorMenor(double[] velocidades)
        {
            var VelocidadMin = HallarVelocidadMin(velocidades);
            var VelocidadMax = HallarVelocidadMax(velocidades);
            var VelocidadMedia = HallarVelocidadMedia(velocidades);
            Console.WriteLine($"La velocidad Maxima es: {VelocidadMax}");
            Console.WriteLine($"La velocidad Minima es: {VelocidadMin}");
            Console.WriteLine($"La velocidad Media es: {VelocidadMedia}");
            Console.WriteLine();
            TareaFinalizada("Datos estadisticos...");
        }

        private static double HallarVelocidadMedia(double[] velocidades)
        {
            double promedio = 0;
            foreach(var velEnArray in velocidades)
            {
                promedio += velEnArray; 
            }
            return promedio/velocidades.Length;
        }

        private static double HallarVelocidadMax(double[] velocidades)
        {
            double Maxima = Min_Velocidad;
            foreach(var velEnArray  in velocidades)
            {
                if(velEnArray > Maxima)
                {
                    Maxima = velEnArray;
                }
            }
            return Maxima;
        }

        private static double HallarVelocidadMin(double[] velocidades)
        {
            double Minima = Max_Velocidad;
            foreach (var velEnAray in velocidades)
            {
                if (velEnAray < Minima)
                {
                    Minima = velEnAray;
                }
            }
            return Minima;
        }

        private static void ModificarDatos(double[] velocidades)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Modificación de Datos");
                ListadoMillas(velocidades);

                var index = PedirIntEnRango("Ingrese un índice de elemento:", 1, velocidades.Length);
                Console.WriteLine($"Valor anterior:{velocidades[index - 1]}");

                double nuevaVel;
                do
                {
                    nuevaVel = PedirDoubleEnRango("Ingrese la nueva Velocidad:",
                            Min_Velocidad, Max_Velocidad);
                } while (false);
                velocidades[index - 1] = nuevaVel;
                var sigueModificando = PedirCharEnRango("¿Desea modificar otra?(S/N)", 's', 'n');
                if (sigueModificando == "N")
                {
                    break;
                }
            } while (true);
            Console.WriteLine();
            TareaFinalizada("Modificación finalizada...");
        }

        private static void ListadoMillas(double[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("Listado de velocidades");
            var tabla = new ConsoleTable("Velocidades", "millas");
            foreach (double velEnArray in velocidades)
            {
                var millas = ConvertToMillas(velEnArray);
                tabla.AddRow(velEnArray, millas);
            }
            Console.WriteLine(tabla.ToString());
            TareaFinalizada("Listado Finalizado");
        }

        private static double ConvertToMillas(double velEnArray)=> velEnArray * 0.621371;

        private static void GenerarVelocidades(double[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("Ingreso de velocidades");
            for (int i = 0; i < velocidades.Length; i++)
            {
                double velIngresada = PedirDoubleEnRango("Ingrese una velocidad expresada en km/h", Min_Velocidad, Max_Velocidad);
                velocidades[i] = velIngresada;
            }
            TareaFinalizada("Ingerso finalizado");
        }

        private static void ListarVelocidades(double[] velocidades)
        {
            Console.Clear();
            Console.WriteLine("Listado de Velocidades a Milas");
            foreach (double velEnArray in velocidades)
            {
                Console.WriteLine(velEnArray);
            }
            TareaFinalizada("Listado Finalizado");
        }

        private static void TareaFinalizada(string mensaje)
        {
            Console.WriteLine($"{mensaje}...ENTER para continuar");
            Console.ReadLine();
        }

        private static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("1-Ingresar Velocidades");
            Console.WriteLine("2-Listado Convertido a Millas");
            Console.WriteLine("3-Datos Estadisticos");
            Console.WriteLine("4-Modificar Datos");
            Console.WriteLine("5-Ver Superior Al Promedio");
            Console.WriteLine("6-Ver Inferior Al Promedio");
            Console.WriteLine("7-Salir");
        }


        private static string PedirString(String mensaje)
        {
             string? cX;
             do
             {
                Console.Write(mensaje);
                 cX = Console.ReadLine();
                 if (!string.IsNullOrEmpty(cX) || !string.IsNullOrWhiteSpace(cX))
                 {
                     break;
                 }
                 Console.WriteLine("No ingreso nada por la consola");
             } while (true);
              return cX;
        }

            private static int PedirInt(string mensaje)
            {
                int nro;
                string cX;
                do
                {
                    cX = PedirString(mensaje);
                    if (int.TryParse(cX, out nro))
                    {
                        break;
                    }
                    Console.WriteLine("Numero no valido");
                } while (true);
                return nro;
            }

            private static int PedirIntEnRango(string mensaje, int valorMenor, int valorMayor)
            {
                bool error = true;
                int valorInt;
                string? cX;
                do
                {
                    cX = PedirString(mensaje);
                    if (!int.TryParse(cX, out valorInt))
                    {
                        Console.WriteLine("Error al intentar ingresar un valor entero");
                    }
                    else if (valorInt < valorMenor || valorInt > valorMayor)
                    {
                        Console.WriteLine($"ERROR valor fuera del rango permitido {valorInt}");
                    }
                    else
                    {
                        error = false;
                    }
                } while (error);
                return valorInt;
            }

            private static int PedirDoubleEnRango(string mensaje, double valorMenor, double valorMayor)
            {
                bool error = true;
                double valorDouble;
                string? cX;
                do
                {
                    cX = PedirString(mensaje);
                    if (!double.TryParse(cX, out valorDouble))
                    {
                        Console.WriteLine("Error al intentar ingresar un valor entero");
                    }
                    else if (valorDouble < valorMenor || valorDouble > valorMayor)
                    {
                        Console.WriteLine($"ERROR valor fuera del rango permitido {valorDouble}");
                    }
                    else
                    {
                        error = false;
                    }
                } while (error);

                return (int)valorDouble;
            }

            public static string PedirCharEnRango(string mensaje, char char1, char char2)
            {
                char cX;
                do
                {

                    Console.Write(mensaje);
                    var tecla = Console.ReadKey();
                    if (tecla.KeyChar.ToString().ToUpper() == char1.ToString().ToUpper()
                        || tecla.KeyChar.ToString().ToUpper() == char2.ToString().ToUpper())
                    {
                        cX = tecla.KeyChar;
                        break;
                    }
                    Console.WriteLine("Tecla presionada no válida");
                } while (true);
                return cX.ToString().ToUpper();

            }
    }
}

