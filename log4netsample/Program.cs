using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using log4net;
using System.IO;

namespace log4netsample
{
    class Program
    {
        //private static readonly log4net.ILog log =
        //        log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            //log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //在应用程序启动时运行的代码
            //log4net.Config.XmlConfigurator.Configure();
            //for (int i = 0; i < 100; i++)
            //    log.Info(string.Format("Application is starting{0}", i));

            //for (int i = 0; i < 100; i++)
            //    log.Debug(string.Format("dbug is starting{0}", i));

            string assemblyFilePath = Assembly.GetExecutingAssembly().Location;
            Console.WriteLine(assemblyFilePath);
            string assemblyDirPath = Path.GetDirectoryName(assemblyFilePath);
            Console.WriteLine(assemblyDirPath);
            string configFilePath = assemblyDirPath + "\\Log4net_multiOut.config";//"\\Log4Net.config";
            Console.WriteLine(configFilePath);
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(configFilePath));
            //log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

            //ILog log = LogManager.GetLogger("mylogger");
            ILog log = LogManager.GetLogger("loginfo");
            for (int i = 0; i < 10; i++)
                log.Info(string.Format("Application is starting{0}", i));

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod());
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            Console.WriteLine("class: {0} - method: {1}",
                System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
                , System.Reflection.MethodBase.GetCurrentMethod());
            //Console.WriteLine(System.Reflection.MethodBase.DeclaringType);

            //get project folder
            Console.WriteLine(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())));
        }
    }
}
