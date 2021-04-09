using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TailorStore.Application.Common.Interfaces;
using TailorStore.Domain.Common;
using TailorStore.Domain.Enums;

namespace TailorStore.Infrastructure.Services {
    public class ImageService : IImageService{
        private readonly ILogger<ImageService> _logger;

        public ImageService(ILogger<ImageService> logger) {
            _logger = logger;
        }

        public async Task<Tuple<bool, string>> SaveImageAsync(ImageType imageType, string base64image, string extension, CancellationToken cancellationToken = default) {
            var image = Convert.FromBase64String(base64image);

            if (image.GetHeaderFromFile().GetFileType() == FileType.Unknwon) {
                _logger.LogWarning("UserImagePicture unsupported header: {0}", image.GetHeaderFromFile());
                return new Tuple<bool, string>(false, string.Empty);
            }



            var savePath = GetSavePath(imageType);

            if (string.IsNullOrEmpty(savePath)) {
                _logger.LogWarning("image save path not found: {0}", imageType.ToString());
                return new Tuple<bool, string>(false, string.Empty);
            }

            if (!Directory.Exists(savePath)) {
                Directory.CreateDirectory(savePath);
            }

            var fileName = Guid.NewGuid();
            var completeFile = $"{fileName}{extension}";
            savePath = Path.Combine(savePath, completeFile);
            await File.WriteAllBytesAsync(savePath, image, cancellationToken);

            return new Tuple<bool, string>(true, completeFile);
        }

        public string GetSavePath(ImageType imageType) {
            return imageType switch {
                ImageType.Fabric => Path.Combine(Environment.GetEnvironmentVariable("ImageSaveLocation"), "coupons"),
                //ImageType.Merchant => Path.Combine(Environment.GetEnvironmentVariable("ImageSaveLocation"), "merchants"),
                //ImageType.User => Path.Combine(Environment.GetEnvironmentVariable("ImageSaveLocation"), "users"),
                _ => string.Empty,
            };
        }
    }
}
