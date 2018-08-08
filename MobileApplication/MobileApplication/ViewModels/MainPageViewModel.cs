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
using System.Text;
using System.Threading;

namespace MobileApplication.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        protected IVersionInfoService<IVersionInfo> Service { get; private set; }
        public MainPageViewModel(INavigationService navigationService, IVersionInfoService<IVersionInfo> service) : base(navigationService)
        {
            Service = service;
            Title = "Hello world";
        }
        //public async virtual void OnNavigatingTo(NavigationParameters parameters)
        //{
        //    var res = await _service.GetVersionInfoAsync(Guid.NewGuid(),CancellationToken.None);
        //    PreviewVersionInfoModel fullVersionInfoModel = res.ToPreviewVersionInfoModel();
        //    Title = fullVersionInfoModel.CodeName;
        //}

    }
}
