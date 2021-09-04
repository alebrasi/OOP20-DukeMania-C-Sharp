using System;
using System.IO;

namespace TaskCSharp
{
    public class StorageFactory : IStorageFactory
    {

        private readonly String CONFIG_FOLDER_NAME = ".dukemania1";
        private readonly String USER_HOME_PATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        private readonly String FILE_SEPARATOR = Path.DirectorySeparatorChar.ToString();
        private readonly String CONFIGS_PATH;
        private readonly Func<String, File1> configurationMappingFunction;

        private readonly Func<String, File1> externalMappingFunction;

        public StorageFactory() {
            CONFIGS_PATH = USER_HOME_PATH + FILE_SEPARATOR + CONFIG_FOLDER_NAME;
            configurationMappingFunction = path => new File1(CONFIGS_PATH + FILE_SEPARATOR + path);
            externalMappingFunction = path => new File1(path);
        }

        public IStorage GetConfigurationStorage()
        {
            return new Storage(configurationMappingFunction);
        }

        public IStorage GetExternalStorage()
        {
            return new Storage(externalMappingFunction);
        }

        private class Storage : IStorage
        {
            private Func<String, File1> fileMappingFunction;
            public Storage(Func<String, File1> fileMappingFunction) 
            {
                this.fileMappingFunction = fileMappingFunction;
            }

            public bool CreateDirectoryRecursively(string path)
            {
                if (!Directory.CreateDirectory(fileMappingFunction(path).Path).Exists) 
                {
                    Directory.CreateDirectory(fileMappingFunction(path).Path);
                    return true;
                }
                return false;
            }

            public bool CreateFileIfNotExists(string path)
            {
                if (!File.Exists(fileMappingFunction(path).Path)) 
                {
                    File.Create(fileMappingFunction(path).Path).Close();
                    return true; 
                }
                return false;
            }

            public File1 GetAsFile(string path)
            {
                return fileMappingFunction(path);
            }

            public byte[] ReadFileAsByte(string filePath)
            {
                return File.ReadAllBytes(fileMappingFunction(filePath).Path);
            }

            public string ReadFileAsString(string filePath)
            {
                return File.ReadAllText(fileMappingFunction(filePath).Path);
            }

            public void WriteStringOnFile(string filePath, string content)
            {
                File.WriteAllText(fileMappingFunction(filePath).Path, content);
            }
        }
    }
}