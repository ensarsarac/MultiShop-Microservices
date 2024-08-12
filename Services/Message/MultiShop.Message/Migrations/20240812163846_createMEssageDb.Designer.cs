﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiShop.Message.DAL.Concrete;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MultiShop.Message.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240812163846_createMEssageDb")]
    partial class createMEssageDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MultiShop.Message.DAL.Entity.MessageEntity", b =>
                {
                    b.Property<int>("MessageEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MessageEntityId"));

                    b.Property<bool>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MessageDetail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ReceiveId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SenderId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MessageEntityId");

                    b.ToTable("Messages");
                });
#pragma warning restore 612, 618
        }
    }
}
