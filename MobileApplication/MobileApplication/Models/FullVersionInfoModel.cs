using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApplication.Models
{
    public class FullVersionInfoModel
    {
        public Guid Id { get; set; }
        public string CodeName { get; set; }
        public string VersionNumber { get; set; }
        public DateTime InitialReleaseDate { get; set; }
        public string Description { get; set; }
    }
}
