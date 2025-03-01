//**********************************************************************************//
//**********        Laboratorio de los Avenger: El codigo de Tony        ***********//
//**********************************************************************************//
//** Hecho por el estudiante: Diego E.                                            **//
//**********************************************************************************//



using System;
using System.IO;
using System.Threading; 

class ControladorDeArchivos // Esta clase contiene todas las funciones que son requisitos para el progama requerido
{
    static string DirectorioBase = @"C:\LaboratorioAvengers";
    static string ArchivoInventos = Path.Combine(DirectorioBase, "inventos.txt"); // Se hizo  estas dos variables como estatic para sean parte de la clase 
    
    // Aqui esta la funcion De crear archivo
    static public void CrearArchivo()
    {
        Console.WriteLine("*****  Crear Archivo  *****");
        Console.WriteLine("\nEstas en la seccion de crear Crear Archivo");
        Console.WriteLine("Tony nos dijo que crearamos el archivo plano inventos.txt cuando seleccionaras esta opcion\n"); // Requisito del programa



        if (!File.Exists(ArchivoInventos))
        {
            try // Manejo de oxcepciones
            {
                string contenido = "******* INVENTOS *******";
                File.WriteAllText(ArchivoInventos, contenido);
                Console.WriteLine("\nArchivo creado en: " + DirectorioBase);
            }
            catch (UnauthorizedAccessException err)
            {
                Console.WriteLine("NO tienes permisos " + err.Message);
            }
            catch (IOException err)
            {
                Console.WriteLine("Hubo un error de IO "+err.Message);
            }
            catch (Exception err)
            {
                Console.WriteLine("Ups, ultron no te dejo hacerlo "+err.Message);
            }
        }
        else
        {
            Console.WriteLine("El archivo ya existe");
        }

    }

