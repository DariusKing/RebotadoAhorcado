using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.;

namespace Ahorcado
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Ahorcado V0.1\nPresione cualquier tecla para empezar");
            Console.ReadKey();
            Menu();

        }
        
        
        public static void Menu()
        {

            bool tempbool = true;
            while (tempbool)
            {
                Console.Clear();
                Console.WriteLine("Elige la modalidad de juego");
                Console.WriteLine("1. Solo");
                Console.WriteLine("2. Multijugador local");
                Console.WriteLine("3. Salir");
                ConsoleKeyInfo seleccion = Console.ReadKey();
                

                {
                    if (seleccion.KeyChar == '1')
                    {
                        Solo();
                        tempbool = false;
                    }
                    else if (seleccion.KeyChar == '2')
                    {
                        Multijugador();
                        tempbool = false;
                    }
                    else if(seleccion.KeyChar == '3')
                    {
                        Environment.Exit(1);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\aEliga una opcion valida");
                    }
                }
            }

        }

        public static void Solo()
        {

        }
        public static void Multijugador()
        {
            //Declaracion de variables
            int counter = 0;
            bool tempbool4 = false;
            bool tempbool2 = false;
            bool tempbool3 = false;
            bool tempbool = false;
            int vidas;
            ConsoleKeyInfo adivinar;
            string palabra = " ";
            char[] palabraArray = new char[1];
            StringBuilder mostrarPalabra;
            int letrasAdivinadas = 0;
            //variable que contiene caracteres de la a a la z
            char[] caracteres = new char[53];
            for (int i = 0; i <= 25; i++)
            {
                caracteres[i] = (char)(i + 65);
                caracteres[i + 26] = (char)(i + 97);
            }
            caracteres[51] = 'ñ';
            caracteres[52] = 'Ñ';
            Console.Clear();

            //Instrucciones
            Console.WriteLine("Instrucciones:\nUn jugador va a ingresar una palabra y el otro jugador tiene que adivinarla.");
            Console.WriteLine("El primer jugador tambien decide la cantidad de vidas que le dara al otro jugador");
            Console.WriteLine("Presione cualquier tecla para empezar el juego");
            Console.ReadKey();
            //Ingresar palabra y vidas
            tempbool2 = true;
            tempbool3 = true;
            Console.Clear();
            while (tempbool3)
            {
                if(counter >= palabraArray.Length)
                {
                    tempbool3 = false;
                }
                while (tempbool2)
                {
                    Console.Write("Ingrese la palabra: ");
                    palabra = Console.ReadLine();
                    palabraArray = palabra.ToLower().ToCharArray();
                    tempbool2 = false;
                }
                //Evaluacion de la palabra si solo contiene caracteres de la a a la z
                for(int i = 0; i < palabraArray.Length; i++ )
                {
                   if (caracteres.Contains(palabraArray[i]))
                    {
                        counter++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese un caracter valido");
                        tempbool2 = true;
                        counter = 0;
                        break;
                    }
                }

            }
            //Transformar los caracteres de la palabra a @
            mostrarPalabra = new StringBuilder(palabraArray.Length);
            for (int i = 0; i < palabraArray.Length; i++)
            {
                mostrarPalabra.Append('@');
            }

            Console.Write("\nIngrese la cantidad de vidas: ");
            int.TryParse(Console.ReadLine(), out vidas);

            //Inicio del juego
            Console.Clear();
            tempbool = true;
            while (tempbool && vidas !=0) //loop que mantiene dentro del juego
            {
                tempbool4 = true;
                while (tempbool4) //loop que permite evaluar las entradas del teclado
                {
                    //Condicion de victoria
                    if (letrasAdivinadas == palabraArray.Length)
                    {
                        Console.Clear();
                        Console.WriteLine("Que bien! Has ganado el juego");
                        tempbool = false;
                        break;
                    }
                    //Desarrollo del juego
                    Console.WriteLine("Palabra actual: ");
                    Console.Write(mostrarPalabra);
                    Console.WriteLine("\nVidas: " + vidas);
                    Console.WriteLine("Ingrese un caracter para adivinar: ");
                    adivinar = Console.ReadKey();
                    Console.Clear();
                    if (!caracteres.Contains(adivinar.KeyChar))
                    {
                        Console.WriteLine("Ingrese un caracter valido");
                        break;
                    }

                    if (palabraArray.Contains(Char.ToLower(adivinar.KeyChar)))
                    {
                        Console.WriteLine("Que bien! Has acertado una letra");
                        for (int i = 0; i < palabraArray.Length; i++)

                        {
                            if (palabraArray[i] == Char.ToLower(adivinar.KeyChar))
                            {
                                mostrarPalabra[i] = palabraArray[i];
                                letrasAdivinadas++;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\aQue mal! No has acertado");
                        vidas--;
                    }
                }
            }
            Console.WriteLine("Presione una letra para volver al menu principal");
            Console.ReadKey();
            Menu();
        }
    }
}




