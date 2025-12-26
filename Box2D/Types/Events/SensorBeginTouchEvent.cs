using Box2D.Id;
using System.Runtime.InteropServices;

namespace Box2D.Types.Events;

/// <summary>
/// A begin touch event is generated when a shape starts to overlap a sensor shape.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct SensorBeginTouchEvent
{
    public ShapeId SensorShapeId;
    public ShapeId VisitorShapeId;
}