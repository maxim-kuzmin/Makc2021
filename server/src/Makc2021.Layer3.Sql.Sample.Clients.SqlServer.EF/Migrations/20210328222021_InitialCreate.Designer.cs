﻿// <auto-generated />
using System;
using Makc2021.Layer3.Sql.Sample.Clients.SqlServer.EF.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Makc2021.Layer3.Sql.Sample.Clients.SqlServer.EF.Migrations
{
    [DbContext(typeof(ClientDbContext))]
    [Migration("20210328222021_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain.DummyMainEntityMapperObject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Name");

                    b.Property<long>("ObjectDummyOneToManyId")
                        .HasColumnType("bigint")
                        .HasColumnName("DummyOneToManyId");

                    b.Property<bool>("PropBoolean")
                        .HasColumnType("bit");

                    b.Property<bool?>("PropBooleanNullable")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PropDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("PropDateNullable")
                        .HasColumnType("datetime2");

                    b.Property<DateTimeOffset>("PropDateTimeOffset")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("PropDateTimeOffsetNullable")
                        .HasColumnType("datetimeoffset");

                    b.Property<decimal>("PropDecimal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("PropDecimalNullable")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PropInt32")
                        .HasColumnType("int");

                    b.Property<int?>("PropInt32Nullable")
                        .HasColumnType("int");

                    b.Property<long>("PropInt64")
                        .HasColumnType("bigint");

                    b.Property<long?>("PropInt64Nullable")
                        .HasColumnType("bigint");

                    b.Property<string>("PropString")
                        .IsRequired()
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PropStringNullable")
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_DummyMain");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("UX_DummyMain_Name");

                    b.HasIndex("ObjectDummyOneToManyId")
                        .HasDatabaseName("IX_DummyMain_DummyOneToManyId");

                    b.ToTable("DummyMain", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany.DummyMainDummyManyToManyEntityMapperObject", b =>
                {
                    b.Property<long>("ObjectDummyMainId")
                        .HasColumnType("bigint")
                        .HasColumnName("DummyMainId");

                    b.Property<long>("ObjectDummyManyToManyId")
                        .HasColumnType("bigint")
                        .HasColumnName("DummyManyToManyId");

                    b.HasKey("ObjectDummyMainId", "ObjectDummyManyToManyId")
                        .HasName("PK_DummyMainDummyManyToMany");

                    b.HasIndex("ObjectDummyManyToManyId")
                        .HasDatabaseName("IX_DummyMainDummyManyToMany_DummyManyToManyId");

                    b.ToTable("DummyMainDummyManyToMany", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyManyToMany.DummyManyToManyEntityMapperObject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("PK_DummyManyToMany");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("UX_DummyManyToMany_Name");

                    b.ToTable("DummyManyToMany", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyOneToMany.DummyOneToManyEntityMapperObject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Name");

                    b.HasKey("Id")
                        .HasName("PK_DummyOneToMany");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("UX_DummyOneToMany_Name");

                    b.ToTable("DummyOneToMany", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTree.DummyTreeEntityMapperObject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Name");

                    b.Property<long?>("ParentId")
                        .HasColumnType("bigint")
                        .HasColumnName("ParentId");

                    b.Property<long>("TreeChildCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L)
                        .HasColumnName("TreeChildCount");

                    b.Property<long>("TreeDescendantCount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L)
                        .HasColumnName("TreeDescendantCount");

                    b.Property<long>("TreeLevel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasDefaultValue(0L)
                        .HasColumnName("TreeLevel");

                    b.Property<string>("TreePath")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(900)
                        .IsUnicode(false)
                        .HasColumnType("varchar(900)")
                        .HasDefaultValue("")
                        .HasColumnName("TreePath");

                    b.Property<int>("TreePosition")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0)
                        .HasColumnName("TreePosition");

                    b.Property<string>("TreeSort")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(900)
                        .IsUnicode(false)
                        .HasColumnType("varchar(900)")
                        .HasDefaultValue("")
                        .HasColumnName("TreeSort");

                    b.HasKey("Id")
                        .HasName("PK_DummyTree");

                    b.HasIndex("Name")
                        .HasDatabaseName("IX_DummyTree_Name");

                    b.HasIndex("ParentId")
                        .HasDatabaseName("IX_DummyTree_ParentId");

                    b.HasIndex("TreeSort")
                        .HasDatabaseName("IX_DummyTree_TreeSort");

                    b.HasIndex("ParentId", "Name")
                        .IsUnique()
                        .HasDatabaseName("UX_DummyTree_ParentId_Name")
                        .HasFilter("[ParentId] IS NOT NULL");

                    b.ToTable("DummyTree", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTreeLink.DummyTreeLinkEntityMapperObject", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint")
                        .HasColumnName("Id");

                    b.Property<long>("ParentId")
                        .HasColumnType("bigint")
                        .HasColumnName("ParentId");

                    b.HasKey("Id", "ParentId")
                        .HasName("PK_DummyTreeLink");

                    b.ToTable("DummyTreeLink", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.Role.RoleEntityMapperObject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("Name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("NormalizedName");

                    b.HasKey("Id")
                        .HasName("PK_Role");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("UX_Role_NormalizedName")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.RoleClaim.RoleClaimEntityMapperObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("RoleId");

                    b.HasKey("Id")
                        .HasName("PK_RoleClaim");

                    b.HasIndex("RoleId")
                        .IsUnique()
                        .HasDatabaseName("UX_RoleClaim_RoleId");

                    b.ToTable("RoleClaim", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.User.UserEntityMapperObject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasMaxLength(256)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("NormalizedEmail");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("NormalizedUserName");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id")
                        .HasName("PK_User");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("IX_User_NormalizedEmail");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UX_User_NormalizedUserName")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("User", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserClaim.UserClaimEntityMapperObject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("UserId");

                    b.HasKey("Id")
                        .HasName("PK_UserClaim");

                    b.HasIndex("UserId")
                        .HasDatabaseName("IX_UserClaim_UserId");

                    b.ToTable("UserClaim", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserLogin.UserLoginEntityMapperObject", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("UserId");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("PK_UserLogin");

                    b.HasIndex("UserId")
                        .HasDatabaseName("IX_UserLogin_UserId");

                    b.ToTable("UserLogin", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserRole.UserRoleEntityMapperObject", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("UserId");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint")
                        .HasColumnName("RoleId");

                    b.HasKey("UserId", "RoleId")
                        .HasName("PK_UserRole");

                    b.HasIndex("RoleId")
                        .HasDatabaseName("IX_UserRole_RoleId");

                    b.ToTable("UserRole", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserToken.UserTokenEntityMapperObject", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Name");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("PK_UserToken");

                    b.ToTable("UserToken", "dbo");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain.DummyMainEntityMapperObject", b =>
                {
                    b.HasOne("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyOneToMany.DummyOneToManyEntityMapperObject", "ObjectOfDummyOneToManyEntity")
                        .WithMany("ObjectsOfDummyMainEntity")
                        .HasForeignKey("ObjectDummyOneToManyId")
                        .HasConstraintName("FK_DummyMain_DummyOneToMany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjectOfDummyOneToManyEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMainDummyManyToMany.DummyMainDummyManyToManyEntityMapperObject", b =>
                {
                    b.HasOne("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain.DummyMainEntityMapperObject", "ObjectOfDummyMainEntity")
                        .WithMany("ObjectsOfDummyMainDummyManyToManyEntity")
                        .HasForeignKey("ObjectDummyMainId")
                        .HasConstraintName("FK_DummyMainDummyManyToMany_DummyMain")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyManyToMany.DummyManyToManyEntityMapperObject", "ObjectOfDummyManyToManyEntity")
                        .WithMany("ObjectsOfDummyMainDummyManyToManyEntity")
                        .HasForeignKey("ObjectDummyManyToManyId")
                        .HasConstraintName("FK_DummyMainDummyManyToMany_DummyManyToMany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjectOfDummyMainEntity");

                    b.Navigation("ObjectOfDummyManyToManyEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTree.DummyTreeEntityMapperObject", b =>
                {
                    b.HasOne("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTree.DummyTreeEntityMapperObject", "ObjectOfDummyTreeEntityParent")
                        .WithMany("ObjectsOfDummyTreeEntityChild")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_DummyTree_DummyTree_ParentId");

                    b.Navigation("ObjectOfDummyTreeEntityParent");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTreeLink.DummyTreeLinkEntityMapperObject", b =>
                {
                    b.HasOne("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTree.DummyTreeEntityMapperObject", "ObjectOfDummyTreeEntity")
                        .WithMany("ObjectsOfDummyTreeLinkEntity")
                        .HasForeignKey("Id")
                        .HasConstraintName("FK_DummyTreeLink_DummyTree")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjectOfDummyTreeEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.RoleClaim.RoleClaimEntityMapperObject", b =>
                {
                    b.HasOne("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.Role.RoleEntityMapperObject", "ObjectOfRoleEntity")
                        .WithMany("ObjectsOfRoleClaimEntity")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_RoleClaim_Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjectOfRoleEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserClaim.UserClaimEntityMapperObject", b =>
                {
                    b.HasOne("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.User.UserEntityMapperObject", "ObjectOfUserEntity")
                        .WithMany("ObjectsOfUserClaimEntity")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserClaim_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjectOfUserEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserLogin.UserLoginEntityMapperObject", b =>
                {
                    b.HasOne("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.User.UserEntityMapperObject", "ObjectOfUserEntity")
                        .WithMany("ObjectsOfUserLoginEntity")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserLogin_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjectOfUserEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserRole.UserRoleEntityMapperObject", b =>
                {
                    b.HasOne("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.Role.RoleEntityMapperObject", "ObjectOfRoleEntity")
                        .WithMany("ObjectsOfUserRoleEntity")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_UserRole_Role")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.User.UserEntityMapperObject", "ObjectOfUserEntity")
                        .WithMany("ObjectsOfUserRoleEntity")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserRole_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjectOfRoleEntity");

                    b.Navigation("ObjectOfUserEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.UserToken.UserTokenEntityMapperObject", b =>
                {
                    b.HasOne("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.User.UserEntityMapperObject", "ObjectOfUserEntity")
                        .WithMany("ObjectsOfUserTokenEntity")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserToken_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjectOfUserEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyMain.DummyMainEntityMapperObject", b =>
                {
                    b.Navigation("ObjectsOfDummyMainDummyManyToManyEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyManyToMany.DummyManyToManyEntityMapperObject", b =>
                {
                    b.Navigation("ObjectsOfDummyMainDummyManyToManyEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyOneToMany.DummyOneToManyEntityMapperObject", b =>
                {
                    b.Navigation("ObjectsOfDummyMainEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.DummyTree.DummyTreeEntityMapperObject", b =>
                {
                    b.Navigation("ObjectsOfDummyTreeEntityChild");

                    b.Navigation("ObjectsOfDummyTreeLinkEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.Role.RoleEntityMapperObject", b =>
                {
                    b.Navigation("ObjectsOfRoleClaimEntity");

                    b.Navigation("ObjectsOfUserRoleEntity");
                });

            modelBuilder.Entity("Makc2021.Layer3.Sql.Sample.Mappers.EF.Entities.User.UserEntityMapperObject", b =>
                {
                    b.Navigation("ObjectsOfUserClaimEntity");

                    b.Navigation("ObjectsOfUserLoginEntity");

                    b.Navigation("ObjectsOfUserRoleEntity");

                    b.Navigation("ObjectsOfUserTokenEntity");
                });
#pragma warning restore 612, 618
        }
    }
}