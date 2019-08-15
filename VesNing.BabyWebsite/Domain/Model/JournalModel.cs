using Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Model
{
   public class JournalModel
    {
       
        public string JournalID
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }
        public string Content
        {
            get; set;
        }
        public DateTime JournalDate
        {
            get;set;
        }
        public string UserId
        {
            get;set;
        }
        public AppUser User
        {
            get; set;
        }
    }
}
