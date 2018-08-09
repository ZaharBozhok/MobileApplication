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
        static DateTime getRandomDate()
        {
            Random rnd = new Random();
            return new DateTime(rnd.Next(2008, 2019), rnd.Next(1, 13), rnd.Next(1, 29));
        }
        static AndoidVersionInfoRepository()
        {
            string riba = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";
            
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Petit Four",
                "1.0",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Cupcake",
                "1.5",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Donut",
                "2.0 – 2.1",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Eclair",
                "2.0 – 2.1",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Froyo",
                "2.2 – 2.2.3",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Gingerbread",
                "2.3 – 2.3.7",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Honeycomb",
                "3.0 – 3.2.6",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Ice Cream Sandwich",
                "4.0 – 4.0.4",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Jelly Bean",
                "4.1 – 4.3.1",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Kit Kat",
                "4.4 – 4.4.4",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Lollypop",
                "5.0 – 5.1.1",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Marshmallow",
                "6.0 – 6.0.1",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Nougat",
                "7.0 – 7.1.2",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Oreo",
                "8.0 – 8.1",
                getRandomDate(),
                riba
                ));
            Storage.Add(new AndroidVersionInfo(
                Guid.NewGuid(),
                "Pie",
                "9.0",
                getRandomDate(),
                riba
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
