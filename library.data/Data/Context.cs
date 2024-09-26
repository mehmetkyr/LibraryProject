using library.data.Identity;
using library.data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace library.data.Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<Context>
    {
        private readonly IConfiguration _configuration;
        public ContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("MsSQLConnection"));

            return new Context(optionsBuilder.Options);
        }
    }

    public class Context : IdentityDbContext<AppUser>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Contact> Contacts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region FluentAPI
            modelBuilder.Entity<Book>(book =>
            {
                book.HasKey(x => x.Id);

                book.Property(x => x.Image)
                    .IsRequired()
                    .HasMaxLength(100);

                book.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                book.Property(x => x.Author)
                    .IsRequired()
                    .HasMaxLength(50);

                book.Property(x => x.Type)
                    .IsRequired()
                    .HasMaxLength(30);

                book.Property(x => x.ISBN)
                    .IsRequired()
                    .HasMaxLength(13);

                book.Property(x => x.PublishDateTime)
                    .IsRequired();

                book.Property(x => x.LocationInfo)
                    .IsRequired()
                    .HasMaxLength(10);

                book.Property(x => x.Status)
                    .IsRequired()
                    .HasDefaultValue("On the shelf")
                    .HasMaxLength(13);

                book.HasOne(b => b.Member)
                    .WithMany(u => u.Books)
                    .HasForeignKey(b => b.MemberId);
            });

            modelBuilder.Entity<AppUser>(member =>
            {
                member.HasKey(x => x.Id);

                member.Property(x => x.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                member.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                member.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                member.Property(x => x.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                member.Property(x => x.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Contact>(contact =>
            {
                contact.HasKey(x => x.Id);

                contact.Property(x => x.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                contact.Property(x => x.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                contact.Property(x => x.Email)
                    .IsRequired()
                    .HasMaxLength(60);

                contact.Property(x => x.Phone)
                    .HasMaxLength(10);

                contact.Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                contact.Property(x => x.Message)
                    .IsRequired()
                    .HasMaxLength(500);
            });

            #endregion

            #region HasData
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Image = "1.jpeg", Name = "Kürk Mantolu Madonna", Author = "Sabahattin Ali", Type = "Novel", ISBN = 9789753638029, PublishDateTime = new DateTime(2023, 08, 15), LocationInfo = "A1-b2", Status = "On the shelf" },
                new Book { Id = 2, Image = "2.jpeg", Name = "Zamanın Kısa Tarihi", Author = "Stephen Hawking", Type = "Science", ISBN = 9786051067582, PublishDateTime = new DateTime(2023, 11, 14), LocationInfo = "A2-b1", Status = "On the shelf" },
                new Book { Id = 3, Image = "3.jpeg", Name = "Dönüşüm", Author = "Franz Kafka", Type = "Novel", ISBN = 9789750719356, PublishDateTime = new DateTime(2019, 06, 17), LocationInfo = "A1-b1", Status = "On the shelf" },
                new Book { Id = 4, Image = "4.jpeg", Name = "Şeker Portakalı", Author = "Jose Mauro De Vasconcelos", Type = "Novel", ISBN = 9789750738609, PublishDateTime = new DateTime(2019, 09, 06), LocationInfo = "A1-b1", Status = "On the shelf" },
                new Book { Id = 5, Image = "5.jpeg", Name = "Etika", Author = "Benedictus Spinoza", Type = "Philosophy", ISBN = 9789752981478, PublishDateTime = new DateTime(2019, 09, 09), LocationInfo = "A3-b1", Status = "On the shelf" },
                new Book { Id = 6, Image = "6.jpeg", Name = "Kozmos Evrenin ve Yaşamın Sırları", Author = "Carl Sagan", Type = "Science", ISBN = 9789752107830, PublishDateTime = new DateTime(2023, 08, 15), LocationInfo = "A2-b1", Status = "On the shelf" },
                new Book { Id = 7, Image = "7.jpeg", Name = "Nietzsche Ağladığında", Author = "Irvin D. Yalom", Type = "Novel", ISBN = 9789755391465, PublishDateTime = new DateTime(2023, 09, 19), LocationInfo = "A1-b1", Status = "On the shelf" },
                new Book { Id = 8, Image = "8.jpeg", Name = "Bir İdam Mahkumunun Son Günü", Author = "Victor Hugo", Type = "Novel", ISBN = 9786052194973, PublishDateTime = new DateTime(2018, 08, 07), LocationInfo = "A1-b1", Status = "On the shelf" },
                new Book { Id = 9, Image = "1.jpeg", Name = "Kürk Mantolu Madonna", Author = "Sabahattin Ali", Type = "Novel", ISBN = 9789753638029, PublishDateTime = new DateTime(2023, 08, 15), LocationInfo = "A1-b2", Status = "On the shelf" },
                new Book { Id = 10, Image = "2.jpeg", Name = "Zamanın Kısa Tarihi", Author = "Stephen Hawking", Type = "Science", ISBN = 9786051067582, PublishDateTime = new DateTime(2023, 11, 14), LocationInfo = "A2-b1", Status = "On the shelf" },
                new Book { Id = 11, Image = "3.jpeg", Name = "Dönüşüm", Author = "Franz Kafka", Type = "Novel", ISBN = 9789750719356, PublishDateTime = new DateTime(2019, 06, 17), LocationInfo = "A1-b1", Status = "On the shelf" },
                new Book { Id = 12, Image = "4.jpeg", Name = "Şeker Portakalı", Author = "Jose Mauro De Vasconcelos", Type = "Novel", ISBN = 9789750738609, PublishDateTime = new DateTime(2019, 09, 06), LocationInfo = "A1-b1", Status = "On the shelf" },
                new Book { Id = 13, Image = "5.jpeg", Name = "Etika", Author = "Benedictus Spinoza", Type = "Philosophy", ISBN = 9789752981478, PublishDateTime = new DateTime(2019, 09, 09), LocationInfo = "A3-b1", Status = "On the shelf" },
                new Book { Id = 14, Image = "6.jpeg", Name = "Kozmos Evrenin ve Yaşamın Sırları", Author = "Carl Sagan", Type = "Science", ISBN = 9789752107830, PublishDateTime = new DateTime(2023, 08, 15), LocationInfo = "A2-b1", Status = "On the shelf" },
                new Book { Id = 15, Image = "7.jpeg", Name = "Nietzsche Ağladığında", Author = "Irvin D. Yalom", Type = "Novel", ISBN = 9789755391465, PublishDateTime = new DateTime(2023, 09, 19), LocationInfo = "A1-b1", Status = "On the shelf" },
                new Book { Id = 16, Image = "8.jpeg", Name = "Bir İdam Mahkumunun Son Günü", Author = "Victor Hugo", Type = "Novel", ISBN = 9786052194973, PublishDateTime = new DateTime(2018, 08, 07), LocationInfo = "A1-b1", Status = "On the shelf" }
            );

            modelBuilder.Entity<Contact>().HasData(
                new Contact { Id = 1, FirstName = "Mehmet", LastName = "Kayar", Email = "kayarmehmetali@outlook.com", Phone = "5318379692", Title = "Örnek Konu", Message = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." },
                new Contact { Id = 2, FirstName = "Ahmet", LastName = "Kılıç", Email = "ahmet@hotmail.com", Phone = "5318379611", Title = "Örnek Başlık", Message = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. " },
                new Contact { Id = 3, FirstName = "Ayşe", LastName = "Koç", Email = "ayse@hotmail.com", Phone = "5318379632", Title = "Örnek Title", Message = "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." }
            );

            //üyeler için seed data başlangıç
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = "1",
                    FirstName = "Admin",
                    LastName = "Admin",
                    PhoneNumber = "0",
                    Address = "None",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@hotmail.com",
                    NormalizedEmail = "ADMIN@HOTMAIL.COM",
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Admin1.")
                },
                new AppUser
                {
                    Id = "2",
                    FirstName = "Mehmet",
                    LastName = "Kayar",
                    PhoneNumber = "5318379692",
                    Address = "Sancaktepe/İstanbul",
                    UserName = "mehmetkyr",
                    NormalizedUserName = "MEHMETKYR",
                    Email = "kayarmehmetali@outlook.com",
                    NormalizedEmail = "KAYARMEHMETALI@OUTLOOK.COM",
                    PasswordHash = new PasswordHasher<AppUser>().HashPassword(null, "Mehmet1.")
                }
            );
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "Moderator", NormalizedName = "MODERATOR" },
                new IdentityRole { Id = "3", Name = "User", NormalizedName = "USER" }
            );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "1", },
                new IdentityUserRole<string> { UserId = "2", RoleId = "2", },
                new IdentityUserRole<string> { UserId = "2", RoleId = "3", }
            );
            //üyeler için seed data bitişi
            #endregion 
        }
    }
}
