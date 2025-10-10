using SQLite;

namespace MauiApp1.SQLite
{
    // Clase auxiliar que guarda valores constantes: nombre, flags(configuraciones), rutas, etc
    public static class Constants
    {
        //Nombre del archio de base de datos
        public const string  DatabaseFilename = "Habitos.db3";

        //Modos para abrir la base de datos
        public const SQLiteOpenFlags Flags =
            // Abre la base de datos en modo leer/escribir
            SQLiteOpenFlags.ReadWrite |
            // Crea la base de datos si no existe
            SQLiteOpenFlags.Create |
            // Habilita el acceso a la base de datos multiproceso
            SQLiteOpenFlags.SharedCache;

        // Ruta dinamica en cada dispositivo para el archivo de la base de datos
        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
