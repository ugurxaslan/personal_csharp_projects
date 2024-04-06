using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static int genislik = 25; // Genişliği 10 katına çıkardık
    static int yukseklik = 50; // Yüksekliği 10 katına çıkardık
    static int yemX, yemY, basX, basY;
    static List<int> kuyrukX, kuyrukY;
    static bool oyunDevam = true;
    static string hareket = "sag"; // Başlangıçta sağa hareket ediyor
    static int score = 0;

    static void Main()
    {
        OyunuBaslat();

        while (oyunDevam)
        {
            KlavyeKontrolleri();
            HareketEt();
            YemKontrol();
            Cizim();
            Thread.Sleep(100);
        }

        Console.WriteLine("Oyun bitti! Toplam puan : " + score);
        Console.ReadLine();
    }
    static void YemKontrol()
    {
        if (basX == yemX && basY == yemY)
        {
            kuyrukX.Add(kuyrukX.Last());
            kuyrukY.Add(kuyrukY.Last());
            YemOlustur();
        }
    }

    static void OyunuBaslat()
    {
        Console.WindowWidth = genislik;
        Console.WindowHeight = yukseklik;
        Console.BufferWidth = Console.WindowWidth;
        Console.BufferHeight = Console.WindowHeight;

        basX = genislik / 2;
        basY = yukseklik / 2;

        kuyrukX = new List<int> { basX };
        kuyrukY = new List<int> { basY };

        YemOlustur();
    }

    static void KlavyeKontrolleri()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo tus = Console.ReadKey(true);

            switch (tus.Key)
            {
                case ConsoleKey.UpArrow:
                    if (hareket != "asagi") hareket = "yukari";
                    break;
                case ConsoleKey.DownArrow:
                    if (hareket != "yukari") hareket = "asagi";
                    break;
                case ConsoleKey.LeftArrow:
                    if (hareket != "sag") hareket = "sol";
                    break;
                case ConsoleKey.RightArrow:
                    if (hareket != "sol") hareket = "sag";
                    break;
            }
        }
    }

    static void HareketEt()
    {
        int yeniBasX = basX;
        int yeniBasY = basY;

        switch (hareket)
        {
            case "yukari":
                yeniBasY--;
                break;
            case "asagi":
                yeniBasY++;
                break;
            case "sol":
                yeniBasX--;
                break;
            case "sag":
                yeniBasX++;
                break;
        }

        if (yeniBasX < 1 || yeniBasX >= genislik - 1 || yeniBasY < 1 || yeniBasY >= yukseklik - 1)
        {
            oyunDevam = false; // Duvarlara çarptığında oyunu bitir
            return;
        }

        if (yeniBasX == yemX && yeniBasY == yemY)
        {
            score += 10;
            YemOlustur();
            kuyrukX.Insert(0, basX);
            kuyrukY.Insert(0, basY);
        }
        else
        {
            kuyrukX.Insert(0, basX);
            kuyrukY.Insert(0, basY);
            kuyrukX.RemoveAt(kuyrukX.Count - 1);
            kuyrukY.RemoveAt(kuyrukY.Count - 1);
        }

        basX = yeniBasX;
        basY = yeniBasY;
    }

    static void YemOlustur()
    {
        Random random = new Random();
        yemX = random.Next(1, genislik - 1);
        yemY = random.Next(1, yukseklik - 1);

        while (kuyrukX.Contains(yemX) && kuyrukY.Contains(yemY))
        {
            // Yem kuyruğun üzerine gelmemeli, bu yüzden tekrar konum seç
            yemX = random.Next(1, genislik - 1);
            yemY = random.Next(1, yukseklik - 1);
        }
    }

    static void Cizim()
    {
        Console.Clear();

        // Duvarları çiz
        for (int i = 0; i < genislik; i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write("#");
            Console.SetCursorPosition(i, yukseklik - 1);
            Console.Write("#");
        }

        for (int i = 0; i < yukseklik; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("#");
            Console.SetCursorPosition(genislik-1, i);
            Console.Write("#");
        }

        Console.SetCursorPosition(basX, basY);
        Console.Write("0");

        for (int i = 0; i < kuyrukX.Count; i++)
        {
            Console.SetCursorPosition(kuyrukX[i], kuyrukY[i]);
            Console.Write(i);
        }

        Console.SetCursorPosition(yemX, yemY);
        Console.Write("x");

        // Skoru göster
        Console.SetCursorPosition(genislik / 2 - 5, 0);
        Console.Write("Skor: " + score);
    }
}
