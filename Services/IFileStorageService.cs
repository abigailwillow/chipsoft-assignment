namespace ChipSoftAssignment.Services;

public interface IFileStorageService {
    Task<Guid> SaveFile(IFormFile formFile);
    Task<byte[]> LoadFile(Guid fileUuid);
}