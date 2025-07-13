using CitrioN.Common;
using UnityEngine.Rendering.PostProcessing;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(810)]
  [MenuPath("Post Processing/Chromatic Aberration")]
  public abstract class Setting_ChromaticAberration<T1> : Setting_PostProcessing<T1, ChromaticAberration>
  {
    //public override string RuntimeName => base.RuntimeName.Replace("Chromatic Aberration ", "");
  }

  [MenuOrder(810)]
  [MenuPath("Post Processing/Chromatic Aberration")]
  public class Setting_ChromaticAberrationActive : Setting_PostProcessing_Direct<bool, ChromaticAberration>
  {
    public override string FieldName => nameof(ChromaticAberration.active);
  }

  public class Setting_ChromaticAberrationEnabled : Setting_ChromaticAberration<bool>
  {
    public override string FieldName => nameof(ChromaticAberration.enabled);
  }

  public class Setting_ChromaticAberrationIntensity : Setting_ChromaticAberration<float>
  {
    public override string FieldName => nameof(ChromaticAberration.intensity);

    public Setting_ChromaticAberrationIntensity()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
    }
  }

  public class Setting_ChromaticAberrationFastMode : Setting_ChromaticAberration<bool>
  {
    public override string FieldName => nameof(ChromaticAberration.fastMode);

    public Setting_ChromaticAberrationFastMode()
    {
      defaultValue = false;
    }
  }
}