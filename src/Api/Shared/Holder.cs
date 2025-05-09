using Domain.Interfaces.v1.Context;

namespace Application.Shared
{
    public static class Holder
    {
        public static ServiceProvider? Container { get; set; }
        public static IContext Context => Container!.GetRequiredService<IContext>();
    }
}