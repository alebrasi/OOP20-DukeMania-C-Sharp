using System;

namespace TaskCSharp
{
    public interface IStorageFactory 
    {
        IStorage GetConfigurationStorage();
        IStorage GetExternalStorage();
    }

}