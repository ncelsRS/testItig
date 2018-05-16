﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using Teme.Shared.Data.Context;
using Teme.Shared.Data.Primitives;
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

                    b.Property<int?>("IconRecordId");

                    b.Property<string>("Iin");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("MiddleName");

                    b.Property<string>("Pwdhash");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("UserType");

                    b.HasKey("Id");

                    b.HasIndex("IconRecordId");

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

            modelBuilder.Entity("Teme.Shared.Data.Context.Icon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("FieldName")
                        .HasMaxLength(500);

                    b.Property<int>("ModuleType");

                    b.Property<int>("ObjectId");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.ToTable("Icons");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.IconRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthRoleId");

                    b.Property<int>("AuthUserId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("DisplayField")
                        .HasMaxLength(500);

                    b.Property<int>("IconId");

                    b.Property<string>("Note")
                        .HasMaxLength(2000);

                    b.Property<string>("ValueField")
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("AuthUserId");

                    b.HasIndex("IconId");

                    b.ToTable("IconRecords");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationAreaKz");

                    b.Property<string>("ApplicationAreaRu");

                    b.Property<string>("AppointmentKz");

                    b.Property<string>("AppointmentRu");

                    b.Property<string>("CardNumber");

                    b.Property<string>("ChangesMade");

                    b.Property<string>("ClassRisk");

                    b.Property<int?>("ContractForm");

                    b.Property<int>("ContractId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<bool?>("IsBlank");

                    b.Property<bool?>("IsClosedSystem");

                    b.Property<bool?>("IsDiagnostics");

                    b.Property<bool?>("IsMeasures");

                    b.Property<bool?>("IsPresenceMedicinalProduct");

                    b.Property<bool?>("IsStyryl");

                    b.Property<bool?>("IsTypeImnMt");

                    b.Property<string>("NameKz");

                    b.Property<string>("NameRu");

                    b.Property<string>("NumberModificationImn");

                    b.Property<string>("RationaleManufacturer");

                    b.Property<string>("RevisionBeforeChanges");

                    b.Property<string>("TradeName");

                    b.Property<bool>("isDeleted");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.PaymentEquipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<int>("EquipmentTypeId");

                    b.Property<string>("Manufacturer");

                    b.Property<string>("Model");

                    b.Property<string>("Name");

                    b.Property<int>("PaymentId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("EquipmentTypeId");

                    b.HasIndex("PaymentId");

                    b.ToTable("PaymentEquipments");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.PaymentPackaging", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("Name");

                    b.Property<string>("NumberUnitsInBox");

                    b.Property<int?>("PackagingTypeId");

                    b.Property<int>("PackagingtTypeId");

                    b.Property<int>("PaymentId");

                    b.Property<string>("ShortDescription");

                    b.Property<string>("SizeHeight");

                    b.Property<string>("SizeLength");

                    b.Property<int?>("SizeMeasureId");

                    b.Property<string>("SizeWidth");

                    b.Property<int?>("VolumeMeasureId");

                    b.Property<string>("VolumeValue");

                    b.HasKey("Id");

                    b.HasIndex("PackagingTypeId");

                    b.HasIndex("PaymentId");

                    b.HasIndex("SizeMeasureId");

                    b.HasIndex("VolumeMeasureId");

                    b.ToTable("PaymentPackagings");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.PaymentPlatform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<string>("FactAddress")
                        .HasMaxLength(255);

                    b.Property<string>("LegalAddress")
                        .HasMaxLength(255);

                    b.Property<string>("NameEn");

                    b.Property<string>("NameKz");

                    b.Property<string>("NameRu");

                    b.Property<int>("PaymentId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("PaymentId");

                    b.ToTable("PaymentPlatforms");
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

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_EquipmentType", b =>
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

                    b.ToTable("Ref_EquipmentTypes");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_Measure", b =>
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

                    b.ToTable("Ref_Measures");
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

            modelBuilder.Entity("Teme.Shared.Data.Context.References.Ref_PackagingType", b =>
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

                    b.ToTable("Ref_PackagingTypes");
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

                    b.Property<string>("Permission");

                    b.Property<string>("Scope");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("StatePolicies");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.UserForAction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContractId");

                    b.Property<DateTime>("DateCreate");

                    b.Property<DateTime>("DateUpdate");

                    b.Property<int>("ExecutorId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.ToTable("UserForActions");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.AuthUser", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.IconRecord")
                        .WithMany("AuthUsers")
                        .HasForeignKey("IconRecordId");
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

            modelBuilder.Entity("Teme.Shared.Data.Context.IconRecord", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.AuthUser", "AuthUser")
                        .WithMany()
                        .HasForeignKey("AuthUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Teme.Shared.Data.Context.Icon", "Icon")
                        .WithMany("IconRecords")
                        .HasForeignKey("IconId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.Payment", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.PaymentEquipment", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.References.Ref_Country", "Ref_Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Teme.Shared.Data.Context.References.Ref_EquipmentType", "Ref_EquipmentType")
                        .WithMany()
                        .HasForeignKey("EquipmentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Teme.Shared.Data.Context.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.PaymentPackaging", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.References.Ref_PackagingType", "Ref_PackagingType")
                        .WithMany()
                        .HasForeignKey("PackagingTypeId");

                    b.HasOne("Teme.Shared.Data.Context.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Teme.Shared.Data.Context.References.Ref_Measure", "Ref_SizeMeasure")
                        .WithMany()
                        .HasForeignKey("SizeMeasureId");

                    b.HasOne("Teme.Shared.Data.Context.References.Ref_Measure", "Ref_VolumeMeasure")
                        .WithMany()
                        .HasForeignKey("VolumeMeasureId");
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.PaymentPlatform", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.References.Ref_Country", "Ref_Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.HasOne("Teme.Shared.Data.Context.Payment", "Payment")
                        .WithMany()
                        .HasForeignKey("PaymentId")
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

            modelBuilder.Entity("Teme.Shared.Data.Context.StatePolicy", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.Contract", "Contract")
                        .WithMany("StatePolicies")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Teme.Shared.Data.Context.UserForAction", b =>
                {
                    b.HasOne("Teme.Shared.Data.Context.Contract", "Contract")
                        .WithMany("UserForActions")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
