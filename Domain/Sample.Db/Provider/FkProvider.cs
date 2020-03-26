using System;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Sample.Db.Model.App;
using Sample.Db.Model.Client;

namespace Sample.Db.Provider
{
    internal static class FkProvider
    {
        public static ModelBuilder BuildFk([NotNull] ModelBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder.Entity<Topic>()
                .HasOne(x => x.Parent)
                .WithMany(x => x.Children)
                .HasForeignKey(x => x.ParentId);

            builder.Entity<Topic>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Topics)
                .HasForeignKey(x => x.AuthorId);

            builder.Entity<Test>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Tests)
                .HasForeignKey(x => x.AuthorId);

            builder.Entity<TestTopic>()
                .HasOne(x => x.Test)
                .WithMany(x => x.TestTopics)
                .HasForeignKey(x => x.TestId);

            builder.Entity<TestTopic>()
                .HasOne(x => x.Topic)
                .WithMany(x => x.TestTopics)
                .HasForeignKey(x => x.TopicId);

            builder.Entity<UserData>()
                .HasOne(x => x.User)
                .WithOne(x => x.UserData)
                .HasForeignKey<UserData>(x => x.Id);

            builder.Entity<UserRole>()
                .HasOne(x => x.User)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.UserId);

            builder.Entity<UserRole>()
                .HasOne(x => x.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(x => x.RoleId);
            
            return builder;
        }
    }
}