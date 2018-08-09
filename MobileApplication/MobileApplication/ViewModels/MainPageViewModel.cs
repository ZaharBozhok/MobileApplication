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
    public class MainPageViewModel : ViewModelBase
    {
        private IEnumerable<PreviewVersionInfoModel> versionsList;
        private DelegateCommand<object> _itemTappedCommand;
        public DelegateCommand<object> ItemTappedCommand =>
            _itemTappedCommand ?? (_itemTappedCommand = new DelegateCommand<object>(ExecuteItemTappedCommand, CanExecuteItemTappedCommand));

        async void ExecuteItemTappedCommand(object parameter)
        {
            NavigationParameters navigationParameters = new NavigationParameters();
            navigationParameters.Add("Id", (Guid)parameter);
            await NavigationService.NavigateAsync("DetailPage", navigationParameters);
        }

        bool CanExecuteItemTappedCommand(object parameter)
        {
            if(parameter is Guid)
                return true;
            return false;
        }

        public IEnumerable<PreviewVersionInfoModel> VersionsList
        {
            get { return versionsList; }
            set { SetProperty(ref versionsList, value); }
        }
        public MainPageViewModel(INavigationService navigationService, IVersionInfoService<IVersionInfo> service) : base(navigationService, service)
        {
            Title = "Versions";
        }
        public override async void OnNavigatedTo(NavigationParameters parameters)
        {
            var res = await VersionInfoService.GetVersionsInfoAsync(CancellationToken.None).ConfigureAwait(false);
            VersionsList = (res.Select(x => x.ToPreviewVersionInfoModel())).ToList();
        }


    }
}
