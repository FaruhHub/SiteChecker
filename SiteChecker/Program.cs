using System;
using System.Windows.Forms;
using Ninject;
using Ninject.Modules;

namespace SiteChecker
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());

            //--------------------------------------------------------
            MyDependencyResolver.Wire(new MyApplicationModule());
            Application.Run(MyDependencyResolver.Resolve<MainForm>());
            //--------------------------------------------------------

        }
    }

    public class MyApplicationModule : NinjectModule
    {
        public override void Load()
        {
            //--Связываем интерфейс с классом-
            Bind<IChecker>().To<Checker>();
            //--------------------------------
        }
    }
    public class MyDependencyResolver
    {
        private static IKernel _ninjectKernel;

        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
    }
}
