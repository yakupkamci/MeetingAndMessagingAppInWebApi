
public class SahaBTMeetContext : DbContext
{
    public DbSet<Account>? Accounts { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Role>? Roles { get; set; }
    public DbSet<Departman>? Departmans { get; set; }
    public DbSet<Address>? Addresses { get; set; }
    public DbSet<AccountRole>? AccountRoles { get; set; }
    public DbSet<IndividualMessage>? IndividualMessages { get; set; }
    public DbSet<AccountIndividualMessage>? AccountIndividualMessages { get; set; }
    public DbSet<Meeting>? Meetings { get; set; }
    public DbSet<AccountMeeting>? AccountMeetings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 28));
        optionsBuilder.UseMySql("server=localhost;database=sahabt;user=root;port=3306;password=toortoor", serverVersion);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        BaseDatabaseBuilder.TableBuilder(modelBuilder);
    }
}