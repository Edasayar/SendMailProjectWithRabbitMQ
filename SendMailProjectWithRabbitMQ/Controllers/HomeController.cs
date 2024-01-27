
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Consume;
using RabbitMQ.Consume.Data;
using SendMailProjectWithRabbitMQ.Models;
using System.Diagnostics;

namespace SendMailProjectWithRabbitMQ.Controllers
{
    public class HomeController : Controller
    {
       

        private readonly RabbitMQHelper _rabbitMQHelper;
       

        public HomeController()
        {

            _rabbitMQHelper = RabbitMQHelper.GetInstance();

        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> SendMail(SendMailVM sendMailVM)
        {
            var dataModel = new DataModel();
            List<User> users = dataModel.GetData().ToList();

            string content = sendMailVM.Content;

            await _rabbitMQHelper.SendTextRequest(users, content);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
