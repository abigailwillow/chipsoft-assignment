namespace ChipSoftAssignment.Models.Resources;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// A limited representation of  referral used for creating a referral only containing the necessary information to create a referral.
/// </summary>
public class ReferralResource {
    [Required]
    [DefaultValue(0)]
    [Range(0, int.MaxValue, ErrorMessage = "PatientId must not be negative.")]
    public required int PatientId { get; init; }
    [Required]
    [DefaultValue(0)]
    [Range(0, int.MaxValue, ErrorMessage = "FromInstitutionId must not be negative.")]
    public required int FromInstitutionId { get; init; }
}