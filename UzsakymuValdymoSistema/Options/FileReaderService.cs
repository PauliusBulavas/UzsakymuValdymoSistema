using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace UzsakymuValdymoSistema.Options
{
    public class FileReaderService
    {
        public static string GetPathToResource(string resourceName)
        {
            String strAppPath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            String strFilePath = Path.Combine(strAppPath, "Resources");
            String strFullFilename = Path.Combine(strFilePath, resourceName);

            return strFullFilename;
        }

        public List<T> Import<T>(string csvFile)
        {
            var list = new List<T>();
            var lines = System.IO.File.ReadAllLines(csvFile);
            var headerLine = lines.First();
            var columns = headerLine.Split(';').ToList().Select((v, i) => new { Position = i, Name = v });

            var dataLines = lines.Skip(1).ToList();
            var type = typeof(T);

            var props = type.GetProperties();
            dataLines.ForEach(line =>
            {
                T obj = (T)Activator.CreateInstance(type);
                var data = line.Split(';').ToList();
                foreach (var prop in props)
                {
                    var column = columns.SingleOrDefault(c => c.Name == prop.Name);
                    var value = data[column.Position];
                    var typeOfProp = prop.PropertyType;
                    prop.SetValue(obj, Convert.ChangeType(value, typeOfProp));
                }
                list.Add(obj);
            });
            return list;
        }

        public void SaveToCsv<T>(List<T> reportData, string path)
        {
            var lines = new List<string>();
            var props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            var header = string.Join(";", props.ToList().Select(x => x.Name));
            lines.Add(header);
            var valueLines = reportData.Select(row => string.Join(";", header.Split(';').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            File.WriteAllLines(path, lines.ToArray());
        }
    }
}