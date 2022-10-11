using MinimalAPI.Endpoints.Internal;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
//builder.Services.AddAuthorization();
builder.Services.AddEndpoints<Program>(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//# if DEBUG
//builder.Services.AddLogging(b => {
//    b.AddConsole();
//});
//#endif
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseHttpLogging();  //this would fill up the hdd in production but it is useful in debugg
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseEndpoints<Program>();
app.UseHttpsRedirection();

//app.UseAuthentication();
//app.UseAuthorization();



app.Run();


