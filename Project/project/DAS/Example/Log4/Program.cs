using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4
{
    class Program
    {
        static void Main(string[] args)
        {
            InitLog4Net();

            var logger = LogManager.GetLogger(typeof(Program));

            // 一般信息
            logger.Info("消息");
            // 警告
            logger.Warn("警告");
            // 一般错误
            logger.Error("异常");
            // 一般错误(格式化)
            logger.ErrorFormat("异常{0}", "Test");
            // 调试信息
            logger.Debug("调试");
            // 致命错误
            logger.Fatal("错误");

            Console.ReadLine();
        }

        /// <summary>
        /// 初始化log4 配置
        /// </summary>
        static void InitLog4Net()
        {
            FileInfo logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "/Log4Config/log4net.config");
            XmlConfigurator.Configure(logCfg);
        }
    }
}
