using MobileApplication.Infrastructure.Data;
using MobileApplication.VersionInfoAndroid.VersionInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApplication.Infrastructure.Mappers
{
    public static class AndroidVersionExtensions
    {
        public static VersionInfo ToApi(this AndroidVersionInfo androidVersionInfo)
        {
            return new VersionInfo(
                androidVersionInfo.Id,
                androidVersionInfo.CodeName,
                androidVersionInfo.VersionNumber,
                androidVersionInfo.InitialReleaseDate,
                androidVersionInfo.Description);
        }
        public static AndroidVersionInfo ToDto(this VersionInfo versionInfo)
        {
            return new AndroidVersionInfo(
                versionInfo.Id,
                versionInfo.CodeName,
                versionInfo.VersionNumber,
                versionInfo.InitialReleaseDate,
                versionInfo.Description
                );
        }
    }
}
