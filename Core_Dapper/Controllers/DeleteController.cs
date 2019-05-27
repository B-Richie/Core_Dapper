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
    public class DeleteController : Controller
    {
        private readonly IArtistService _svc;

        public DeleteController(IArtistService svc)
        {
            _svc = svc;
        }
        public IActionResult Index()
        {
            var model = _svc.GetFirstOrDefault(6418);

            if (model == null)
                return NotFound();

            return View(model);
        }

        public async Task<IActionResult> DeleteAsync(IArtistDto model, string btnDelete)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (btnDelete == "DeleteAsync")
                    {
                        var result = await _svc.DeleteAsync(model.ArtistID);
                    }
                    else
                    {
                        var result = _svc.Delete(model.ArtistID);
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