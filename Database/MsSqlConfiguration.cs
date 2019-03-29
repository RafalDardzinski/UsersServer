
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
        public MsSqlConfiguration(MsSqlConnectionString connectionString, HbmMapping compiledModels, string mappingDocumentFileName)
        {
            SetDatabaseIntegration(connectionString);
            SetModelMappings(compiledModels, mappingDocumentFileName);
        }

        // Przeciążenie konstruktora używające domyślnej nazwy dokumentu mapującego.
        public MsSqlConfiguration(MsSqlConnectionString connectionString, HbmMapping compiledModels)
            : this(connectionString, compiledModels, "default")
        {

        }

        // Ustawia integrację z bazą danych MSSQL na podstawie connection string.
        private void SetDatabaseIntegration(MsSqlConnectionString connectionString)
        {
            this.DataBaseIntegration(db =>
            {
                db.ConnectionString = connectionString.Value;
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
            });
        }

        // Dodaje skompilowane modele do konfiguracji.
        private void SetModelMappings(HbmMapping compiledModels, string documentFileName)
        {
            this.AddDeserializedMapping(compiledModels, documentFileName);
        }
    }
}