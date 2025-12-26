using System.Runtime.InteropServices;

namespace Box2D;

[StructLayout(LayoutKind.Sequential)]
public unsafe partial struct Timer
{
    private ulong _start;

    public static Timer Create()
    {
        return new Timer { _start = GetTicks() };
    }

    public float GetMilliseconds()
    {
        return GetMilliseconds(_start);
    }

    public float GetMillisecondsAndReset()
    {
        fixed (ulong* ptr = &_start)
        {
            return GetMillisecondsAndReset(ptr);
        }
    }
    
    /// <summary>
    /// Get the absolute number of system ticks. The value is platform specific.
    /// </summary>
    [LibraryImport("box2d", EntryPoint = "b2GetTicks")]
    public static partial ulong GetTicks();

    /// <summary>
    /// Get the milliseconds passed from an initial tick value.
    /// </summary>
    [LibraryImport("box2d", EntryPoint = "b2GetMilliseconds")]
    public static partial float GetMilliseconds(ulong ticks);

    /// <summary>
    /// Get the milliseconds passed from an initial tick value. Resets the passed in
    /// value to the current tick value.
    /// </summary>
    [LibraryImport("box2d", EntryPoint = "b2GetMillisecondsAndReset")]
    public static partial float GetMillisecondsAndReset(ulong* ticks);
}