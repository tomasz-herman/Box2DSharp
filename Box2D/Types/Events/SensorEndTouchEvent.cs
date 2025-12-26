using Box2D.Id;
using System.Runtime.InteropServices;

namespace Box2D.Types.Events;

/// <summary>
/// An end touch event is generated when a shape stops overlapping a sensor shape.
///     These include things like setting the transform, destroying a body or shape, or changing
///     a filter. You will also get an end event if the sensor or visitor are destroyed.
///     Therefore you should always confirm the shape id is valid using b2Shape_IsValid.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct SensorEndTouchEvent
{
    public ShapeId SensorShapeId;
    public ShapeId VisitorShapeId;
}