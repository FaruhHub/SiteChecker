
namespace SiteChecker
{
    public interface IChecker
    {
        string WebChecker(string url, bool allowToRedirect);
    }
}
