using CitrioN.Common;
using UnityEngine.Rendering.PostProcessing;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(810)]
  [MenuPath("Post Processing/Grain")]
  public abstract class Setting_Grain<T1> : Setting_PostProcessing<T1, Grain>
  {
    //public override string RuntimeName => base.RuntimeName.Replace("Grain ", "");
  }

  [MenuOrder(810)]
  [MenuPath("Post Processing/Grain")]
  public class Setting_GrainActive : Setting_PostProcessing_Direct<bool, Grain>
  {
    public override string FieldName => nameof(Grain.active);
  }

  public class Setting_GrainEnabled : Setting_Grain<bool>
  {
    public override string FieldName => nameof(Grain.enabled);
  }

  public class Setting_GrainColored : Setting_Grain<bool>
  {
    public override string FieldName => nameof(Grain.colored);
  }

  public class Setting_GrainIntensity : Setting_Grain<float>
  {
    public override string FieldName => nameof(Grain.intensity);

    public Setting_GrainIntensity()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
    }
  }

  public class Setting_GrainSize : Setting_Grain<float>
  {
    public override string FieldName => nameof(Grain.size);

    public Setting_GrainSize()
    {
      options.AddMinMaxRangeValues("0.3", "3");
      options.AddStepSize("0.01");

      defaultValue = 1;
    }
  }

  public class Setting_GrainLuminanceContribution : Setting_Grain<float>
  {
    public override string FieldName => nameof(Grain.lumContrib);

    public Setting_GrainLuminanceContribution()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 0.8f;
    }
  }
}