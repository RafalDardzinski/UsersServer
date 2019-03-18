using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace UsersServer.User
{
    public class UserMapping : ClassMapping<UserModel>
    {
        public UserMapping()
        {
            Table("Users");
            Id(u => u.UserId, im => im.Generator(Generators.Identity));
            Property(u => u.FirstName, m =>
            {
                m.Length(50);
                m.NotNullable(true);
            });
            Property(u => u.LastName, m =>
            {
                m.Length(50);
                m.NotNullable(true);
            });
            Property(u => u.Username, m =>
            {
                m.Length(50);
                m.NotNullable(true);
                m.Unique(true);
            });
            Property(u => u.Password, m =>
            {
                m.Length(255);
                m.NotNullable(true);
            });

            Bag(u => u.Groups, cm =>
            {
                cm.Table("Users2Groups");
                cm.Key(k => k.Column("GroupId"));
                cm.Cascade(Cascade.None);
                //cm.Inverse(true);
                cm.Lazy(CollectionLazy.NoLazy); // chcę mieć dostęp do wszystkich grup do których należy użytkownik.
            }, m => m.ManyToMany(t => t.Column("UserId")));
        }
    }
}
