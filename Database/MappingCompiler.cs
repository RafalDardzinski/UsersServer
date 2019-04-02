using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using UsersServer.Group;
using UsersServer.User;

namespace UsersServer.Database
{
    /// <summary>
    /// Compiles NHibernate mapping by code models.
    /// </summary>
    class MappingCompiler
    {
        /// <summary>
        /// Compiles models.
        /// </summary>
        /// <returns>Compiled models.</returns>
        public static HbmMapping CompileModels()
        {
            var modelMapper = new ModelMapper();
            modelMapper.AddMapping<UserMapping>();
            modelMapper.AddMapping<GroupMapping>();
            return modelMapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}
