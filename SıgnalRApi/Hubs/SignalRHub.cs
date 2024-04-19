using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.SignalR;
using System.Runtime.ConstrainedExecution;

namespace SıgnalRApi.Hubs
{
	//Eklediğimiz bu class bizim için bir sunucu görevi görmüş olacak.Yani biz dağıtım işlemini Hub sınıfı hangisi ise onun üzerinden sağlayacağız.
	//Cors : Tarayıcılar kullanıcıyı korumak üzere kullancı bir sitede gezinti yaparken ilgili sitenin başka bir siteye web isteği yapmasına sınırlama getirir. Bu sınırlama Same Origin Policy (SOP) olarak adlandırılır.  

	//Program.cs de SignalR ve Cors Politikasını eklemelisin.
	public class SignalRHub : Hub  //Hub SignalR dan gelen bir sınıf
	{
		private readonly ICategoryService _categoryService;
		private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}
		public static int clientCount { get; set; } = 0; //Static modifikatörü bu özelliğin sınıfa özgü olduğunu yani bir sınıfın bir örneği olmadan erişilebileceğini belirtir. Bu durumda clientCount özelliği sınıfa aittir ve sınıfın bir örneği olmadan erişilebilir.
        //Bu da clientCountun sınıfın tüm öğeleri arasında paylaşılmasını ve tüm öğeleri tarafından aynı değere sahip olmasını sağlar.Bu özellik sayesinde sınıf düzeyinde sayıcılar ve durum takibi yapabilmek için kullanabiliriz.Static olmadığında bu yüzden sayfayı her yinelediğimizde her sayfa için 1 değeri geliyordu.

        public async Task SendStatistic()//Genellikle Send ile adlandırılır.
		{
			// Kategori sayısını anlık olarak getiren SignalR metodu
			var value = _categoryService.CategoryCountAsync();

			await Clients.All.SendAsync("ReceiveCategoryCount", value);  //SignalR kullanımına özel bir yapı. 
																		 //Burada gelen değeri client tarafına göndereceğim.ReceiveCategoryCount ismini ben verdim kategoriden gelen değeri almak anlamındadır.
																		 //Client tarafına geldiğim zaman SendCategoryCount metodunu çağıracağım.Bu metoda invoke ile istek at bu metodun içindeki ReceiveCategoryCount olarak yazdığım ifadeyi kullan.Abonelik olarak da anlatılır genel olarak bu durumda SendCategoryCount a abone olup ReceiveCategoryCount kullanmış olacağım.

			//Ürün sayısını anlık olarak getiren SignalR metodu
			var value2 = _productService.ProductCountAsync();
			await Clients.All.SendAsync("ReceiveProductCount", value2); 

			//Aktif kategori sayısını getiren metot
			var value3 = _categoryService.ActiveCategoryCountAsync();
			await Clients.All.SendAsync("ReceiveActiveCategoryCount", value3);

			//Pasif kategori sayısını getiren metot
			var value4 = _categoryService.PassiveCategoryCountAsync();
			await Clients.All.SendAsync("ReceivePassiveCategoryCount", value4);

			//Kategori adına göre ürün sayısını getiren SignalR metodu(Hamburger/Drink)
			var value5=_productService.ProductCountByCategoryNameHamburgerAsync();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger",value5);

			var value6 = _productService.ProductCountByCategoryNameDrinkAsync();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink",value6);

			//Ortalama fiyat
			var value7=_productService.ProductPriceAvgAsync();
			await Clients.All.SendAsync("ReceiveProductPriceAvg",value7.ToString("0.00") + "₺");

			//En Pahalı Ürün
			var value8=_productService.ProductNameByMaxPriceAsync();
			await Clients.All.SendAsync("ReceiveProductNameByMaxPrice",value8);
			
			//En Ucuz Ürün
			var value9= _productService.ProductNameByMinPriceAsync();
			await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);

			//Ortalama Hamburger Fiyatı
			var value10 = _productService.ProductAvgPriceByHamburgerAsync();
			await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value10);

			//Toplam Sipariş Sayısı
			var value11=_orderService.TotalOrderCountAsync();
			await Clients.All.SendAsync("ReceiveTotalOrderCount",value11);

			//Aktif Sipariş Sayısı
			var value12 = _orderService.ActiveOrderCountAsync();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

			//Son Sipariş Tutarı
			var value13 = _orderService.LastOrderPriceAsync();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.ToString("0.00") + "₺");
 
			//Kasadaki Tutar
			var value14 =_moneyCaseService.TotalMoneyCaseAmountAsync();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00") + "₺");

			//Masa Sayısı
			var value16 = _menuTableService.MenuTableCountAsync();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value16);

		}
		public async Task SendProgress()
		{
			//Kasadaki Toplam Tutar
			var value = _moneyCaseService.TotalMoneyCaseAmountAsync();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount",value.ToString("0.00") + "₺");

			//Aktif Sipariş Sayısı
			var value2 = _orderService.ActiveOrderCountAsync();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value2);

			//Aktif Masa Sayısı
			var value3 = _menuTableService.MenuTableCountAsync();
			await Clients.All.SendAsync("ReceiveMenuTableCount",value3);

            //Ortalama Ürün Fiyatı
            var value5 = _productService.ProductPriceAvgAsync();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", value5);

            //Ortalama Hamburger Fiyatı
            var value6 = _productService.ProductAvgPriceByHamburgerAsync();
            await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value6);

            //Ortalama Kategoriye Göre İçecek Fiyatı
            var value7 = _productService.ProductCountByCategoryNameDrinkAsync();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value7);

            //Toplam Sipariş Sayısı
            var value8 = _orderService.TotalOrderCountAsync();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value8);

            var value9 = _productService.ProductPriceBySteakBurgerAsync();
            await Clients.All.SendAsync("ReceiveProductPriceBySteakBurger", value9);

            var value10 = _productService.TotalPriceByDrinkCategoryAsync();
            await Clients.All.SendAsync("ReceiveTotalPriceByDrinkCategory", value10);

            var value11 = _productService.TotalPriceBySaladCategoryAsync();
            await Clients.All.SendAsync("ReceiveTotalPriceBySaladCategory", value11);

        }
        public async Task GetBookingList()
		{
			var values= _bookingService.GetListAllAsync();
			await Clients.All.SendAsync("ReceiveBookingList",values);
		}
		public async Task SendNotification()
		{
			var value=_notificationService.NotificationCountByStatusFalseAsync();
			await Clients.All.SendAsync("ReceiveNotificationCountByStatusFalse",value);

			var notificationListByFalse=_notificationService.GetAllNotificationListByFalseAsync();
			await Clients.All.SendAsync("ReceiveNotificationListByFalse", notificationListByFalse);
		}
		public async Task GetMenuTableStatus()
		{
			//Masaların dolu boş olma durumu için yazılan metot

			var value = _menuTableService.GetListAllAsync();
			await Clients.All.SendAsync("ReceiveMenuTableStatus",value);
		}
		public async Task SendMessage(string user,string message)
		{
			await Clients.All.SendAsync("ReceiveMessage",user,message);

		}
		//Anlık client sayılarını çekmek için yazılan metot
		//Override yazdıktan sonra otomatik olarak geliyor metot
		//Bu metot client a bağlı client sayısını getirir.
		public override async Task OnConnectedAsync()
		{
			clientCount++;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
			await base.OnConnectedAsync();
		}
		//Dışarıdan hata oluşabilmesine karşın iki metot birlikte kullanılıyor.
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
			clientCount--;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }

    }
}
