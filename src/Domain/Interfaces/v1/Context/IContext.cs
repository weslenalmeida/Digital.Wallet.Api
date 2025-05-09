namespace Domain.Interfaces.v1.Context
{
    public interface IContext
    {
        Guid Id { get; }
        IDictionary<string, object> ContextData { get; }
        public T GetContext<T>(string key);
        public void AddOrOverwriteContext(string key, object value);
    }
}