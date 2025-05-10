using Domain.Interfaces.v1.Context;

namespace Application.Shared
{
    public class Context : IContext
    {
        public Guid Id { get; private set; }
        private readonly Dictionary<string, object>? _context;
        public IDictionary<string, object> ContextData => _context!;

        public Context()
        {
            Id = Guid.NewGuid();
            _context = [];
        }

        public void AddOrOverwriteContext(string key, object value)
        {
            if (_context!.ContainsKey(key))
                _context[key] = value;
            else
                _context!.Add(key, value);
        }

        public T GetContext<T>(string key)
        {
            if (_context!.ContainsKey(key)) return (T)_context.GetValueOrDefault(key)!;

            return default!;
        }
    }
}