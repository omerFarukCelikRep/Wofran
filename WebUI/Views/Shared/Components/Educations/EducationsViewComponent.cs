using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Views.Shared.Components.Educations
{
    public class EducationsViewComponent : ViewComponent
    {
        private readonly IEducationService _educationService;

        public EducationsViewComponent(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            return View(await _educationService.GetAll(a => a.JobSeekerID == new Guid(id)));
        }
    }
}
