using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
    public class _DashboardStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
           
            #region ProductCount - ToplamİlanSayısı

            var responseMessage1 = await client.GetAsync("https://localhost:44352/api/Statistics/ProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion

            #region EmployeeNameByMax - EnBaşarılıPersonel

            var responseMessage2 = await client.GetAsync("https://localhost:44352/api/Statistics/EmployeeNameByMaxProductCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData2;
            #endregion


            #region DifferentCityCount - İlandakiŞehirSayıları

            var responseMessage3 = await client.GetAsync("https://localhost:44352/api/Statistics/DifferentCityCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData3;
            #endregion

            #region AveragePriceByRent - Ort Kira

            var responseMessage4 = await client.GetAsync("https://localhost:44352/api/Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
           // var convertedData = Convert.ToDecimal(jsonData4.Split(".")[0]).ToString("0.00");
            ViewBag.averageProductPriceByRent = Convert.ToDecimal(jsonData4.Split(".")[0]).ToString("0.00"); ;
            #endregion


            return View();
        }
    }
}
