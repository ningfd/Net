using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace VesNing.EF.Util
{
    /// <summary>
    /// 实例化IOC容器
    /// 单例容器构造
    /// </summary>
    class UntityContain
    {
        private static IUnityContainer container = null;
        static UntityContain()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "cfg\\Unity.Config");
            Configuration config=ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            UnityConfigurationSection section=(UnityConfigurationSection)config.GetSection(UnityConfigurationSection.SectionName);
            container = new UnityContainer();
            section.Configure(container, "VesContainerGeneric");
        }
        public static IUnityContainer GetContainer()
        {
            return container;
        }
    }
}
