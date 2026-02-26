using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PlanPoker.DTO;
using System;

namespace PlanPoker
{
    /// <summary>
    /// Класс CustomExceptionFilter.
    /// </summary>
    public class CustomExceptionFilter : IExceptionFilter
    {
        /// <summary>
        /// Метод OnException.
        /// </summary>
        /// <param name="context">Экземпляр ExceptionContext.</param>
        public void OnException(ExceptionContext context)
        {

            var dto = new ExceptionDTO()
            {
                Message = context.Exception.Message
            };

            context.Result = new JsonResult(dto)
            {
                StatusCode = (context.Exception is UnauthorizedAccessException) ? 401 : 500, 
            };

            context.ExceptionHandled = true;
        }
    }
}
