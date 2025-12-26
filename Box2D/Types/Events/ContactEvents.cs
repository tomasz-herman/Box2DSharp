using System.Runtime.InteropServices;
namespace Box2D.Types.Events;

/// <summary>
/// Contact events are buffered in the Box2D world and are available
/// as event arrays after the time step is complete.
/// Note: these may become invalid if bodies and/or shapes are destroyed
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public unsafe struct ContactEvents
{
    public ContactBeginTouchEvent* BeginEvents;
    public ContactEndTouchEvent* EndEvents;
    public ContactHitEvent* HitEvents;
    public int BeginCount;
    public int EndCount;
    public int HitCount;
}