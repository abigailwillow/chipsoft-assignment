namespace ChipSoftAssignment.Models;

/// <summary>
/// A referral of a patient from one institution to another, including a referral letter and the patient's allergies at the time of referral.
/// </summary>
public class Referral {
    public required int PatientId { get; init; }
    public required int FromInstitutionId { get; init; }
    public required int ToInstitutionId { get; init; }
    public required string ReferralLetterFileUuid { get; init; }
    public required Allergy[] Allergies { get; init; }
}
