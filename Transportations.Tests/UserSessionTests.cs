using Xunit;
using Transportations.BLL;

namespace Transportations.Tests
{
    public class UserSessionTests
    {
        [Fact]
        public void Start_SetsValues()
        {
            UserSession.Clear();
            UserSession.Start("user", "Администратор");

            Assert.True(UserSession.IsAuthenticated);
            Assert.Equal("user", UserSession.CurrentLogin);
            Assert.Equal("Администратор", UserSession.CurrentRole);
        }

        [Fact]
        public void Clear_ResetsValues()
        {
            UserSession.Start("user", "Редактор");
            UserSession.Clear();

            Assert.False(UserSession.IsAuthenticated);
            Assert.Null(UserSession.CurrentLogin);
            Assert.Null(UserSession.CurrentRole);
        }

        [Fact]
        public void CanEdit_WorksCorrectly()
        {
            UserSession.Start("a", "Администратор");
            Assert.True(UserSession.CanEdit);

            UserSession.Start("b", "Редактор");
            Assert.True(UserSession.CanEdit);

            UserSession.Start("c", "Сотрудник");
            Assert.False(UserSession.CanEdit);
        }
    }
}