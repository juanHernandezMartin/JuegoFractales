using CitrioN.Common;
using UnityEngine.Rendering.PostProcessing;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(810)]
  [MenuPath("Post Processing/Lens Distortion")]
  public abstract class Setting_LensDistortion<T1> : Setting_PostProcessing<T1, LensDistortion>
  {
    //public override string RuntimeName => base.RuntimeName.Replace("Lens Distortion ", "");
  }

  [MenuOrder(810)]
  [MenuPath("Post Processing/Lens Distortion")]
  public class Setting_LensDistortionActive : Setting_PostProcessing_Direct<bool, LensDistortion>
  {
    public override string FieldName => nameof(LensDistortion.active);
  }

  public class Setting_LensDistortionEnabled : Setting_LensDistortion<bool>
  {
    public override string FieldName => nameof(LensDistortion.enabled);
  }

  public class Setting_LensDistortionIntensity : Setting_LensDistortion<float>
  {
    public override string FieldName => nameof(LensDistortion.intensity);

    public Setting_LensDistortionIntensity()
    {
      options.AddMinMaxRangeValues("-100", "100");
      options.AddStepSize("0.1");
    }
  }

  public class Setting_LensDistortionIntensityXMultiplier : Setting_LensDistortion<float>
  {
    public override string FieldName => nameof(LensDistortion.intensityX);

    public Setting_LensDistortionIntensityXMultiplier()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 1;
    }
  }

  public class Setting_LensDistortionIntensityYMultiplier : Setting_LensDistortion<float>
  {
    public override string FieldName => nameof(LensDistortion.intensityY);

    public Setting_LensDistortionIntensityYMultiplier()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 1;
    }
  }

  public class Setting_LensDistortionCenterX : Setting_LensDistortion<float>
  {
    public override string FieldName => nameof(LensDistortion.centerX);

    public Setting_LensDistortionCenterX()
    {
      options.AddMinMaxRangeValues("-1", "1");
      options.AddStepSize("0.01");
    }
  }

  public class Setting_LensDistortionCenterY : Setting_LensDistortion<float>
  {
    public override string FieldName => nameof(LensDistortion.centerY);

    public Setting_LensDistortionCenterY()
    {
      options.AddMinMaxRangeValues("-1", "1");
      options.AddStepSize("0.01");
    }
  }

  public class Setting_LensDistortionScale : Setting_LensDistortion<float>
  {
    public override string FieldName => nameof(LensDistortion.scale);

    public Setting_LensDistortionScale()
    {
      options.AddMinMaxRangeValues("0.01", "5");
      options.AddStepSize("0.01");

      defaultValue = 1;
    }
  }
}