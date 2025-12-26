namespace Box2D.Types.Events;

/// <summary>
/// Body events are buffered in the Box2D world and are available
/// as event arrays after the time step is complete.
/// Note: this data becomes invalid if bodies are destroyed
/// </summary>
public unsafe struct BodyEvents
{
    public BodyMoveEvent* MoveEvents;
    public int MoveCount;
}