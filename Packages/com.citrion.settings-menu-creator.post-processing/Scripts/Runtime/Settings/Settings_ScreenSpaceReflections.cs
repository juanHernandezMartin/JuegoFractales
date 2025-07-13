using CitrioN.Common;
using UnityEngine.Rendering.PostProcessing;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(810)]
  [MenuPath("Post Processing/Screen Space Reflections")]
  public abstract class Setting_ScreenSpaceReflections<T> : Setting_PostProcessing<T, ScreenSpaceReflections>
  {
    //public override string RuntimeName => base.RuntimeName.Replace("Screen Space Reflections ", "");
  }

  [MenuOrder(810)]
  [MenuPath("Post Processing/Screen Space Reflections")]
  public class Setting_ScreenSpaceReflectionsActive : Setting_PostProcessing_Direct<bool, ScreenSpaceReflections>
  {
    public override string FieldName => nameof(ScreenSpaceReflections.active);
  }

  public class Setting_ScreenSpaceReflectionsEnabled : Setting_ScreenSpaceReflections<bool>
  {
    public override string FieldName => nameof(ScreenSpaceReflections.enabled);
  }

  public class Setting_ScreenSpaceReflectionsPreset : Setting_ScreenSpaceReflections<ScreenSpaceReflectionPreset>
  {
    public override string FieldName => nameof(ScreenSpaceReflections.preset);

    public Setting_ScreenSpaceReflectionsPreset()
    {
      // TODO Add the custom preset settings and then disable the removal of the custom preset
      // Remove the custom preset
      options.RemoveAt(options.Count - 1);

      defaultValue = ScreenSpaceReflectionPreset.Medium;
    }
  }

  public class Setting_ScreenSpaceReflectionsMaximumMarchDistance : Setting_ScreenSpaceReflections<float>
  {
    public override string FieldName => nameof(ScreenSpaceReflections.maximumMarchDistance);

    public Setting_ScreenSpaceReflectionsMaximumMarchDistance()
    {
      options.AddMinMaxRangeValues("100", "200");
      options.AddStepSize("1");

      defaultValue = 100;
    }
  }

  public class Setting_ScreenSpaceReflectionsDistanceFade : Setting_ScreenSpaceReflections<float>
  {
    public override string FieldName => nameof(ScreenSpaceReflections.distanceFade);

    public Setting_ScreenSpaceReflectionsDistanceFade()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 0.5f;
    }
  }

  public class Setting_ScreenSpaceReflectionsVignette : Setting_ScreenSpaceReflections<float>
  {
    public override string FieldName => nameof(ScreenSpaceReflections.vignette);

    public Setting_ScreenSpaceReflectionsVignette()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 0.5f;
    }
  }
}