using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdzeliNote.Manager.Model
{
    public class Share : BaseClass
    {
        public Guid NoteId { get; set; }

        public Guid UserId { get; set; }
    }
}
