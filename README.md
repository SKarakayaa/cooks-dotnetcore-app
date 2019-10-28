# cooks-dotnetcore-app

Proje 5-Katmanlı Mimari kullanılmaktadır.

Class Libraryler .NET Standard 2.0 ile oluşturuldu.
API ise .NET Core 2.2 ile oluşturuldu.

DataAccessLayer (DAL) katmanında Core katmanında uygulanan GenericRepositoryPattern kullanılmaktadır.
DependencyInjection Aracı olarak Autofac kullanılmaktadır. BussinessLogicLayer (BLL) katmanında interface'lerin miras vereceği sınıflar belirlenmiş olup,
Startup.cs class'ı içinde Configure edilmiştir.

Proje Azure.com ve Somee.com da yayınlanmıştır. Veritabanı Somee.com'da bulunmaktadır.

Azure Adres : https://cooks-api.azurewebsites.net/api/foods

Somee Adres : http://cooks-api.somee.com/api/foods

Aşağıda verilen yollar apinin kullandığı url rotalarıdır.

foods/ : GetsAllFoods-Post-Put-Delete

foods/{userId} : Belli bir kullanıcının sahip olduğu yemek menüleri

foods/{typeId} : Belli bir türe ait olan yemeklerin listesi

foods/{foodId} : Belli bir yemek getirir
