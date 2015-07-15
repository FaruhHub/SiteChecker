using System;
using System.Windows.Forms;

namespace SiteChecker
{
    public partial class MainForm : Form
    {
        private readonly IChecker _checker;

        enum Choice
        {
            One = 1,
            Two,
            Three
        }
        public MainForm(IChecker checker)
        {
            InitializeComponent();
            _checker = checker;

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

            //---делаю вывод на экран-----------------------------------------------------------------
            if (rbtnScreen.Checked)
            {
                //richTextBox1.Text = _logWrite.GetResults(_checker.WebChecker(textBoxUrl.Text, checkBox1.Checked));
                ILogWrite get = GetConstructor.ReturnConstructor((int)Choice.One);
                richTextBox1.Text = get.GetResults(_checker.WebChecker(textBoxUrl.Text, checkBox1.Checked));
            }

            //---делаю вывод в файл--------------------------------------------------------------------
            if (rbtnFile.Checked)
            {
                ILogWrite get = GetConstructor.ReturnConstructor((int)Choice.Two);
                get.GetResults(_checker.WebChecker(textBoxUrl.Text, checkBox1.Checked));
            }

            //---делаю вывод в совместном режиме--------------------------------------------------------
            if (rbtnBoth.Checked)
            {
                ILogWrite get = GetConstructor.ReturnConstructor((int)Choice.Three);
                richTextBox1.Text = get.GetResults(_checker.WebChecker(textBoxUrl.Text, checkBox1.Checked));
            }

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

        private void rbtnScreen_CheckedChanged(object sender, EventArgs e)
        {
            rbtnScreen.Checked = true;
            rbtnFile.Checked = false;
            rbtnBoth.Checked = false;
        }

        private void rbtnFile_CheckedChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = String.Empty;

            rbtnScreen.Checked = false;
            rbtnFile.Checked = true;
            rbtnBoth.Checked = false;
        }

        private void rbtnBoth_CheckedChanged(object sender, EventArgs e)
        {
            rbtnScreen.Checked = false;
            rbtnFile.Checked = false;
            rbtnBoth.Checked = true;
        }
    }
}
