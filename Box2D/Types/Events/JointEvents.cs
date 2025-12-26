using System.Runtime.InteropServices;
namespace Box2D.Types.Events;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct JointEvents
{
    public JointEvent* Events;
    public int Count;
}