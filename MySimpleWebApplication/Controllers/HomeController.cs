using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySimpleWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySimpleWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private static List<ContactFormModel> _submissions = new List<ContactFormModel>();

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View("Contact");
        }

        [HttpPost]
        public IActionResult SubmitContact(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                // Add the form submission to a static list
                _submissions.Add(model);

                // Redirect to the submissions page
                return RedirectToAction("Submissions");
            }
            // In case of validation errors, re-display the form
            return View("Contact");
        }
        [HttpGet]
        public IActionResult Submissions(string nameFilter)
        {
            // Ensure the list is initialized
            List<ContactFormModel> filteredSubmissions;

            // Apply the name filter if provided
            if (!string.IsNullOrEmpty(nameFilter))
            {
                filteredSubmissions = _submissions.FindAll(s => s.Name.Contains(nameFilter));
            }
            else
            {
                // Otherwise return all submissions
                filteredSubmissions = _submissions;
            }

            // Pass an empty list if there are no submissions, ensuring model is never null
            filteredSubmissions ??= new List<ContactFormModel>();

            // Pass the filtered list to the view
            return View(filteredSubmissions);
        }
    }
}
