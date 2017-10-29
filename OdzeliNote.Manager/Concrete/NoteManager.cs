using System;
using OdzeliNote.Manager.Model;
using OdzeliNote.Repository;
using System.Collections.Generic;

namespace OdzeliNote.Manager
{
    public class NoteManager : INoteManager
    {
        string _connectionString;

        public NoteManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Note Create(Note note)
        {
            using (var context = new UserContext(_connectionString))
            {
                var userManager = new Concrete.UserManager("DefaultConnection");
                var user = userManager.GetUser(note.UserId);
                var notetwo = new Repository.Model.Note()
                {
                    Id = note.Id,
                    Name = note.Name,
                    Text = note.Text,
                    Changed = DateTime.Now,
                    Created = DateTime.Now,
                    UserId = note.UserId
                };
                context.Note.Add(notetwo);
                context.SaveChanges();
                return new Note()
                {
                    Id = notetwo.Id,
                    Name = notetwo.Name,
                    UserId = notetwo.UserId
                };
            };
        }

        public Note GetNote(Guid noteId)
        {
            using (var context = new UserContext(_connectionString))
            {
                Note resultNote = new Note();
                foreach (var note in context.Note)
                {
                    if (note.Id == noteId)
                    {
                        resultNote = new Note()
                        {
                            Id = note.Id,
                            Name = note.Name,
                            Text = note.Text,
                            Created = note.Created,
                            Changed = note.Changed,
                            UserId = note.UserId,
                            CategoryId = note.CategoryId
                        };
                    }
                }
                return resultNote;
            }
        }

        public void Remove(Guid noteId)
        {
            using (var context = new UserContext(_connectionString))
            {
                foreach (var note in context.Note)
                {
                    if (note.Id == noteId)
                    {
                        context.Note.Remove(note);
                    }
                }
            }
        }

        public List<Note> Load(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void Share(Guid noteId)
        {
            throw new NotImplementedException();
        }

        public void Update(Note note)
        {
            throw new NotImplementedException();
        }
    }
}
