﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using UsersServer.User;

namespace UsersServer.Database
{
    class MappingCompiler
    {
        public static HbmMapping CompileModels()
        {
            // tutaj wolałbym przekazać listę klas, ale nie wiem jeszcze jak to poprawnie zrobić, dlatego koduję modele na sztywno
            var modelMapper = new ModelMapper();
            modelMapper.AddMapping<UserMapping>();
            return modelMapper.CompileMappingForAllExplicitlyAddedEntities();
        }
    }
}
