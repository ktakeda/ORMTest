using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Sample.CustomerService.Domain; 

namespace Sample.CustomerService.Maps {
    
    
    public class Map : ClassMap<> {
        
        public Map() {
			Table("モンスター");
			LazyLoad();
			Id(x => x.No).GeneratedBy.Identity().Column("No");
			Map(x => x.).Column("モンスター名").Not.Nullable();
			Map(x => x.).Column("レア度").Not.Nullable();
			Map(x => x.Lv).Column("最大Lv").Not.Nullable();
			Map(x => x.).Column("スキル").Not.Nullable();
        }
    }
}
