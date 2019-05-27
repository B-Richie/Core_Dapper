using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_Dapper.Models;
using Core_Dapper.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core_Dapper.Controllers
{
    public class InsertController : Controller
    {

        private readonly IArtistService _svc;

        public InsertController(IArtistService svc)
        {
            _svc = svc;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Insert(B2B_ACTIVITY_QUEUE_Dto model)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var result = _svc.Insert(model);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            return View();
        //        }
        //    }
        //    catch (DbUpdateException)
        //    {
        //        ModelState.AddModelError("", "An error occurred while executing your query");
        //        return View();
        //    }
        //}

        public async Task<IActionResult> InsertAsync(ArtistDto model, string btnInsert)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (btnInsert == "InsertAsync")
                    {
                        var result = await _svc.InsertAsync(model);
                    }
                    else
                    {
                        var result = _svc.Insert(model);                        
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "An error occurred while executing your query");
                return View();
            }
        }
    }
}