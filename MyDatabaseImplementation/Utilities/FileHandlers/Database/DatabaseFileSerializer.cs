using MyDatabaseImplementation.Core.Models;
using Newtonsoft.Json;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Database
{
    public class DatabaseFileSerializer : IDatabaseFileSerializer
    {
        public string Serialize(DatabaseInformationModel databaseInformation)
        {
            return JsonConvert.SerializeObject(databaseInformation);
        }
    }
}
