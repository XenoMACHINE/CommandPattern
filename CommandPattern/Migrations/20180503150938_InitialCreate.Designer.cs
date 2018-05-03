﻿// <auto-generated />
using CommandPattern;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace CommandPattern.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20180503150938_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("CommandPattern.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("brand");

                    b.Property<string>("model");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CommandPattern.People", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.HasKey("Id");

                    b.ToTable("Peoples");
                });
#pragma warning restore 612, 618
        }
    }
}