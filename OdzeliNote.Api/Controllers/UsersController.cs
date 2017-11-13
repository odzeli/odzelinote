using System;
using NLog;
using System.Web.Http;
using OdzeliNote.Manager.Model;
using OdzeliNote.Manager.Concrete;
using OdzeliNote.Manager.Abstract;

namespace OdzeliNote.Api.Controllers
{
    /// <summary>
    /// Управление пользователями
    /// </summary>
    public class UsersController : ApiController
    {
        private readonly IUserManager _usersManager;
        private readonly string _connectinString;

        public UsersController()
        {
            _connectinString = "DefaultConnection";
            _usersManager = new UserManager(_connectinString);
        }

        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/users/{id}")]
        public User Get(Guid id)
        {
            logger.Info("Получение пользователя");
            return _usersManager.GetUser(id);
        }
        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public User Create(User user)
        {
            return _usersManager.Create(user);
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        [HttpDelete]
        public void Delete(Guid id)
        {
            _usersManager.Delete(id);
        }
    }
}