
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DoubleList;

public class DoublyLinkedList<T> where T : IComparable<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _tail = null;
        _head = null;
    }

    public void Adicionar(T data)
    {
        DoubleNode<T> newNode = new DoubleNode<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        if (newNode.Data.CompareTo(_head.Data) <= 0)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
            return;
        }

        if (newNode.Data.CompareTo(_tail.Data) >= 0)
        {
            _tail.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
            return;
        }

        DoubleNode<T> current = _head;
        while (current.Next != null && newNode.Data.CompareTo(current.Next.Data) > 0)
        {
            current = current.Next;
        }

        newNode.Next = current.Next;
        newNode.Prev = current;
        if (current.Next != null)
        {
            current.Next.Prev = newNode;
        }
        current.Next = newNode;
    }

    // metodo me devuelve la lista hacia adelante
    public string MostrarAdelante()
    {
        var output = string.Empty;
        var current = _head;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Next;
        }
        return output.Length > 0 ? output.Substring(0, output.Length - 5) : output;
    }

    public string MostrarAtras() // metodo me devuelve la lista hacia atras
    {
        var output = string.Empty;
        var current = _tail;
        while (current != null)
        {
            output += $"{current.Data} <=> ";
            current = current.Prev;
        }
        return output.Length > 0 ? output.Substring(0, output.Length - 5) : output;
    }
    public bool Existe(T data)
    {
        DoubleNode<T>? current = _head;
        while (current != null)
        {
            if (current.Data != null && current.Data.Equals(data))
            {
                return true; // Se encontró el elemento
            }
            current = current.Next;
        }
        return false; // No se encontró el elemento después de recorrer toda la lista

    }
    public void OrdenarDescendente()
    {
        if (_head == null) return; // Lista vacía
        bool swapped;
        do
        {
            swapped = false;
            var current = _head;
            while (current != null && current.Next != null)
            {
                if (Comparer<T>.Default.Compare(current.Data, current.Next.Data) < 0)
                {
                    // Intercambiar los datos
                    var temp = current.Data;
                    current.Data = current.Next.Data;
                    current.Next.Data = temp;
                    swapped = true;
                }
                current = current.Next;
            }
        } while (swapped);
    }
    public void MostrarModa()
    {
        if (_head == null) return; // Lista vacía
        var current = _head;
        var count = 0;
        var maxCount = 0;
        var moda = default(T);
        while (current != null)
        {
            count = 1;
            var innerCurrent = current.Next;
            while (innerCurrent != null)
            {
                if (current.Data != null && current.Data.Equals(innerCurrent.Data))
                {
                    count++;
                }
                innerCurrent = innerCurrent.Next;
            }
            if (count > maxCount)
            {
                maxCount = count;
                moda = current.Data;
            }
            current = current.Next;
        }
        Console.WriteLine($"La moda es: {moda}");
    }
    public void MostrarGrafico()
    {
        if (_head == null)
        {
            Console.WriteLine("La lista está vacía, no hay gráfico para mostrar.");
            return;
        }

        Dictionary<T, int> frecuencia = new Dictionary<T, int>();
        DoubleNode<T>? current = _head;

        // Contar la frecuencia de cada elemento
        while (current != null)
        {
            if (current.Data != null)
            {
                if (frecuencia.ContainsKey(current.Data))
                {
                    frecuencia[current.Data]++;
                }
                else
                {
                    frecuencia[current.Data] = 1;
                }
            }
            current = current.Next;
        }

        if (frecuencia.Count == 0)
        {
            Console.WriteLine("No hay elementos en la lista para generar el gráfico.");
            return;
        }

        Console.WriteLine("\nGráfico de Frecuencia:");
        foreach (KeyValuePair<T, int> par in frecuencia.OrderBy(key => key.Key)) // Ordenar por elemento para una mejor visualización
        {
            Console.WriteLine($"{par.Key}: {new string('*', par.Value)}");
        }
        Console.WriteLine();
    }
    public void EliminarUnaOcurrencia(T data)
    {
        DoubleNode<T>? current = _head;

        while (current != null)
        {
            if (current.Data != null && current.Data.Equals(data))
            {
                // Se encontró el nodo a eliminar

                if (current == _head)
                {
                    _head = _head.Next;
                    if (_head != null)
                    {
                        _head.Prev = null;
                    }
                    if (_head == null) // La lista quedó vacía
                    {
                        _tail = null;
                    }
                }
                else if (current == _tail)
                {
                    _tail = _tail.Prev;
                    if (_tail != null)
                    {
                        _tail.Next = null;
                    }
                    if (_tail == null) // La lista quedó vacía
                    {
                        _head = null;
                    }
                }
                else
                {
                    current.Prev.Next = current.Next;
                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                }
                return; // Se eliminó la primera ocurrencia, podemos salir
            }
            current = current.Next;
        }

        // Si el bucle termina y no se encontró el elemento
        Console.WriteLine($"El elemento '{data}' no se encontró en la lista para eliminar.");
    }
    public void EliminarTodasLasOcurrencias(T data)
    {
        DoubleNode<T>? current = _head;

        while (current != null)
        {
            if (current.Data != null && current.Data.Equals(data))
            {
                // Se encontró una ocurrencia para eliminar

                if (current == _head)
                {
                    _head = _head.Next;
                    if (_head != null)
                    {
                        _head.Prev = null;
                    }
                    if (_head == null) // La lista quedó vacía
                    {
                        _tail = null;
                    }
                    current = _head; // Importante: mover current a la nueva cabeza
                    continue; // Saltar al inicio del bucle para la siguiente verificación
                }
                else if (current == _tail)
                {
                    _tail = _tail.Prev;
                    if (_tail != null)
                    {
                        _tail.Next = null;
                    }
                    if (_tail == null) // La lista quedó vacía
                    {
                        _head = null;
                    }
                    break; // Ya no hay más nodos después de la cola
                }
                else
                {
                    current.Prev.Next = current.Next;
                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    current = current.Next; // Mover current al siguiente nodo
                    continue; // Saltar al inicio del bucle
                }
            }
            current = current.Next;
        }

        Console.WriteLine($"Se eliminaron todas las ocurrencias de '{data}' (si existían).");
    }
}
