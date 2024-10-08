﻿// <auto-generated />
using System;
using Infrastructure.Persistence.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(PfpTransactionsApiDatabaseContext))]
    [Migration("20240807221631_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Persistence.EntityFramework.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_date");

                    b.Property<Guid>("FundId")
                        .HasColumnType("uuid")
                        .HasColumnName("fund_id");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<Guid?>("LimitId")
                        .HasColumnType("uuid")
                        .HasColumnName("limit_id");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("categories_pkey");

                    b.HasIndex("FundId");

                    b.HasIndex("LimitId");

                    b.HasIndex(new[] { "Name" }, "categories_name_key")
                        .IsUnique();

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Persistence.EntityFramework.Models.Fund", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<int?>("InternalId")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("internal_id");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("numeric")
                        .HasColumnName("total_amount");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("funds_pkey");

                    b.HasIndex(new[] { "InternalId" }, "funds_internal_id_key")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "funds_name_key")
                        .IsUnique();

                    b.ToTable("funds", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Persistence.EntityFramework.Models.Limit", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_date");

                    b.Property<int?>("InternalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("internal_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("InternalId"));

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("limits_pkey");

                    b.HasIndex(new[] { "InternalId" }, "limits_internal_id_key")
                        .IsUnique();

                    b.ToTable("limits", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Persistence.EntityFramework.Models.Recurrence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_date");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer")
                        .HasColumnName("recurrence_type_id");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("recurrences_pkey");

                    b.HasIndex("TypeId");

                    b.ToTable("recurrences", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Persistence.EntityFramework.Models.RecurrenceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("recurrence_types_pkey");

                    b.ToTable("recurrence_types", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Persistence.EntityFramework.Models.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("deleted_date");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("description");

                    b.Property<int>("InternalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("internal_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InternalId"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsSplit")
                        .HasColumnType("boolean")
                        .HasColumnName("is_split");

                    b.Property<int?>("RecurrenceId")
                        .HasColumnType("integer")
                        .HasColumnName("recurrence_id");

                    b.Property<int?>("TransactionNotSplitInternalId")
                        .HasColumnType("int")
                        .HasColumnName("transaction_not_split_internal_id");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_date");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("transactions_pkey");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RecurrenceId");

                    b.HasIndex("TransactionNotSplitInternalId");

                    b.HasIndex(new[] { "InternalId" }, "transactions_internal_id_key")
                        .IsUnique();

                    b.ToTable("transactions", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Persistence.EntityFramework.Models.Category", b =>
                {
                    b.HasOne("Infrastructure.Persistence.EntityFramework.Models.Fund", null)
                        .WithMany("Categories")
                        .HasForeignKey("FundId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Persistence.EntityFramework.Models.Limit", "Limit")
                        .WithMany()
                        .HasForeignKey("LimitId")
                        .HasConstraintName("fk__categories__limit_id__limits__limit_id");

                    b.Navigation("Limit");
                });

            modelBuilder.Entity("Infrastructure.Persistence.EntityFramework.Models.Recurrence", b =>
                {
                    b.HasOne("Infrastructure.Persistence.EntityFramework.Models.RecurrenceType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Infrastructure.Persistence.EntityFramework.Models.Transaction", b =>
                {
                    b.HasOne("Infrastructure.Persistence.EntityFramework.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Persistence.EntityFramework.Models.Recurrence", "Recurrence")
                        .WithMany()
                        .HasForeignKey("RecurrenceId");

                    b.HasOne("Infrastructure.Persistence.EntityFramework.Models.Transaction", null)
                        .WithMany("SplitTransactions")
                        .HasForeignKey("TransactionNotSplitInternalId")
                        .HasPrincipalKey("InternalId");

                    b.Navigation("Category");

                    b.Navigation("Recurrence");
                });

            modelBuilder.Entity("Infrastructure.Persistence.EntityFramework.Models.Fund", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("Infrastructure.Persistence.EntityFramework.Models.Transaction", b =>
                {
                    b.Navigation("SplitTransactions");
                });
#pragma warning restore 612, 618
        }
    }
}
