using System;

class MayinTarlasi
{
    static void Main()
    {
        // Oyun alanı boyutları
        int satir = 20;
        int sutun = 20;
        int mayinSayisi = 40;

        // Oyun alanını ve mayınları oluştur
        char[,] oyunAlani = new char[satir, sutun];
        bool[,] mayinlar = new bool[satir, sutun];

        // Oyun alanını başlat
        for (int i = 0; i < satir; i++)
        {
            for (int j = 0; j < sutun; j++)
            {
                oyunAlani[i, j] = '-';
                mayinlar[i, j] = false;
            }
        }

        // Mayınları rastgele yerleştir
        Random rastgele = new Random();
        int yerlestirilenMayin = 0;
        while (yerlestirilenMayin < mayinSayisi)
        {
            int x = rastgele.Next(0, satir);
            int y = rastgele.Next(0, sutun);

            if (!mayinlar[x, y])
            {
                mayinlar[x, y] = true;
                yerlestirilenMayin++;
            }
        }

        // Oyun döngüsü
        bool oyunDevam = true;
        while (oyunDevam)
        {
            Console.Clear();
            // Oyun alanını yazdır
            for (int i = 0; i < satir; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    Console.Write(oyunAlani[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Bir hücre seçin (örneğin: 5 7): ");
            string[] girdi = Console.ReadLine().Split();
            if (girdi.Length != 2) continue;

            int secimSatir = int.Parse(girdi[0]);
            int secimSutun = int.Parse(girdi[1]);

            // Geçerli bir seçim yapıldı mı?
            if (secimSatir < 0 || secimSatir >= satir || secimSutun < 0 || secimSutun >= sutun)
            {
                Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                continue;
            }

            // Mayın mı var?
            if (mayinlar[secimSatir, secimSutun])
            {
                Console.Clear();
                Console.WriteLine("BOOOM! Mayına bastınız. Oyun bitti!");
                oyunDevam = false;
            }
            else
            {
                oyunAlani[secimSatir, secimSutun] = '0'; // Şimdilik sadece açılan hücreyi gösteriyoruz
            }
        }
    }
}
