﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFGetStarted.Migrations
{
    [DbContext(typeof(BloggingContext))]
    [Migration("20240211214905_CreatedTeamsWorkers")]
    partial class CreatedTeamsWorkers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Blog", b =>
                {
                    b.Property<int>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BlogId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("EFGetStarted.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeamID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TaskId");

                    b.HasIndex("TeamID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("EFGetStarted.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrentTaskTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeamID");

                    b.HasIndex("CurrentTaskTaskId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("EFGetStarted.TeamWorker", b =>
                {
                    b.Property<int>("TeamID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamID", "WorkerID");

                    b.HasIndex("WorkerID");

                    b.ToTable("TeamWorker");
                });

            modelBuilder.Entity("EFGetStarted.Todo", b =>
                {
                    b.Property<int>("TodoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDone")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaskId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WorkerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TodoId");

                    b.HasIndex("TaskId");

                    b.HasIndex("WorkerID");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("EFGetStarted.Worker", b =>
                {
                    b.Property<int>("WorkerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrentTodoTodoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WorkerID");

                    b.HasIndex("CurrentTodoTodoId");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("Post", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BlogId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PostId");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("EFGetStarted.Task", b =>
                {
                    b.HasOne("EFGetStarted.Team", null)
                        .WithMany("Tasks")
                        .HasForeignKey("TeamID");
                });

            modelBuilder.Entity("EFGetStarted.Team", b =>
                {
                    b.HasOne("EFGetStarted.Task", "CurrentTask")
                        .WithMany()
                        .HasForeignKey("CurrentTaskTaskId");

                    b.Navigation("CurrentTask");
                });

            modelBuilder.Entity("EFGetStarted.TeamWorker", b =>
                {
                    b.HasOne("EFGetStarted.Team", "team")
                        .WithMany("Workers")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFGetStarted.Worker", "Worker")
                        .WithMany("Teams")
                        .HasForeignKey("WorkerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");

                    b.Navigation("team");
                });

            modelBuilder.Entity("EFGetStarted.Todo", b =>
                {
                    b.HasOne("EFGetStarted.Task", "Task")
                        .WithMany("Todos")
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFGetStarted.Worker", null)
                        .WithMany("Todos")
                        .HasForeignKey("WorkerID");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("EFGetStarted.Worker", b =>
                {
                    b.HasOne("EFGetStarted.Todo", "CurrentTodo")
                        .WithMany()
                        .HasForeignKey("CurrentTodoTodoId");

                    b.Navigation("CurrentTodo");
                });

            modelBuilder.Entity("Post", b =>
                {
                    b.HasOne("Blog", "Blog")
                        .WithMany("Posts")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Blog");
                });

            modelBuilder.Entity("Blog", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("EFGetStarted.Task", b =>
                {
                    b.Navigation("Todos");
                });

            modelBuilder.Entity("EFGetStarted.Team", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("EFGetStarted.Worker", b =>
                {
                    b.Navigation("Teams");

                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
