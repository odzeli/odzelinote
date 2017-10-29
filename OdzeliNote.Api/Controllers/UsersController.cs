﻿using System;
using NLog;
using System.Web.Http;
using OdzeliNote.Manager.Model;
using OdzeliNote.Manager.Concrete;

namespace OdzeliNote.Api.Controllers
{
    /// <summary>
    /// Управление пользователями
    /// </summary>
    public class UsersController : ApiController
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns></returns>
        [HttpGet]
        public User Get(Guid id)
        {
            logger.Info("Получение пользователя");
            var _usersRepository = new UserManager("DefaultConnection");
            return _usersRepository.GetUser(id);
        }
        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="user">Пользователь</param>
        /// <returns></returns>
        [HttpPost]
        public User Create(User user)
        {
            var _usersRepository = new UserManager("DefaultConnection");
            return _usersRepository.Create(user);
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        [HttpDelete]
        public void Delete(Guid id)
        {
            var _usersRepository = new UserManager("DefaultConnection");
            _usersRepository.Delete(id);
        }
    }
}