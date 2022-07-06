using AutoMapper;
using MediatR;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TouristAppBackend.Application.Common.Interfaces;
using TouristAppBackend.Application.Common.Interfaces.Validators;
using TouristAppBackend.Domain.Models;

namespace TouristAppBackend.Application.Images.Commands.UploadImage
{
    public class CreateImageHandler : IRequestHandler<CreateImageCommand, string>
    {
        private readonly ITouristAppContext _touristAppContext;
        private readonly IMapper _mapper;
        private readonly IFileStore _fileStore;
        private readonly IImageFileValidator _imageFileValidator;

        public CreateImageHandler(
            ITouristAppContext touristAppContext,
            IMapper mapper,
            IFileStore fileStore,
            IImageFileValidator imageFileValidator
            )
        {
            _touristAppContext = touristAppContext;
            _mapper = mapper;
            _fileStore = fileStore;
            _imageFileValidator = imageFileValidator;
        }

        public async Task<string> Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            var picture = _mapper.Map<Picture>(request);

            picture.CreatedBy = _touristAppContext.Users.Where(u => u.Id == picture.AuthorId).Select(s => s.FirstName).FirstOrDefault();

            _imageFileValidator.Validte(request.Picture);

            string folderName = Path.Combine("StaticFiles", "Images");

            string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            byte[] bytes = _fileStore.GetBytes(request.Picture);

            picture.PathToImage = _fileStore.SafeWriteFile(bytes, request.Picture.FileName, pathToSave);

            _touristAppContext.Pictures.Add(picture);
            await _touristAppContext.SaveChangesAsync(cancellationToken);

            return picture.PathToImage;
        }
    }
}
