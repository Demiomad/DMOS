using DMOS.Core.Info;
using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Extensions
{
    public static class VersionStageExtensions
    {
        private static Dictionary<VersionStage, string> _stageMap = new()
        {
            { VersionStage.PreAlpha, "prealpha" },
            { VersionStage.Alpha, "alpha" },
            { VersionStage.Beta, "beta" },
            { VersionStage.ReleaseCandidate, "rc" },
            { VersionStage.Stable, "stable" }
        };

        /// <summary>
        /// Gets a version stage's name.
        /// </summary>
        /// <param name="stage">The version stage.</param>
        /// <returns>The stage's name.</returns>
        public static string GetName(this VersionStage stage)
            => _stageMap[stage];
    }
}
