using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core_Dapper.Models;
using Microsoft.AspNetCore.Mvc;


namespace Core_Dapper.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IB2bActivityQueueService _svc;
        //private readonly xIConnectionFactory _svccf;
        //private readonly xn_IConnectionSetup Setup;
        //private readonly DatabaseConnections _homeDbs;

        public HomeController()
        {
            //_svc = svc;
            //_homeDbs = homeDbs;
            //_svccf = svccf;
            //Setup = setup;
        }

        //public xConnectionService ConnectionService { get; set; }
        //public xIConnectionFactoryTransient ConnectionFactoryTransient { get; set; }
        //public xIConnectionFactoryScoped ConnectionFactoryScoped { get; set; }

        //public HomeController(ConnectionService connectionService, IConnectionFactoryScoped connectionFactoryScoped, IConnectionFactoryTransient connectionFactoryTransient)
        //{
        //    ConnectionService = connectionService;
        //    ConnectionFactoryScoped = connectionFactoryScoped;
        //    ConnectionFactoryTransient = connectionFactoryTransient;
        //}
        public async Task<IActionResult> Index()
        {
            //var result = new IArtistDto
            //{
            //    ACTIVITY_ID = 6420,
            //    REQUEST_XML = "updated request xml"
            //};


            //var b = new B2B_ACTIVITY_QUEUE_Dto
            //{
            //    ACTIVITY_STATUS = 2,
            //    CREATED_ON = DateTime.Now,
            //    ACTIVITY_TOOL_TYPE = 237,
            //    ACTIVITY_USER_ID = "9373821281",
            //    SHOW_ON_HOME_PAGE = 0,
            //    REQUEST_XML = "please remove me, i'm way too big",
            //    DATA_1 = "informative field description",
            //    DATA_2 = "hey, you're the same as above!",
            //    DATA_3 = "what??",
            //    DATA_4 = "now i'm really confused???",
            //    DATA_5 = "maybe data_6 too??",
            //    SUCCESS = "1",
            //    RESPONSE_XML = "just like my sibling",
            //    ERROR_MESSAGE = "that's what you get!"

            //};
            //var result = await _svc.Insert(b);
            //var result = await _svc.GetListAsync(237, 6398);
            //var result = _svc.GetFirstOrDefault(6420);
            //result.REQUEST_XML = "updated string";

            //var update = await _svc.Update(result);
            //var result = _svc.GetList(237);
            //var result = _svc.CallProcedure("17959850");
            //var result = await _svc.GetFirstOrDefaultAsync(6407);
            //return View(result);

            //long size = 0;
            //using (Stream stream = new MemoryStream())
            //{
            //    BinaryFormatter formatter = new BinaryFormatter();
            //    formatter.Serialize(stream, result);
            //    size = stream.Length;
            //}

            //var delete = await _svc.Delete(6420);

            //return null;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
