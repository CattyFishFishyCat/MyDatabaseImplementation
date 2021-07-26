using System.Collections.Generic;

namespace MyDatabaseImplementation.Core.Models
{
    public class DatabaseInformationModel
    {
        public string Version { get; }
        public IEnumerable<SchemaInformationModel> Schemas { get; }

        public DatabaseInformationModel(string version, IEnumerable<SchemaInformationModel> schemas)
        {
            this.Version = version;
            this.Schemas = schemas;
        }
    }
}
