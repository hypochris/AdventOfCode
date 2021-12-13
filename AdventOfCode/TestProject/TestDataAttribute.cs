using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Xunit.Sdk;

namespace Helper;

public class TestDataAttribute : DataAttribute
{
    private readonly string _basePath = "Data/";
    private readonly string _filePath;
    
    public TestDataAttribute(string filePath)
    {
        _filePath = filePath;
    }
    
    public override IEnumerable<object[]> GetData(MethodInfo testMethod)
    {
        if (testMethod == null) { throw new ArgumentNullException(nameof(testMethod)); }

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), _basePath, $"{_filePath}.txt");
        var path = Path.IsPathRooted(filePath)
            ? filePath
            : Path.GetRelativePath(Directory.GetCurrentDirectory(), filePath);
            
        if (!File.Exists(filePath))
        {
            throw new ArgumentException($"Could not find file at path: {path}");
        }

        var fileData = File.ReadAllLines(filePath);

        var objectList = new List<object[]>
        {
            new object[] { fileData }
        };
        return objectList;
    }
}
