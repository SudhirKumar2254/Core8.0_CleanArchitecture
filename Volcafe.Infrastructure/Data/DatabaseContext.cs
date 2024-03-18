﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volcafe.Core.Entities;

namespace Volcafe.Infrastructure.Data;

public partial class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AgentCategoryDocument> AgentCategoryDocuments { get; set; }

    public virtual DbSet<AgentCategoryType> AgentCategoryTypes { get; set; }

    public virtual DbSet<ContractDetail> ContractDetails { get; set; }

    public virtual DbSet<ContractDetailsDailyLoad> ContractDetailsDailyLoads { get; set; }

    public virtual DbSet<ContractDocument> ContractDocuments { get; set; }

    public virtual DbSet<ContractReviewDetail> ContractReviewDetails { get; set; }

    public virtual DbSet<ContractStatus> ContractStatuses { get; set; }

    public virtual DbSet<ContractStatusHistory> ContractStatusHistories { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

    public virtual DbSet<Entity> Entities { get; set; }

    public virtual DbSet<FarmDetail> FarmDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<WorkflowStatusMapping> WorkflowStatusMappings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AgentCategoryDocument>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__AgentCat__1ABEEF0FED7DE63B");

            entity.HasOne(d => d.AgentCategoryType).WithMany(p => p.AgentCategoryDocuments)
                .HasForeignKey(d => d.AgentCategoryTypeId)
                .HasConstraintName("FK__AgentCate__Agent__5C37ACAD");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.AgentCategoryDocuments)
                .HasForeignKey(d => d.DocumentTypeId)
                .HasConstraintName("FK__AgentCate__Docum__5D2BD0E6");
        });

        modelBuilder.Entity<AgentCategoryType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AgentCat__3214EC0711A77942");

            entity.ToTable("AgentCategoryType");

            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<ContractDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contract__3214EC07702EAF89");

            entity.Property(e => e.AgentId)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ContractId)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.ContractSummary).HasMaxLength(1000);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EntityCode)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.Quantity).HasDefaultValue(0);
            entity.Property(e => e.Reviewer).HasMaxLength(255);

            entity.HasOne(d => d.Agent).WithMany(p => p.ContractDetails)
                .HasPrincipalKey(p => p.AgentId)
                .HasForeignKey(d => d.AgentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContractD__Agent__689D8392");

            entity.HasOne(d => d.EntityCodeNavigation).WithMany(p => p.ContractDetails)
                .HasForeignKey(d => d.EntityCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContractD__Entit__6A85CC04");

            entity.HasOne(d => d.Status).WithMany(p => p.ContractDetails)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContractD__Statu__6B79F03D");
        });

        modelBuilder.Entity<ContractDetailsDailyLoad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contract__3214EC07E1517025");

            entity.ToTable("ContractDetailsDailyLoad");

            entity.Property(e => e.AgentId)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ContractId).HasMaxLength(20);
            entity.Property(e => e.ContractSummary).HasMaxLength(1000);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EntityCode).HasMaxLength(10);
            entity.Property(e => e.UpstreamSystem).HasMaxLength(20);
        });

        modelBuilder.Entity<ContractDocument>(entity =>
        {
            entity.HasKey(e => e.ContractDocId).HasName("PK__Contract__B8DAC4F3D96ADDD6");

            entity.Property(e => e.DocName).HasMaxLength(500);
            entity.Property(e => e.DocPath).HasMaxLength(500);

            entity.HasOne(d => d.Contract).WithMany(p => p.ContractDocuments)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK__ContractD__Contr__7F80E8EA");

            entity.HasOne(d => d.Document).WithMany(p => p.ContractDocuments)
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("FK__ContractD__Docum__00750D23");
        });

        modelBuilder.Entity<ContractReviewDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contract__3214EC0727C057EA");

            entity.Property(e => e.ReviewRemarks).HasMaxLength(500);
            entity.Property(e => e.ReviewStatus)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ReviewedBy)
                .IsRequired()
                .HasMaxLength(200);
            entity.Property(e => e.ReviewedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Contract).WithMany(p => p.ContractReviewDetails)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContractR__Contr__731B1205");
        });

        modelBuilder.Entity<ContractStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Contract__C8EE20636743581D");

            entity.ToTable("ContractStatus");

            entity.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<ContractStatusHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contract__3214EC072677FFDC");

            entity.ToTable("ContractStatusHistory");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Contract).WithMany(p => p.ContractStatusHistories)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContractS__Contr__76EBA2E9");

            entity.HasOne(d => d.Status).WithMany(p => p.ContractStatusHistories)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContractS__Statu__78D3EB5B");

            entity.HasOne(d => d.WorkflowStatusMapping).WithMany(p => p.ContractStatusHistories)
                .HasForeignKey(d => d.WorkflowStatusMappingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ContractS__Workf__77DFC722");
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC07B5F45EF4");

            entity.ToTable("DocumentType");

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<EmailTemplate>(entity =>
        {
            entity.HasKey(e => e.TemplateCode).HasName("PK__EmailTem__0FDB5080520D2E7F");

            entity.ToTable("EmailTemplate");

            entity.Property(e => e.TemplateCode).HasMaxLength(20);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TemplateDetails).HasMaxLength(500);
            entity.Property(e => e.TemplateName)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Entity>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Entity__A25C5AA61358D1AD");

            entity.ToTable("Entity");

            entity.Property(e => e.Code).HasMaxLength(10);
            entity.Property(e => e.LegalName).HasMaxLength(100);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<FarmDetail>(entity =>
        {
            entity.HasKey(e => e.FarmId).HasName("PK__FarmDeta__ED7BBAB92E8731D0");

            entity.Property(e => e.FarmName).HasMaxLength(500);
            entity.Property(e => e.FarmPolygon).HasMaxLength(500);
            entity.Property(e => e.GeoLocationCoordinates).HasMaxLength(500);

            entity.HasOne(d => d.Contract).WithMany(p => p.FarmDetails)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FarmDetai__Contr__7CA47C3F");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CFDCCBD6A");

            entity.HasIndex(e => e.AgentId, "UQ__Users__9AC3BFF01C37CDDF").IsUnique();

            entity.Property(e => e.Active).HasDefaultValue(true);
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.AgentId)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ModifiedDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Reviewer)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.AgentCategoryType).WithMany(p => p.Users)
                .HasForeignKey(d => d.AgentCategoryTypeId)
                .HasConstraintName("FK__Users__AgentCate__62E4AA3C");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .HasConstraintName("FK__Users__UserRoleI__61F08603");

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName("FK__Users__UserTypeI__60FC61CA");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC072F23AEEF");

            entity.ToTable("UserRole");

            entity.Property(e => e.Role)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.UserType).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName("FK__UserRole__UserTy__54968AE5");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserType__3214EC072EE7E6C0");

            entity.ToTable("UserType");

            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<WorkflowStatusMapping>(entity =>
        {
            entity.HasKey(e => e.MappingId).HasName("PK__Workflow__8B57819D5DBC957E");

            entity.ToTable("WorkflowStatusMapping");

            entity.HasOne(d => d.Status).WithMany(p => p.WorkflowStatusMappings)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__WorkflowS__Statu__595B4002");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}