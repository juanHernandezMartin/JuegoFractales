using CitrioN.Common;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(800)]
  [MenuPath("Post Processing")]
  public abstract class Setting_PostProcessing<T1, T2> : Setting_Generic_Reflection_Field_Unity<T1, T2> where T2 : PostProcessEffectSettings
  {
    [SerializeField]
    [Tooltip("Reference to the PostProcessProfile to manage.\n\n" +
             "If left blank the PostProcessProfile specified in\n" +
             "the SettingsCollection will be used.")]
    protected PostProcessProfile profileOverride;

    public override string EditorNamePrefix => "[PP]";

    //public override bool StoreValueInternally => false;

    public override object GetObject(SettingsCollection settings)
    {
      var profile = GetProfile(settings);
      if (profile == null)
      {
        ConsoleLogger.LogWarning($"Unable to find object for {GetType().Name} " +
                                 $"because the profile is missing.");
        return null;
      }

      if (profile.TryGetSettings<T2>(out var setting))
      {
        return setting;
      }

      // TODO If Unity fixes the null ref issue this could be enabled
      // to support adding settings that are not on the profile.
      //setting = profile.AddSettings<T2>();
      //profile.isDirty = true;
      //return setting;

      ConsoleLogger.LogWarning($"Unable to find post process effect for {GetType().Name} " +
                               $"because no setting of type {typeof(T2).Name} " +
                               $"is on the profile.");
      return null;
    }

    protected virtual PostProcessProfile GetProfile(SettingsCollection settings)
    {
      if (profileOverride != null) { return profileOverride; }
      return settings != null ? settings.PostProcessProfile : null;
    }

    public override List<object> GetCurrentValues(SettingsCollection settings)
    {
      var field = FieldInfo;
      if (field == null) { return null; }

      var obj = GetObject(settings);
      if (obj == null) { return null; }

      object fieldValue = null;
      try
      {
        fieldValue = field.GetValue(obj);
      }
      catch (System.Exception) { /*throw;*/ }

      if (fieldValue != null && fieldValue is ParameterOverride<T1> parameterOverride)
      {
        var value = parameterOverride.GetValue<T1>();
        // We also set the value override so it actually enables
        // this value override on the post processing profile
        parameterOverride.Override(value);
        return new List<object>() { value };
      }
      return null;
    }

    protected override object ApplySettingChangeWithValue(SettingsCollection settings, T1 value)
    {
      var field = FieldInfo;
      if (field == null) { return null; }

      var obj = GetObject(settings);
      if (obj == null) { return null; }

      var fieldValue = field.GetValue(obj);
      if (fieldValue is ParameterOverride<T1> parameterOverride)
      {
        //parameterOverride.value = value;
        parameterOverride.Override(value);
        value = parameterOverride.GetValue<T1>();
        return value;
      }
      return null;
    }
  }
}