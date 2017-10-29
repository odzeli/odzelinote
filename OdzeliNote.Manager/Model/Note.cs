using System;
namespace OdzeliNote.Manager.Model
{
    public class Note : BaseClass
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Changed { get; set; }

        public Guid UserId { get; set; }

        public Guid? CategoryId { get; set; }
    }
}
