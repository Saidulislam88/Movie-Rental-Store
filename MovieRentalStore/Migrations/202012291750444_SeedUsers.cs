namespace MovieRentalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {

            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0638746d-6e16-4e79-acc2-03f7eb7ffe6e', N'guest@mail.com', 0, N'AK+3ID9aa7sJNoE1xq9ZFFqYwGzqnt/SQUpQtZQIKe2xAmsuSqLMnBOtYt5UqYzjiQ==', N'9ac2dd3a-f318-4477-ab40-9b2c475313d3', NULL, 0, 0, NULL, 1, 0, N'guest@mail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4037266a-b302-4220-a209-a42ac592318a', N'admin@mail.com', 0, N'AA0SsBKcnsf/MmDoimVvpDGS3PfGY7KxcPUImGx/r5C74zgd1CUDG35wP57XIuMvuw==', N'd2fd2b32-7dbd-4f11-a9a6-a2ece9a45770', NULL, 0, 0, NULL, 1, 0, N'admin@mail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'52a920f1-aee6-4f71-b817-a3c5b5d9e8ab', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4037266a-b302-4220-a209-a42ac592318a', N'52a920f1-aee6-4f71-b817-a3c5b5d9e8ab')

");
        }
        
        public override void Down()
        {
        }
    }
}
