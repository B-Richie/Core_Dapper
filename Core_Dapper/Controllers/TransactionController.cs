using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_Dapper.Models;
using Core_Dapper.Services;
using Dapper_DAL.Models;
using Microsoft.AspNetCore.Mvc;


namespace Core_Dapper.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IArtistService _svc;

        public TransactionController(IArtistService svc)
        {
            _svc = svc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ExecuteTransaction()
        {

            try
            {
                var b2b = new ArtistDto();
                var result = _svc.ExecuteTransaction(b2b);
                //int? result = null;

                if (result == null)
                    return NotFound();

                return View(result);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "An error occurred while executing your query");
                return View();
            }
        }
    }
}