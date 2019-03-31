using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace UsersServer.Database
{
    // Klasa odpowiadająca za stworzenie konfiguracji dla Database Managera.
    public class MsSqlConfiguration : Configuration
    {
        // Tworzy konkretną konfigurację MSSQL dla nHibernate 
        public MsSqlConfiguration(string connectionString, string mappingDocumentFileName = "default")
        {
            var compiledModels = MappingCompiler.CompileModels();
            SetDatabaseIntegration(connectionString);
            this.AddDeserializedMapping(compiledModels, mappingDocumentFileName);
        }
        
        // Ustawia integrację z bazą danych MSSQL na podstawie connection string.
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
