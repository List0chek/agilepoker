using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4
{
    public class AccessRightsChecker
    {
        public AccessRights AccessRight { get; set; }

        /// <summary>
        /// Метод для проверки прав.
        /// Сначала проходит по всем правилам для поиска 64 правила, если оно есть, выводится AccessRights.AccessDenied.
        /// Если 64 правила найдено не было, то выводятся все правила из листа с правилами.
        /// </summary>
        public static void ShowAccessRights(AccessRights accessRights)
        {
            if (accessRights.HasFlag(AccessRights.AccessDenied))
            {
                Console.WriteLine(AccessRights.AccessDenied);
            }
            else
            {
                Console.WriteLine(accessRights);
            }   
        }

        /// <summary>
        /// Тип прав.
        /// </summary>
        [Flags, Serializable]
        public enum AccessRights : byte
        {
            /// <summary>
            /// Просмотр.
            /// </summary>
            View = 1,

            /// <summary>
            /// Выполнение.
            /// </summary>
            Run = 2,

            /// <summary>
            /// Добавление.
            /// </summary>
            Add = 4,

            /// <summary>
            /// Изменение.
            /// </summary>
            Edit = 8,

            /// <summary>
            /// Утверждение.
            /// </summary>
            Ratify = 16,

            /// <summary>
            /// Удаление.
            /// </summary>
            Delete = 32,

            /// <summary>
            /// Нет доступа.
            /// </summary>
            /// <remarks>
            /// Этот флаг имеет максимальный приоритет.
            /// Если он установлен, остальные флаги игнорируются 
            /// </remarks>
            AccessDenied = 64
        }
    }
}