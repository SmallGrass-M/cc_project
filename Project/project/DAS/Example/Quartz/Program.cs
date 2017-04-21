using Quartz;
using Quartz.Impl;
using QuartzTest.Job;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Common.Logging.LogManager.Adapter = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter { Level = Common.Logging.LogLevel.Info };

            //从工厂中获取一个调度器实例化
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            //开启调度器
            scheduler.Start();

            #region 例子1
            //{
            //    //创建一个作业
            //    IJobDetail job = JobBuilder.Create<TestJob>().WithIdentity("作业名", "作业组").Build();

            //    //创建一个触发器
            //    ITrigger trigger = TriggerBuilder.Create()
            //        .WithIdentity("trigger1", "group1")
            //        .StartNow()
            //        .WithSimpleSchedule(x => x
            //            .WithIntervalInSeconds(10)
            //            .RepeatForever())
            //        .Build();

            //    //把作业，触发器加入调度器。
            //    scheduler.ScheduleJob(job, trigger);
            //}
            #endregion

            #region 例子2
            //{
            //    IJobDetail job2 = JobBuilder.Create<TestJob>()
            //                               .WithIdentity("myJob", "group1")
            //                               .UsingJobData("jobSays", "Hello World!")
            //                               .Build();


            //    ITrigger trigger2 = TriggerBuilder.Create()
            //                                .WithIdentity("mytrigger", "group1")
            //                                .StartNow()
            //                                .WithCronSchedule("0/5 * * ? * *")    //时间表达式，从0秒开始(0可以去掉)5秒一次     
            //                                .Build();

            //    scheduler.ScheduleJob(job2, trigger2);
            //}
            #endregion
        }
    }
}
