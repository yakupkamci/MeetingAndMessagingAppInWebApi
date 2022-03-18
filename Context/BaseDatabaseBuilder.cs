public static class BaseDatabaseBuilder
{
    static void SetDataToDB(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Role>().HasData(
            new Role
            {
                Id = 1,
                Name = "Junior",
            },
            new Role
            {
                Id = 2,
                Name = "Middle",
            },
            new Role
            {
                Id = 3,
                Name = "Senior",
            },
            new Role
            {
                Id = 4,
                Name = "Team Lead",
            }
        );


        modelBuilder.Entity<Departman>().HasData(
            new Departman
            {
                Id = 1,
                Name = "Yazilim"
            },
            new Departman
            {
                Id = 2,
                Name = "Insan Kaynaklari"
            },
            new Departman
            {
                Id = 3,
                Name = "Donanim"
            },
            new Departman
            {
                Id = 4,
                Name = "Test"
            }
        );
    }

    public static void TableBuilder(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email).IsRequired();
            entity.Property(e => e.Password).IsRequired();
            entity.Property(e => e.IsVisibility);
            entity.Property(e => e.IsBlocked);
            entity.HasOne(e => e.User).WithOne(r => r.Account).HasForeignKey<User>(k => k.AccountId);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Surname).IsRequired();
            entity.Property(e => e.Gender).IsRequired();
            entity.HasOne(e => e.Address).WithOne(r => r.User).HasForeignKey<Address>(k => k.UserId);
            entity.HasOne(e => e.Departman).WithMany(r => r.User).HasForeignKey(k => k.DepartmanId);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.OpenAddress1).IsRequired();
            entity.Property(e => e.OpenAddress2);
            entity.Property(e => e.Country).IsRequired();
            entity.Property(e => e.City).IsRequired();
            entity.Property(e => e.District).IsRequired();
        });

        modelBuilder.Entity<Departman>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();

        });

        modelBuilder.Entity<IndividualMessage>(entity=>{
            entity.HasKey(e=>e.Id);
            entity.Property(e=>e.MessageType);
            entity.Property(e=>e.Content).IsRequired();
            entity.Property(e=>e.ReceiverAccountId);
            entity.Property(e=>e.IsRead);
        });

        modelBuilder.Entity<Meeting>(entity=>{
            entity.HasKey(e=>e.Id);
            entity.Property(e=>e.Name).IsRequired();
            entity.Property(e=>e.Subject);
            entity.Property(e=>e.OrganizerId).IsRequired();            
            entity.Property(e=>e.StartTime).IsRequired();
            entity.Property(e=>e.EndTime);
            entity.Property(e=>e.IsCompleted);
        });


        modelBuilder.Entity<AccountRole>(entity=>{
            entity.HasKey(x=>x.Id);
            entity.HasOne(x=>x.Role).WithMany(x=>x.AccountRoles).HasForeignKey(x=>x.RoleId);
            entity.HasOne(x=>x.Account).WithMany(x=>x.AccountRoles).HasForeignKey(x=>x.AccountId);
        });

        modelBuilder.Entity<AccountIndividualMessage>(entity=>{
            entity.HasKey(e=>e.Id);
            entity.HasOne(e=>e.Account).WithMany(e=>e.AccountIndividualMessages).HasForeignKey(e=>e.AccountId);
            entity.HasOne(e=>e.IndividualMessage).WithMany(e=>e.AccountIndividualMessages).HasForeignKey(e=>e.IndividualMessageId);
            entity.Property(e=>e.CreationDate);
        });

        modelBuilder.Entity<AccountMeeting>(entity=>{
            entity.HasKey(e=>e.Id);
            entity.HasOne(e=>e.Account).WithMany(r=>r.AccountMeeting).HasForeignKey(k=>k.AccountId);
            entity.HasOne(e=>e.Meeting).WithMany(r=>r.AccountMeeting).HasForeignKey(k=>k.MeetingId);
            entity.Property(e=>e.CreatingDate);
            entity.Property(e=>e.MeetingLink);

        });

        SetDataToDB(modelBuilder);
    }
}