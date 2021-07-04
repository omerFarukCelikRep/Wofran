using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class JobSeekerController : Controller
    {
        private readonly IJobSeekerService _jobSeekerService;
        private readonly IEducationService _educationService;

        public JobSeekerController(IJobSeekerService jobSeekerService, IEducationService educationService)
        {
            _jobSeekerService = jobSeekerService;
            _educationService = educationService;
        }

        // GET: JobSeekerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: JobSeekerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobSeekerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobSeekerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobSeekerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobSeekerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JobSeekerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobSeekerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Education()
        {
            JobSeeker jobSeeker = await _jobSeekerService.Get(a => a.UserID == new Guid("b74ddd14-6340-4840-95c2-db12554843e5"));
            return View(jobSeeker);
        }

        [HttpPost]
        public async Task<IActionResult> AddEducation(Education education)
        {
            education.JobSeekerID = new Guid("b74ddd14-6340-4840-95c2-db12554843e5");
            if (education.ID != Guid.Empty)
            {
                await _educationService.Update(education);
            }
            else if (ModelState.IsValid)
            {
                JobSeeker jobSeeker = await _jobSeekerService.Get(a => a.UserID == new Guid("b74ddd14-6340-4840-95c2-db12554843e5"));
                jobSeeker.Educations.Add(education);
                await _jobSeekerService.Update(jobSeeker);

                return ViewComponent("Educations", new { id = jobSeeker.UserID.ToString() });
            }

            return ViewComponent("Educations", new { id = "b74ddd14-6340-4840-95c2-db12554843e5" });
        }


        [HttpGet]
        public async Task<IActionResult> EditEducation(string id)
        {
            return Json(await _educationService.GetByID(new Guid(id)));
        }
    }
}
