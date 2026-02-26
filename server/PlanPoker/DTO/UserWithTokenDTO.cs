using PlanPoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanPoker.DTO
{
    public class UserWithTokenDTO
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        public UserDTO User { get; set; }

        /// <summary>
        /// Токен пользователя.
        /// </summary>
        public string Token { get; set; }
    }
}
