﻿using Serilog;
using Teme.Contract.Infrastructure.WorkflowSteps;
using WorkflowCore.Interface;

namespace Teme.Contract.Infrastructure
{

    public class Data
    {
        public object Value { get; set; }
        public int Counter { get; set; }
    }

    public class ContractWorkflow : IWorkflow<Data>
    {
        public string Id => "Contract";

        public int Version => 0; // Test version

        public void Build(IWorkflowBuilder<Data> builder)
        {
            builder.StartWith<A1Step>()
                .While(data => data.Counter < 15)
                    .Do(x => x
                        .StartWith<CounterIncrement>()
                            .Input(step => step.Counter, data => data.Counter)
                            .Output(data => data.Counter, step => step.Counter)
                        .Then<CounterPrint>()
                            .Input(step => step.Counter, data => data.Counter)
                            .Output(data => data.Counter, step => step.Counter))
                .WaitFor("event", data => "key")
                .UserTask("Do you apptove", data => "user")
                    .WithOption("yes", "I approve").Do(then => then
                        .StartWith(context => Log.Information("You approved"))
                    )
                    .WithOption("no", "I do not approve").Do(then => then
                        .StartWith(context => Log.Information("You did not approve"))
                    )
                .Then<Finish>();
        }
    }
}
