using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApplication.Abstractions.VersionInfo
{
    public interface IVersionInfo
    {
        Guid Id { get; }
        string CodeName { get; }
        string VersionNumber { get; }
        DateTime InitialReleaseDate { get; }
        string Description { get; }
    }
}
