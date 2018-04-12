﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teme.Contract.Infrastructure;
using WorkflowCore.Interface;
using WorkflowCore.Users.Models;

namespace Teme.Contract.Logic
{
    public class ContractLogic
    {
        private readonly IWorkflowHost _host;

        public ContractLogic(IWorkflowHost host)
        {
            _host = host;
        }

        public async Task<string> StartWorkflow()
        {
            var key = Guid.NewGuid().ToString();
            var awaiter = TaskCompletionService.AddTask(key);
            await _host.StartWorkflow("Contract", new ContractWorkflowTransitionData {
                AwaiterKey = key,
                ExecutorId = "declarantId",
                ContractType = 0
            });
            return await awaiter;
        }

        public async Task<string> PublishEvent(string name, string key, object data = null)
        {
            await _host.PublishEvent(name, key, data);
            return "Event published";
        }

    }
}
