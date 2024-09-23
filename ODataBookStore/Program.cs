using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataBookStore;
using ODataBookStore.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddOData(opt => opt.Select().Filter()
    .Count().OrderBy().Expand().SetMaxTop(100)
    .AddRouteComponents("odata", GetEdmModel()));


// Register the In-Memory Database
builder.Services.AddDbContext<BookStoreContext>(options =>
    options.UseInMemoryDatabase("BookStoreDB"));

var app = builder.Build();

app.UseODataBatching();

app.UseRouting();

//Test middleware
app.Use(next => context =>
{
    var endpoint = context.GetEndpoint();
    if (endpoint == null)
    {
        return next(context);
    }

    IEnumerable<string> templates;
    IODataRoutingMetadata metadata =
    endpoint.Metadata.GetMetadata<IODataRoutingMetadata>();
    if (metadata != null)
    {
        templates = metadata.Template.GetTemplates();
    }
    return next(context);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

    var books = builder.EntitySet<Book>("Books");
    books.EntityType
        .Filter()    // Enable filtering on all properties
        .OrderBy()   // Enable ordering on all properties
        .Expand();   // Allow expanding related entities

    var presses = builder.EntitySet<Press>("Presses");
    presses.EntityType
        .Filter()
        .OrderBy()
        .Expand();

    return builder.GetEdmModel();
}


