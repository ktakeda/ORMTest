using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;

namespace LightSpeedTest.Model
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table("モンスター", IdColumnName="No")]
  public partial class モンスター : Entity<int>
  {
    #region Fields
  
    [ValidatePresence]
    [ValidateLength(0, 20)]
    private string _モンスター名;
    private int _レア度;
    private int _最大lv;
    [ValidatePresence]
    [ValidateLength(0, 20)]
    private string _スキル;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the モンスター名 entity attribute.</summary>
    public const string モンスター名Field = "モンスター名";
    /// <summary>Identifies the レア度 entity attribute.</summary>
    public const string レア度Field = "レア度";
    /// <summary>Identifies the 最大lv entity attribute.</summary>
    public const string 最大lvField = "最大lv";
    /// <summary>Identifies the スキル entity attribute.</summary>
    public const string スキルField = "スキル";


    #endregion
    
    #region Properties



    [System.Diagnostics.DebuggerNonUserCode]
    public string モンスター名
    {
      get { return Get(ref _モンスター名, "モンスター名"); }
      set { Set(ref _モンスター名, value, "モンスター名"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public int レア度
    {
      get { return Get(ref _レア度, "レア度"); }
      set { Set(ref _レア度, value, "レア度"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public int 最大lv
    {
      get { return Get(ref _最大lv, "最大lv"); }
      set { Set(ref _最大lv, value, "最大lv"); }
    }

    [System.Diagnostics.DebuggerNonUserCode]
    public string スキル
    {
      get { return Get(ref _スキル, "スキル"); }
      set { Set(ref _スキル, value, "スキル"); }
    }

    #endregion
  }
}
