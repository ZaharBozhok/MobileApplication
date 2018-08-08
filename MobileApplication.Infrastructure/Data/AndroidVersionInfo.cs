using System;
using System.Collections.Generic;
using System.Text;
using MobileApplication.VersionInfoAndroid.VersionInfo;

namespace MobileApplication.Infrastructure.Data
{
    public class AndroidVersionInfo
    {
        public AndroidVersionInfo(Guid id, string codeName, string versionNumber, DateTime initialReleaseDate, string description)
        {
            Id = id;
            CodeName = codeName;
            VersionNumber = versionNumber;
            InitialReleaseDate = initialReleaseDate;
            Description = description;
        }

        public Guid Id { get; set; }
        public string CodeName { get; set; }
        public string VersionNumber { get; set; }
        public DateTime InitialReleaseDate { get; set; }
        public string Description { get; set; }
    }
}
