using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersServer
{
    interface IRepository
    {
        void Create(Model model);
        List<Model> Read();
        Model Read(Delegate filterFunc); // read specific
        void Update();
        void Delete();
    }
}
