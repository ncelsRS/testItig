﻿using System.Collections.Generic;
using System.Threading.Tasks;
using WorkflowCore.Users.Models;

namespace Teme.Contract.Logic
{
    public interface IActionsLogic
    {
        /// <summary>
        /// Возвращает открытые задачи для пользователя
        /// </summary>
        /// <param name="workflowId">Идентификатор воркфлоу договора</param>
        /// <returns>Открытые задачи для пользователя по текущему контракту</returns>
        Task<IEnumerable<OpenUserAction>> OpenUserActions(string workflowId);
    }
}