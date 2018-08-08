using MobileApplication.Infrastructure.Data;
using MobileApplication.Infrastructure.Mappers;
using MobileApplication.VersionInfoAndroid;
using MobileApplication.VersionInfoAndroid.VersionInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileApplication.Infrastructure.Repositories
{
    public class AndoidVersionInfoRepository : InMemoryRepostiry<AndroidVersionInfo>, IVersionInfoRepository<VersionInfo>
    {
        static AndoidVersionInfoRepository()
        {
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "HelloWorld",
                "1.0",
                new DateTime(2022, 0, 3),
                "Description"
                ));
        }
        public virtual async Task<VersionInfo> CreateVersionInfoAsync(string codeName, string versionNumber, DateTime initialReleaseDate, string descriprion, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return await Task.Run(() =>
            {
                AndroidVersionInfo androidVersionInfo = new AndroidVersionInfo(
                    Guid.NewGuid(),
                    codeName,
                    versionNumber,
                    initialReleaseDate,
                    descriprion
                    );
                Storage.Add(androidVersionInfo);
                return androidVersionInfo.ToApi();
            }, token).ConfigureAwait(false);
        }

        public virtual async Task<bool> DeleteVersionInfoAsync(Guid id, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return await Task.Run(() => Storage.TryTake(out _), token).ConfigureAwait(false);
        }

        public virtual async Task<VersionInfo> GetVersionInfoAsync(Guid id, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return await Task.Run(() =>
            {
                AndroidVersionInfo androidVersionInfo = Storage.FirstOrDefault(x => x.Id.Equals(id));
                return Task.FromResult(androidVersionInfo?.ToApi());
            }, token).ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<VersionInfo>> GetVersionsInfoAsync(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return await Task.Run(() =>
            {
                return Storage.ToList().Select(x => x.ToApi());
            }, token).ConfigureAwait(false);
        }

        public virtual async Task<VersionInfo> UpdateVersionInfoAsync(Guid id, string codeName, string versionNumber, DateTime initialReleaseDate, string descriprion, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return await Task.Run(() =>
            {
                if (Storage.TryPeek(out AndroidVersionInfo androidVersionInfo))
                {
                    androidVersionInfo.Id = id;
                    androidVersionInfo.CodeName = codeName;
                    androidVersionInfo.InitialReleaseDate = initialReleaseDate;
                    androidVersionInfo.VersionNumber = versionNumber;
                    androidVersionInfo.Description = descriprion;
                    return androidVersionInfo.ToApi();
                }
                return null;
            }, token).ConfigureAwait(false);
        }
    }
}
