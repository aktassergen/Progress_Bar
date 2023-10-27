namespace Progress_Bar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool degisken = true;
            while (degisken)
            {
                degisken = false;
                Console.Write("Kaç adet Progress Bar oluşturmak istiyorsunuz: ");
                string deger = Console.ReadLine();
                bool result1 = int.TryParse(deger, out int progressBarCount);
                if (result1 == true && progressBarCount > 0)
                {
                    for (int i = 1; i <= progressBarCount; i++)
                    {
                        Console.WriteLine($"Progress Bar {i}:");
                        UpdateProgressBar(0);//baslangıç değeri 0 olmalı
                        int updateInterval = 60;

                        for (int progress = 0; progress <= 100; progress += 2)
                        {
                            Thread.Sleep(updateInterval);
                            Console.CursorVisible = false;
                            Console.SetCursorPosition(0, Console.CursorTop);
                            UpdateProgressBar(progress);
                        }
                        

                        Console.WriteLine();
                        Console.WriteLine("Downloaded!");
                    }

                    bool degisken2 = true;
                    while (degisken2)
                    {
                        degisken = true;
                        Console.Write("devam etmek için 'E', çıkış için 'H' tuşuna basın.");
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.E)
                        {
                            degisken = true;
                            degisken2 = false;
                            Console.Clear();
                        }
                        else if (keyInfo.Key == ConsoleKey.H)
                        {
                            degisken = false;
                            degisken2 = false;
                        }
                        else
                        {
                            Console.Write("Çizime devam etmek için 'E', çıkış için 'H' tuşuna basın.");
                            Console.Clear();
                        }
                    }
                }
                else if (progressBarCount<=0|| result1 ==false|| string.IsNullOrWhiteSpace(deger) || string.IsNullOrWhiteSpace(deger))
                {
                    degisken = true;
                    Console.Clear();
                }
                else
                {
                    bool degisken2 = true;
                    while (degisken2)
                    {
                        degisken = true;
                        Console.Write("devam etmek için 'E', çıkış için 'H' tuşuna basın.");
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.E)
                        {
                            degisken = true;
                            degisken2 = false;
                            Console.Clear();
                        }
                        else if (keyInfo.Key == ConsoleKey.H)
                        {
                            degisken = false;
                            degisken2 = false;
                        }
                        else
                        {
                            Console.Write("devam etmek için 'E', çıkış için 'H' tuşuna basın.");
                            Console.Clear();
                        }
                    }
                }
            }
           
           
           

        }
        static void UpdateProgressBar(int progress)
        {
            int totalSpaces = 50;
            int filledChars = (int)Math.Ceiling((double)progress / 100 * totalSpaces);
            int i ;
            Console.Write("[");

            for ( i = 0; i < filledChars; i++)
            {
                Console.Write("#");
            }

            for (int j = filledChars; j < totalSpaces; j++)
            {
                Console.Write(" ");
            }
            Console.Write($"]{progress,2}% Downloading...");

            
           
        }

    }
}