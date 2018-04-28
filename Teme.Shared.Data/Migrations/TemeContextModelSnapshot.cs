﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Teme.Shared.Data.Context;
using Teme.Shared.Data.Primitives.Contract;

namespace Teme.Shared.Data.Migrations
{
    [DbContext(typeof(TemeContext))]
    partial class TemeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("UserType");

                    b.HasKey("Id");

                    b.ToTable("AuthUsers");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.AuthUserScopes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthUserId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Scope");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AuthUserId");

                    b.ToTable("AuthUserScopes");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ChoosePayer");

                    b.Property<int>("ContractForm");

                    b.Property<string>("ContractScope");

                    b.Property<int>("ContractType");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<int?>("DeclarantDetailId");

                    b.Property<int?>("DeclarantId");

                    b.Property<bool>("DeclarantIsManufacture");

                    b.Property<int>("HolderType");

                    b.Property<int?>("ManufacturDetailId");

                    b.Property<int?>("ManufacturId");

                    b.Property<string>("MedicalDeviceNameKz")
                        .HasMaxLength(255);

                    b.Property<string>("MedicalDeviceNameRu")
                        .HasMaxLength(255);

                    b.Property<string>("Number")
                        .HasMaxLength(255);

                    b.Property<int?>("PayerDetailId");

                    b.Property<int?>("PayerId");

                    b.Property<string>("WorkflowId")
                        .HasMaxLength(50);

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("DeclarantDetailId");

                    b.HasIndex("DeclarantId");

                    b.HasIndex("ManufacturDetailId");

                    b.HasIndex("ManufacturId");

                    b.HasIndex("PayerDetailId");

                    b.HasIndex("PayerId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.CostWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContractId");

                    b.Property<int?>("Count");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool>("IsImport");

                    b.Property<int?>("PriceListId");

                    b.Property<decimal?>("PriceWithValueAddedTax");

                    b.Property<decimal?>("TotalPriceWithValueAddedTax");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("PriceListId");

                    b.ToTable("CostWorks");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.Declarant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("IdNumber")
                        .HasMaxLength(12);

                    b.Property<bool>("IsConfirmed");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsJuridical");

                    b.Property<bool>("IsResident");

                    b.Property<string>("NameEn");

                    b.Property<string>("NameKz");

                    b.Property<string>("NameRu");

                    b.Property<int?>("OrganizationFormId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("OrganizationFormId");

                    b.ToTable("Declarants");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.DeclarantDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BankBin");

                    b.Property<int?>("BankId");

                    b.Property<string>("BankIik")
                        .HasMaxLength(255);

                    b.Property<string>("BankName")
                        .HasMaxLength(255);

                    b.Property<string>("BankSwift")
                        .HasMaxLength(255);

                    b.Property<string>("BossFirstName")
                        .HasMaxLength(255);

                    b.Property<string>("BossLastName")
                        .HasMaxLength(255);

                    b.Property<string>("BossMiddleName")
                        .HasMaxLength(255);

                    b.Property<string>("BossPositionKz")
                        .HasMaxLength(255);

                    b.Property<string>("BossPositionRu")
                        .HasMaxLength(255);

                    b.Property<int?>("CurrencyId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<DateTime?>("DeclarantDocEndDate");

                    b.Property<string>("DeclarantDocNumber")
                        .HasMaxLength(255);

                    b.Property<DateTime?>("DeclarantDocStartDate");

                    b.Property<int>("DeclarantDocType");

                    b.Property<bool>("DeclarantDocWithoutNumber");

                    b.Property<int>("DeclarantId");

                    b.Property<bool>("DeclarantPerpetualDoc");

                    b.Property<string>("Email")
                        .HasMaxLength(255);

                    b.Property<string>("FactAddress")
                        .HasMaxLength(255);

                    b.Property<string>("LegalAddress")
                        .HasMaxLength(255);

                    b.Property<string>("Phone")
                        .HasMaxLength(20);

                    b.Property<string>("Phone2")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("DeclarantId");

                    b.ToTable("DeclarantDetails");
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

            modelBuilder.Entity("Teme.Shared.Data.Context.References.UserForAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserForActions");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("RoleName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.StatePolicy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContractId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<int>("PermissionScopeId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.ToTable("StatePolicies");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.AuthUserScopes", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.AuthUser")
                        .WithMany("Scopes")
                        .HasForeignKey("AuthUserId");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.Contract", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.DeclarantDetail", "DeclarantDetail")
                        .WithMany("DeclarantDetailContract")
                        .HasForeignKey("DeclarantDetailId");

                    b.HasOne("Teme.Shared.Data.Context.Declarant", "Declarant")
                        .WithMany("DeclarantContract")
                        .HasForeignKey("DeclarantId");

                    b.HasOne("Teme.Shared.Data.Context.DeclarantDetail", "ManufacturDetail")
                        .WithMany("ManufacturDetailContract")
                        .HasForeignKey("ManufacturDetailId");

                    b.HasOne("Teme.Shared.Data.Context.Declarant", "Manufactur")
                        .WithMany("ManufacturContract")
                        .HasForeignKey("ManufacturId");

                    b.HasOne("Teme.Shared.Data.Context.DeclarantDetail", "PayerDetail")
                        .WithMany("PayerDetailContract")
                        .HasForeignKey("PayerDetailId");

                    b.HasOne("Teme.Shared.Data.Context.Declarant", "Payer")
                        .WithMany("PayerContract")
                        .HasForeignKey("PayerId");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.CostWork", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.Contract", "Contract")
                        .WithMany("CostWorks")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Teme.Shared.Data.Context.References.Ref_PriceList", "Ref_PriceList")
                        .WithMany("CostWorks")
                        .HasForeignKey("PriceListId");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.Declarant", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.References.Ref_Country", "Ref_Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Teme.Shared.Data.Context.References.Ref_OrganizationForm", "Ref_OrganizationForm")
                        .WithMany()
                        .HasForeignKey("OrganizationFormId");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.DeclarantDetail", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.References.Ref_Bank", "Ref_Bank")
                        .WithMany("DeclarantDetails")
                        .HasForeignKey("BankId");

                    b.HasOne("Teme.Shared.Data.Context.References.Ref_Currency", "Ref_Currency")
                        .WithMany("DeclarantDetails")
                        .HasForeignKey("CurrencyId");

                    b.HasOne("Teme.Shared.Data.Context.Declarant", "Declarant")
                        .WithMany("DeclarantDetails")
                        .HasForeignKey("DeclarantId")
                        .OnDelete(DeleteBehavior.Cascade);
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
