using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorStore.Domain.Enums;

namespace TailorStore.Domain.Common {
    public static class ImageExtensions {
        public static string GetHeaderFromFile(this byte[] v) {
            var buffer = new byte[8];

            using var ms = new MemoryStream(v);
            using var reader = new BinaryReader(ms);
            reader.Read(buffer, 0, buffer.Length);

            var sb = new StringBuilder();
            foreach (var b in buffer) {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

        // https://social.msdn.microsoft.com/Forums/vstudio/en-US/9d25b9b9-fd3d-4a1a-86b7-b5cd08089802/how-to-indentify-type-of-image-when-we-have-byte-array-of-image?forum=netfxbcl
        public static FileType GetFileType(this string header) {
            if (header.StartsWith("FFD8FFE")) {
                return FileType.JPEG;
                //return "JPG";
                //} else if (header.StartsWith("49492A")) {
                //    return "TIFF";
                //} else if (header.StartsWith("424D")) {
                //    return "BMP";
                //} else if (header.StartsWith("474946")) {
                //    return "GIF";
            } else if (header.StartsWith("89504E470D0A1A0A")) {
                return FileType.PNG;
                //return "PNG";
            } else {
                return FileType.Unknwon; //UnKnown
            }
        }
    }
}
