using BuissnesLayer;
using BuissnesLayer.Interfaces;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TestAppMVC.Models;

namespace TestAppMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EFDBContext _dbContext;
        private IDirectrysRepository _directrysRepository;
        private DataManager _dataManager;


        public HomeController(ILogger<HomeController> logger, 
            //EFDBContext dbContext, IDirectrysRepository directrysRepository,
            DataManager dataManager)
        {
            _logger = logger;
            //_dbContext = dbContext;
            //_directrysRepository = directrysRepository;
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            MyHelloModel _model = new MyHelloModel() { HelloMessage = "Hello, Aleksander" };

            //List<Directry> _dirs = _dbContext.Directry.Include(x=>x.Materials).ToList();
            //return View(_model);
            //List<Directry> _dirs = _directrysRepository.GetAllDirectrys().ToList();
            List<Directry> _dirs = _dataManager.Directrys.GetAllDirectrys(true).ToList();
            return View(_dirs);
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