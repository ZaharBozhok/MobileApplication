using MobileApplication.Abstractions;
using MobileApplication.Abstractions.VersionInfo;
using MobileApplication.Abstractions.VersionInfoService;
using MobileApplication.Infrastructure.Repositories;
using MobileApplication.VersionInfoAndroid.VersionInfo;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApplication.DependencyInjection
{
    public static class ConfigureContainer
    {
        public static IContainerRegistry ConfigureApplicationContainer(this IContainerRegistry container)
        {
            //container.re
            container.RegisterSingleton<IVersionInfoRepository<VersionInfo>, AndoidVersionInfoRepository>();
            container.RegisterSingleton<IVersionInfoService<IVersionInfo>, VersionInfoService>();
            container.RegisterSingleton<IReadOnlyVersionInfoService<IVersionInfo>, VersionInfoService>();
            return container;
        }
    }
}
