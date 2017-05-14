﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TrainingDay.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {       
        //add name independent of built in User information, for flexibility and practice extending 
        public string AssociateName { get; set; }       
                         


    }
}
