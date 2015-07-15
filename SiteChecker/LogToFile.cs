using System.IO;
using System.Text;

namespace SiteChecker
{
    class LogToFile : ILogWrite
    {
        private readonly string filePath = @"C:\Users\Faruh\Documents\GitHub\SiteChecker\LogFile.txt";

        public string GetResults(string results)
        {
            //---делаем логгирование полученных результатов в файл---------------------
            if (!File.Exists(filePath))
            {
                using (FileStream fs = File.Create(filePath))
                {
                    File.WriteAllText(filePath, results, Encoding.UTF8);
                    fs.Close();
                }
            }
            else
            {
                string currentContent = File.ReadAllText(filePath, Encoding.UTF8);
                File.WriteAllText(filePath, results + currentContent, Encoding.UTF8);
            }
            //--------------------------------------------------------------------------  
            return null;
        }
    }
}
