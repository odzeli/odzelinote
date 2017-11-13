using System;
using OdzeliNote.Manager;
using OdzeliNote.Repository;
using OdzeliNote.Manager.Model;
using OdzeliNote.Manager.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OdzeliNote.Tests
{
    [TestClass]
    public class NoteManagerTests
    {
        private readonly INoteManager _noteManager;
        string _connectionString;
        public NoteManagerTests()
        {
            _connectionString = "DefaultConnection";
            _noteManager = new NoteManager(_connectionString, new UserManager(_connectionString));
        }
        [TestMethod]
        public void CreateNote()
        {
            var note = new Note()
            {
                Id = Guid.Empty,
                Name = "Bolivia",
                Text = "Boltovnya",
                UserId = Guid.Parse("7D900474-7EB3-E711-8302-AC9E17413A67")
            };
            var returnedNote = _noteManager.Create(note);
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
