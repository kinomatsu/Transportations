using System.Data;
using System.IO;
using Xunit;
using Transportations.BLL;
using Transportations.DAL;

namespace Transportations.Tests
{
    public class CsvExportTests
    {
        [Fact]
        public void ExportToCsv_CreatesFileWithData()
        {
            var table = new DataTable();
            table.Columns.Add("A");
            table.Columns.Add("B");

            table.Rows.Add("1", "2");

            var repo = new DataRepository("fake");
            var service = new DataService(repo);

            var path = Path.GetTempFileName();

            service.ExportToCsv(table, path);

            var text = File.ReadAllText(path);

            Assert.Contains("A;B", text);
            Assert.Contains("1;2", text);
        }
    }
}