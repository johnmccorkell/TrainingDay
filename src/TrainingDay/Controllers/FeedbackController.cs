using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingDay.ViewModels;
using TrainingDay.Models;
using Microsoft.EntityFrameworkCore;
using TrainingDay.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TrainingDay.Controllers
{
    [Authorize]
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
        public IActionResult AddFeedback()
        {
            IEnumerable<ApplicationUser> userList = context.ApplicationUsers.ToList();
            AddFeedbackViewModel addFeedbackViewModel = new AddFeedbackViewModel(userList);

            return View(addFeedbackViewModel);
        }



        [HttpPost]        
        public IActionResult AddFeedback(AddFeedbackViewModel addFeedbackViewModel)
        {    
            if (ModelState.IsValid)
            {   
                string UsersName= User.Identity.Name;
                ApplicationUser CurrentUser= context.ApplicationUsers.Single
                    (c => c.UserName == UsersName);

                Feedback newFeedback = new Feedback
                {   ApplicationUserID= CurrentUser.Id,
                    EntryDate = DateTime.Now,
                    MentorID=addFeedbackViewModel.MentorID,
                    ManagerID=addFeedbackViewModel.ManagerID,                    
                    Focus = addFeedbackViewModel.Focus,
                    Accomplishment=addFeedbackViewModel.Accomplishment,
                    Confidence=addFeedbackViewModel.Confidence,
                    ILikeNotes = addFeedbackViewModel.ILikeNotes,
                    IWishNotes=addFeedbackViewModel.IWishNotes,
                    ManagerNotes=addFeedbackViewModel.ManagerNotes
                };

                context.Feedbacks.Add(newFeedback);
                context.SaveChanges();

                return Redirect("/Feedback");

            }
            return View(addFeedbackViewModel);
        }


        
    }
}