﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Teme.Contract.Infrastructure;
using Teme.Contract.Infrastructure.Primitives.Enums;
using Teme.Shared.Data.Primitives.Contract;
using WorkflowCore.Users.Models;

namespace Teme.Contract.Logic.DeclarantActions
{
    public class DeclarantActionsLogic : IDeclarantActionsLogic
    {
        private readonly IContractWorkflowLogic _wflogic;

        public DeclarantActionsLogic(IContractWorkflowLogic wflogic)
        {
            _wflogic = wflogic;
        }

        public async Task<object> PublishUserAction(string userPromt, string userOption, string contractId)
        {
            var actions = await _wflogic.GetUserActions(contractId, "declarant");
            var action = actions
                .FirstOrDefault(x => x.Prompt == userPromt && x.Options.ContainsKey(userOption));
            if (action == null) throw new ArgumentException("Action not found");

            var executorsIds = new Dictionary<string, IEnumerable<string>> {{ScopeEnum.Coz, new[] {"BossCoz"}}};
            
            var r = await _wflogic.PublishUserAction(action.Key, userOption, executorsIds, ContractTypeEnum.OneToMore);

            return new {r};
        }
    }
}