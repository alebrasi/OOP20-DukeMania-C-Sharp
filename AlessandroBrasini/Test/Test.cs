using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskCSharp;
using System.IO;
using System.Diagnostics;
using System;

namespace Test
{
    [TestClass]
    public class Test
    {
        IStorage _storage = new StorageFactory().GetConfigurationStorage();

        [TestMethod]
        public void TestMethod1()
        {   
            string path = _storage.GetAsFile("").Path;
            string dirSeparator = Path.DirectorySeparatorChar.ToString();

            _storage.CreateDirectoryRecursively("test/test2");
            Assert.IsTrue(Directory.Exists(path + dirSeparator + "test" + dirSeparator + "test2"));

            _storage.CreateFileIfNotExists("testFile");
            Assert.IsTrue(File.Exists(path + dirSeparator + "testFile"));

            _storage.WriteStringOnFile("testFile", "test");
            Assert.AreEqual(_storage.ReadFileAsString("testFile"), "test");
            
            _storage.CreateFileIfNotExists("testFile2");
            byte[] payload = {84, 104, 101, 32, 71, 97, 109, 101};
            File.WriteAllBytes(path + dirSeparator + "testFile2", payload);
            CollectionAssert.AreEqual(_storage.ReadFileAsByte("testFile2"), payload);

            //Cleanup
            Directory.Delete(path + dirSeparator + "test" + dirSeparator + "test2");
            Directory.Delete(path + dirSeparator + "test");
            File.Delete(path + dirSeparator + "testFile");
            File.Delete(path + dirSeparator + "testFile2");
            Directory.Delete(path);
        }

    }
}
