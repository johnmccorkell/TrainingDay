using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingDay.ViewModels;
using TrainingDay.Models;
using Microsoft.EntityFrameworkCore;
using TrainingDay.Data;

namespace TrainingDay.Controllers
{
    public class FeedbackController : Controller
    {

        private ApplicationDbContext context;

        public FeedbackController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            IEnumerable<AccomplishmentRating> categoryList = context.Accomplishments.ToList();
            AddFeedbackViewModel addFeedbackViewModel = new AddFeedbackViewModel(categoryList);

            return View();
        }

        [HttpPost]
        public IActionResult Add(AddFeedbackViewModel addFeedbackViewModel)
        {
            if (ModelState.IsValid)
            {



                return Redirect("/Index");

            }
            return View(addFeedbackViewModel);

        }
    }
}