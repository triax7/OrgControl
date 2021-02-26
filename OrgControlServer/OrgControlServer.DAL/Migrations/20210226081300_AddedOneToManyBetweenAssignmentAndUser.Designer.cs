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
    [Migration("20210226081300_AddedOneToManyBetweenAssignmentAndUser")]
    partial class AddedOneToManyBetweenAssignmentAndUser
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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AllowedRolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AllowedAssignmentsId", "AllowedRolesId");

                    b.HasIndex("AllowedRolesId");

                    b.ToTable("AssignmentRole");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.Assignment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.Event", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.RefreshToken", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("CanCreateAssignments")
                        .HasColumnType("bit");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("EventId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<string>("RolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RolesId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("RoleZone", b =>
                {
                    b.Property<string>("AllowedRolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AllowedZonesId")
                        .ValueGeneratedOnAdd()
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

            modelBuilder.Entity("OrgControlServer.DAL.Models.Assignment", b =>
                {
                    b.HasOne("OrgControlServer.DAL.Models.Event", "Event")
                        .WithMany("Assignments")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OrgControlServer.DAL.Models.User", "User")
                        .WithMany("Duties")
                        .HasForeignKey("UserId");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.Event", b =>
                {
                    b.HasOne("OrgControlServer.DAL.Models.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.RefreshToken", b =>
                {
                    b.HasOne("OrgControlServer.DAL.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.Role", b =>
                {
                    b.HasOne("OrgControlServer.DAL.Models.Event", "Event")
                        .WithMany("Roles")
                        .HasForeignKey("EventId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.Zone", b =>
                {
                    b.HasOne("OrgControlServer.DAL.Models.Event", "Event")
                        .WithMany("Zones")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Event");
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

            modelBuilder.Entity("OrgControlServer.DAL.Models.Event", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Roles");

                    b.Navigation("Zones");
                });

            modelBuilder.Entity("OrgControlServer.DAL.Models.User", b =>
                {
                    b.Navigation("Duties");

                    b.Navigation("Events");

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
