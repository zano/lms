using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LMS.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateDateTime { get; set; }
        public int AuthorId { get; set; }
        public int TargetDocumentId { get; set; }

        public virtual ApplicationUser Author { get; set; }
        public virtual Document TargetDocument { get; set; } // Todo:  Could be even more generic and apply to Activity or even Group or User (for wall) or UserUser (for pm)

        // Todo: Revision management
    }
}