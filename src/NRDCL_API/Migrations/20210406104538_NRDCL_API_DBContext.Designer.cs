﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NRDCL_API.Data;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NRDCL_API.Migrations
{
    [DbContext(typeof(NRDCL_API_DB_Context))]
    [Migration("20210406104538_NRDCL_API_DBContext")]
    partial class NRDCL_API_DBContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("NRDCL.Models.Cus.Customer", b =>
                {
                    b.Property<string>("CitizenshipID")
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EmailId")
                        .HasColumnType("text");

                    b.Property<string>("TelephoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("CitizenshipID");

                    b.ToTable("Customer_Table");
                });
#pragma warning restore 612, 618
        }
    }
}