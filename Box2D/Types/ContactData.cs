using Box2D.Collision;
using System.Runtime.InteropServices;
using Box2D.Id;

namespace Box2D.Types;

/// <summary>
/// Data for a touching contact. This is returned by the contact iterator.
/// </summary>
/// <seealso cref="Box2D.Shape.GetContactData"/>
/// <seealso cref="Box2D.Body.GetContactData"/>
[StructLayout(LayoutKind.Sequential)]
public struct ContactData
{
    public ShapeId ShapeIdA;
    public ShapeId ShapeIdB;
    public Manifold Manifold;
}