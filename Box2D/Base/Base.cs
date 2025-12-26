using System.Runtime.InteropServices;

namespace Box2D.Base;

public static unsafe class Base
{
    /// <summary>
    /// This allows the user to override the allocation functions. These should be
    /// set during application startup.
    /// </summary>
    [DllImport("box2d", EntryPoint = "b2SetAllocator")]
    public static extern void SetAllocator(AllocFcn allocFcn, FreeFcn freeFcn);

    /// <summary>
    /// Return the total bytes allocated by Box2D
    /// </summary>
    [DllImport("box2d", EntryPoint = "b2GetByteCount")]
    public static extern int GetByteCount();

    /// <summary>
    /// Override the default assert callback
    /// </summary>
    /// <param name="assertFcn">a non-null assert callback</param>
    [DllImport("box2d", EntryPoint = "b2SetAssertFcn")]
    public static extern void SetAssertFcn(AssertFcn assertFcn);

    /// <summary>
    /// Yield to be used in a busy loop.
    /// </summary>
    [DllImport("box2d", EntryPoint = "b2Yield")]
    public static extern void Yield();
    
    /// <summary>
    /// Simple djb2 hash function for determinism testing
    /// </summary>
    [DllImport("box2d", EntryPoint = "b2Hash")]
    public static extern void Hash(uint hash, byte* data, int count);

    [DllImport("box2d", EntryPoint = "b2SetLengthUnitsPerMeter")]
    public static extern void SetLengthUnitsPerMeter(float lengthUnits);

    [DllImport("box2d", EntryPoint = "b2GetLengthUnitsPerMeter")]
    public static extern float GetLengthUnitsPerMeter();
}