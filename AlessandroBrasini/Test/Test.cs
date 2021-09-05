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
        private static IStorage _storage;
        private static string _path;
        private static string _dirSeparator;

        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            _storage = new StorageFactory().GetConfigurationStorage();
            _path = _storage.GetAsFile("").Path;
            _dirSeparator = Path.DirectorySeparatorChar.ToString();
        }

        [TestMethod]
        public void TestCreateDirectoryRecursively()
        {  
            _storage.CreateDirectoryRecursively("test/test2");
            Assert.IsTrue(Directory.Exists(_path + _dirSeparator + "test" + _dirSeparator + "test2"));
        }

        [TestMethod]
        public void TestCreateFileIfNotExists()
        {
            _storage.CreateFileIfNotExists("testFile");
            Assert.IsTrue(File.Exists(_path + _dirSeparator + "testFile"));
        }

        [TestMethod]
        public void TestWriteStringOnFile()
        {
            _storage.WriteStringOnFile("testFile", "test");
            Assert.AreEqual(_storage.ReadFileAsString("testFile"), "test");
        }

        [TestMethod]
        public void TestReadBytesFromFile()
        {
            _storage.CreateFileIfNotExists("testFile2");
            byte[] payload = {84, 104, 101, 32, 71, 97, 109, 101};
            File.WriteAllBytes(_path + _dirSeparator + "testFile2", payload);
            CollectionAssert.AreEqual(_storage.ReadFileAsByte("testFile2"), payload);
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            Directory.Delete(_path + _dirSeparator + "test" + _dirSeparator + "test2");
            Directory.Delete(_path + _dirSeparator + "test");
            File.Delete(_path + _dirSeparator + "testFile");
            File.Delete(_path + _dirSeparator + "testFile2");
            Directory.Delete(_path);
        }

    }
}
