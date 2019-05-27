using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_Dapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core_Dapper.Controllers
{
    public class ExecuteProcController : Controller
    {
        private readonly IArtistService _svc;

        public ExecuteProcController(IArtistService svc)
        {
            _svc = svc;
        }

        public async Task<IActionResult> ExecuteAsync()
        {
            try
            {
                var result = await _svc.CallProcedureAsync("17603497");

                if (result == null)
                    return NotFound();

                return View(result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred while executing your query");
                return View();
            }
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}