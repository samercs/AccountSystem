using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using OrangeJetpack.Localization;
using AccountSystem.Entities;
using AccountSystem.Entities.Enum;

namespace AccountSystem.Data.Migrations
{
    public partial class SeedEmailTemplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var emailTemplates = new List<EmailTemplate>
            {
                new EmailTemplate
                {
                    TemplateType = EmailTemplateType.AccountRegistration,
                    Description = "Sent as a welcome message to newly registered users.",
                    Subject = new[]
                    {
                        new LocalizedContent("en", @"Welcome to {SiteTitle}"),
                        new LocalizedContent("ar", @"")
                    }.Serialize(),
                    Message = new[]
                    {
                        new LocalizedContent("en", @"<h1>Hi {User.FirstName}</h1><p>Welcome to {SiteTitle} and thank you so much for taking the time to register. If you ever have questions or comments please just let us know. Thank you!</p>"),
                        new LocalizedContent("ar", @"")
                    }.Serialize()
                },
                new EmailTemplate
                {
                    TemplateType = EmailTemplateType.PasswordReset,
                    Description = "Sent when a user requests a password reset.",
                    Subject = new[]
                    {
                        new LocalizedContent("en", @"Reset Password"),
                        new LocalizedContent("ar", @"")
                    }.Serialize(),
                    Message = new[]
                    {
                        new LocalizedContent("en", @"<h1>Hi {User.EmailAddress}</h1><p>We have received a request to reset your password. Please follow the link below to begin resetting your password.</p><p><a href=""{ResetPasswordUrl}"">Reset Password</a></p>"),
                        new LocalizedContent("ar", @"")
                    }.Serialize()
                },
                new EmailTemplate
                {
                    TemplateType = EmailTemplateType.PasswordChanged,
                    Description = "Sent as a confirmation that a password was changed.",
                    Subject = new[]
                    {
                        new LocalizedContent("en", @"Password Changed"),
                        new LocalizedContent("ar", @"")
                    }.Serialize(),
                    Message = new[]
                    {
                        new LocalizedContent("en", @"<h1>Hi {User.FirstName}</h1><p>This email is just to confirm your password was recently changed on the {SiteTitle} website. If you did not make this change please let us know.</p>"),
                        new LocalizedContent("ar", @"")
                    }.Serialize()
                },
                new EmailTemplate
                {
                    TemplateType = EmailTemplateType.EmailChanged,
                    Description = "Sent as a confirmation that an email was changed.",
                    Subject = new[]
                    {
                        new LocalizedContent("en", @"Email Changed"),
                        new LocalizedContent("ar", @"")
                    }.Serialize(),
                    Message = new[]
                    {
                        new LocalizedContent("en", @"<h1>Hi {User.FirstName}</h1><p>This email is just to confirm your email address was recently changed on the {SiteTitle} website. If you did not make this change please let us know.</p>"),
                        new LocalizedContent("ar", @"")
                    }.Serialize()
                },
                new EmailTemplate
                {
                    TemplateType = EmailTemplateType.NoAccount,
                    Description = "Sent when a user attempts to access a non-existent account.",
                    Subject = new[]
                    {
                        new LocalizedContent("en", @"User Account"),
                        new LocalizedContent("ar", @"")
                    }.Serialize(),
                    Message = new[]
                    {
                        new LocalizedContent("en", @"<h1>Hi {EmailAddress}</h1><p>It appears that a request was made to reset a lost or forgotten password but unfortunately we don''t have an account for this email address.</p>"),
                        new LocalizedContent("ar", @"")
                    }.Serialize()
                }
            };

            foreach (var emailTemplate in emailTemplates)
            {
                migrationBuilder.Sql($"INSERT INTO [dbo].[EmailTemplates] ([TemplateType], [Description], [Subject], [Message], [CreatedUtc], [IsDeleted]) VALUES ('{(int)emailTemplate.TemplateType}', '{emailTemplate.Description}', '{emailTemplate.Subject}', '{emailTemplate.Message}','{DateTime.UtcNow}', 0);");
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from dbo.EmailTemplates");
        }
    }
}
