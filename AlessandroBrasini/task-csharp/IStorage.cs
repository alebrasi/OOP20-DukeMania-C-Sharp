using System;

namespace TaskCSharp
{
    public interface IStorage 
    {
        ///<summary>Write a string on a file</summary>
        ///<param name="filePath">The path of the file</param>
        ///<param name="content"> The content to write</param>
        void WriteStringOnFile(String filePath, String content);

        ///<summary>Read a file as a string</summary>
        ///<param name="filePath">The path of the file</param>
        ///<returns>The file content</returns>
        String ReadFileAsString(String filePath);

        ///<summary>Read the file as a byte array</summary>
        ///<param name="filePath">The path of the file</param>
        ///<returns>The file content</returns>
        byte[] ReadFileAsByte(String filePath);

        ///<summary>Creates a directory at the specified path. If the directories contained in the path don't exists, provides to create them</summary>
        ///<param name="path">The directory path</param>
        ///<returns>True if the directory gas been create, false otherwise</returns>
        bool CreateDirectoryRecursively(String path);

        ///<summary>Creates a file if it not exists. If the directories contained in the path don't exists, provides to create them</summary>
        ///<param name="path">The file path</param>
        ///<returns>True if the file file has been created, false otherwise</returns>
        bool CreateFileIfNotExists(String path);

        ///<summary>Returns the specified file as File1 object</summary>
        ///<param name="path">The file path</param>
        ///<returns>The file</returns>
        File1 GetAsFile(String path);
    }
}