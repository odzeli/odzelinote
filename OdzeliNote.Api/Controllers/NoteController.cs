using System;
using System.Web.Http;
using OdzeliNote.Manager;
using OdzeliNote.Manager.Model;
using OdzeliNote.Manager.Concrete;

namespace OdzeliNote.Api.Controllers
{
    /// <summary>
    /// Управление заметками
    /// </summary>
    public class NoteController : ApiController
    {
        private readonly INoteManager _noteManager;
        string _connectionString;

        public NoteController()
        {
            _connectionString = "DefaultConnection";
            _noteManager = new NoteManager(_connectionString, new UserManager(_connectionString));
        }
        /// <summary>
        /// Получени заметки для пользователя
        /// </summary>
        /// <param name="noteId">Идентификатор пользователя</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/note/{id}")]
        public Note Get(Guid id)
        {
            return _noteManager.GetNote(id);
        }
        /// <summary>
        /// Создание заметки
        /// </summary>
        /// <param name="note">Заметка</param>
        /// <returns></returns>
        [HttpPost]
        public Note Create(Note note)
        {
            return _noteManager.Create(note);
        }
        /// <summary>
        /// Удалени заметки
        /// </summary>
        /// <param name="noteId">Идентификатор заметки</param>
        [HttpDelete]
        public void Remove(Guid noteId)
        {
            _noteManager.Remove(noteId);
        }

        [HttpGet]
        [Route("api/note/testId/{id}")]
        public Guid TestId(Guid id)
        {
            return id;
        }

        [HttpGet]
        [Route("api/note/test")]
        public string Test()
        {
            return "rrr";
        }
    }
}
