using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            #region ActiveCategoryCount

            var responseMessage = await client.GetAsync("https://localhost:44352/api/Statistics/ActiveCategoryCount");
            var jsonData= await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;
            #endregion

            #region ActiveEmployeeCount

            var responseMessage1 = await client.GetAsync("https://localhost:44352/api/Statistics/ActiveEmployeeCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData1;
            #endregion

            #region ApartmentCount

            var responseMessage2 = await client.GetAsync("https://localhost:44352/api/Statistics/ApartmentCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.apartmentCount = jsonData2;
            #endregion

            #region AverageProductPriceByRent

            var responseMessage3 = await client.GetAsync("https://localhost:44352/api/Statistics/AverageProductPriceByRent");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            var convertedData = Convert.ToDecimal(jsonData3.Split(".")[0]).ToString("0.00");
            ViewBag.averageProductPriceByRent = convertedData;
            #endregion

            #region AverageProductPriceBySale

            var responseMessage4 = await client.GetAsync("https://localhost:44352/api/Statistics/AverageProductPriceBySale");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            var convertedData1 = Convert.ToDecimal(jsonData4.Split(".")[0]).ToString("0.00");
            ViewBag.averageProductPriceBySale = convertedData1;
            #endregion

            #region AverageRoomCount

            var responseMessage5 = await client.GetAsync("https://localhost:44352/api/Statistics/AverageRoomCount");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.averageRoomCount = jsonData5;
            #endregion

            #region CategoryCount

            var responseMessage6 = await client.GetAsync("https://localhost:44352/api/Statistics/CategoryCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.categoryCount = jsonData6;
            #endregion

            #region CategoryNameByMaxProductCount

            var responseMessage7 = await client.GetAsync("https://localhost:44352/api/Statistics/CategoryNameByMaxProductCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.categoryNameByMaxProductCount = jsonData7;
            #endregion

            #region CityNameByMaxProductCount

            var responseMessage8 = await client.GetAsync("https://localhost:44352/api/Statistics/CityNameByMaxProductCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.cityNameByMaxProductCount = jsonData8;
            #endregion

            #region DifferentCityCount

            var responseMessage9 = await client.GetAsync("https://localhost:44352/api/Statistics/DifferentCityCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData9;
            #endregion

            #region EmployeeNameByMaxProductCount

            var responseMessage10 = await client.GetAsync("https://localhost:44352/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData10;
            #endregion

            #region LastProductPrice

            var responseMessage11 = await client.GetAsync("https://localhost:44352/api/Statistics/LastProductPrice");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.lastProductPrice = jsonData11;
            #endregion

            #region NewestBuildingYear

            var responseMessage12 = await client.GetAsync("https://localhost:44352/api/Statistics/NewestBuildingYear");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.newestBuildingYear = jsonData12;
            #endregion

            #region OldestBuildingYear

            var responseMessage13 = await client.GetAsync("https://localhost:44352/api/Statistics/OldestBuildingYear");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.oldestBuildingYear = jsonData13;
            #endregion

            #region PassiveCategoryCount

            var responseMessage14 = await client.GetAsync("https://localhost:44352/api/Statistics/PassiveCategoryCount");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            ViewBag.passiveCategoryCount = jsonData14;
            #endregion

            #region ProductCount

            var responseMessage15 = await client.GetAsync("https://localhost:44352/api/Statistics/ProductCount");
            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData15;
            #endregion



            return View();
        }
    }
}
