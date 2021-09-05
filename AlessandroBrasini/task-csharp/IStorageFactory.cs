using System;

namespace TaskCSharp
{
    public interface IStorageFactory 
    {
        ///<summary>Creates a storage that points to configuration folder storage</summary>
        ///<returns>The associated configuration storage</returns>
        IStorage GetConfigurationStorage();

        ///<summary>Creates a storage that points to the same file path</summary>
        ///<returns>The associated storage</returns>
        IStorage GetExternalStorage();
    }

}