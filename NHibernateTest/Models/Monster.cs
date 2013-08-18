using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace NHibernateTest.Models {
    
    public class Monster {
        public virtual int No { get; set; }
        [Required]
        public virtual string Name { get; set; }
        [Required]
        public virtual int Rarity { get; set; }
        [Required]
        public virtual int Maxlv { get; set; }
        [Required]
        public virtual string Skill { get; set; }
    }
}
