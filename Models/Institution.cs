namespace ChipSoftAssignment.Models;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// A healthcare institution that can send and receive referrals for patients.
/// </summary>
public class Institution {
    [Required]
    [DefaultValue(0)]
    [Range(0, int.MaxValue, ErrorMessage = "Id must not be negative.")]
    public required int Id { get; init; }
    [Required]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Institution name must be between 1 and 100 characters.")]
    public required string Name { get; init; }
    public required List<Referral> Referrals { get; init; }
}