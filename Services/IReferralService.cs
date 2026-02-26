namespace ChipSoftAssignment.Services;

using ChipSoftAssignment.Models;
using ChipSoftAssignment.Models.Resources;

public interface IReferralService {
    Task<Referral[]> GetReferralsByInstitutionId(int institutionId);
    Task AddReferralByInstitutionId(int institutionId, ReferralResource referral, IFormFile referralLetter);
}