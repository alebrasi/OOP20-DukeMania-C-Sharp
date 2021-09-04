using System;

namespace TaskCSharp
{
    public interface IStorage 
    {
        void writeStringOnFile(String filePath, String content);
        String readFileAsString(String filePath);
        byte[] readFileAsByte(String filePath);
        bool createDirectoryRecursively(String path);
        bool createFileIfNotExists(String path);
        File1 getAsFile(String path);
    }
}