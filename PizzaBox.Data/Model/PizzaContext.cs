using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PizzaBox.Data.Model
{
    public partial class PizzaContext : DbContext
    {
        public PizzaContext()
        {
        }

        public PizzaContext(DbContextOptions<PizzaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }
        public virtual DbSet<PizzaOrder> PizzaOrder { get; set; }
        public virtual DbSet<PizzaToppings> PizzaToppings { get; set; }
        public virtual DbSet<Toppings> Toppings { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=utadbservernew.database.windows.net;Database=PizzaDb;user id=edls95;Password=Password7.;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => e.Locationid)
                    .HasName("PK__Inventor__306F78A677627819");

                entity.Property(e => e.Locationid)
                    .HasColumnName("locationid")
                    .ValueGeneratedNever();

                entity.Property(e => e.Beef).HasColumnName("beef");

                entity.Property(e => e.Cheese).HasColumnName("cheese");

                entity.Property(e => e.Chicken).HasColumnName("chicken");

                entity.Property(e => e.Ham).HasColumnName("ham");

                entity.Property(e => e.Jalapenos).HasColumnName("jalapenos");

                entity.Property(e => e.Largeoriginaldough).HasColumnName("largeoriginaldough");

                entity.Property(e => e.Largestuffeddough).HasColumnName("largestuffeddough");

                entity.Property(e => e.Largethindough).HasColumnName("largethindough");

                entity.Property(e => e.Mediumoriginaldough).HasColumnName("mediumoriginaldough");

                entity.Property(e => e.Mediumstuffeddough).HasColumnName("mediumstuffeddough");

                entity.Property(e => e.Mediumthindough).HasColumnName("mediumthindough");

                entity.Property(e => e.Mushrooms).HasColumnName("mushrooms");

                entity.Property(e => e.Onions).HasColumnName("onions");

                entity.Property(e => e.Pepperoni).HasColumnName("pepperoni");

                entity.Property(e => e.Peppers).HasColumnName("peppers");

                entity.Property(e => e.Pineapple).HasColumnName("pineapple");

                entity.Property(e => e.Sausage).HasColumnName("sausage");

                entity.Property(e => e.Smalloriginaldough).HasColumnName("smalloriginaldough");

                entity.Property(e => e.Smallstuffeddough).HasColumnName("smallstuffeddough");

                entity.Property(e => e.Smallthindough).HasColumnName("smallthindough");

                entity.HasOne(d => d.Location)
                    .WithOne(p => p.Inventory)
                    .HasForeignKey<Inventory>(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inventory__locat__6FE99F9F");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasColumnName("state")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Street1)
                    .IsRequired()
                    .HasColumnName("street1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Street2)
                    .HasColumnName("street2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode)
                    .IsRequired()
                    .HasColumnName("zipcode")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Locationid).HasColumnName("locationid");

                entity.Property(e => e.Ordertime)
                    .HasColumnName("ordertime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Totalcost)
                    .HasColumnName("totalcost")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Userid)
                    .IsRequired()
                    .HasColumnName("userid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Locationid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__location__59063A47");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__userid__5812160E");
            });

            modelBuilder.Entity<Pizza>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Crust)
                    .IsRequired()
                    .HasColumnName("crust")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnName("size")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaOrder>(entity =>
            {
                entity.HasKey(e => new { e.Orderid, e.Pizzaid })
                    .HasName("PK__PizzaOrd__6CDA8E3DE27ABFD2");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Pizzaid).HasColumnName("pizzaid");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.Orderid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaOrde__order__72C60C4A");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaOrder)
                    .HasForeignKey(d => d.Pizzaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaOrde__pizza__73BA3083");
            });

            modelBuilder.Entity<PizzaToppings>(entity =>
            {
                entity.HasKey(e => new { e.Pizzaid, e.Toppingid })
                    .HasName("PK__PizzaTop__47E5F128333F3514");

                entity.Property(e => e.Pizzaid).HasColumnName("pizzaid");

                entity.Property(e => e.Toppingid).HasColumnName("toppingid");

                entity.HasOne(d => d.Pizza)
                    .WithMany(p => p.PizzaToppings)
                    .HasForeignKey(d => d.Pizzaid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaTopp__pizza__76969D2E");

                entity.HasOne(d => d.Topping)
                    .WithMany(p => p.PizzaToppings)
                    .HasForeignKey(d => d.Toppingid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PizzaTopp__toppi__778AC167");
            });

            modelBuilder.Entity<Toppings>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__Users__F3DBC573C7CBF5D8");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
