using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkTest.Models.Mapping
{
    public class モンスターMap : EntityTypeConfiguration<モンスター>
    {
        public モンスターMap()
        {
            // Primary Key
            this.HasKey(t => t.No);

            // Properties
            this.Property(t => t.モンスター名)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.スキル)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("モンスター");
            this.Property(t => t.No).HasColumnName("No");
            this.Property(t => t.モンスター名).HasColumnName("モンスター名");
            this.Property(t => t.レア度).HasColumnName("レア度");
            this.Property(t => t.最大Lv).HasColumnName("最大Lv");
            this.Property(t => t.スキル).HasColumnName("スキル");
        }
    }
}
