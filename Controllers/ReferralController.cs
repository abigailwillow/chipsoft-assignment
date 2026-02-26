namespace ChipSoftAssignment.Controllers;

using ChipSoftAssignment.Models;
using ChipSoftAssignment.Models.Resources;
using ChipSoftAssignment.Services;

using Microsoft.AspNetCore.Mvc;

[Route("institutions/{institutionId:int:min(0)}")]
public class ReferralController(ILogger<ReferralController> logger, IReferralService referralService) {
    private readonly ILogger _logger = logger;
    
    [HttpPost("referrals")]
    [Consumes("multipart/form-data")]
    [Produces("application/json")]
    public async Task<IResult> SendReferral(
        [FromRoute] int institutionId,
        [FromForm] ReferralResource referral,
        IFormFile? referralLetterFile) {
        
        if (referralLetterFile == null) {
            _logger.LogError("No referral letter attached to referral to institution with identifier {institutionId}", institutionId);
            return Results.BadRequest("Referral letter attachment is required");
        }
        
        await referralService.AddReferralByInstitutionId(institutionId, referral, referralLetterFile);
        return Results.Created($"referrals/{institutionId}", referral);
    }
    
    [HttpGet("referrals")]
    [Produces("application/json")]
    public async Task<Referral[]> GetReferrals([FromRoute] int institutionId) {
        return await referralService.GetReferralsByInstitutionId(institutionId);
    }
}