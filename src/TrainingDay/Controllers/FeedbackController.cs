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

        //options to create or review feedback
        public IActionResult Index()
        {

            return View();
        }

        //form to create feedback
        [HttpGet]       
        public IActionResult AddFeedback()
        {   
            //create list of users for select list options
            IEnumerable<ApplicationUser> userList = context.ApplicationUsers.ToList();
            AddFeedbackViewModel addFeedbackViewModel = new AddFeedbackViewModel(userList);

            return View(addFeedbackViewModel);
        }


        //processes feedback form, creates and saves new feedback if valid, sends emails to manager and mentor
        [HttpPost]        
        public IActionResult AddFeedback(AddFeedbackViewModel addFeedbackViewModel)
        {    
            if (ModelState.IsValid)
            {   //find identity of logged in user 
                string UsersName= User.Identity.Name;
                //call database for user object
                ApplicationUser CurrentUser= context.ApplicationUsers.Single
                    (c => c.UserName == UsersName);

                Feedback newFeedback = new Feedback
                {   //collect ID of user object for record
                    ApplicationUserID = CurrentUser.Id,
                    ProviderName=CurrentUser.AssociateName,
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


                //find mentorID and name using their ID from the feedback
                ApplicationUser Mentor = context.ApplicationUsers.Single
                    (c => c.Id == newFeedback.MentorID);
                newFeedback.MentorName = Mentor.AssociateName;
                //grab their email
                string recepientMentor = Mentor.Email;
                //call email method, passing in address
                EmailNotification.SendEmail(recepientMentor);

                //find manager using their ID from the feedback
                ApplicationUser Manager = context.ApplicationUsers.Single
                    (c => c.Id == newFeedback.ManagerID);
                newFeedback.ManagerName = Manager.AssociateName;
                //grab their email
                string recepientManager = Manager.Email;
                //call email method, passing in address-LOOK AT WAY TO DRY REPEAT
                EmailNotification.SendEmail(recepientManager);

                //add and update database
                context.Feedbacks.Add(newFeedback);
                context.SaveChanges();

                //return to home feedback screen
                return Redirect("/Feedback");

            }
            //return to form if model does not validate
            return View(addFeedbackViewModel);
        }


        
    }
}