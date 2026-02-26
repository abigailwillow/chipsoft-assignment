using ChipSoftAssignment.Models;

namespace ChipSoftAssignment.Services;

public class MockDatabaseService(ILogger<MockDatabaseService> logger) : IDatabaseService {
    private readonly ILogger _logger = logger;

    #region Mock Data
    private List<Patient> patients = [
        new Patient {
            Id = 0,
            Name = "Jane Doe",
            Allergies = [new Allergy("Penicillin", AllergySeverity.Moderate)],
            Medications = [new Medication("Paracetamol", "1000mg daily")],
            Referrals = [],
        },
        new Patient {
            Id = 1,
            Name = "John Doe",
            Allergies = [new Allergy("Peanuts", AllergySeverity.Severe)],
            Medications = [new Medication("Ibuprofen", "400mg daily")],
            Referrals = [],
        }
    ];
    
    private List<Institution> institutions = [
        new Institution { Id = 0, Name = "Spaarne Gasthuis", Referrals = []},
        new Institution { Id = 1, Name = "Rode Kruis Ziekenhuis", Referrals = []},
    ];
    #endregion
    
    public Task<Patient> GetPatientById(int patientId) {
        Patient? patient = patients.Find(p => p.Id == patientId);

        if (patient == null) {
            _logger.LogWarning("Patient with id {patientId} not found", patientId);
            throw new KeyNotFoundException($"Patient with id {patientId} not found");
        }
        
        _logger.LogInformation("Retrieving data for patient: {patientName}", patient.Name);
        return Task.FromResult(patient);
    }
    
    public async Task<Medication[]> GetMedicationByPatientId(int patientId) {
        Patient patient = await GetPatientById(patientId);
        Medication[] medications = patient.Medications.ToArray();
        _logger.LogInformation("Retrieved {medicationCount} medications for patient: {patientName}", medications.Length, patient.Name);
        return medications;
    }
    
    public async Task<Allergy[]> GetAllergiesByPatientId(int patientId) {
        Patient patient = await GetPatientById(patientId);
        Allergy[] allergies = patient.Allergies.ToArray();
        _logger.LogInformation("Retrieved {allergyCount} allergies for patient: {patientName}", allergies.Length, patient.Name);
        return allergies;
    }

    public Task<Institution> GetInstitutionById(int institutionId) {
        Institution? institution = institutions.Find(i => i.Id == institutionId);
        
        if (institution == null) {
            _logger.LogWarning("Institution with id {institutionId} not found", institutionId);
            throw new KeyNotFoundException($"Institution with id {institutionId} not found");
        }
        
        _logger.LogInformation("Retrieving data for institution: {institutionName}", institution.Name);
        return Task.FromResult(institution);
    }

    public async Task<Referral[]> GetReferralsByInstitutionId(int institutionId) {
        Institution institution = await GetInstitutionById(institutionId);
        Referral[] referrals = institution.Referrals.ToArray();
        _logger.LogInformation("Retrieved {referralCount} referrals for institution: {institutionName}", referrals.Length, institution.Name);
        return referrals;
    }
    
    public async Task AddReferralByInstitutionId(int institutionId, Referral referral) {
        Institution institution = await GetInstitutionById(institutionId);
        institution.Referrals.Add(referral);
        _logger.LogInformation("Added referral for patient with identifier {patientName} to institution: {institutionName}", referral.PatientId, institution.Name);
    }
}