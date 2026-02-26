using System;
using System.Linq;
using DataService.Models;

namespace DataService
{
  /// <summary>
  /// Интерфейс IRepository.
  /// </summary>
  /// <typeparam name="T">Тип сущности.</typeparam>
  public interface IRepository<T> where T : class, IEntity
  {
    /// <summary>
    /// Метод для сохранения экземпляра сущности.
    /// </summary>
    /// <param name="entity">Экземпляр сущности.</param>
    /// <returns>Возвращает экземпляр сущности.</returns>
    T Save(T entity);

    /// <summary>
    /// Метод для поиска экземпляра сущности по Id.
    /// </summary>
    /// <param name="id">Id сущности.</param>
    /// <returns>Возвращает экземпляр сущности.</returns>
    T Get(Guid id);

    /// <summary>
    /// Метод для поиска всех экземпляров сущности.
    /// </summary>
    /// <returns>Возвращает все экземпляры сущности.</returns>
    IQueryable<T> GetAll();


    /// <summary>
    /// Метод удаляет экземпляр сущности.
    /// </summary>
    /// <param name="id">Id сущности.</param>
    /// <returns>Возвращает экземпляр сущности.</returns>
    T Delete(Guid id);

    /// <summary>
    /// Метод создает экземпляр сущности.
    /// </summary>
    /// <returns>Возвращает экземпляр сущности.</returns>
    T Create();
  }
}