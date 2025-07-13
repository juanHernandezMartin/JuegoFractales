using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  public abstract class Setting_PostProcessing_Direct<T1, T2> : Setting_PostProcessing<T1, T2> where T2 : PostProcessEffectSettings
  {
    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      var field = FieldInfo;
      if (field == null) { return null; }
      var obj = GetObject(settings);
      if (obj == null) { return null; }
      var value = field.GetValue(obj);
      return new List<object>() { value };
    }

    protected override object ApplySettingChangeWithValue(SettingsCollection settings, T1 value)
    {
      var field = FieldInfo;
      if (field == null) { return null; }

      var obj = GetObject(settings);
      if (obj == null) { return null; }

      field.SetValue(obj, value);
      return field.GetValue(obj);
    }
  }
}