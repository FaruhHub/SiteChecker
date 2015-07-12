
namespace SiteChecker
{
    class TestClass:IChecker
    {
        public string WebChecker(string url, bool allowToRedirect)
        {
            return "---==== тестовая строка ====---";
        }
    }
}
