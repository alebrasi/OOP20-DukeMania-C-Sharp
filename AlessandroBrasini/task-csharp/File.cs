using System;

namespace TaskCSharp
{
    public class File1 
    {
        private readonly String _path;
        public File1(String path) 
        {
            this._path = path;
        }
        public string Path => _path;
    }
}