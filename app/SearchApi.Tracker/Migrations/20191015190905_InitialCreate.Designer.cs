﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SearchApi.Tracker.Db;

namespace SearchApi.Tracker.Migrations
{
    [DbContext(typeof(StateMachineContext))]
    [Migration("20191015190905_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SearchApi.Tracker.Tracking.Investigation", b =>
                {
                    b.Property<Guid>("CorrelationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CurrentState");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid>("SearchRequestId");

                    b.HasKey("CorrelationId");

                    b.ToTable("Investigations");
                });
#pragma warning restore 612, 618
        }
    }
}
