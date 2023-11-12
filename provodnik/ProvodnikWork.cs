using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace provodnik
{
    internal static class ProvodnikWork
    {
        public static void ShowDirectoryInfo(string a)
        {
            while (true)
            {
                Console.Clear();
                string[] folders                    = Directory.GetDirectories(a);
                string[] files                      = Directory.GetFiles(a);
                List<string> allFiles               = new List<string>();

                    for (int i = 0; i < folders.Length; i++)
                    {
                        allFiles.Add(folders[i]);
                    }
                    for (int i = 0; i < files.Length; i++)
                    {
                        allFiles.Add(files[i]);
                    }


                    foreach (string folder in folders)
                    {
                        var createDate              = Directory.GetCreationTime(folder);


                        Console.Write               ("  папка: " + folder);

                        Console.SetCursorPosition   (40, Console.CursorTop);
                        Console.WriteLine           (createDate);
                    }
                    foreach (string file in files)
                    {
                        var createDate              = Directory.GetCreationTime(file);
                        var extension               = Path.GetExtension(file);


                        Console.Write               ("  файл: " + file);

                        Console.SetCursorPosition   (40, Console.CursorTop);
                        Console.Write               (createDate);

                        Console.SetCursorPosition   (70, Console.CursorTop);
                        Console.WriteLine           (extension);
                    }


                    int pos = Strelki.strelki(0, folders.Length + files.Length);
                    if (pos == -1)
                    {
                        return;
                    }
                    else
                    {
                        try
                        {
                            ShowDirectoryInfo(allFiles[pos]);
                        }
                        catch (IOException)
                        {
                            Process.Start(new ProcessStartInfo { FileName = allFiles[pos], UseShellExecute = true });
                        }
                    }
            }
        }
    }
}
