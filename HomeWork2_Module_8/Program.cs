using System;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Введите путь к директории:");
            string directoryPath = Console.ReadLine();

            // Проверяем, существует ли директория
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("Указанной директории не существует.");
                return;
            }

            // Получаем размер директории
            long directorySize = GetDirectorySize(directoryPath);

            double SizeInKilobytes = (double)directorySize / 1024;
            int precision = 3; 

            string KilobyteNumber = Math.Round((double)directorySize / 1024, precision).ToString();


            string GigabyteNumber = Math.Round((double)directorySize / (1024 * 1024 * 1024), precision).ToString();

            Console.WriteLine($"Размер папки {directoryPath} составляет {KilobyteNumber} кбайт ({GigabyteNumber} Гбайт)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    
    static long GetDirectorySize(string directoryPath)
    {
        long size = 0;

        
        string[] files = Directory.GetFiles(directoryPath);

       
        foreach (string file in files)
        {
            FileInfo fileInfo = new FileInfo(file);
            size += fileInfo.Length;
        }

       
        string[] subdirectories = Directory.GetDirectories(directoryPath);

       
        foreach (string subdirectory in subdirectories)
        {
            size += GetDirectorySize(subdirectory);
        }

        return size;
    }
}