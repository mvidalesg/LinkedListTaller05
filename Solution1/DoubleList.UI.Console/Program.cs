using System;
using DoubleList;
using System.ComponentModel.Design;

namespace DoubleList
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<string> lista = new DoublyLinkedList<string>(); // Por ahora usaremos string, podemos cambiarlo después si es necesario

            int opcion = -1;

            while (opcion != 0)
            {
                Console.WriteLine("\nMenú de Lista Doblemente Ligada:");
                Console.WriteLine("1. Adicionar elemento (orden ascendente)");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atrás");
                Console.WriteLine("4. Ordenar descendentemente");
                Console.WriteLine("5. Mostrar la(s) moda(s)");
                Console.WriteLine("6. Mostrar gráfico");
                Console.WriteLine("7. Existe elemento");
                Console.WriteLine("8. Eliminar una ocurrencia");
                Console.WriteLine("9. Eliminar todas las ocurrencias");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese el elemento a adicionar: ");
                            string? elementoAdicionar = Console.ReadLine();
                            if (!string.IsNullOrEmpty(elementoAdicionar))
                            {
                                lista.Adicionar(elementoAdicionar);
                                Console.WriteLine($"Elemento '{elementoAdicionar}' adicionado.");
                            }
                            else
                            {
                                Console.WriteLine("No se ingresó ningún elemento.");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Lista hacia adelante: " + lista.MostrarAdelante());
                            break;
                        case 3:
                            Console.WriteLine("Lista hacia atrás: " + lista.MostrarAtras());
                            break;
                        case 4:
                            lista.OrdenarDescendente();
                            Console.WriteLine("Lista ordenada descendentemente.");
                            break;
                        case 5:
                            lista.MostrarModa();
                            break;
                        case 6:
                            lista.MostrarGrafico();
                            break;
                        case 7:
                            Console.Write("Ingrese el elemento a buscar: ");
                            string? elementoBuscar = Console.ReadLine();
                            if (!string.IsNullOrEmpty(elementoBuscar))
                            {
                                if (lista.Existe(elementoBuscar))
                                {
                                    Console.WriteLine($"El elemento '{elementoBuscar}' existe en la lista.");
                                }
                                else
                                {
                                    Console.WriteLine($"El elemento '{elementoBuscar}' no existe en la lista.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No se ingresó ningún elemento a buscar.");
                            }
                            break;
                        case 8:
                            Console.Write("Ingrese el elemento a eliminar (una ocurrencia): ");
                            string? elementoEliminarUna = Console.ReadLine();
                            if (!string.IsNullOrEmpty(elementoEliminarUna))
                            {
                                lista.EliminarUnaOcurrencia(elementoEliminarUna);
                            }
                            else
                            {
                                Console.WriteLine("No se ingresó ningún elemento a eliminar.");
                            }
                            break;
                        case 9:
                            Console.Write("Ingrese el elemento a eliminar (todas las ocurrencias): ");
                            string? elementoEliminarTodas = Console.ReadLine();
                            if (!string.IsNullOrEmpty(elementoEliminarTodas))
                            {
                                lista.EliminarTodasLasOcurrencias(elementoEliminarTodas);
                            }
                            else
                            {
                                Console.WriteLine("No se ingresó ningún elemento a eliminar.");
                            }
                            break;
                        case 0:
                            Console.WriteLine("Saliendo del programa.");
                            break;
                        default:
                            Console.WriteLine("Opción inválida. Por favor, intente de nuevo.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida. Por favor, ingrese un número.");
                }
            }
        }
    }
}