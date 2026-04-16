using System;
using System.Collections.Generic;
using System.Text;

namespace DMOS.Core.Info
{
    /// <summary>
    /// Represents a version's stage, in other words, the software release life cycle.
    /// </summary>
    public enum VersionStage
    {
        /// <summary>
        /// Dev releases, nightly builds, etc.
        /// </summary>
        PreAlpha,

        /// <summary>
        /// Initial testing phase. Use at own risk.
        /// </summary>
        Alpha,

        /// <summary>
        /// Feature complete, but may contain bugs.
        /// </summary>
        Beta,

        /// <summary>
        /// Final testing.
        /// </summary>
        ReleaseCandidate,

        /// <summary>
        /// Full stable release.
        /// </summary>
        Stable
    }
}
