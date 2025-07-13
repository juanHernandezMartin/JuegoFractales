using CitrioN.Common;
using UnityEngine.Rendering.PostProcessing;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(810)]
  [MenuPath("Post Processing/Auto Exposure")]
  public abstract class Setting_AutoExposure<T1> : Setting_PostProcessing<T1, AutoExposure>
  {
    //public override string RuntimeName => base.RuntimeName.Replace("Auto Exposure ", "");
  }

  [MenuOrder(810)]
  [MenuPath("Post Processing/Auto Exposure")]
  public class Setting_AutoExposureActive : Setting_PostProcessing_Direct<bool, AutoExposure>
  {
    //public override string RuntimeName => "Auto Exposure";

    public override string FieldName => nameof(AutoExposure.active);
  }

  public class Setting_AutoExposureEnabled : Setting_AutoExposure<bool>
  {
    public override string FieldName => nameof(AutoExposure.enabled);
  }

  // TODO Check if Vector2 support can be implemented
  //public class Setting_AutoExposureFiltering : Setting_AutoExposure<Vector2>
  //{
  //  public override string FieldName => nameof(AutoExposure.filtering);
  //}

  public class Setting_AutoExposureMinLuminance : Setting_AutoExposure<float>
  {
    public override string FieldName => nameof(AutoExposure.minLuminance);

    public Setting_AutoExposureMinLuminance()
    {
      options.AddMinMaxRangeValues("-9", "9");
      options.AddStepSize("0.1");
    }
  }

  public class Setting_AutoExposureMaxLuminance : Setting_AutoExposure<float>
  {
    public override string FieldName => nameof(AutoExposure.maxLuminance);

    public Setting_AutoExposureMaxLuminance()
    {
      options.AddMinMaxRangeValues("-9", "9");
      options.AddStepSize("0.1");
    }
  }

  public class Setting_AutoExposureCompensation : Setting_AutoExposure<float>
  {
    public override string FieldName => nameof(AutoExposure.keyValue);

    public Setting_AutoExposureCompensation()
    {
      options.AddMinMaxRangeValues("0.01", "2");
      options.AddStepSize("0.01");

      defaultValue = 1f;
    }
  }

  public class Setting_AutoExposureEyeAdaptation : Setting_AutoExposure<EyeAdaptation>
  {
    public override string FieldName => nameof(AutoExposure.eyeAdaptation);
  }

  public class Setting_AutoExposureAdaptationSpeedUp : Setting_AutoExposure<float>
  {
    public override string FieldName => nameof(AutoExposure.speedUp);

    public Setting_AutoExposureAdaptationSpeedUp()
    {
      options.AddMinMaxRangeValues("0", "10");
      options.AddStepSize("0.1");

      defaultValue = 2;
    }
  }

  public class Setting_AutoExposureAdaptationSpeedDown : Setting_AutoExposure<float>
  {
    public override string FieldName => nameof(AutoExposure.speedDown);

    public Setting_AutoExposureAdaptationSpeedDown()
    {
      options.AddMinMaxRangeValues("0", "10");
      options.AddStepSize("0.1");

      defaultValue = 1;
    }
  }
}