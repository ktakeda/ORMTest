using System;
using System.Collections.Generic;

namespace EntityFrameworkTest.Models
{
    public partial class モンスター
    {
        public int No { get; set; }
        public string モンスター名 { get; set; }
        public int レア度 { get; set; }
        public int 最大Lv { get; set; }
        public string スキル { get; set; }
    }
}
