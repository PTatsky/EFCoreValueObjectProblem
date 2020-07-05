﻿// <auto-generated />
using EFSimpleExample;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFSimpleExample.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200705143842_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFSimpleExample.ZoneState", b =>
                {
                    b.Property<string>("ZoneKey")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ZoneKey");

                    b.ToTable("ZoneStates");
                });

            modelBuilder.Entity("EFSimpleExample.ZoneState", b =>
                {
                    b.OwnsOne("EFSimpleExample.ControlPanelNodeId", "NodeId", b1 =>
                        {
                            b1.Property<string>("ZoneStateZoneKey")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<short>("NodeId")
                                .HasColumnType("smallint");

                            b1.HasKey("ZoneStateZoneKey");

                            b1.ToTable("ZoneStates");

                            b1.WithOwner()
                                .HasForeignKey("ZoneStateZoneKey");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
