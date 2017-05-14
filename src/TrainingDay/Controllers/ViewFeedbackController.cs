using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TrainingDay.Models;
using TrainingDay.Data;
using Microsoft.AspNetCore.Authorization;
using TrainingDay.ViewModels;

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

            //create list of saved feedback
            IList<Feedback> feedbackList = context.Feedbacks.ToList();

            //filter for feedback, only make available to pertinent manager/mentor
            List<Feedback> Feedbacks = new List<Feedback>();
            foreach (var item in feedbackList)
            {   //add feedback to list only if ID of current logged in user matches that of manager or mentor
                if (item.MentorID == CurrentUserID || item.ManagerID == CurrentUserID)
                {
                    Feedbacks.Add(item);
                }

            }
            //pass filtered list to view
            return View(Feedbacks);
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

            //use ID of feedback provider
            ApplicationUser FeedbackProvider = context.ApplicationUsers.Single
                (c => c.Id == individualFeedback.ApplicationUserID);
            //convert ID of feedback provider to name
            string feedbackProviderName = FeedbackProvider.AssociateName;

            //pass Feedback and provider name to view
            IndividualFeedbackViewModel individualFeedbackViewModel = new IndividualFeedbackViewModel(individualFeedback, CurrentUserID, feedbackProviderName);

            return View(individualFeedbackViewModel);

        }

    }
}