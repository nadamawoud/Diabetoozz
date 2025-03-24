using Diabetes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Diabetes.Repository.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<MedicalSyndicate> MedicalSyndicates { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Clerk> Clerks { get; set; }
        public DbSet<CasualUser> CasualUsers { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<NewsFeedPost> NewsFeedPosts { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<SuspectDiabetesResult> SuspectDiabetesResults { get; set; }
        public DbSet<Symptoms> Symptoms { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<BloodSugarMeasurement> BloodSugarMeasurements { get; set; }
        public DbSet<ChatbotQuestionDoctor> ChatbotQuestionDoctors { get; set; }
        public DbSet<ChatbotQuestionCasualUser> ChatbotQuestionCasualUsers { get; set; }
        public DbSet<SuggestionFood> SuggestionFoods { get; set; }

    }
}





