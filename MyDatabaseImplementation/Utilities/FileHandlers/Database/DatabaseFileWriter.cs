using MyDatabaseImplementation.Core.Models;
using System.IO;
using System.Text;

namespace MyDatabaseImplementation.Utilities.FileHandlers.Database
{
    public class DatabaseFileWriter: IDatabaseFileWriter
    {
        private readonly IDatabaseFileSerializer databaseFileSerializer;

        public DatabaseFileWriter(IDatabaseFileSerializer databaseFileSerializer)
        {
            this.databaseFileSerializer = databaseFileSerializer;
        }

        public void Write(FileInformation fileInformation, DatabaseInformationModel databaseInformation)
        {
            using (FileStream fileStream = new FileStream(fileInformation.FullPath, FileMode.Open, FileAccess.Write))
            {
                if (fileStream.Length == 0)
                {
                    string databaseInformationJson = this.databaseFileSerializer.Serialize(databaseInformation);
                    byte[] databaseInformationBytes = Encoding.ASCII.GetBytes(databaseInformationJson);
                    fileStream.Write(databaseInformationBytes);
                }
            }
        }
    }
}
