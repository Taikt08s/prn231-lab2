using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ODataBookStore.Model;
using System.Net.Http.Headers;


namespace ODataBookStoreWebClient.Controllers
{
    public class BookController : Controller
    {
        private readonly HttpClient client;
        private string ProductApiUrl;

        public BookController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ProductApiUrl = "https://localhost:7108/odata/Books"; // Update this URL as needed
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await client.GetAsync(ProductApiUrl);
            string strData = await response.Content.ReadAsStringAsync();
            dynamic temp = JObject.Parse(strData);
            List<Book> items = ((JArray)temp.value).Select(x => new Book
            {
                Id = (int)x["Id"],
                Author = (string)x["Author"],
                ISBN = (string)x["ISBN"],
                Title = (string)x["Title"],
                Price = (decimal)x["Price"],
            }).ToList();

            return View(items);
        }

        // Complete Details Method
        public async Task<IActionResult> Details(int id)
        {
            string detailsUrl = $"{ProductApiUrl}({id})";
            HttpResponseMessage response = await client.GetAsync(detailsUrl);

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string strData = await response.Content.ReadAsStringAsync();
            dynamic temp = JObject.Parse(strData);
            Book item = new Book
            {
                Id = (int)temp["Id"],
                Author = (string)temp["Author"],
                ISBN = (string)temp["ISBN"],
                Title = (string)temp["Title"],
                Price = (decimal)temp["Price"]
            };

            return View(item);
        }

        // Complete Create Method (GET and POST)
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(book));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.PostAsync(ProductApiUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                return View(book);
            }

            return RedirectToAction(nameof(Index));
        }

        // Complete Edit Method (GET and POST)
        public async Task<IActionResult> Edit(int id)
        {
            string editUrl = $"{ProductApiUrl}({id})";
            HttpResponseMessage response = await client.GetAsync(editUrl);

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string strData = await response.Content.ReadAsStringAsync();
            dynamic temp = JObject.Parse(strData);
            Book item = new Book
            {
                Id = (int)temp["Id"],
                Author = (string)temp["Author"],
                ISBN = (string)temp["ISBN"],
                Title = (string)temp["Title"],
                Price = (decimal)temp["Price"]
            };

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(book));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            string editUrl = $"{ProductApiUrl}({id})";
            HttpResponseMessage response = await client.PutAsync(editUrl, content);

            if (!response.IsSuccessStatusCode)
            {
                return View(book);
            }

            return RedirectToAction(nameof(Index));
        }

        // Complete Delete Method (GET and POST)
        public async Task<IActionResult> Delete(int id)
        {
            string deleteUrl = $"{ProductApiUrl}({id})";
            HttpResponseMessage response = await client.GetAsync(deleteUrl);

            if (!response.IsSuccessStatusCode)
            {
                return NotFound();
            }

            string strData = await response.Content.ReadAsStringAsync();
            dynamic temp = JObject.Parse(strData);
            Book item = new Book
            {
                Id = (int)temp["Id"],
                Author = (string)temp["Author"],
                ISBN = (string)temp["ISBN"],
                Title = (string)temp["Title"],
                Price = (decimal)temp["Price"]
            };

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            string deleteUrl = $"{ProductApiUrl}({id})";
            HttpResponseMessage response = await client.DeleteAsync(deleteUrl);

            if (!response.IsSuccessStatusCode)
            {
                return View(); // Or handle error accordingly
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
