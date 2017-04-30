using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrainingDay.Models
{
    public class Feedback
      
    {
        public int ID { get; set; }

        public DateTime EntryDate { get; set; }

        public int ApplicationUserID { get; set; }

        public int MentorID { get; set; }

        public int ManagerID { get; set; }

        public string Focus { get; set; }

        public AccomplishmentRating Accomplishment {  get; set; }

        public ConfidenceRating Confidence{  get; set; }

        public string ILikeNotes { get; set; }

        public string IWishNotes { get; set; }

        public string ManagerNotes { get; set; }


    }
}
