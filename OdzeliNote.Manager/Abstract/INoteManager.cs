using System;
using OdzeliNote.Manager.Model;
using System.Collections.Generic;

namespace OdzeliNote.Manager
{
    interface INoteManager
    {
        Note Create(Note note);

        void Update(Note note);

        void Remove(Guid noteId);

        void Share(Guid noteId);

        List<Note> Load(Guid userId);

        Note GetNote(Guid noteId);
    }
}
