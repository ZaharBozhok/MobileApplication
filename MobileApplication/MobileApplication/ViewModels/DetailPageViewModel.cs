using MobileApplication.Abstractions.VersionInfo;
using MobileApplication.Abstractions.VersionInfoService;
using MobileApplication.Extensions;
using MobileApplication.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MobileApplication.ViewModels
{
    public class DetailPageViewModel : ViewModelBase
    {
        private FullVersionInfoModel currentVersion;
        public FullVersionInfoModel CurrentVersion
        {
            get { return currentVersion; }
            set { SetProperty(ref currentVersion, value); }
        }
        public DetailPageViewModel(INavigationService navigationService, IVersionInfoService<IVersionInfo> service) : base(navigationService, service)
        {
            Title = "Info";
        }
        public async override void OnNavigatedTo(NavigationParameters parameters)
        {
            var res = await VersionInfoService.GetVersionInfoAsync(parameters.GetValue<Guid>("Id"), CancellationToken.None);
            CurrentVersion = res.ToFullVersionInfoModel();
        }

    }
}
