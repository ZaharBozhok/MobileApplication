using MobileApplication.Abstractions.VersionInfo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileApplication.Abstractions.VersionInfoService
{
    public interface IVersionInfoService<T> : IReadOnlyVersionInfoService<T> where T : IVersionInfo
    {
        Task DeleteVersionAsync(Guid id, CancellationToken token);
        Task<T> UpdateVersionInfoAsync(Guid id, string codeName, string versionNumber, DateTime initialReleaseDate, string descriprion, CancellationToken token);
        Task<T> CreateVersionInfoAsync(string codeName, string versionNumber, DateTime initialReleaseDate, string descriprion, CancellationToken token);
    }
    public interface IReadOnlyVersionInfoService<T> where T : IVersionInfo
    {
        Task<T> GetVersionInfoAsync(Guid id, CancellationToken token);
        Task<IEnumerable<T>> GetVersionsInfoAsync(CancellationToken token);
    }
}
