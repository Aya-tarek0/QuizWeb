<<<<<<< HEAD

=======
>>>>>>> 5688410f72673af4d1142f9c5cc61d76a5e4ef0d
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quiz.Interface;
using Quiz.Models;
using Quiz.Repository;

namespace Quiz
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
              .AddEntityFrameworkStores<QuizContext>();
            builder.Services.AddDbContext<QuizContext>(option => {
                option.UseSqlServer(builder.Configuration.GetConnectionString("db"));
            });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidIssuer= builder.Configuration["JWT:Iss"],
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["JWT:Aud"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });

            builder.Services.AddScoped<IExamResultRepository, ExamResultRepository>();
            builder.Services.AddScoped<IQuestionBankRepository, QuestionBankRepository>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IOptionRepository, OptionRepository>();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

<<<<<<< HEAD


            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
=======
            builder.Services.AddScoped<IExamResultRepository, ExamResultRepository>();
            builder.Services.AddScoped<IUserAnswerRepository, UserAnswerRepository>();

            builder.Services.AddControllers();
         
>>>>>>> 5688410f72673af4d1142f9c5cc61d76a5e4ef0d
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register the repository
            builder.Services.AddScoped<ExamRepository>();
            builder.Services.AddScoped<ExamQuestionsRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

    }
}
