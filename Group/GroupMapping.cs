using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace UsersServer.Group
{
    public class GroupMapping : ClassMapping<GroupModel>
    {
        public GroupMapping()
        {
            Table("Groups");
            Id(g => g.Id, im => im.Generator(Generators.Identity));
            Property(u => u.Name, nm =>
            {
                nm.Length(50);
                nm.NotNullable(true);
            });

            Bag(g => g.Name, u =>
            {
                u.Table("Users2Groups");
                u.Key(k =>
                {
                    k.Column("Id");
                    k.NotNullable(true);
                });
                u.Cascade(Cascade.All);
                u.Inverse(true);
            }, g => g.ManyToMany(m => m.Column("Id")));
        }
    }
}
