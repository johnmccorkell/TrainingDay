using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingDay.Models;

namespace TrainingDay.ViewModels
{
    public class IndividualFeedbackViewModel
    {
        public Feedback IndividualFeedback { get; set; } 

        public string CurrentUserId { get; set; }

        public string FeedbackProviderName { get; set; }

        public IndividualFeedbackViewModel() { }        

        public IndividualFeedbackViewModel(Feedback individualFeedback, string currentUserID, string feedBackProviderName)
        {
            IndividualFeedback = individualFeedback;
            CurrentUserId = currentUserID;
            FeedbackProviderName = feedBackProviderName;

            if (CurrentUserId!=IndividualFeedback.ManagerID)
            {
                IndividualFeedback.ManagerNotes = null;

            }

          
        }
    }
}
