using MobileApplication.Abstractions.VersionInfo;
using MobileApplication.Abstractions.VersionInfoService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MobileApplication.VersionInfoAndroid.VersionInfo
{
    public class VersionInfoService : IVersionInfoService<IVersionInfo>
    {
        private readonly IVersionInfoRepository<VersionInfo> _repository;

        public VersionInfoService(IVersionInfoRepository<VersionInfo> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IVersionInfo> CreateVersionInfoAsync(string codeName, string versionNumber, DateTime initialReleaseDate, string descriprion, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return await _repository.CreateVersionInfoAsync(codeName, versionNumber, initialReleaseDate, descriprion, token).ConfigureAwait(false);
        }

        public virtual async Task DeleteVersionAsync(Guid id, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            await _repository.DeleteVersionInfoAsync(id, token).ConfigureAwait(false);
        }

        public virtual async Task<IVersionInfo> GetVersionInfoAsync(Guid id, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return await _repository.GetVersionInfoAsync(id, token).ConfigureAwait(false);
        }

        public virtual async Task<IVersionInfo> UpdateVersionInfoAsync(Guid id, string codeName, string versionNumber, DateTime initialReleaseDate, string descriprion, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return await _repository.UpdateVersionInfoAsync(id, codeName, versionNumber, initialReleaseDate, descriprion, token).ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<IVersionInfo>> GetVersionsInfoAsync(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            return await _repository.GetVersionsInfoAsync(token).ConfigureAwait(false);
        }
    }
}
