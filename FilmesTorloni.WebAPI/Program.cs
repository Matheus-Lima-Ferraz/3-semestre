using FilmesTorloni.WebAPI.BdContextFilme;
using FilmesTorloni.WebAPI.Interfaces;
using FilmesTorloni.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
using Microsoft.OpenApi;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados (exemplo com SQL Server)
builder.Services.AddDbContext<FilmeContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiona o repositório ao container de injeção de dependência 
builder.Services.AddScoped<IGeneroRepository, GeneroRepository>();
builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//Adiciona serviço de jwt Bearer (forma de autenticação)
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})

.AddJwtBearer("JwtBearer", options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         //valida quem está solicitando
         ValidateIssuer = true,

         //valida quem está recebendo
         ValidateAudience = true,

         //define se o tempo de expiração será validado
         ValidateLifetime = true,

         //forma de criptografia e valida a chave de autenticação 
         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

         //valida o tempo de expiração do token
         ClockSkew = TimeSpan.FromMinutes(5),

         //nome do issuer (de onde está vindo)
         ValidIssuer = "api_filmes",

         //nome do audience (para onde ele está indo)
         ValidAudience = "api_filmes"
        };
 });

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("V1", new OpenApiInfo
        {
            Version = "V1",
            Title = "Filmes API",
            Description = "Uma API com catálogo de filmes",
            TermsOfService = new Uri("https://example.com/terms"),
            Contact = new OpenApiContact
            {
                Name = "Matheus-Lima-Ferraz",
                Url = new Uri("https://github.com/Matheus-Lima-Ferraz")
            },
            License = new OpenApiLicense
            {
                Name = "Example License",
                Url = new Uri("https://example.com/lincese")
            }
        });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT"
    });

    options.AddSecurityRequirement(Document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", Document)] = Array.Empty<string>().ToList()
    });

});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Adiciona o serviço de Controllers
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options => { });

    app.UseSwaggerUI(options => 
    {
        options.SwaggerEndpoint("/Swagger/V1/Swagger.json", "V1");

        options.RoutePrefix = String.Empty;
    });
}

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();


// Adiciona o mapeamento de Controllers
app.MapControllers();

app.Run();
