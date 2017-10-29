using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdzeliNote.Manager;
using OdzeliNote.Manager.Model;
using System.Linq;
using OdzeliNote.Repository;

namespace OdzeliNote.Tests
{
    [TestClass]
    public class NoteManagerTests
    {
        [TestMethod]
        public void CreateNote()
        {
            var noteManager = new NoteManager("DefaultConnection");
            var note = new Note()
            {
                Id = Guid.Empty,
                Name = "Bolivia",
                Text = "Boltovnya",
                UserId = Guid.Parse("7D900474-7EB3-E711-8302-AC9E17413A67")
            };
            var returnedNote = noteManager.Create(note);
            Assert.AreEqual(returnedNote.Name, note.Name);
            Assert.AreNotEqual(returnedNote.Id, Guid.Empty);
            Assert.AreEqual(returnedNote.UserId, note.UserId);
        }

        [TestCleanup]
        public void CleanTests()
        {
            using (var context = new UserContext("DefaultConnection"))
            {
                foreach (var note in context.Note)
                {
                    context.Note.Remove(note);
                }
                context.SaveChanges();
            }
        }
    }
}
