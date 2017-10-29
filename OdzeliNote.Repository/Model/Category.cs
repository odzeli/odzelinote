using System;

namespace OdzeliNote.Repository.Model
{
    public class Category : BaseClass
    {
        public string Name { get; set; }

        public Guid? NoteId { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual Note Note { get; set; }
    }
}
