using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TrainingDay.Models;

namespace TrainingDay.ViewModels
{
    public class AddFeedbackViewModel
    {
        public string ApplicationUserID { get; set; } 

        public AccomplishmentRating Accomplishment { get; set; }
        public List<SelectListItem> AccomplishmentRatings { get; set; }        

        public ConfidenceRating Confidence { get; set; }
        public List<SelectListItem> ConfidenceRatings { get; set; }
        
        //public List<ApplicationUser> UserList { get; set; }
        public List<SelectListItem> Users { get; set; }       


        [Required]
        [Display(Name = "Focus Area")]
        public string Focus { get; set; }

        [Required]
        [Display(Name = "I Like Notes")]
        public string ILikeNotes { get; set; }

        [Required]
        [Display(Name ="I Wish Notes")]
        public string IWishNotes { get; set; }

        [Display(Name ="Manager Notes")]
        public string ManagerNotes { get; set; }

        [Required]
        public string ManagerID { get; set; }

        [Required]
        public string MentorID { get; set; }

        public AddFeedbackViewModel() { }

        public AddFeedbackViewModel(IEnumerable<ApplicationUser> userList)
        {            

            AccomplishmentRatings = new List<SelectListItem>();

            // <option value="0">Behind</option>
            AccomplishmentRatings.Add(new SelectListItem()
            {
                Value = ((int)AccomplishmentRating.Behind).ToString(),
                Text = AccomplishmentRating.Behind.ToString()
            });

            // <option value="1">Current</option>
            AccomplishmentRatings.Add(new SelectListItem()
            {
                Value = ((int)AccomplishmentRating.Current).ToString(),
                Text = AccomplishmentRating.Current.ToString()
            });

            // <option value="2">Ahead</option>
            AccomplishmentRatings.Add(new SelectListItem()
            {
                Value = ((int)AccomplishmentRating.Ahead).ToString(),
                Text = AccomplishmentRating.Ahead.ToString()
            });

            ConfidenceRatings = new List<SelectListItem>();

            // <option value="0">Red</option>
            ConfidenceRatings.Add(new SelectListItem()
            {
                Value = ((int)ConfidenceRating.Red).ToString(),
                Text = ConfidenceRating.Red.ToString()
            });

            // <option value="1">Yellow</option>
            ConfidenceRatings.Add(new SelectListItem()
            {
                Value = ((int)ConfidenceRating.Yellow).ToString(),
                Text = ConfidenceRating.Yellow.ToString()
            });

            // <option value="2">Green</option>
            ConfidenceRatings.Add(new SelectListItem()
            {
                Value = ((int)ConfidenceRating.Green).ToString(),
                Text = ConfidenceRating.Green.ToString()
            });

            Users = new List<SelectListItem>();

            foreach (var user in userList)
            {
                Users.Add(new SelectListItem
                {   Value = user.Id.ToString(),
                    Text = user.AssociateName.ToString()
                });
            }

        }

    
    }
}
