using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RichLife.Data.models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RichLife.Enum;
using RIchLife.Utilites;

namespace RichLife.Data.Config
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Email).HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).HasMaxLength(100);
            builder.Property(x => x.PasswordKey).HasMaxLength(100);
            builder.Property(x => x.Password).HasMaxLength(100);
            builder.HasMany(x => x.UserTokens)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }
    }

    public static class UserExtension
    {
        public static bool UpdateName(this User user, string newName)
        {
            if (newName.HasValue())
                user.Name = newName;
            return newName.HasValue();
        }

        public static bool UpdateEmail(this User user, string newEmail)
        {
            if (newEmail.HasValue())
                user.Email = newEmail;
            return newEmail.HasValue();
        }

        public static bool UpdatePhoneNumber(this User user, string newPhoneNumber)
        {
            if (newPhoneNumber.HasValue())
                user.PhoneNumber = newPhoneNumber;
            return newPhoneNumber.HasValue();
        }

        public static bool UpdateTookTheProgram(this User user, bool? TookTheProgram)
        {
            if (TookTheProgram.HasValue)
                user.TookTheProgram = TookTheProgram.Value;
            if (user.TookTheProgram)
                user.RefferalKey = user.Id.ToString();
            return TookTheProgram.HasValue;
        }
        public static bool UpdateCodeNumber(this User user, string CodeNumber)
        {
            if (CodeNumber.HasValue())
                user.CodeNumber = CodeNumber;
            return CodeNumber.HasValue(); 
        }

        public static bool UpdateUserRole(this User user, bool? IsAdmin)
        {
            if (!IsAdmin.HasValue) return false;
            user.Role = IsAdmin.Value ? UserRole.Admin : UserRole.User;
            return true;
        }

        public static IQueryable<User> WhereEmail(this IQueryable<User> query, string email)
            => query.Where(x => !x.IsDelete && x.Email == email);

        public static IQueryable<User> SearchString(this IQueryable<User> query, string search)
        {
            if (search.HasValue())
            {
                query = query.Where(x => x.Email.Contains(search)
                                         || x.Name.Contains(search)
                                         || x.Gender.Contains(search)
                                         || x.PhoneNumber.Contains(search)
                                         || x.RefferalKey.Contains(search)
                );
            }
            return query;
        }
    }
}
