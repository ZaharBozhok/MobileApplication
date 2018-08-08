using MobileApplication.Abstractions.VersionInfo;
using MobileApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApplication.Extensions
{
    public static class VersionInfoExtensions
    {
        public static FullVersionInfoModel ToFullVersionInfoModel(this IVersionInfo version)
        {
            return new FullVersionInfoModel()
            {
                Id = version.Id,
                CodeName = version.CodeName,
                VersionNumber = version.VersionNumber,
                InitialReleaseDate = version.InitialReleaseDate,
                Description = version.Description
            };
        }
        public static PreviewVersionInfoModel ToPreviewVersionInfoModel(this IVersionInfo version)
        {
            return new PreviewVersionInfoModel()
            {
                Id = version.Id,
                CodeName = version.CodeName,
                VersionNumber = version.VersionNumber
            };
        }
    }
}
