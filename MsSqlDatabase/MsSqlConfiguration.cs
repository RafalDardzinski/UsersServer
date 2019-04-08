using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace UsersServer.Database
{
    /// <summary>
    /// Configuration specific to MSSQL databases.
    /// </summary>
    public class MsSqlConfiguration : Configuration
    {
        public MsSqlConfiguration(IConnectionString connectionString, string mappingDocumentFileName = "default")
        {
            var compiledModels = MappingCompiler.CompileModels();
            SetDatabaseIntegration(connectionString.Value);
            AddDeserializedMapping(compiledModels, mappingDocumentFileName);
        }
        
        /// <summary>
        /// Sets integration with the database.
        /// </summary>
        /// <param name="connectionString"></param>
        private void SetDatabaseIntegration(string connectionString)
        {
            this.DataBaseIntegration(db =>
            {
                db.ConnectionString = connectionString;
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
            });
        }
    }
}
