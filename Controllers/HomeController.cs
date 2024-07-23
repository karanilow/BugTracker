using bugtracker.Data;
using bugtracker.Models;
using bugtracker.Models.Home;
using bugtracker.Models.Projects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace bugtracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BugtrackerContext _context;

        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, BugtrackerContext context, IMemoryCache cache)
        {
            _context = context;
            _logger = logger;
            _cache = cache;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var viewModel = new HomeViewModel();

            viewModel.Projects = _context.Projects.Select(p => new ProjectItemViewModel(p)).ToList();

            PopulateProjectsDropDownList();

            return View(viewModel);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int code)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [Route("{*url}", Order = 999)]
        public IActionResult Error404()
        {
            Response.StatusCode = 404;
            return View();
        }

        private void PopulateProjectsDropDownList(object selectedProject = null)
        {
            List<ProjectItemViewModel> projectList;
            if (!_cache.TryGetValue("ProjectList", out projectList))
            {
                projectList = _context.Projects.OrderBy(p => p.Title).Select(p => new ProjectItemViewModel(p)).ToList();
                _cache.Set("ProjectList", projectList, TimeSpan.FromMinutes(10));
            }

            ViewBag.ProjectList = new SelectList(projectList, "Id", "Title", selectedProject);

        }
    }
}