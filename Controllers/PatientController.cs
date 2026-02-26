namespace ChipSoftAssignment.Controllers;

using ChipSoftAssignment.Models;
using ChipSoftAssignment.Services;

using Microsoft.AspNetCore.Mvc;

[Route("patients/{patientId:int:min(0)}")]
public class PatientController(IDatabaseService databaseService) {
    [HttpGet("medications")]
    [Produces("application/json")]
    public async Task<Medication[]> GetMedications([FromRoute] int patientId) {
        return await databaseService.GetMedicationByPatientId(patientId);
    }
}