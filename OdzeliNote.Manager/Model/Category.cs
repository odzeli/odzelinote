﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdzeliNote.Manager.Model
{
    public class Category : BaseClass
    {
        public string Name { get; set; }

        public Guid UserId { get; set; }

        public Guid? NoteId { get; set; }
    }
}
