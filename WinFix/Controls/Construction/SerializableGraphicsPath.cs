using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RA
{
    /// <summary>
    /// Сериализуемая обертка над GraphicsPath
    /// </summary>
    [Serializable]
    public sealed class SGraphicsPath : ISerializable, IDisposable
    {
        public GraphicsPath Path = new GraphicsPath();

		public SGraphicsPath() { }
		public SGraphicsPath(GraphicsPath GPath) {
			Path = GPath;
		}
		private SGraphicsPath(SerializationInfo info, StreamingContext context)
        {
            if (info.MemberCount > 0)
            {
                var points = (PointF[])info.GetValue("p", typeof(PointF[]));
                var types = (byte[])info.GetValue("t", typeof(byte[]));
                Path = new GraphicsPath(points, types);
            }
            else
                Path = new GraphicsPath();
        }

        public void Dispose()
        {
            Path.Dispose();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (Path.PointCount <= 0) return;
            info.AddValue("p", Path.PathPoints);
            info.AddValue("t", Path.PathTypes);
        }

		public static implicit operator GraphicsPath(SGraphicsPath path)
        {
            return path.Path;
        }

		public static implicit operator SGraphicsPath(GraphicsPath path)
        {
			return new SGraphicsPath { Path = path };
        }
    }
}
