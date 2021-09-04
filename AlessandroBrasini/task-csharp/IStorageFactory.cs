using System;

namespace TaskCSharp
{
    public interface IStorageFactory 
    {
        IStorage getConfigurationStorage();
        IStorage getExternalStorage();
    }

}