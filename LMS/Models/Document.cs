using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string OriginalName { get; set; }
        public string Path { get; set; }
        public int ApplicationUserId { get; set; }
        public int GroupId { get; set; }
        public DateTime CreateDateTime { get; set; }

        public virtual ApplicationUser Uploader { get; set; }
        public virtual Group Group { get; set; } // TODO: change this to Activity or some such

        // Comments
    }
}