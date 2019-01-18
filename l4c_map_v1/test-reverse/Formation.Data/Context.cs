namespace Formation.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<applicant> applicants { get; set; }
        public virtual DbSet<arrival> arrivals { get; set; }
        public virtual DbSet<client> clients { get; set; }
        public virtual DbSet<demand> demands { get; set; }
        public virtual DbSet<demand_time_off> demand_time_off { get; set; }
        public virtual DbSet<document> documents { get; set; }
        public virtual DbSet<employement_letter> employement_letter { get; set; }
        public virtual DbSet<file> files { get; set; }
        public virtual DbSet<historical_mandate> historical_mandate { get; set; }
        public virtual DbSet<mandate> mandates { get; set; }
        public virtual DbSet<meeting> meetings { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<organizational_chart> organizational_chart { get; set; }
        public virtual DbSet<profitability> profitabilities { get; set; }
        public virtual DbSet<project> projects { get; set; }
        public virtual DbSet<request> requests { get; set; }
        public virtual DbSet<required_skills> required_skills { get; set; }
        public virtual DbSet<responsable> responsables { get; set; }
        public virtual DbSet<ressource> ressources { get; set; }
        public virtual DbSet<skill> skills { get; set; }
        public virtual DbSet<sponsor> sponsors { get; set; }
        public virtual DbSet<test> tests { get; set; }
        public virtual DbSet<time_off> time_off { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<applicant>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<applicant>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<applicant>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<applicant>()
                .Property(e => e.applicantState)
                .IsUnicode(false);

            modelBuilder.Entity<applicant>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<applicant>()
                .HasMany(e => e.sponsors)
                .WithRequired(e => e.applicant)
                .HasForeignKey(e => e.idApplicant)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<client>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.logo)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.typeCategory)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .Property(e => e.typeClient)
                .IsUnicode(false);

            modelBuilder.Entity<client>()
                .HasMany(e => e.requests)
                .WithOptional(e => e.client)
                .HasForeignKey(e => e.idClient);

            modelBuilder.Entity<demand>()
                .Property(e => e.demandState)
                .IsUnicode(false);

            modelBuilder.Entity<demand>()
                .Property(e => e.specialty)
                .IsUnicode(false);

            modelBuilder.Entity<demand>()
                .HasMany(e => e.meetings)
                .WithRequired(e => e.demand)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<demand_time_off>()
                .Property(e => e.stateDemandTimeOff)
                .IsUnicode(false);

            modelBuilder.Entity<demand_time_off>()
                .HasMany(e => e.time_off)
                .WithRequired(e => e.demand_time_off)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<document>()
                .Property(e => e.documentType)
                .IsUnicode(false);

            modelBuilder.Entity<document>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<document>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<employement_letter>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<employement_letter>()
                .HasMany(e => e.files)
                .WithOptional(e => e.employement_letter)
                .HasForeignKey(e => e.idEmployementLetter);

            modelBuilder.Entity<file>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<file>()
                .HasMany(e => e.demands)
                .WithOptional(e => e.file)
                .HasForeignKey(e => e.idFile);

            modelBuilder.Entity<file>()
                .HasMany(e => e.documents)
                .WithOptional(e => e.file)
                .HasForeignKey(e => e.idFile);

            modelBuilder.Entity<historical_mandate>()
                .HasMany(e => e.mandates)
                .WithMany(e => e.historical_mandate)
                .Map(m => m.ToTable("historical_mandate_mandate").MapLeftKey("Historical_mandate_idHistoricalMandate").MapRightKey(new[] { "listeMandate_idProject", "listeMandate_idRessource" }));

            modelBuilder.Entity<mandate>()
                .Property(e => e.mandateType)
                .IsUnicode(false);

            modelBuilder.Entity<meeting>()
                .Property(e => e.typeResult)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.fromTo)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.messageType)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.adresse)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.mandates)
                .WithRequired(e => e.project)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<project>()
                .HasMany(e => e.messages)
                .WithOptional(e => e.project)
                .HasForeignKey(e => e.id_project);

            modelBuilder.Entity<required_skills>()
                .Property(e => e.education)
                .IsUnicode(false);

            modelBuilder.Entity<responsable>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<responsable>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<responsable>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<responsable>()
                .Property(e => e.speciality)
                .IsUnicode(false);

            modelBuilder.Entity<responsable>()
                .HasMany(e => e.arrivals)
                .WithOptional(e => e.responsable)
                .HasForeignKey(e => e.responsable_id);

            modelBuilder.Entity<responsable>()
                .HasMany(e => e.employement_letter)
                .WithOptional(e => e.responsable)
                .HasForeignKey(e => e.idResponsable);

            modelBuilder.Entity<responsable>()
                .HasMany(e => e.meetings)
                .WithRequired(e => e.responsable)
                .HasForeignKey(e => e.idResponsable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<responsable>()
                .HasMany(e => e.requests)
                .WithOptional(e => e.responsable)
                .HasForeignKey(e => e.idResponsable);

            modelBuilder.Entity<responsable>()
                .HasMany(e => e.time_off)
                .WithRequired(e => e.responsable)
                .HasForeignKey(e => e.idResponsable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<responsable>()
                .HasMany(e => e.sponsors)
                .WithRequired(e => e.responsable)
                .HasForeignKey(e => e.idResponsable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<responsable>()
                .HasMany(e => e.tests)
                .WithOptional(e => e.responsable)
                .HasForeignKey(e => e.idResponsable);

            modelBuilder.Entity<ressource>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.picture)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.businessSector)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.cv)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.specialty)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .Property(e => e.typeContrat)
                .IsUnicode(false);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e.mandates)
                .WithRequired(e => e.ressource)
                .HasForeignKey(e => e.idRessource)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e.skills)
                .WithOptional(e => e.ressource)
                .HasForeignKey(e => e.idRessource);

            modelBuilder.Entity<ressource>()
                .HasMany(e => e.sponsors)
                .WithOptional(e => e.ressource)
                .HasForeignKey(e => e.ressource_id);

            modelBuilder.Entity<skill>()
                .Property(e => e.degree)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.document)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.specialty)
                .IsUnicode(false);

            modelBuilder.Entity<sponsor>()
                .Property(e => e.country)
                .IsUnicode(false);

            modelBuilder.Entity<sponsor>()
                .Property(e => e.language)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .Property(e => e.specialty)
                .IsUnicode(false);

            modelBuilder.Entity<test>()
                .HasMany(e => e.files)
                .WithMany(e => e.tests)
                .Map(m => m.ToTable("file_test").MapLeftKey("listeTest_idTest").MapRightKey("File_id"));

            modelBuilder.Entity<user>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.picture)
                .IsUnicode(false);
        }
    }
}
