using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GCCommerce.Entities
{
    public partial class GCCommerceContext : DbContext
    {
        public virtual DbSet<Admission> Admission { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<FeeStructure> FeeStructure { get; set; }
        public virtual DbSet<Gallery> Gallery { get; set; }
        public virtual DbSet<MeritList> MeritList { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Program> Program { get; set; }
        public virtual DbSet<Seats> Seats { get; set; }
        public virtual DbSet<Shift> Shift { get; set; }
        public virtual DbSet<Teacher> Teacher { get; set; }

        public GCCommerceContext(DbContextOptions<GCCommerceContext> abc):base(abc)
        {

        }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=DESKTOP-R51537J\AWAIS;Database=GCCommerce;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admission>(entity =>
            {
                entity.Property(e => e.AdmissionId).HasColumnName("ADMISSION_ID");

                entity.Property(e => e.AdmissionDocument)
                    .IsRequired()
                    .HasColumnName("ADMISSION_DOCUMENT")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.AdmissionEligibilityCriteria)
                    .IsRequired()
                    .HasColumnName("ADMISSION_ELIGIBILITY_CRITERIA")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("DATE_UPDATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkProgramId).HasColumnName("FK_PROGRAM_ID");

                entity.HasOne(d => d.FkProgram)
                    .WithMany(p => p.Admission)
                    .HasForeignKey(d => d.FkProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Admission_Program");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventId).HasColumnName("EVENT_ID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("DATE_UPDATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventDate)
                    .HasColumnName("EVENT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventDescription)
                    .IsRequired()
                    .HasColumnName("EVENT_DESCRIPTION")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EventName)
                    .IsRequired()
                    .HasColumnName("EVENT_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FeeStructure>(entity =>
            {
                entity.ToTable("Fee_Structure");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("DATE_UPDATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkProgramId).HasColumnName("FK_PROGRAM_ID");

                entity.Property(e => e.Shift)
                    .IsRequired()
                    .HasColumnName("SHIFT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Year1).HasColumnName("YEAR_1");

                entity.Property(e => e.Year2).HasColumnName("YEAR_2");

                entity.HasOne(d => d.FkProgram)
                    .WithMany(p => p.FeeStructure)
                    .HasForeignKey(d => d.FkProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fee_Structure_Program");
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.Property(e => e.GalleryId).HasColumnName("GALLERY_ID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("DATE_UPDATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.GalleryImageDescription)
                    .IsRequired()
                    .HasColumnName("GALLERY_IMAGE_DESCRIPTION")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.GalleryImageName)
                    .IsRequired()
                    .HasColumnName("GALLERY_IMAGE_NAME")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MeritList>(entity =>
            {
                entity.ToTable("Merit_List");

                entity.Property(e => e.MeritListId).HasColumnName("MERIT_LIST_ID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("DATE_UPDATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkProgramId).HasColumnName("FK_PROGRAM_ID");

                entity.Property(e => e.MeritListValue)
                    .IsRequired()
                    .HasColumnName("MERIT_LIST_VALUE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Shift)
                    .IsRequired()
                    .HasColumnName("SHIFT")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkProgram)
                    .WithMany(p => p.MeritList)
                    .HasForeignKey(d => d.FkProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Merit_List_Program");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId).HasColumnName("NEWS_ID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("DATE_UPDATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewsValue)
                    .IsRequired()
                    .HasColumnName("NEWS_VALUE")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Program>(entity =>
            {
                entity.Property(e => e.ProgramId).HasColumnName("PROGRAM_ID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("DATE_UPDATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkShiftId).HasColumnName("FK_SHIFT_ID");

                entity.Property(e => e.ProgramTitle)
                    .IsRequired()
                    .HasColumnName("PROGRAM_TITLE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkShift)
                    .WithMany(p => p.Program)
                    .HasForeignKey(d => d.FkShiftId)
                    .HasConstraintName("FK_Program_Shift");
            });

            modelBuilder.Entity<Seats>(entity =>
            {
                entity.HasKey(e => e.SeatId);

                entity.Property(e => e.SeatId).HasColumnName("SEAT_ID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("DATE_UPDATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.FkProgramId).HasColumnName("FK_PROGRAM_ID");

                entity.Property(e => e.SeatsAvailable).HasColumnName("SEATS_AVAILABLE");

                entity.Property(e => e.SeatsReserve).HasColumnName("SEATS_RESERVE");

                entity.Property(e => e.SeatsTotal).HasColumnName("SEATS_TOTAL");

                entity.HasOne(d => d.FkProgram)
                    .WithMany(p => p.Seats)
                    .HasForeignKey(d => d.FkProgramId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Seats_Program");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.Property(e => e.ShiftId).HasColumnName("SHIFT_ID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("DATE_UPDATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Shift1)
                    .IsRequired()
                    .HasColumnName("SHIFT")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId).HasColumnName("TEACHER_ID");

                entity.Property(e => e.DateCreated)
                    .HasColumnName("DATE_CREATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateUpdated)
                    .HasColumnName("DATE_UPDATED")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("FIRST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Grade)
                    .IsRequired()
                    .HasColumnName("GRADE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HiredDate)
                    .HasColumnName("HIRED_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.Image)
                    .HasColumnName("IMAGE")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("LAST_NAME")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qualification)
                    .IsRequired()
                    .HasColumnName("QUALIFICATION")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RetirementDate)
                    .HasColumnName("RETIREMENT_DATE")
                    .HasColumnType("datetime");

                entity.Property(e => e.TransferDate)
                    .HasColumnName("TRANSFER_DATE")
                    .HasColumnType("datetime");
            });
        }
    }
}
