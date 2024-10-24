namespace SingletonDesignPatternAspNetCoreExample.Services
{
    //veri tabani islemleri sorumlulugunu ustlenen sinifimiz
    //Bu sinifi singleton tasarlamak istiyoruz.Cunku;
    //Uygulamada her db islemi gerektiginde bu siniftan herbiri icin 1+ nesne üretmektense tek bir nesne olusturarak onu cagırmak istiyoruz
    public class DataBaseService
    {
        //1-Sinifin ctor unu private yapmak
        private DataBaseService()
        {
            //kac nesne uretilmis görebilmek icin console a yazabiliriz.
            Console.WriteLine($"{nameof(DataBaseService)} is created!");
        }

        //2-Nesne uretim sorumlulugunu ustlenen bir member tanımlamak
        //Bu member propta olabilir method da olabilir.

        //Geriye DatabaseService dönecek bir fonksiyon tanımlıyoruz.

        static DataBaseService _databaseService;
        public static DataBaseService GetInstance
        {
            get
            {
                //bu kontrol nesnenin daha once uretilmisse tekrar uretilmemesini saglar.
                //boylelikle nesne ilgili sınıf icın bir kez uretilmis olur.
                if (_databaseService == null)
                {
                    _databaseService = new DataBaseService();
                }
                return _databaseService;
            }
        }

        public int Count { get; set; }
        public bool Connection()
        {
            Count++;
            Console.WriteLine("Bağlantı Sağlandı...");
            return true;
        }

        public bool Disconnect()
        {
            Console.WriteLine("Bağlantı Koparıldı...");
            return true;
        }

    }
}
