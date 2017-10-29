namespace OdzeliNote.Repository.Model
{
    public class Share : BaseClass
    {
        public virtual Note Note { get; set; }

        public virtual User User { get; set; }
    }
}
