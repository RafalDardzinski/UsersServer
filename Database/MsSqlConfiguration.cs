using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Connection;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using UsersServer.User;

namespace UsersServer.Database
{
    public class MsSqlConfiguration : Configuration
    {

        public MsSqlConfiguration(string connectionString)
        {
            this.DataBaseIntegration(db =>
            {
                db.ConnectionString = connectionString;
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
            });
            MapModels("mssql-db");
        }

        private void MapModels(string documentFileName)
        {
            var modelMapper = new ModelMapper();
            modelMapper.AddMapping(new UserMapping());

            var compiledMapping = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
            this.AddDeserializedMapping(compiledMapping, documentFileName);
        }
    }
}
