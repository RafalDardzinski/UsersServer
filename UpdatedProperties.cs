using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer
{
    public abstract class UpdatedProperties<T> where T: class
    {
        protected readonly Dictionary<string, dynamic> _properties;

        protected UpdatedProperties(Dictionary<string, dynamic> properties)
        {
            _properties = properties;
        }

        public abstract T Set(T model);
    }
}
