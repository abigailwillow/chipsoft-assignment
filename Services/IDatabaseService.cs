using ChipSoftAssignment.Models;

namespace ChipSoftAssignment.Services;

public interface IDatabaseService {
    Task<Patient> GetPatientById(int patientId);
    Task<Medication[]> GetMedicationByPatientId(int patientId);
    Task<Allergy[]> GetAllergiesByPatientId(int patientId);
    Task<Institution> GetInstitutionById(int institutionId);
    Task<Referral[]> GetReferralsByInstitutionId(int institutionId);
    Task AddReferralByInstitutionId(int institutionId, Referral referral);
}