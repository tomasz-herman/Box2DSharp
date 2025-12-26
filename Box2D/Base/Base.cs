using System.Runtime.InteropServices;

namespace Box2D.Base;

public static unsafe partial class Base
{
    /// <summary>
    /// This allows the user to override the allocation functions. These should be
    /// set during application startup.
    /// </summary>
    [LibraryImport("box2d", EntryPoint = "b2SetAllocator")]
    public static partial void SetAllocator(AllocFcn allocFcn, FreeFcn freeFcn);

    /// <summary>
    /// Return the total bytes allocated by Box2D
    /// </summary>
    [LibraryImport("box2d", EntryPoint = "b2GetByteCount")]
    public static partial int GetByteCount();

    /// <summary>
    /// Override the default assert callback
    /// </summary>
    /// <param name="assertFcn">a non-null assert callback</param>
    [LibraryImport("box2d", EntryPoint = "b2SetAssertFcn")]
    public static partial void SetAssertFcn(AssertFcn assertFcn);

    /// <summary>
    /// Yield to be used in a busy loop.
    /// </summary>
    [LibraryImport("box2d", EntryPoint = "b2Yield")]
    public static partial void Yield();
    
    /// <summary>
    /// Simple djb2 hash function for determinism testing
    /// </summary>
    [LibraryImport("box2d", EntryPoint = "b2Hash")]
    public static partial void Hash(uint hash, byte* data, int count);

    [LibraryImport("box2d", EntryPoint = "b2SetLengthUnitsPerMeter")]
    public static partial void SetLengthUnitsPerMeter(float lengthUnits);

    [LibraryImport("box2d", EntryPoint = "b2GetLengthUnitsPerMeter")]
    public static partial float GetLengthUnitsPerMeter();
}