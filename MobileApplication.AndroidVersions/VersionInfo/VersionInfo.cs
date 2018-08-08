using MobileApplication.Abstractions.VersionInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApplication.VersionInfoAndroid.VersionInfo
{
    public class VersionInfo : IVersionInfo
    {
        public VersionInfo(Guid id, string codeName, string versionNumber, DateTime initialReleaseDate, string description)
        {
            Id = id;
            CodeName = codeName;
            VersionNumber = versionNumber;
            InitialReleaseDate = initialReleaseDate;
            Description = description;
        }

        public Guid Id { get; }

        public string CodeName { get; }

        public string VersionNumber { get; }

        public DateTime InitialReleaseDate { get; }

        public string Description { get; }
    }
}
