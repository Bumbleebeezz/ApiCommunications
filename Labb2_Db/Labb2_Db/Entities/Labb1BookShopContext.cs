using Microsoft.EntityFrameworkCore;

namespace Labb2_Db.Entities;

public partial class Labb1BookShopContext : DbContext
{
    public Labb1BookShopContext()
    {
    }

    public Labb1BookShopContext(DbContextOptions<Labb1BookShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Format> Formats { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<InventoryBalance> InventoryBalances { get; set; }

    public virtual DbSet<Publisher> Publishers { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<StoreOrder> StoreOrders { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<TitlesPerAuthor> TitlesPerAuthors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MARIACONFIG;Initial Catalog=Labb1_BookShop;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC275AAE1084");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.FirstName).HasMaxLength(30);
            entity.Property(e => e.LastName).HasMaxLength(30);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Isbn).HasName("PK__Books__447D36EB9C8F8CBD");

            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.FormatId).HasColumnName("FormatID");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.Language).HasMaxLength(30);
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuthorID");

            entity.HasOne(d => d.Format).WithMany(p => p.Books)
                .HasForeignKey(d => d.FormatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormatID");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GenreID");
        });

        modelBuilder.Entity<Format>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Formats__3214EC27F19C5E11");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genres__3214EC27E19186FB");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(20);
        });

        modelBuilder.Entity<InventoryBalance>(entity =>
        {
            entity.HasKey(e => new { e.StoreId, e.Isbn, e.AuthorId, e.FormatId }).HasName("PK__Inventor__3D302AAF7D857466");

            entity.ToTable("InventoryBalance");

            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.FormatId).HasColumnName("FormatID");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Author).WithMany(p => p.InventoryBalances)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AuthorID_IB");

            entity.HasOne(d => d.Format).WithMany(p => p.InventoryBalances)
                .HasForeignKey(d => d.FormatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormatID_IB");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.InventoryBalances)
                .HasForeignKey(d => d.Isbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ISBN_IB");

            entity.HasOne(d => d.Store).WithMany(p => p.InventoryBalances)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreID_IB");
        });

        modelBuilder.Entity<Publisher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Publishe__3214EC2747F86261");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Adress).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Stores__3214EC27CEFF1E17");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Adress).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<StoreOrder>(entity =>
        {
            entity.HasKey(e => new { e.Id, e.StoreId }).HasName("PK__StoreOrd__31ACC329AFA4A7B8");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.StoreId).HasColumnName("StoreID");
            entity.Property(e => e.FormatId).HasColumnName("FormatID");
            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");
            entity.Property(e => e.PublisherId).HasColumnName("PublisherID");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");

            entity.HasOne(d => d.Format).WithMany(p => p.StoreOrders)
                .HasForeignKey(d => d.FormatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FormatID_SO");

            entity.HasOne(d => d.IsbnNavigation).WithMany(p => p.StoreOrders)
                .HasForeignKey(d => d.Isbn)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ISBN_SO");

            entity.HasOne(d => d.Publisher).WithMany(p => p.StoreOrders)
                .HasForeignKey(d => d.PublisherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PublisherID");

            entity.HasOne(d => d.Store).WithMany(p => p.StoreOrders)
                .HasForeignKey(d => d.StoreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoreID_SO");

            entity.HasOne(d => d.Supplier).WithMany(p => p.StoreOrders)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SupplierID_SO");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC270D3B22B8");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Adress).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
        });

        modelBuilder.Entity<TitlesPerAuthor>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TitlesPerAuthors");

            entity.Property(e => e.InventoryValue).HasMaxLength(4000);
            entity.Property(e => e.Name).HasMaxLength(61);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
