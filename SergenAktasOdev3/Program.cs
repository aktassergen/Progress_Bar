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
                Console.Write("Progress Bar için genişlik: ");
                string totalSpacess = Console.ReadLine();
                Console.Write("Progress Karakteri: ");
                string progressCharr = Console.ReadLine();
                Console.Write("Progress Bar doldurulurken yazılacak yazı: ");
                string progressText = Console.ReadLine();
                Console.Write("Progress Bar doldurulması bittiğinde yazılacak yazı: ");
                string progressCompleteText = Console.ReadLine();

                bool result1 = int.TryParse(deger, out int progressBarCount);
                bool result2 = byte.TryParse(totalSpacess, out byte totalSpaces);
                bool result3 = char.TryParse(progressCharr, out char progressChar);

                if (result1 == true && progressBarCount >= 0 && result2 == true && totalSpaces >= 0 && result3 == true)
                {


                    Console.Write("Progress Bar için renk seçimi [0-15]: ");
                    ConsoleColor progressBarColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Console.ReadLine());
                    Console.Write("Progress Bar yüzde yazısı için renk seçimi [0-15]: ");
                    ConsoleColor progressBarTextColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Console.ReadLine());
                    for (int i = 1; i <= progressBarCount; i++)
                    {
                        Console.WriteLine($"Progress Bar {i}:");

                        UpdateProgressBar(0, progressChar, progressText, progressCompleteText, totalSpaces, progressBarColor, progressBarTextColor);//baslangıç değeri 0 olmalı
                        int updateInterval = 60;
                        for (int progress = 0; progress <= 100; progress += 2)
                        {
                            Thread.Sleep(updateInterval);
                            Console.SetCursorPosition(0, Console.CursorTop);
                            UpdateProgressBar(progress, progressChar, progressText, progressCompleteText, totalSpaces, progressBarColor, progressBarTextColor);
                        }
                        Console.WriteLine();
                    }
                    HandleContinueOrExit(ref degisken);
                }
                else if (string.IsNullOrWhiteSpace(deger) && string.IsNullOrWhiteSpace(totalSpacess) && string.IsNullOrWhiteSpace(progressCharr) && string.IsNullOrWhiteSpace(progressText) && string.IsNullOrWhiteSpace(progressCompleteText) && string.IsNullOrWhiteSpace(progressCompleteText))
                {
                    for (int i = 1; i <= 1; i++)
                    {
                        Console.WriteLine($"Progress Bar {i}:");
                        UpdateProgressBar2(0);//baslangıç değeri 0 olmalı
                        int updateInterval = 60;

                        for (int progress = 0; progress <= 100; progress += 2)
                        {
                            Thread.Sleep(updateInterval);
                            Console.SetCursorPosition(0, Console.CursorTop);
                            UpdateProgressBar2(progress);
                        }
                    }
                    Console.WriteLine();
                    HandleContinueOrExit(ref degisken);
                }
                else
                {
                    HandleContinueOrExit(ref degisken);
                }
            }
        }

        static void HandleContinueOrExit(ref bool degisken)
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


        static void UpdateProgressBar(int progress, char progressChar, string progressText, string progressCompleteText, byte totalSpaces, ConsoleColor progressBarColor, ConsoleColor progressBarTextColor)
        {

            int filledChars = (int)Math.Ceiling((double)progress / 100 * totalSpaces);
            int i;
            Console.Write("[");
            Console.ForegroundColor = progressBarColor;
            for (i = 0; i < filledChars; i++)
            {
                Console.Write(progressChar);
            }
            Console.ResetColor();
            for (int j = filledChars; j < totalSpaces; j++)
            {
                Console.Write(" ");
            }
            Console.ForegroundColor = progressBarTextColor;
            if (progress != 100)
            {
                Console.Write($"]{progress,2}% {progressText}...");
            }

            else
            {
                Console.Write($"]{progress,2}% {progressCompleteText}.");
            }
            Console.ResetColor();
        }

        static void UpdateProgressBar2(int progress)
        {
            int totalSpaces = 50;
            int filledChars = (int)Math.Ceiling((double)progress / 100 * totalSpaces);
            int i;
            Console.Write("[");

            for (i = 0; i < filledChars; i++)
            {
                Console.Write("#");
            }

            for (int j = filledChars; j < totalSpaces; j++)
            {
                Console.Write(" ");
            }

            if (progress != 100)
            {
                Console.Write($"]{progress,2}% Downloading...");
            }

            else
            {
                Console.Write($"]{progress,2}% Downloaded.");
            }

        }

    }
}