using Core.Interface;
using org.mariuszgromada.math.mxparser;
using Service;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICalculate, CalculateService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

License.iConfirmNonCommercialUse("Dvar Raii");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
