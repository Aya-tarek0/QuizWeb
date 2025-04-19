
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
<<<<<<< HEAD

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

=======
<<<<<<< Updated upstream
=======

            builder.Services.AddScoped<IExamResultRepository, ExamResultRepository>();
            builder.Services.AddScoped<IUserAnswerRepository, UserAnswerRepository>();


>>>>>>> Stashed changes
>>>>>>> Fahmy
            builder.Services.AddControllers();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
