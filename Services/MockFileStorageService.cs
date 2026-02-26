namespace ChipSoftAssignment.Services;

public class MockFileStorageService(ILogger<MockFileStorageService> logger) : IFileStorageService {
    private readonly Dictionary<Guid, byte[]> _fileStorage = new Dictionary<Guid, byte[]>();
    
    public async Task<Guid> SaveFile(IFormFile formFile) {
        Guid fileUuid = Guid.NewGuid();
        
        using MemoryStream formFileStream = new MemoryStream();
        await formFile.CopyToAsync(formFileStream);
        _fileStorage.Add(fileUuid, formFileStream.ToArray());
        
        logger.LogInformation("Saved file with identifier {fileUuid}", fileUuid);
        return await Task.FromResult(fileUuid);
    }
    
    public async Task<byte[]> LoadFile(Guid fileUuid) {
        if (!_fileStorage.ContainsKey(fileUuid)) {
            logger.LogError("No file found with identifier {fileUuid}", fileUuid);
            throw new FileNotFoundException($"No file found with identifier {fileUuid}");
        }
        
        logger.LogInformation("Loaded file with identifier {fileUuid}", fileUuid);
        return await Task.FromResult(_fileStorage[fileUuid]);
    }
}