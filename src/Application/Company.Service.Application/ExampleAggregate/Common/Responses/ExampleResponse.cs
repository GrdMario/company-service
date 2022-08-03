namespace Company.Service.Application.ExampleAggregate.Common.Responses
{
    using System;

    public class ExampleResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
