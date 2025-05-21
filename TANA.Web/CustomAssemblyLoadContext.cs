using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace TANA.Web
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public IntPtr LoadUnmanagedLibrary(string absolutePath)
        {
            return LoadUnmanagedDll(absolutePath);
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllPath)
        {
            return LoadUnmanagedDllFromPath(unmanagedDllPath);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null!;
        }

        public static string GetWkhtmltoxLibraryPath()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return "libwkhtmltox.dll";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return "/usr/lib/libwkhtmltox.so";

            throw new PlatformNotSupportedException("Unsupported OS");
        }
    }
}
