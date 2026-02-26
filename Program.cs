using ChipSoftAssignment.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDatabaseService, MockDatabaseService>();
builder.Services.AddSingleton<IFileStorageService, MockFileStorageService>();
builder.Services.AddSingleton<IReferralService, ReferralService>();

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
