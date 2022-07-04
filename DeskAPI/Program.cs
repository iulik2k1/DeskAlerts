using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.Resource;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

var scopeRequiredByApi = app.Configuration["AzureAd:Scopes"] ?? "";


Message msg = new Message { user = @"IULIK-PC\iulik", message = "Expira parola in 2 zile", expire = DateTime.Now.AddDays(2) };

app.MapGet("/getMessageQueue", () =>
{
    return Results.Ok(msg);
});



app.MapPost("/pushMessageQueue", async (string user, string message, DateTime dt, HttpResponse response) => {
    Message msgqueue = new Message { user = user, message = message, expire = dt };
    Console.WriteLine(msgqueue);
    return Results.Ok();
});



app.Run();


public class Message
{
    public string user { get; set; }
    public string message { get; set; }
    public DateTime expire { get; set; }

}
