namespace ChipSoftAssignment.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// A patient that can be referred between institutions, and their associated information.
/// </summary>
public class Patient  {
    [Required]
    [DefaultValue(0)]
    [Range(0, int.MaxValue, ErrorMessage = "Id must not be negative.")]
    public required int Id { get; init; }
    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Patient name must be between 1 and 100 characters.")]
    public required string Name { get; init; }
    public required List<Allergy> Allergies { get; init; }
    public required List<Medication> Medications { get; init; }
    public required List<Referral> Referrals { get; init; }
}

/// <summary>
/// A record of an allergy of a patient.
/// </summary>
/// <param name="Name">Name of the allergen</param>
/// <param name="Severity">Severity of allergy</param>
public record Allergy(string Name, AllergySeverity Severity);

/// <summary>
/// A medication that a patient is using.
/// </summary>
/// <param name="Name">The name of the medication</param>
/// <param name="Dosage">The dosage the patient is using</param>
public record Medication(string Name, string Dosage);

/// <summary>
/// The severity of an allergy measured on a scale of light, moderate, and severe.
/// </summary>
public enum AllergySeverity {
    Severe,
    Moderate,
    Light,
}
