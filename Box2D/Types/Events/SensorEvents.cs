namespace Box2D.Types.Events;

/// <summary>
/// Sensor events are buffered in the Box2D world and are available
/// as begin/end overlap event arrays after the time step is complete.
/// Note: these may become invalid if bodies and/or shapes are destroyed
/// </summary>
public unsafe struct SensorEvents
{
    public SensorBeginTouchEvent* BeginEvents;
    public SensorBeginTouchEvent* EndEvents;
    public int BeginCount;
    public int EndCount;
}