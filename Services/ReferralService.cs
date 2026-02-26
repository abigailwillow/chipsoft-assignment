using ChipSoftAssignment.Models;
using ChipSoftAssignment.Models.Resources;

namespace ChipSoftAssignment.Services;

public class ReferralService(IDatabaseService databaseService, IFileStorageService fileStorageService) : IReferralService {
    public async Task<Referral[]> GetReferralsByInstitutionId(int institutionId) {
        return await databaseService.GetReferralsByInstitutionId(institutionId);
    }

    /// <summary>
    /// Takes a limited referral resource and its associated referral letter, and adds it to the database associated with the institution the referral is for.
    /// </summary>
    /// <param name="institutionId">The institution this referral is for</param>
    /// <param name="referral">The data of the referral</param>
    /// <param name="referralLetter">The referral letter file</param>
    public async Task AddReferralByInstitutionId(int institutionId, ReferralResource referral, IFormFile referralLetter) {
        Guid referralLetterFileUuid = await fileStorageService.SaveFile(referralLetter);

        await databaseService.AddReferralByInstitutionId(institutionId, new Referral {
            PatientId = referral.PatientId,
            FromInstitutionId = referral.FromInstitutionId,
            ToInstitutionId = institutionId,
            ReferralLetterFileUuid = referralLetterFileUuid.ToString(),
            Allergies = await databaseService.GetAllergiesByPatientId(referral.PatientId)
        });
    }
}