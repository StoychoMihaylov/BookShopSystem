using System.Security.Claims;
using System.Threading.Tasks;
using BookShopSytem.Models.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShopSystem.Data
{
    using System.Data.Entity;

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class BookShopContext : IdentityDbContext<ApplicationUser>
    {
        public BookShopContext()
            : base("BookShopContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BookShopContext>());
        }

        public static BookShopContext Create()
        {
            return new BookShopContext();
        }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(book => book.RelatedBooks)
                .WithMany()
                .Map(configuration =>
                {
                    configuration.MapLeftKey("BookId");
                    configuration.MapRightKey("RelatedBookId");
                    configuration.ToTable("BooksRelatedBooks");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}