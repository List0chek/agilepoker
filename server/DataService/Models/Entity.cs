using System;

namespace DataService.Models
{
    /// <summary>
    /// Абстрактный класс для определения сущности.
    /// </summary>
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// Id сущности Entity.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Конструктор класса Entity.
        /// </summary>
        /// <param name="id">Id сущности Entity.</param>
        public Entity(Guid id)
        {
            this.Id = id;
        }
    }
}
