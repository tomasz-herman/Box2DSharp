using System.Runtime.InteropServices;

namespace Box2D;

public unsafe struct Timer
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
    [DllImport("box2d", EntryPoint = "b2GetTicks")]
    public static extern ulong GetTicks();

    /// <summary>
    /// Get the milliseconds passed from an initial tick value.
    /// </summary>
    [DllImport("box2d", EntryPoint = "b2GetMilliseconds")]
    public static extern float GetMilliseconds(ulong ticks);

    /// <summary>
    /// Get the milliseconds passed from an initial tick value. Resets the passed in
    /// value to the current tick value.
    /// </summary>
    [DllImport("box2d", EntryPoint = "b2GetMillisecondsAndReset")]
    public static extern float GetMillisecondsAndReset(ulong* ticks);
}
