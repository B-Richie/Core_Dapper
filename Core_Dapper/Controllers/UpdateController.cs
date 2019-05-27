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
    public class UpdateController : Controller
    {
        private readonly IArtistService _svc;

        public UpdateController(IArtistService svc)
        {
            _svc = svc;
        }

        public IActionResult Index()
        {
            var model = _svc.GetFirstOrDefault(6428);

            if (model == null)
                return NotFound();

            return View(model);
        }

        public async Task<IActionResult> UpdateAsync(IArtistDto model, string btnUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (btnUpdate == "UpdateAsync")
                    {
                        var result = await _svc.UpdateAsync(model);
                    }
                    else
                    {
                        var result = _svc.Update(model);
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