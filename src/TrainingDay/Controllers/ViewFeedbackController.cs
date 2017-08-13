using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingDay.Models;
using TrainingDay.Data;
using Microsoft.AspNetCore.Authorization;
using TrainingDay.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace TrainingDay.Controllers
{
    [Authorize]
    public class ViewFeedbackController : Controller
    {
        private ApplicationDbContext context;       

        public ViewFeedbackController(ApplicationDbContext dbContext)
        {
            context = dbContext;
            

        }



        //create filtered list of feedback
        public IActionResult Index()
        {
            //get identity of logged in user
            string UsersName = User.Identity.Name;
            //call database for name of user
            ApplicationUser CurrentUser = context.ApplicationUsers.Single
                (c => c.UserName == UsersName);
            //collect ID of logged in user
            string CurrentUserID = CurrentUser.Id;

            //create filtered list of saved feedback so only selected manager or mentor can view           
            List<Feedback> FeedbackList = context
                .Feedbacks
                .Where(m => m.ManagerID == CurrentUserID)
                .Where(mt => mt.MentorID == CurrentUserID)
                .ToList();          

               return View(FeedbackList);          

            
        }



        //view details of individual piece of feedback, passes in ID of selected feedback from view
        public IActionResult IndividualFeedback(int id)
        {     
            //get identity of logged in user
            string UsersName = User.Identity.Name;
            //call database for name of user
            ApplicationUser CurrentUser = context.ApplicationUsers.Single
                (c => c.UserName == UsersName);
            //collect ID of logged in user-LOOK FOR WAY TO DRY THIS REPEAT
            string CurrentUserID = CurrentUser.Id;

           //find feedback using passed in ID
            Feedback individualFeedback = context.Feedbacks.Single
                (m => m.ID == id);            

            //pass Feedback and current user ID to view
            IndividualFeedbackViewModel individualFeedbackViewModel = new IndividualFeedbackViewModel(individualFeedback, CurrentUserID);

            return View(individualFeedbackViewModel);
        }


        


        } 
    }
