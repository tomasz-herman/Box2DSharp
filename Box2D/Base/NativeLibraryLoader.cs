using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Box2D.Base;

internal static class NativeLibraryLoader
{
    [ModuleInitializer]
    internal static void Initialize()    
    {
        NativeLibrary.SetDllImportResolver(Assembly.GetExecutingAssembly(), DllImportResolver);
    }

    private static IntPtr DllImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
    {
        if (libraryName != "box2d")
        {
            return IntPtr.Zero;
        }

        string rid;
        string fileName;

        if (OperatingSystem.IsWindows())
        {
            rid = "win-x64";
            fileName = "box2d.dll";
        }
        else if (OperatingSystem.IsLinux())
        {
            rid = "linux-x64";
            fileName = "libbox2d.so";
        }
        else if (OperatingSystem.IsMacOS())
        {
            rid = "osx-x64";
            fileName = "libbox2d.dylib";
        }
        else
        {
            return IntPtr.Zero;
        }

        string path = Path.Combine(AppContext.BaseDirectory, "runtimes", rid, "native", fileName);

        if (NativeLibrary.TryLoad(path, out IntPtr handle))
        {
            return handle;
        }

        return IntPtr.Zero;
    }
}