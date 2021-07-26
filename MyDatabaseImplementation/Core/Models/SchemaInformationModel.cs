namespace MyDatabaseImplementation.Core.Models
{
    public class SchemaInformationModel
    {
        public string Name { get; }
        public string Directory { get; }
        public string InfoFile { get; }

        public SchemaInformationModel(string name, string directory, string infoFile)
        {
            this.Name = name;
            this.Directory = directory;
            this.InfoFile = infoFile;
        }
    }
}
