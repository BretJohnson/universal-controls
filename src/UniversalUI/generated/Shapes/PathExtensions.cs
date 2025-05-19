// This file is generated from IPath.cs. Update the source file to change its contents.

using AnywhereUI.Media;

namespace AnywhereUI.Shapes
{
    public static class PathExtensions
    {
        public static T Data<T>(this T path, IGeometry value) where T : IPath
        {
            path.Data = value;
            return path;
        }
    }
}
