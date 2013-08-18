using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using NHibernateTest.Models; 

namespace NHibernateTest.Models.Maps {
    
    
    public class MonsterMap : ClassMap<Monster> {
        
        public MonsterMap() {
			Table("Monster");
			LazyLoad();
			Id(x => x.No).GeneratedBy.Identity().Column("No");
			Map(x => x.Name).Column("Name").Not.Nullable();
			Map(x => x.Rarity).Column("Rarity").Not.Nullable();
			Map(x => x.Maxlv).Column("MaxLv").Not.Nullable();
			Map(x => x.Skill).Column("Skill").Not.Nullable();
        }
    }
}
