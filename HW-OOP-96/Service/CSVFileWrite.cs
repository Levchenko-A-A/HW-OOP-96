using CsvHelper;
using CsvHelper.Configuration;
using HW_OOP_96.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_OOP_96.Service
{
    public class CSVFileWrite
    {
        public void SaveToCsv<T>(IEnumerable<T> data, string filePath)
        {
            using (var writer = new StreamWriter(filePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(data);
            }
        }
    }
}
