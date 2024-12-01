using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

public class Asignatura
{
    public string Nombre;
    public double Calificacion;

    public Asignatura(string nombre, double calificacion)
    {
        Nombre = nombre;
        Calificacion = calificacion;
    }
}

public class RegistroAcademico
{
    public string NombreEstudiante;
    public string NumeroEstudiante;
    public List<Asignatura> Asignaturas = new List<Asignatura>();

    public RegistroAcademico(string nombreEstudiante, string numeroEstudiante)
    {
        NombreEstudiante = nombreEstudiante;
        NumeroEstudiante = numeroEstudiante;
    }

    public void AñadirAsignatura(string nombre, double calificacion)
    {
        Asignaturas.Add(new Asignatura(nombre, calificacion));
    }

    public void ImprimirInformacion()
    {
        Console.WriteLine($"Nombre: {NombreEstudiante}");
        Console.WriteLine($"Número: {NumeroEstudiante}");
        Console.WriteLine("Asignaturas:");
        foreach (var asignatura in Asignaturas)
        {
            Console.WriteLine($"- {asignatura.Nombre}: {asignatura.Calificacion}");
        }
    }

    public double CalcularPromedio()
    {
        double suma = 0;
        foreach (var asignatura in Asignaturas)
        {
            suma += asignatura.Calificacion;
        }
        return Asignaturas.Count > 0 ? suma / Asignaturas.Count : 0;
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Ingrese el nombre del estudiante:");
        string nombreEstudiante = Console.ReadLine();

        Console.WriteLine("Ingrese el número del estudiante:");
        string numeroEstudiante = Console.ReadLine();

        RegistroAcademico registro = new RegistroAcademico(nombreEstudiante, numeroEstudiante);

        while (true)
        {
            Console.WriteLine(" Menú ");
            Console.WriteLine("1. Añadir Asignatura");
            Console.WriteLine("2. Imprimir Información");
            Console.WriteLine("3. Calcular Promedio");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                Console.WriteLine("Nombre de la asignatura:");
                string nombreAsignatura = Console.ReadLine();

                Console.WriteLine("Calificación (0-100):");
                double calificacion;
                while (!double.TryParse(Console.ReadLine(), out calificacion) || calificacion < 0 || calificacion > 100)
                {
                    Console.WriteLine("Ingrese una calificación válida entre 0 y 100:");
                }

                registro.AñadirAsignatura(nombreAsignatura, calificacion);
                Console.WriteLine("Asignatura añadida.");
            }
            else if (opcion == "2")
            {
                registro.ImprimirInformacion();
            }
            else if (opcion == "3")
            {
                double promedio = registro.CalcularPromedio();
                Console.WriteLine($"Promedio: {promedio:F2}");
            }
            else if (opcion == "4")
            {
                Console.WriteLine("Saliendo...");
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida. Intente de nuevo.");
            }
        }
    }
}