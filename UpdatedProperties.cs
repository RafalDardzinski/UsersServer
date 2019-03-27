using System.Collections.Generic;

namespace UsersServer
{
    public abstract class UpdatedProperties<T> where T: class
    {
        protected readonly Dictionary<string, dynamic> _properties;

        protected UpdatedProperties(Dictionary<string, dynamic> properties)
        {
            _properties = properties;
        }

        // Zaktualizuj instancję modelu. Dla każdego modelu musi być zdefiniowana oddzielnie.
        public abstract T Set(T model);
    }
}
