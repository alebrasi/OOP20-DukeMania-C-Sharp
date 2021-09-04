using System;

namespace TaskCSharp
{
    public interface IStorage 
    {
        void WriteStringOnFile(String filePath, String content);
        String ReadFileAsString(String filePath);
        byte[] ReadFileAsByte(String filePath);
        bool CreateDirectoryRecursively(String path);
        bool CreateFileIfNotExists(String path);
        File1 GetAsFile(String path);
    }
}