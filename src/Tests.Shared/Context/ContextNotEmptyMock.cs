using Domain.Interfaces.v1.Context;
using Domain.Models.v1;

namespace Tests.Shared.Context
{
    public class ContextNotEmptyMock
    {
        public IContext GetContext()
        {
            var context = new Application.Shared.Context();
            context.AddOrOverwriteContext("UserInformation", new UserInformation(Guid.NewGuid(), "role"));
            return context;
        }
    }
}
