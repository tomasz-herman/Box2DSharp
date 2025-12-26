using System.Runtime.InteropServices;

namespace Box2D.Base;

/// <summary>
/// Version numbering scheme.
/// See https://semver.org/
/// </summary>
public struct Version
{
    /// <summary>
    /// Significant changes
    /// </summary>
    public int Major;
    /// <summary>
    /// Incremental changes
    /// </summary>
    public int Minor;
    /// <summary>
    /// Bug fixes
    /// </summary>
    public int Revision;

    /// <summary>
    /// Get the current version of Box2D
    /// </summary>
    [DllImport("box2d",  EntryPoint = "b2GetVersion")]
    public static extern Version GetVersion();

    public override string ToString() => $"{Major}.{Minor}.{Revision}";
}