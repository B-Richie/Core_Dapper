using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_Dapper.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Core_Dapper.Controllers
{
    public class GetController : Controller
    {
        private readonly IArtistService _svc;

        private readonly ILogger _logger;

        public GetController(IArtistService svc, ILogger<GetController> logger)
        {
            _svc = svc;
            _logger = logger;

        }

        public IActionResult GetList()
        {
            try
            {
                var id = 237;
                _logger.LogInformation("Getting list of activity results for {ID}", id);
                var result = _svc.GetList(id);                

                if (result == null)
                {
                    _logger.LogWarning("Get list by {ID} not found", id);
                    return NotFound();
                }
                    

                return View(result);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred getting activity list");
                ModelState.AddModelError("", "An error occurred while executing your query");
                return View();
            }            
        }

        public IActionResult GetOverride()
        {
            try
            {
                var result = _svc.GetOverride(8268);

                if (result == null)
                    return NotFound();

                return View(result);

            }
            catch(Exception)
            {
                ModelState.AddModelError("", "An error occurred while executing your query");
                return View();
            }
        }

        public async Task<IActionResult> GetListAsync()
        {
            try
            {
                var result = await _svc.GetListAsync(237);

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

        public IActionResult GetFirstOrDefault()
        {
            try
            {
                var result = _svc.GetFirstOrDefault(8268);
                //var result2 = _svc.GetFirstOrDefault(8267);

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

        public async Task<IActionResult> GetFirstorDefaultAsync()
        {
            try
            {
                var result = await _svc.GetFirstOrDefaultAsync(6419);
                //if (result != null)
                //    return RedirectToAction("GetFirstorDefaultAsync2", "Get2");


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
    }
}