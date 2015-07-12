using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace SiteChecker
{
    class Checker : IChecker
    {
        
        public string WebChecker(string url, bool allowToRedirect)
        {
         string http = "http://";
         string https = "https://";
         string lblResult = String.Empty;
         string lblStatusDescription = String.Empty;
         string lblCause = String.Empty;
         string all;

            try
            {

                //------проверяем есть ли ссылка-------------
                if (url == String.Empty)
                {
                    MessageBox.Show(@"Вы не вввели ссылку !");
                    return null;
                }
                //------если есть идем дальше-----------------
                
                //---делаем проверку на наличие протокола "http://" в ссылке запроса
                if (!(url.StartsWith(http) || url.StartsWith(https)))
                    url = url.Insert(0, http);
                //------------------------------------------------------------------

                // Создаём объект запроса
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                
                // выясняем введенная ссылка перенаправляет на другую ссылку,
                // если запретим перенаправлять можем получить ошибку 302.
                if (allowToRedirect)
                {
                    request.AllowAutoRedirect = true;
                }
                else
                {
                    request.AllowAutoRedirect = false;
                }

                // Получаем ответ с сервера, если запрашиваемый URL не действителен, переходим к блоку
                // catch, иначе идем дальше.
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();


                if (request.HaveResponse)
                {
                    lblResult = (response.StatusCode == HttpStatusCode.OK) ? "Сайт доступен" : "Сайт не доступен";
                    lblStatusDescription = response.StatusDescription;
                    lblCause = ((int)response.StatusCode).ToString();
                }

                response.Close();
                request.Abort();

            }

            catch (WebException ex)
            {
                lblResult = @"Сайт не доступен";
                lblStatusDescription = ex.Message;

                //---делаем проверку является ли код ошибки HttpStatusCode или WebExceptionStatus
                if (((HttpWebResponse)ex.Response) != null)
                {
                    lblCause = ((int)(((HttpWebResponse)ex.Response).StatusCode)).ToString();
                }
                else
                {
                    lblCause = ((int)(ex.Status)).ToString();
                }
                //-------------------------------------------------------------------------------
            }

            finally
            {
                string filePath = @"C:\Users\Faruh\Documents\GitHub\SiteChecker\LogFile.txt";
                StringBuilder newContent = new StringBuilder();
                DateTime date = DateTime.Now;

                newContent.AppendLine("URL: "              + url +
                                    "\nДата проверки: "    + date +
                                    "\nСтатус: "           + lblResult +
                                    "\nОписание статуса: " + lblStatusDescription +
                                    "\nКод статуса: "      + lblCause +
                                  "\n");
                all = newContent.ToString();
                
                //---делаем логгирование полученных результатов в файл---------------------
                if (!File.Exists(filePath))
                {
                    using (FileStream fs = File.Create(filePath))
                    {
                        File.WriteAllText(filePath, newContent.ToString(), Encoding.UTF8);
                        fs.Close();
                    }
                }
                else
                {
                    string currentContent = File.ReadAllText(filePath, Encoding.UTF8);
                    File.WriteAllText(filePath, newContent + currentContent, Encoding.UTF8);
                }
                //--------------------------------------------------------------------------
            }
            return all; //возвращаем полученные данные в интерфейс приложения
        }
    }
}
