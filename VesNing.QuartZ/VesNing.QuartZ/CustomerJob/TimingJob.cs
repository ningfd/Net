using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VesNing.QuartZ.CustomerJob
{
    /// <summary>
    /// 自定义任务任务
    /// </summary>
    class TimingJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            JobDataMap dataMap = context.JobDetail.JobDataMap;
            Console.WriteLine(dataMap.Get("student1"));
            JobDataMap dataMap1 = context.Trigger.JobDataMap;
            Console.WriteLine(dataMap1.Get("student4"));
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");
            JobDataMap dataMap2 = context.MergedJobDataMap;
            return Task.Run(()=> {
                Console.WriteLine($"当前线程{Thread.CurrentThread.Name}==>:{Thread.CurrentThread.ManagedThreadId}");
            });
        }
    }
}
