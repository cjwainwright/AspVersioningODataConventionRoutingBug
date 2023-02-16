using AspVersioningODataConventionRoutingBug.Models;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

#if false

// Setting up the Edm model without versioning.
// Navigation and property routing work

var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Person>("People");
builder.Services.AddControllers().AddOData(options =>
{
    options.AddRouteComponents(modelBuilder.GetEdmModel());
});

#else

// Setting up the Edm model with versioning.
// Navigation and property routing do not work.

builder.Services.AddControllers().AddOData();
builder.Services.AddApiVersioning().AddOData(options =>
{
    options.ModelBuilder.DefaultModelConfiguration = (builder, version, prefix) =>
    {
        builder.EntitySet<Person>("People");
    };
    options.AddRouteComponents();
});

#endif


var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseODataRouteDebug();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
