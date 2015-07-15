
namespace SiteChecker
{
    public static class GetConstructor
    {
        private const int One = 1;
        private const int Two = 2;
        private const int Three = 3;
        public static ILogWrite ReturnConstructor(int choice)
        {
            if (choice == One)
                return new LogToScreen();
            if (choice == Two)
                return new LogToFile();
            if (choice == Three)
                return new LogToBoth();
            return null;
        }
    }
}
