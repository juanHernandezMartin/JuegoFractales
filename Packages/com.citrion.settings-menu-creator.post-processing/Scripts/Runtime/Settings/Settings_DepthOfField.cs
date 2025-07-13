using CitrioN.Common;
using UnityEngine.Rendering.PostProcessing;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(810)]
  [MenuPath("Post Processing/Depth Of Field")]
  public abstract class Setting_DepthOfField<T1> : Setting_PostProcessing<T1, DepthOfField>
  {
    //public override string RuntimeName => base.RuntimeName.Replace("Depth Of Field ", "");
  }

  [MenuOrder(810)]
  [MenuPath("Post Processing/Depth Of Field")]
  public class Setting_DepthOfFieldActive : Setting_PostProcessing_Direct<bool, DepthOfField>
  {
    public override string FieldName => nameof(DepthOfField.active);
  }

  public class Setting_DepthOfFieldEnabled : Setting_DepthOfField<bool>
  {
    public override string FieldName => nameof(DepthOfField.enabled);
  }

  public class Setting_DepthOfFieldFocusDistance : Setting_DepthOfField<float>
  {
    public override string FieldName => nameof(DepthOfField.focusDistance);

    public Setting_DepthOfFieldFocusDistance()
    {
      options.AddMinMaxRangeValues("0.1", "200");
      options.AddStepSize("0.1");

      defaultValue = 10f;
    }
  }

  public class Setting_DepthOfFieldAperture : Setting_DepthOfField<float>
  {
    public override string FieldName => nameof(DepthOfField.aperture);

    public Setting_DepthOfFieldAperture()
    {
      options.AddMinMaxRangeValues("0.1", "32");
      options.AddStepSize("0.1");

      defaultValue = 5.6f;
    }
  }

  public class Setting_DepthOfFieldFocalLength : Setting_DepthOfField<float>
  {
    public override string FieldName => nameof(DepthOfField.focalLength);

    public Setting_DepthOfFieldFocalLength()
    {
      options.AddMinMaxRangeValues("1", "300");
      options.AddStepSize("1");

      defaultValue = 50;
    }
  }

  public class Setting_DepthOfFieldMaxBlurSize : Setting_DepthOfField<KernelSize>
  {
    public override string FieldName => nameof(DepthOfField.kernelSize);

    public Setting_DepthOfFieldMaxBlurSize()
    {
      defaultValue = KernelSize.Medium;
    }
  }
}