using DataService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataService.Repositories
{
    /// <summary>
    /// Класс для хранения и обработки данных в памяти.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    public abstract class InMemoryRepository<T> : IRepository<T> where T : class, IEntity
    {
        /// <summary>
        /// Лист для хранения данных в памяти.
        /// </summary>
        protected List<T> InMemoryStorage { get; } = new List<T>();

        /// <summary>
        /// Метод для поиска экземпляра сущности по Id.
        /// </summary>
        /// <param name="id">Id сущности.</param>
        /// <returns>Возвращает экземпляр сущности.</returns>
        public virtual T Get(Guid id)
        {
            return this.InMemoryStorage.Find(item => item.Id.Equals(id));
        }

        /// <summary>
        /// Метод для поиска всех экземпляров сущности.
        /// </summary>
        /// <returns>Возвращает все экземпляры сущности.</returns>
        public virtual IQueryable<T> GetAll()
        {
            return this.InMemoryStorage.AsQueryable<T>();
        }

        /// <summary>
        /// Метод сохраняет новый или обновленный экземпляр сущности.
        /// </summary>
        /// <param name="entity">Экземпляр сущности.</param>
        /// <returns>Возвращает экземпляр сущности.</returns>
        public virtual T Save(T entity)
        {
            var index = this.InMemoryStorage.FindIndex(item => item.Id.Equals(entity.Id));
            if (index == -1)
            {
                this.InMemoryStorage.Add(entity);
            }
            else
            {
                this.InMemoryStorage[index] = entity;
            }

            return entity;
        }

        /// <summary>
        /// Метод удаляет экземпляр сущности.
        /// </summary>
        /// <param name="id">Id сущности.</param>
        /// <returns>Возвращает экземпляр сущности.</returns>
        public virtual T Delete(Guid id)
        {
            var entity = this.InMemoryStorage.Find(item => item.Id.Equals(id));
            this.InMemoryStorage.Remove(entity);
            return entity;
        }

        /// <summary>
        /// Метод создает экземпляр сущности.
        /// </summary>
        /// <returns>Возвращает экземпляр сущности.</returns>
        public virtual T Create()
        {
            var id = Guid.NewGuid();
            var type = typeof(T);
            return (T)Activator.CreateInstance(type, id);
        }
    }
}
