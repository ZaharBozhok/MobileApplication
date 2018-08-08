using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileApplication.VersionInfoAndroid.VersionInfo
{
    public interface IVersionInfoRepository<T> where T : VersionInfo
    {
        Task<bool> DeleteVersionInfoAsync(Guid id, CancellationToken token);
        
        Task<T> UpdateVersionInfoAsync(Guid id, string codeName, string versionNumber, DateTime initialReleaseDate, string descriprion, CancellationToken token);

        Task<T> CreateVersionInfoAsync(string codeName, string versionNumber, DateTime initialReleaseDate, string descriprion, CancellationToken token);

        Task<IEnumerable<T>> GetVersionsInfoAsync(CancellationToken token);

        Task<T> GetVersionInfoAsync(Guid id, CancellationToken token);
    }
}
