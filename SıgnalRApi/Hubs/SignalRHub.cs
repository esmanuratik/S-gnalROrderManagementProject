using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;

namespace SıgnalRApi.Hubs
{
    //Eklediğimiz bu class bizim için bir sunucu görevi görmüş olacak.Yani biz dağıtım işlemini Hub sınıfı hangisi ise onun üzerinden sağlayacağız.
    //Cors : Tarayıcılar kullanıcıyı korumak üzere kullancı bir sitede gezinti yaparken ilgili sitenin başka bir siteye web isteği yapmasına sınırlama getirir. Bu sınırlama Same Origin Policy (SOP) olarak adlandırılır.  

    //Program.cs de SignalR ve Cors Politikasını eklemelisin.
    public class SignalRHub:Hub  //Hub SignalR dan gelen bir sınıf
    {
        SignalRContext context = new SignalRContext();
        
        public async Task SendCategoryCount()//Genellikle Send ile adlandırılır.
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount",value);//SignalR kullanımına özel bir yapı. //Burada gelen değeri client tarafına göndereceğim.ReceiveCategoryCount ismini ben verdim kategoriden gelen değeri almak anlamındadır.
            //Client tarafına geldiğim zaman SendCategoryCount metodunu çağıracağım.Bu metoda invoke ile istek at bu metodun içindeki ReceiveCategoryCount olarak yazdığım ifadeyi kullan.Abonelik olarak da anlatılır genel olarak bu durmda SendCategoryCount a abone olup  ReceiveCategoryCount kullanış olacağım.
        }
    }
}
 