    // Aqui esta la funcion De Agregar Invento
    public static void AgregarINvento()
    {
        Console.WriteLine("*****  Agregar Invento  *****");

        Console.WriteLine("\nUsuario puedes agregar el invento, escribelo porfavor: ");

        try
        {
            // Verificar cuántos inventos ya existen en el archivo
            int contador = 1;
            if (File.Exists(ArchivoInventos))
            {
                string[] lineas = File.ReadAllLines(ArchivoInventos);
                contador = lineas.Skip(1).Count() + 1; // Contamos las líneas y sumamos 1 para el siguiente número y tambien saltamos una linea para el titulo
            }

            string? invento = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(invento)) // Verificamos que no sea vacío
            {
                File.AppendAllText(ArchivoInventos, contador + ". " + invento + "\n");
                Console.WriteLine("Invento agregado con éxito.");
            }
            else
            {
                Console.WriteLine("No ingresaste ningún invento.");
            }
        }
        catch (Exception err)
        {
            Console.WriteLine("Ocurrió un error: " + err.Message);
        }
    }


    // Aqui esta la funcion De Leer Linea Por Linea
    public static void LeerLineaPorLinea()
    {
        Console.WriteLine("*****  Leer lina por Linea  *****");
        Console.WriteLine("\nEstas en la funcion de Leer Linea por linea!");

        Console.WriteLine("Se leera el Contenido del texto linea por linea : b");
        
        try
        {
            string[] Contenido = File.ReadAllLines(ArchivoInventos);
            foreach (string contenido in Contenido) { Console.WriteLine(contenido); }
            Console.WriteLine("\n");

        }catch (Exception err)
        {
            Console.WriteLine("Ocurrio un error: "+err.Message+"\n");
        }
    }

    // Aqui esta la funcion De Leer Todo EL Texto
    public static void LeerTodoElTexto()
    {
        Console.Clear();
        Console.WriteLine("*****  Leer todo el Texto del archivo  *****");

        Console.WriteLine("Hey usuario! Seleccionaste la opcion de Leer todo el texto");
        Console.WriteLine("Se mostrara el texto por completo en un string");

        try
        {
            string Texto = File.ReadAllText(ArchivoInventos);
            Console.WriteLine(Texto);
        }
        catch (Exception err)
        {
            Console.WriteLine("Ups algo salio mal, quiza fue culpa de ultron" + err.Message);
        }

    }

    // Aqui esta la funcion De Copiar Archivo
    public static void CopiarArchivo()
    {
        Console.Clear();
        Console.WriteLine("***** Copiar Archivos *****");
        ListarArchivos();
        Console.WriteLine("\nPara poder Copiar algun archivo o carpeta, te mostre la lista de estos ");
        Console.WriteLine("Te enseno esto para que puedas copiar la RUTA ");

        Console.WriteLine("\nA continuacion Ingrese la Ruta del archivo ORIGINAL que quiera copiar : ");
        string? ArchivoACopiar = Console.ReadLine();

        Console.WriteLine("\nIngrese la Ruta de DESTINO del archivo que quiera copiar : ");
        string? ArchivoDestino = Console.ReadLine();
        try
        {
            if (Directory.Exists(ArchivoDestino))
            {
                string? nombreArchivo = Path.GetFileName(ArchivoACopiar);
                ArchivoDestino = Path.Combine(ArchivoDestino, nombreArchivo);
            }
        }
        catch(Exception err)
        {
            Console.WriteLine("ups, ocurrio un error :" + err.Message);
        }

        try
        {
            File.Copy(ArchivoACopiar, ArchivoDestino);
            Console.WriteLine("Se copio el archivo con exito");
        }
        catch (Exception err) 
        {
            Console.WriteLine("ups, ocurrio algo mas" + err.Message);
        }
    }

    // Aqui esta la funcion De Mover Archivo
    public static void MoverArchivo()
    {
        Console.WriteLine("\nTe mostrare una lista de los archivos en el directorio");
        ListarArchivos();

        Console.WriteLine("\nIngrese la Ruta del archivo ORIGINAL que quiera copiar");
        string? ArchivoACopiar = Console.ReadLine();

        Console.WriteLine("\nIngrese la Ruta de DESTINO del archivo que quiera copiar");
        string? ArchivoDestino = Console.ReadLine();
        try
        {
            if (Directory.Exists(ArchivoDestino))
            {
                string? nombreArchivo = Path.GetFileName(ArchivoACopiar);
                ArchivoDestino = Path.Combine(ArchivoDestino, nombreArchivo);
            }
        }
        catch (Exception err)
        {
            Console.WriteLine("ups, ocurrio un error : " + err.Message);
        }

        try
        {
            File.Move(ArchivoACopiar, ArchivoDestino);
            Console.WriteLine("Se movio el archivo con exito");
        }
        catch (Exception err)
        {
            Console.WriteLine("ups, ocurrio algo mas: " + err.Message);
        }
    }

    // Aqui esta la funcion De Crear Carpeta
    public static void CrearCarpeta()
    {
        Console.Clear();
        Console.WriteLine("***** Crear Carpeta *****");
        string? NombreCarpetaNueva;
        do
        {
            Console.WriteLine("Ingrese el nombre de la carpeta que quiera crear (no puede estar vacio) :");
            NombreCarpetaNueva = Console.ReadLine();
            
        }while (string.IsNullOrEmpty(NombreCarpetaNueva));

        string? CarpetaNueva = Path.Combine(DirectorioBase, NombreCarpetaNueva);

        if (!Directory.Exists(CarpetaNueva))
        {
            try
            {
                Directory.CreateDirectory(CarpetaNueva);
                Console.WriteLine($"La carpeta {NombreCarpetaNueva} se creado exitosamente ");
            }catch(Exception err)
            {
                Console.WriteLine("Hubo un error, pueda que Ultron tenga que ver"+err.Message);
            }

        }
        else
        {
            Console.WriteLine("La carpeta ya existe");
        }
    }

    // Aqui esta la funcion De Listar Archivos
    public static void ListarArchivos()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" Listado de archivos y carpetas ");
        if (Directory.Exists(DirectorioBase))
        {
            string[] Carpetas = Directory.GetDirectories(DirectorioBase,"*",SearchOption.AllDirectories);
            string[] Archivos = Directory.GetFiles(DirectorioBase,"*",SearchOption.AllDirectories);

            Console.WriteLine("\nCarpetas encontradas: \n");

            if (Carpetas.Length == 0)
            {
                Console.WriteLine("No se encontraron carpetas en el directorio.");
            }
            else
            {
                foreach (string Carpeta in Carpetas)
                {
                    Console.WriteLine(Path.GetFileName(Carpeta) + " - Ruta: " + Carpeta);
                }
            }

            Console.WriteLine("\nArchivos encontrados (Pueden repetirse archivos si se encuentran en otras carpetas): \n");

            if (Archivos.Length == 0)
            {
                Console.WriteLine("No se encontraron archivos en el directorio.");
            }
            else
            {
                foreach (string Archivo in Archivos)
                {
                    Console.WriteLine(Path.GetFileName(Archivo) + " - Ruta: " + Archivo);
                }
            }
        }
        else
        {
            Console.WriteLine("El directorio no existe");
        }
        Console.ResetColor();
    }

    // Aqui esta la funcion De Eliminar Archivo
    public static void EliminarArchivo()
    {
        Console.WriteLine("****** Eliminar Archivos ******");
        ListarArchivos();

        Console.WriteLine("\nUsuario estas en la opcion eliminar archivos, haz lo siguiente: ");
        Console.WriteLine("Ingrese La Ruta del archivo a eliminar");

        string? Archivoeliminar = Console.ReadLine();

        if (!File.Exists(Archivoeliminar))
        {
            Console.WriteLine("El archivo no existe. No se puede eliminar.");
            return;
        }

        try // Aqui hay manejo de excepciones
        {
            File.Delete(Archivoeliminar); Console.WriteLine($"El archivo {Archivoeliminar} ha sido eliminado con exito");
        }catch (FileNotFoundException e) 
        { 
            Console.WriteLine(" El sistema NO a encontrado el archivo a eliminar, quiza el Ultron tiene que ver al respecto:"+e.Message);
        }
        catch (UnauthorizedAccessException e)
        {
            Console.WriteLine(" Hey! es peligroso que cualquier persona tenga acceso, no se te permite borrar sin la autorizacion requierida" + e.Message);
        }
        catch(Exception e)
        {
            Console.WriteLine("Ups, hubo un error quiza ultron tiene algo que ver"+e.Message);
        }
    }

}
class Program // Aqui se encuentra el programa principal
{
    static void Main()
    {

        while (true) // bucle para el menu
        {
            Console.WriteLine("****** Sistema de gestion de archivo de los avengers ******");

            Console.WriteLine("\nHola usuario!  ");
            Console.WriteLine("Este programa te proporciona las siguientes opciones\n");
            Console.WriteLine(" 1. Crear el archivo");
            Console.WriteLine(" 2. Agregar inventos");
            Console.WriteLine(" 3. Leer linea por linea el archivo");
            Console.WriteLine(" 4. Leer todo el archivo");
            Console.WriteLine(" 5. Copiar el archivo");
            Console.WriteLine(" 6. Mover el archivo");
            Console.WriteLine(" 7. Crear carpeta");
            Console.WriteLine(" 8. Listar archivos");
            Console.WriteLine(" 9. Eliminar Archivo");
            Console.WriteLine(" 10. Salir");

            Console.Write("\nIngrese el numero que corresponda a la accion que quieras realizar: ");
            string? opcion = Console.ReadLine(); Console.WriteLine($"Has Ingresado la opcion {opcion}\n");
            Thread.Sleep(1000); // Funcion curiosa

            switch (opcion)
            {
                case "1":
                    ControladorDeArchivos.CrearArchivo();
                    Console.WriteLine("\nPresione cualquier tecla para volver al menu...");
                    Console.ReadKey(); Console.WriteLine(""); // Este linea de codigo es para que el usuario vea el codigo y avance cuando quiera
                    break;
                case "2":
                    ControladorDeArchivos.AgregarINvento();
                    Console.WriteLine("\nPresione cualquier tecla para volver al menu...");
                    Console.ReadKey(); Console.WriteLine("");
                    break;
                case "3":
                    ControladorDeArchivos.LeerLineaPorLinea();
                    Console.WriteLine("\nPresione cualquier tecla para volver al menu...");
                    Console.ReadKey(); Console.WriteLine("");
                    break;
                case "4":
                    ControladorDeArchivos.LeerTodoElTexto();
                    Console.WriteLine("\nPresione cualquier tecla para volver al menu...");
                    Console.ReadKey(); Console.WriteLine("");
                    break;
                case "5":
                    ControladorDeArchivos.CopiarArchivo();
                    Console.WriteLine("\nPresione cualquier tecla para volver al menu...");
                    Console.ReadKey(); Console.WriteLine("");
                    break;
                case "6":
                    ControladorDeArchivos.MoverArchivo();
                    Console.WriteLine("\nPresione cualquier tecla para volver al menu...");
                    Console.ReadKey(); Console.WriteLine("");
                    break;
                case "7":
                    ControladorDeArchivos.CrearCarpeta();
                    Console.WriteLine("\nPresione cualquier tecla para volver al menu...");
                    Console.ReadKey(); Console.WriteLine("");
                    break;
                case "8":
                    Console.WriteLine("*******  Lista  *******"); // Esta lista estara presente en mas funciones
                    Console.WriteLine("\nEsta lista es muy util para tu puedas ver los cambios de las carpetas y archivos.");
                    Console.WriteLine("Encontraras esta lista en las demas funciones de este programa para que no tengas que usar esta funcion todo el rato\n");
                    ControladorDeArchivos.ListarArchivos(); // Aqui se llama la funcion
                    Console.WriteLine("\nPresione cualquier tecla para volver al menu...");
                    Console.ReadKey(); Console.WriteLine("");
                    break;
                case "9":
                    ControladorDeArchivos.EliminarArchivo();
                    Console.WriteLine("\nPresione cualquier tecla para volver al menu...");
                    Console.ReadKey(); Console.WriteLine("");
                    break;
                case "10":
                    Console.WriteLine("saliendo ...");
                    return;
                default:
                    Console.WriteLine("Opcion no valida, ingreselo de nuevo\n");
                    break;
            }
        }
    }
}

