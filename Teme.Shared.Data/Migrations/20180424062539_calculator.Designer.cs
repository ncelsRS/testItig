﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Teme.Shared.Data.Context;

namespace Teme.Shared.Data.Migrations
{
    [DbContext(typeof(TemeContext))]
    [Migration("20180424062539_calculator")]
    partial class calculator
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Teme.Shared.Data.Context.AuthUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bin");

                    b.Property<string>("CompanyName");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool?>("HasIin");

                    b.Property<string>("Iin")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.Property<string>("Pwdhash")
                        .IsRequired();

                    b.Property<string>("UserType");

                    b.HasKey("Id");

                    b.ToTable("AuthUsers");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_ApplicationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("ContractForm")
                        .HasMaxLength(20);

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NameKz")
                        .IsRequired();

                    b.Property<string>("NameRu")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ref_ApplicationTypes");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsConfirmed");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NameKz")
                        .IsRequired();

                    b.Property<string>("NameRu")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ref_Banks");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_ClassifierMedicalArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NameKz")
                        .IsRequired();

                    b.Property<string>("NameRu")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ref_ClassifierMedicalAreas");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NameKz")
                        .IsRequired();

                    b.Property<string>("NameRu")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ref_Countries");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NameKz")
                        .IsRequired();

                    b.Property<string>("NameRu")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ref_Currencies");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_DegreeRiskClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NameKz")
                        .IsRequired();

                    b.Property<string>("NameRu")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ref_DegreeRiskClasses");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_NomenclatureCodeMedProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("DefenitionNameKz");

                    b.Property<string>("DefenitionNameRu");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NameKz")
                        .IsRequired();

                    b.Property<string>("NameRu")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ref_NomenclatureCodeMedProducts");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_OrganizationForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsConfirmed");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NameKz")
                        .IsRequired();

                    b.Property<string>("NameRu")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ref_OrganizationForms");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_PriceList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsImport");

                    b.Property<decimal>("Price");

                    b.Property<int>("PriceTypeId");

                    b.Property<int>("ServiceTypeId");

                    b.HasKey("Id");

                    b.HasIndex("PriceTypeId");

                    b.HasIndex("ServiceTypeId");

                    b.ToTable("Ref_PriceLists");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_PriceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NameKz")
                        .IsRequired();

                    b.Property<string>("NameRu")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ref_PriceTypes");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_ServiceType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ApplicationTypeId");

                    b.Property<string>("Code");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NameKz")
                        .IsRequired();

                    b.Property<string>("NameRu")
                        .IsRequired();

                    b.Property<int?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationTypeId");

                    b.HasIndex("ParentId");

                    b.ToTable("Ref_ServiceTypes");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_StorageCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("NameKz")
                        .IsRequired();

                    b.Property<string>("NameRu")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Ref_StorageConditions");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_ValueAddedTax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsDeleted");

                    b.Property<decimal>("Value");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Ref_ValueAddedTaxes");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_PriceList", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.References.Ref_PriceType", "Ref_PriceType")
                        .WithMany("Ref_PriceList")
                        .HasForeignKey("PriceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Teme.Shared.Data.Context.References.Ref_ServiceType", "Ref_ServiceType")
                        .WithMany("Ref_PriceList")
                        .HasForeignKey("ServiceTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_ServiceType", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.References.Ref_ApplicationType", "Ref_ApplicationType")
                        .WithMany("Ref_ServiceTypes")
                        .HasForeignKey("ApplicationTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Teme.Shared.Data.Context.References.Ref_ServiceType", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
