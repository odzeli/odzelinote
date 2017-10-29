using System;
using System.Web.Http;
using OdzeliNote.Manager;
using OdzeliNote.Manager.Model;

namespace OdzeliNote.Api.Controllers
{
    /// <summary>
    /// Управление заметками
    /// </summary>
    public class NoteController : ApiController
    {
        NoteManager _userManager = new NoteManager("DefaultConnection");
        /// <summary>
        /// Получени заметки для пользователя
        /// </summary>
        /// <param name="noteId">Идентификатор пользователя</param>
        /// <returns></returns>
        [HttpGet]
        public Note Get(Guid noteId)
        {
            return _userManager.GetNote(noteId);
        }
        /// <summary>
        /// Создание заметки
        /// </summary>
        /// <param name="note">Заметка</param>
        /// <returns></returns>
        [HttpPost]
        public Note Create(Note note)
        {
            return _userManager.Create(note);
        }
        /// <summary>
        /// Удалени заметки
        /// </summary>
        /// <param name="noteId">Идентификатор заметки</param>
        [HttpDelete]
        public void Remove(Guid noteId)
        {
            _userManager.Remove(noteId);
        }
    }
}
