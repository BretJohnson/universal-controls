// This file is generated from IPath.cs. Update the source file to change its contents.

using AnywhereControls.Media;

namespace AnywhereControls.Shapes
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
