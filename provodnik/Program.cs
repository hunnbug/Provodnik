namespace provodnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                DriveInfo[] info = DriveInfo.GetDrives();

                Console.Clear();
                Console.SetCursorPosition(50, 0);
                Console.WriteLine("|проводник v f.01|");


                    foreach (var drive in info)
                    {
                        Console.WriteLine
                        ("  " + drive.Name + " " + drive.AvailableFreeSpace / 1073741824 + "гб " + "свободно из " + drive.TotalSize / 1073741824 + "гб");
                    }


                    int pos = Strelki.strelki(1, info.Count());
                    if (pos == -1)
                    {
                        return;
                    }
                    else
                    {
                        ProvodnikWork.ShowDirectoryInfo(info[pos - 1].RootDirectory.FullName);
                    }
            }
        }
    }
}