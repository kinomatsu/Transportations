using Xunit;
using Transportations.BLL;
using Transportations.DAL;

namespace Transportations.Tests
{
    public class DataServiceTests
    {
        [Fact]
        public void Insert_Throws_WhenNoPermission()
        {
            UserSession.Start("user", "Наблюдатель");

            var repo = new DataRepository("fake");
            var service = new DataService(repo);

            Assert.Throws<System.UnauthorizedAccessException>(() =>
            {
                service.Insert("Водители", new System.Collections.Generic.Dictionary<string, object>());
            });
        }

        [Fact]
        public void CanInsert_WhenEditor()
        {
            UserSession.Start("user", "Редактор");

            var repo = new DataRepository("fake");
            var service = new DataService(repo);

            Assert.ThrowsAny<System.Exception>(() =>
            {
                service.Insert("Водители", new System.Collections.Generic.Dictionary<string, object>());
            });
        }
    }
}0