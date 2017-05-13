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

        public IActionResult Index()
        {
            string UsersName = User.Identity.Name;
            ApplicationUser CurrentUser = context.ApplicationUsers.Single
                (c => c.UserName == UsersName);
            string CurrentUserID = CurrentUser.Id;

            IList<Feedback> feedbackList = context.Feedbacks.ToList();

            List<Feedback> Feedbacks = new List<Feedback>();

            foreach (var item in feedbackList)
            {
                if (item.MentorID == CurrentUserID || item.ManagerID == CurrentUserID)
                {
                    Feedbacks.Add(item);
                }

            }
            return View(Feedbacks);
        }

        public IActionResult IndividualFeedback(int id)
        {
            string UsersName = User.Identity.Name;
            ApplicationUser CurrentUser = context.ApplicationUsers.Single
                (c => c.UserName == UsersName);
            string CurrentUserID = CurrentUser.Id;
           
            Feedback individualFeedback = context.Feedbacks.Single
                (m => m.ID == id);

            ApplicationUser FeedbackProvider = context.ApplicationUsers.Single
                (c => c.Id == individualFeedback.ApplicationUserID);

            string feedbackProviderName = FeedbackProvider.AssociateName;

            IndividualFeedbackViewModel individualFeedbackViewModel = new IndividualFeedbackViewModel(individualFeedback, CurrentUserID, feedbackProviderName);

            return View(individualFeedbackViewModel);


        }

    }
}