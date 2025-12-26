using Box2D.Id;
using System.Runtime.InteropServices;

namespace Box2D.Types.Events;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct JointEvent
{
    public JointId JointId;
    public void* UserData;
}