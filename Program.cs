using System;
using System.IO;

namespace FilesWork
{

    class Program
    {
        
        static void Main(string[] args)
        {
            string dirName = @"D:\test";
            if (Directory.Exists(dirName))
            {
                DirectoryInfo directory = new DirectoryInfo(dirName);
                DirectoryInfo[] directories = directory.GetDirectories();
                FileInfo[] files = directory.GetFiles();

                foreach (var dir in directories)
                {
                    try
                    {
                        DateTime begin = dir.LastAccessTime;
                        DateTime end = DateTime.Now;
                        TimeSpan rez = end - begin;
                        if (rez.TotalMinutes >= 30)
                        {
                            dir.Delete(true);
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Произошла ошибка: " + ex.Message);
                    }
                }


                foreach (var file in files)
                {
                    try
                    {
                        DateTime begin = file.LastAccessTime;
                        DateTime end = DateTime.Now;
                        TimeSpan rez = end - begin;
                        if (rez.TotalMinutes >= 30)
                        {
                            file.Delete();
                        }
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Console.WriteLine("Отсутствует доступ. Ошибка: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Произошла ошибка: " + ex.Message);
                    }
                }

            }
            else { Console.WriteLine("По указанному адресу папка отсутствует"); }
                    
        }
    }
}
