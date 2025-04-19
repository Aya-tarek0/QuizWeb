
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
=======
            builder.Services.AddScoped<IExamResultRepository, ExamResultRepository>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IOptionRepository, OptionRepository>();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                });

<<<<<<< HEAD
=======
=======
<<<<<<< Updated upstream
=======
>>>>>>> c69ea66bcdfe1a7d6f80024ce1eb28ded3ad042e

            builder.Services.AddScoped<IExamResultRepository, ExamResultRepository>();
            builder.Services.AddScoped<IUserAnswerRepository, UserAnswerRepository>();

            builder.Services.AddControllers();
            
>>>>>>> 859348639a517e7673eddb39ffc25c04c7b5071e
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
