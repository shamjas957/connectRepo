using Azure.Identity;
using ConnectApi.Core.Handlers.WeatherForecast;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAppConfigurationKeyVault();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "swaggerAADdemo", Version = "v1" });
    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "OAuth2.0 Auth Code with PKCE",
        Name = "oauth2",
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri($"https://login.microsoftonline.com/{builder.Configuration["AzureAd:TenantId"]}/oauth2/v2.0/authorize"),
                TokenUrl = new Uri($"https://login.microsoftonline.com/{builder.Configuration["AzureAd:TenantId"]}/oauth2/v2.0/token"),
                Scopes = new Dictionary<string, string>
                {
                    //scope that the web api exposes--  description that will appear on the swagger window
                    // replace the client id
                    { $"api://{builder.Configuration["AzureAD:ClientId"]}/swagger", "read the api" }
                }
            }
        }
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
            },
             //scope that the web api exposes
            new[] { $"api://{builder.Configuration["AzureAD:ClientId"]}/swagger" }
        }
    });
});
//builder.Services.Configure<JwtBearerOptions>(JwtBearerDefaults.AuthenticationScheme, options =>
//{
//    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//    {
//        ValidateIssuer = false,
//        ValidateAudience = false,
//    };     // for debugging auth events
//    options.Events = new JwtBearerEvents
//    {
//        OnMessageReceived = (c) => {
//            return Task.CompletedTask;
//        },
//        OnChallenge = (c) => {
//            return Task.CompletedTask;
//        },
//        OnForbidden = (context) => {
//            return Task.CompletedTask;
//        },
//        OnAuthenticationFailed = (context) =>
//        {
//            return Task.CompletedTask;
//        }
//    };
//    options.Audience = "74360d9c-c5e1-49bd-abc0-b95900d000aa";
//    options.Authority = "https://login.microsoftonline.com/";
//});
builder.Services.RegisterHelper();

// Add services to the container.
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddControllers(op=>
{
    op.Filters.Add(new AuthorizeFilter());
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<WeatherForecastCommandHandler>());
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();



var app = builder.Build();

app.UseExceptionHandling();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "swaggerAADdemo v1");
        c.OAuthClientId(builder.Configuration["Swagger:ClientId"]);
        c.OAuthRealm(builder.Configuration["AzureAD:ClientId"]);
        c.OAuthUsePkce();
        c.OAuthScopeSeparator(" ");
    });

}



//if (builder.Environment.IsProduction())
//{
//    builder.Configuration.AddAzureKeyVault(
//        new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/"),
//        new DefaultAzureCredential());
//}


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
