using System;

namespace OdzeliNote.Repository.Model
{
    public class Note : BaseClass
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Changed { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Guid? CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}

