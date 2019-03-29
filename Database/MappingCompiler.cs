
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using UsersServer.Group;
using UsersServer.User;

namespace UsersServer.Database
{
    class MappingCompiler
    {
        // Kompiluje modele za pomocą mappera modeli nHibernate (mapping by code).
        public static HbmMapping CompileModels()
        {
            // tutaj wolałbym przekazać listę klas, ale nie wiem jeszcze jak to poprawnie zrobić, dlatego koduję modele na sztywno
            var modelMapper = new ModelMapper();
            modelMapper.AddMapping<UserMapping>();
            modelMapper.AddMapping<GroupMapping>();
            return modelMapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}