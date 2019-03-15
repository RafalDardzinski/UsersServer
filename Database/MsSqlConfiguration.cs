using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using UsersServer.User;

namespace UsersServer.Database
{
    public class MsSqlConfiguration : Configuration
    {
        // klasa tworząca konkretną konfigurację dla nHibernate
        public MsSqlConfiguration(string connectionString, HbmMapping compiledModels, string mappingDocumentFileName)
        {
            Console.WriteLine(connectionString);
            SetDatabaseIntegration(connectionString);
            SetModelMappings(compiledModels, mappingDocumentFileName);
        }

        public MsSqlConfiguration(string connectionString, HbmMapping compiledModels)
            : this(connectionString, compiledModels, "default")
        {
            
        }
        

        private void SetDatabaseIntegration(string connectionString)
        {
            this.DataBaseIntegration(db =>
            {
                db.ConnectionString = connectionString;
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
            });
        }

        private void SetModelMappings(HbmMapping compiledModels, string documentFileName)
        {
            this.AddDeserializedMapping(compiledModels, documentFileName);
        }
    }
}
