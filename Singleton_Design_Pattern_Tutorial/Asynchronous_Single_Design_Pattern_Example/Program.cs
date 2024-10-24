
var Task1 = Task.Run(() =>
{
    Example.GetInstance();
});
var Task2 = Task.Run(() =>
{
    Example.GetInstance();
});

Task.WhenAll(Task1, Task2);

var Task3 = Task.Run(() =>
{
    Example.GetInstance();
});
var Task4 = Task.Run(() =>
{
    Example.GetInstance();
});

Task.WhenAll(Task3, Task4);
class Example
{
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturulmuştur.");
    }

    static Example _example;
    static object _obj = new object();
    public static Example GetInstance()
    {
        lock (_obj)
        {
            if (_example == null)
            {
                _example = new Example();
            }
        }

        return _example;

    }

}




//asenkron islemlerde eszamanlı gidildiğinden dolayı 1+ taskların çalıştırıldığı durumlarda bazı Task'lar icin Instance olusurken digerleri icin olusmayabilir.
//paralel ilerlemelerde Tasklar aynı andada nesne olusturma adiminda olabilirler. Ayni anda geldiklerinde 1+ Task nesenin null olmadığı yerde olursa birisi icin nesne olusurken digeri icin olusmaz bu durumda.
//Bu nedenle asenkron calisirken GetInstance methodunu buna gore duzenliyoruz;
//Eger asenkron surecteyse asenkron olan sureci luck lıyoruz.
//luckladitan sonra GetInstance methodunun icerisindeki islemi tek bir fonk. karsilik gerceklestiriyoruz.
//yani 2+ Task bu methodun icine girmisse birini lucklıyoruz (kitliyoruz.) 1 Task icin bu kodlar calistiktan sonra digerine geciyoruz.
//Bu islem sonucunda ilk gelen icin bir kez nesne olusuyor. Kac tane asenkron Task calisirsa calissin bir tane nesne olusur.
//Kısaca lock mekanizmasiyla asenkron islemlerde birden fazla nesne olusturulmasinin onune gecmis oluyoruz.
//luck kullanmadan yapmak istersek 2.singleton yöntemi olan static ctor kullanilabilir.