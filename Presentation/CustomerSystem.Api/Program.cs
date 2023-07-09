using CustomerSystem.Infrastructure.Filters;
using CustomerSystem.Infrastructure.InfrastructureRegistirations;
using CustomerSystm.Domain.Validators.Customer;
using FluentValidation.AspNetCore;
using Serilog;
using Serilog.Sinks.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CustomPolicy",
                      policy =>
                      {
                          policy.WithOrigins("http://127.0.0.1:3000");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});

// Add services to the container.

builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(config=>config.RegisterValidatorsFromAssemblyContaining<CreateCustomerValidator>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//db added
builder.Services.AddDatabase(builder.Configuration);
//add repositorys
builder.Services.AddRepositorys();
//add service
builder.Services.AddServices();
//AutoMapper added
builder.Services.AddMapper();
//seri log added
Serilog.Core.Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    //.WriteTo.File("logs/log.txt")//folder structure must be created in the server...
    .WriteTo.PostgreSQL(builder.Configuration.GetConnectionString("DefaultConnection"),"Logs",
    needAutoCreateTable:true,
    columnOptions:new Dictionary<string, ColumnWriterBase>
    {
        {"message",new RenderedMessageColumnWriter()},
        {"message_teplate",new MessageTemplateColumnWriter()},
        {"level",new LevelColumnWriter()},
        {"time_stamp",new TimestampColumnWriter() },
        {"excetion",new ExceptionColumnWriter()},
        {"log_event",new LogEventSerializedColumnWriter()},

    })
    .CreateLogger();
builder.Host.UseSerilog(log);
//serilog and
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CustomPolicy");

app.MapControllers();

app.Run();

