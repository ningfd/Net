using Quartz;
using Quartz.Impl;
using Quartz.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VesNing.QuartZ.CustomerJob;

namespace VesNing.QuartZ
{
    class QuaretZManager
    {
        public QuaretZManager()
        {
           
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public static async Task Start()
        {
            LogProvider.SetCurrentLogProvider(new ConosleLogProvider());
            StdSchedulerFactory stdScheduleFactory = new StdSchedulerFactory();
            IScheduler scheduler = await stdScheduleFactory.GetScheduler();//定义单元实例
            Console.WriteLine($"创建Schedule完成...");
            //创建作业
            IJobDetail jobDetail = JobBuilder.Create<TimingJob>().
                WithIdentity("custome1", "group1").
                WithDescription("任务进程").Build();
            Console.WriteLine($"创建Job完成...");
            //实例化Trigger：
            ITrigger trigger = TriggerBuilder.Create().
                WithIdentity("trigger1", "group1").
                StartNow().
                WithSimpleSchedule((x) => { x.WithIntervalInSeconds(1).WithRepeatCount(10); }).
                WithDescription("10s一次，共执行10次").Build();
            Console.WriteLine($"创建ITrigger定时器完成...");
            //将JobDetail和Trigger添加至Schedule
            await scheduler.ScheduleJob(jobDetail, trigger);
            Console.WriteLine($"scheduler作业添加完成......");
            await scheduler.Start();
            Console.WriteLine($"scheduler开始启动......");
        }
    }
}
