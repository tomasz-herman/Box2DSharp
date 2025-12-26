using Box2D.Id;

namespace Box2D.Types.Events;

/// <summary>
/// A begin touch event is generated when a shape starts to overlap a sensor shape.
/// </summary>
public struct SensorBeginTouchEvent
{
    public ShapeId SensorShapeId;
    public ShapeId VisitorShapeId;
}