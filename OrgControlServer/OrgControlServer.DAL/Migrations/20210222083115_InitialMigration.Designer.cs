﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrgControlServer.DAL;

namespace OrgControlServer.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210222083115_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssignmentRole", b =>
                {
                    b.Property<string>("AllowedAssignmentsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AllowedRolesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AllowedAssignmentsId", "AllowedRolesId");

                    b.HasIndex("AllowedRolesId");

                    b.ToTable("AssignmentRole");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.Assignment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.RefreshToken", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("CanCreateAssignments")
                        .HasColumnType("bit");

                    b.Property<bool>("CanCreateRoles")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.Zone", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<string>("RolesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("RoleZone", b =>
                {
                    b.Property<string>("AllowedRolesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AllowedZonesId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AllowedRolesId", "AllowedZonesId");

                    b.HasIndex("AllowedZonesId");

                    b.ToTable("RoleZone");
                });

            modelBuilder.Entity("AssignmentRole", b =>
                {
                    b.HasOne("OrgControlServer.DAL.Models.Assignment", null)
                        .WithMany()
                        .HasForeignKey("AllowedAssignmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrgControlServer.DAL.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("AllowedRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.RefreshToken", b =>
                {
                    b.HasOne("OrgControlServer.DAL.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("OrgControlServer.DAL.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrgControlServer.DAL.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RoleZone", b =>
                {
                    b.HasOne("OrgControlServer.DAL.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("AllowedRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrgControlServer.DAL.Models.Zone", null)
                        .WithMany()
                        .HasForeignKey("AllowedZonesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.User", b =>
                {
                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}