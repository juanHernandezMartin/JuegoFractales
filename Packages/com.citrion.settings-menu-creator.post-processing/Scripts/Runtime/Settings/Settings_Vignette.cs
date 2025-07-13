using CitrioN.Common;
using UnityEngine.Rendering.PostProcessing;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(810)]
  [MenuPath("Post Processing/Vignette")]
  public abstract class Setting_Vignette<T> : Setting_PostProcessing<T, Vignette>
  {
    //public override string RuntimeName => base.RuntimeName.Replace("Vignette ", "");
  }

  [MenuOrder(810)]
  [MenuPath("Post Processing/Vignette")]
  public class Setting_VignetteActive : Setting_PostProcessing_Direct<bool, Vignette>
  {
    public override string FieldName => nameof(Vignette.active);
  }

  public class Setting_VignetteEnabled : Setting_Vignette<bool>
  {
    public override string FieldName => nameof(Vignette.enabled);
  }

  public class Setting_VignetteMode : Setting_Vignette<VignetteMode>
  {
    public override string FieldName => nameof(Vignette.mode);
  }

  public class Setting_VignetteIntensity : Setting_Vignette<float>
  {
    public override string FieldName => nameof(Vignette.intensity);

    public Setting_VignetteIntensity()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();
    }
  }

  public class Setting_VignetteSmoothness : Setting_Vignette<float>
  {
    public override string FieldName => nameof(Vignette.smoothness);

    public Setting_VignetteSmoothness()
    {
      options.AddMinMaxRangeValues("0.01", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 0.2f;
    }
  }

  public class Setting_VignetteRoundness : Setting_Vignette<float>
  {
    public override string FieldName => nameof(Vignette.roundness);

    public Setting_VignetteRoundness()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 1;
    }
  }

  public class Setting_VignetteRounded : Setting_Vignette<bool>
  {
    public override string FieldName => nameof(Vignette.rounded);

    public Setting_VignetteRounded()
    {
      defaultValue = false;
    }
  }
}