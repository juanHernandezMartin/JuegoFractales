using CitrioN.Common;
using UnityEngine.Rendering.PostProcessing;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(810)]
  [MenuPath("Post Processing/Motion Blur")]
  public abstract class Setting_MotionBlur<T1> : Setting_PostProcessing<T1, MotionBlur>
  {
    //public override string RuntimeName => base.RuntimeName.Replace("Motion Blur ", "");
  }

  [MenuOrder(810)]
  [MenuPath("Post Processing/Motion Blur")]
  public class Setting_MotionBlurActive : Setting_PostProcessing_Direct<bool, MotionBlur>
  {
    public override string FieldName => nameof(MotionBlur.active);
  }

  public class Setting_MotionBlurEnabled : Setting_MotionBlur<bool>
  {
    public override string FieldName => nameof(MotionBlur.enabled);
  }

  public class Setting_MotionBlurShutterAngle : Setting_MotionBlur<float>
  {
    public override string FieldName => nameof(MotionBlur.shutterAngle);

    public Setting_MotionBlurShutterAngle()
    {
      options.AddMinMaxRangeValues("0", "360");
      options.AddStepSize("1");

      defaultValue = 270;
    }
  }

  // TODO: Doesn't seem to work. Needs investigation
  //public class Setting_MotionBlurSampleCount : Setting_MotionBlur<float>
  //{
  //  public override string FieldName => nameof(MotionBlur.sampleCount);

  //  public Setting_MotionBlurSampleCount()
  //  {
  //    options.AddMinMaxRangeValues("4", "32");
  //    options.AddStepSize("1");

  //    defaultValue = 10;
  //  }
  //}
}