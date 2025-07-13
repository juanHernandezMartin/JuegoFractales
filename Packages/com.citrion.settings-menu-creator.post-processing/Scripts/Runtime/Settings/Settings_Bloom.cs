using CitrioN.Common;
using UnityEngine.Rendering.PostProcessing;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(810)]
  [MenuPath("Post Processing/Bloom")]
  public abstract class Setting_Bloom<T1> : Setting_PostProcessing<T1, Bloom>
  {
    //public override string RuntimeName => base.RuntimeName.Replace("Bloom ", "");
  }

  [MenuOrder(810)]
  [MenuPath("Post Processing/Bloom")]
  public class Setting_BloomActive : Setting_PostProcessing_Direct<bool, Bloom>
  {
    public override string FieldName => nameof(Bloom.active);
  }

  public class Setting_BloomEnabled : Setting_Bloom<bool>
  {
    public override string FieldName => nameof(Bloom.enabled);
  }

  public class Setting_BloomIntensity : Setting_Bloom<float>
  {
    public override string FieldName => nameof(Bloom.intensity);

    public Setting_BloomIntensity()
    {
      options.AddMinMaxRangeValues("0", "5");
      options.AddStepSize("0.1");

      defaultValue = 1;
    }
  }

  public class Setting_BloomThreshold : Setting_Bloom<float>
  {
    public override string FieldName => nameof(Bloom.threshold);

    public Setting_BloomThreshold()
    {
      options.AddMinMaxRangeValues("0", "5");
      options.AddStepSize("0.01");

      defaultValue = 1;
    }
  }

  public class Setting_BloomSoftKnee : Setting_Bloom<float>
  {
    public override string FieldName => nameof(Bloom.softKnee);

    public Setting_BloomSoftKnee()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");

      defaultValue = 0.5f;
    }
  }

  public class Setting_BloomClamp : Setting_Bloom<float>
  {
    public override string FieldName => nameof(Bloom.clamp);

    public Setting_BloomClamp()
    {
      options.AddMinMaxRangeValues("0", "100000");
      options.AddStepSize("10");

      defaultValue = 65472;
    }
  }

  public class Setting_BloomDiffusion : Setting_Bloom<float>
  {
    public override string FieldName => nameof(Bloom.diffusion);

    public Setting_BloomDiffusion()
    {
      options.AddMinMaxRangeValues("1", "10");
      options.AddStepSize("0.1");

      defaultValue = 7;
    }
  }

  public class Setting_BloomAnamorphicRatio : Setting_Bloom<float>
  {
    public override string FieldName => nameof(Bloom.anamorphicRatio);

    public Setting_BloomAnamorphicRatio()
    {
      options.AddMinMaxRangeValues("-1", "1");
      options.AddStepSize("0.01");
    }
  }

  public class Setting_BloomFastMode : Setting_Bloom<bool>
  {
    public override string FieldName => nameof(Bloom.fastMode);

    public Setting_BloomFastMode()
    {
      defaultValue = false;
    }
  }

  public class Setting_BloomDirtIntensity : Setting_Bloom<float>
  {
    public override string FieldName => nameof(Bloom.dirtIntensity);

    public Setting_BloomDirtIntensity()
    {
      options.AddMinMaxRangeValues("0", "5");
      options.AddStepSize("0.1");
    }
  }
}