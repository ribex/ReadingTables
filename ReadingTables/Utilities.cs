using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ReadingTables
{
    class Utilities
    {

        static List<TableDataCollection> _tableDataCollections = new List<TableDataCollection>();


        public static void ReadTable(IWebElement table)
        {
            // Get all the columns from the table
            var columns = table.FindElements(By.TagName("th"));

            // Get all the rows from the table
            var rows = table.FindElements(By.TagName("tr"));

            // Create row index
            int rowIndex = 0;

            foreach (var row in rows)
            {
                var colIndex = 0;
                var colDatas = row.FindElements(By.TagName("td"));

                foreach (var colValue in colDatas)
                {
                    _tableDataCollections.Add(new TableDataCollection
                    {
                        RowNumber = rowIndex,
                        ColumnName = columns[colIndex].Text,
                        ColumnValue = colValue.Text
                    });

                    // Move to next column
                    colIndex++;
                }

                rowIndex++;
            }
        }

        public static string ReadCell(string columnName, int rowNumber)
        {
            var data = (from e in _tableDataCollections
                where e.ColumnName == columnName && e.RowNumber == rowNumber
                select e.ColumnValue).SingleOrDefault();

            return data;
        }
    }

    public class TableDataCollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
    }
}
