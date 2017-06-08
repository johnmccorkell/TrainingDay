using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingDay.Models
{   //properties of individual feedback
    public class Feedback
      
    {
        public int ID { get; set; }

        //timestamp
        public DateTime EntryDate { get; set; }

        //ID of feedback provider
        public string ApplicationUserID { get; set; }

        public string ProviderName { get; set; }

        //ID of the name the provider selects as their mentor
        public string MentorID { get; set; }

        //ID of the name the provider selects as their manager
        public string ManagerID { get; set; }

        //focus of provider's training activities or area of concentration
        public string Focus { get; set; }

        //options for provider to select to rate their sense of accomplishment,
        //setting as enum to create consistency
        public AccomplishmentRating Accomplishment {  get; set; }

        //options for provider to select to rate their confidence moving forward,
        //setting as enum to create consistency
        public ConfidenceRating Confidence{  get; set; }

        //freefrom text for provider to explain what they liked about activities/trainer
        public string ILikeNotes { get; set; }

        //freefrom text for provider to explain what they would like to change about activities/trainer
        public string IWishNotes { get; set; }

        //freefrom text for provider to send confidential notes/concerns to their manager
        public string ManagerNotes { get; set; }


    }
}
