using System;
using System.IO;

namespace TaskCSharp
{
    public class StorageFactory : IStorageFactory
    {

        readonly String CONFIG_FOLDER_NAME = ".dukemania1";
        readonly String USER_HOME_PATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        readonly String FILE_SEPARATOR = Path.DirectorySeparatorChar.ToString();
        readonly String CONFIGS_PATH;
        readonly Func<String, File1> configurationMappingFunction;

        readonly Func<String, File1> externalMappingFunction;

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
            private Func<String, File1> _fileMappingFunction;
            public Storage(Func<String, File1> _fileMappingFunction) 
            {
                this._fileMappingFunction = _fileMappingFunction;
            }

            public bool CreateDirectoryRecursively(string path)
            {
                if (!Directory.CreateDirectory(_fileMappingFunction(path).Path).Exists) 
                {
                    Directory.CreateDirectory(_fileMappingFunction(path).Path);
                    return true;
                }
                return false;
            }

            public bool CreateFileIfNotExists(string path)
            {
                if (!File.Exists(_fileMappingFunction(path).Path)) 
                {
                    File.Create(_fileMappingFunction(path).Path).Close();
                    return true; 
                }
                return false;
            }

            public File1 GetAsFile(string path)
            {
                return _fileMappingFunction(path);
            }

            public byte[] ReadFileAsByte(string filePath)
            {
                return File.ReadAllBytes(_fileMappingFunction(filePath).Path);
            }

            public string ReadFileAsString(string filePath)
            {
                return File.ReadAllText(_fileMappingFunction(filePath).Path);
            }

            public void WriteStringOnFile(string filePath, string content)
            {
                File.WriteAllText(_fileMappingFunction(filePath).Path, content);
            }
        }
    }
}