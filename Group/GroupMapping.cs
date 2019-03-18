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
                nm.Unique(true);
            });

            Bag(g => g.Users, gm =>
            {
                gm.Table("Users2Groups");
                gm.Key(k => k.Column("Id"));
                gm.Cascade(Cascade.None);
            }, m => m.ManyToMany(t => t.Column("GroupId")));
        }
    }
}
