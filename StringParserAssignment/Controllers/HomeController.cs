using StringParserAssignment.Models;
using StringParserAssignment.Services;
using System.Linq;
using System.Web.Mvc;

namespace StringParserAssignment.Controllers
{
    public class HomeController : Controller
    {
       IParserService _parserService;

        public HomeController() : this(new ParserService())
        {
        }

        public HomeController(IParserService parserService)
        {
            _parserService = parserService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(new StringParserViewModel() { Parsers = _parserService.GetAllParsers() });
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        public JsonResult Parse(StringParserViewModel parserViewModel)
        {
            var result = _parserService.Parse(parserViewModel.InputText, parserViewModel.Parsers.First());
            return Json(result);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

       

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

     

        
    }
}
