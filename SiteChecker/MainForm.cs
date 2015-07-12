using System;
using System.Windows.Forms;

namespace SiteChecker
{
    public partial class MainForm : Form
    {
        private readonly IChecker _checker;
        public MainForm(IChecker checker)
        {
            _checker = checker;
            InitializeComponent();
        }
        
        private void btnSubmit_Click(object sender, EventArgs e)
        {
        //---ссылки которые тестировал------------------------------------
            //textBoxUrl.Text = "http://shpargalkablog.ru/2012/03/404.htm"; // 404
            //textBoxUrl.Text = "http://www.muliver.org/";        // WebExceptionStatus code with 2
            //textBoxUrl.Text = "http://aasrfykhuhgjgftuftu.com"; // WebExceptionStatus code with 1
            //textBoxUrl.Text = "http://ktonanovenkogo.ru/xmlrpc.php";// 405
            //textBoxUrl.Text = "http://dou.ua/";   // 200
            //textBoxUrl.Text = "http://academy.binary-studio.com/";  // 200
            //textBoxUrl.Text = "http://www.gooogle.com/";  // 200 либо 301

            richTextBox1.Text = _checker.WebChecker(textBoxUrl.Text, checkBox1.Checked);

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBoxUrl.Text = String.Empty;
            richTextBox1.Text = String.Empty;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Text = (checkBox1.Checked) ? "Да" : "Нет";
        }
    }
}
