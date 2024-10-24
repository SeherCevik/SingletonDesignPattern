//example sınıfının uygulama bazında global olrak tanımlanmasını istiyorsak singleton a ihtiyacımız var.
class Example
{
    //Example sınıfınfan kaç nesne oluşturursak o kadar ctor tetiklenir ve consolewriteline çalışır. Bu şekilde kaç nesne oluşturulduğunu takip edeceğiz.
    //singleton desen, bir sınıfın yalnızca bir örneğinin olmasını sağlar. 
    //bu yüzden singleton desen ile oluşturulan sınıftan new ile nesne üretilememesi gerekir.
    //new ile nesne üretirken ctor çağılır. Eğer nesne üretilsin istemiyorsak ctor u ulaşılamaz yapmamzı gerekir.(private)
    private Example()
    {
        Console.WriteLine($"{nameof(Example)} nesnesi oluşturuldu.");

    }

    //en nihayetinde bu sınıfa ulaşabilmemiz için bir tane nesnesi olmalı;
    //singleton desen, bir sınıfın yalnızca bir örneğinin olmasını sağlar.
    //bunun için static bir member oluştururuz ve bu static member nesne üretme sorumluluğunu üstlenir.

    //nesne üretim sorumluluğunu üstlenen member(üye)
    //bu sınıftan nesne üretmek istersek bu methodu kullanacağız;
    //Example ex = Example.GetInstance

    //singleton sınıftan bir nesne oluşturulmasını sağlar. işte o üyeyi tutan ınstance budur:
    static Example _example;
    public static Example GetInstance
    {
        get
        {
            //gereksiz new olmamalı bir tane olmalı o yüzden daha önce oluşturulmuşsa onu kullanırız yopksa newleriz.
            if (_example == null)
            {
                _example = new Example();
            }
            return _example;

        }
    }
    //Bu member, prop yada method olur. Yukaridaki prop old. icin get var.
}



