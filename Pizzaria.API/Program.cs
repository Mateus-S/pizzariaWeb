using Pizzaria.API.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// INJETAR DEPENDÊNCIAS CUSTOMIZADAS
builder.Services.AddProjectServices(builder.Configuration);

var app = builder.Build();

// PIPELINE
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowBlazorClient");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();