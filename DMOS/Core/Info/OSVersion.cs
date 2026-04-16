using DMOS.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Info
{
    /// <summary>
    /// Represents a system version.
    /// </summary>
    public class OSVersion
    {
        /// <summary>
        /// The major version, used for breaking changes.
        /// </summary>
        public int Major { get; set; }

        /// <summary>
        /// The minor version, used for non-breaking changes.
        /// </summary>
        public int Minor { get; set; }

        /// <summary>
        /// The patch version, used for bug fixes.
        /// </summary>
        public int Patch { get; set; }

        /// <summary>
        /// The release candidate version.
        /// </summary>
        public int RCVersion { get; set; }

        /// <summary>
        /// The stage of this version.
        /// </summary>
        public VersionStage Stage { get; set; }

        /// <summary>
        /// Constructs a new version.
        /// </summary>
        public OSVersion(int major, int minor, int patch, VersionStage stage)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
            Stage = stage;
        }

        /// <summary>
        /// Converts the version info into a string.
        /// </summary>
        /// <returns>The version string.</returns>
        public string ToVersionString()
        {
            var sb = new StringBuilder($"{Major}.{Minor}.{Patch}-");

            if (Stage == VersionStage.ReleaseCandidate)
                sb.Append($"rc-{RCVersion}");
            else
                sb.Append(Stage.GetName());

            return sb.ToString();
        }
    }
}
