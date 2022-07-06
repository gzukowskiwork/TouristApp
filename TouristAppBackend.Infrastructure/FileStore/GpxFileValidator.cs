using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using TouristAppBackend.Application.Common.Interfaces.Validators;
using TouristAppBackend.Common;

namespace TouristAppBackend.Infrastructure.FileStore
{
    internal class GpxFileValidator : IGpxFileValidator
    {
        public void Validte<T>(T tclass)
        {
            var file = tclass as IFormFile;
            var extension = Path.GetExtension(file.FileName);

            if (file == null)
            {
                throw new ArgumentNullException(Constants.ErrorMesseges.FileCannotBeNull);
            }

            if (IsFileTypeUnsupported(extension))
            {
                throw new FormatException(string.Format(Constants.ErrorMesseges.UnsupportedFileFormat, file.FileName));
            }
        }

        private bool IsFileTypeUnsupported(string type)
        {
            string shortType = type.Substring(1);
            List<string> supportedFileTypes = new List<string>();

            foreach (var supportedType in Enum.GetValues(typeof(SupportedGpxFileType)))
            {
                supportedFileTypes.Add(supportedType.ToString());
            }

            return !supportedFileTypes.Contains(shortType);
        }
    }
}
