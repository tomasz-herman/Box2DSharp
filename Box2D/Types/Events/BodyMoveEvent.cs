using System.Runtime.InteropServices;
using Box2D.Id;
using Box2D.Math;

namespace Box2D.Types.Events;

/// <summary>
/// Body move events triggered when a body moves.
/// </summary>
/// <remarks>
/// Note: If sleeping is disabled all dynamic and kinematic bodies will trigger move events.
/// </remarks>
public unsafe struct BodyMoveEvent
{
    public Transform Transform;
    public BodyId BodyId;
    public void* UserData;
    [MarshalAs(UnmanagedType.U1)]
    public bool FellAsleep;
}