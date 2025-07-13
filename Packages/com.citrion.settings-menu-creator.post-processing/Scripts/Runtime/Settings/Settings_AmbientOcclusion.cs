using CitrioN.Common;
using UnityEngine.Rendering.PostProcessing;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(810)]
  [MenuPath("Post Processing/Ambient Occlusion")]
  public abstract class Setting_AmbientOcclusion<T1> : Setting_PostProcessing<T1, AmbientOcclusion>
  {
    //public override string RuntimeName => base.RuntimeName.Replace("Ambient Occlusion ", "");
  }

  [MenuOrder(810)]
  [MenuPath("Post Processing/Ambient Occlusion")]
  public class Setting_AmbientOcclusionActive : Setting_PostProcessing_Direct<bool, AmbientOcclusion>
  {
    public override string FieldName => nameof(AmbientOcclusion.active);
  }

  public class Setting_AmbientOcclusionEnabled : Setting_AmbientOcclusion<bool>
  {
    public override string FieldName => nameof(AmbientOcclusion.enabled);
  }

  public class Setting_AmbientOcclusionMode : Setting_AmbientOcclusion<AmbientOcclusionMode>
  {
    public override string FieldName => nameof(AmbientOcclusion.mode);

    public Setting_AmbientOcclusionMode()
    {
      defaultValue = AmbientOcclusionMode.MultiScaleVolumetricObscurance;
    }
  }

  public class Setting_AmbientOcclusionIntensity : Setting_AmbientOcclusion<float>
  {
    public override string FieldName => nameof(AmbientOcclusion.intensity);

    public Setting_AmbientOcclusionIntensity()
    {
      options.AddMinMaxRangeValues("0", "4");
      options.AddStepSize("0.01");
    }
  }

  public class Setting_AmbientOcclusionRadius : Setting_AmbientOcclusion<float>
  {
    public override string FieldName => nameof(AmbientOcclusion.radius);

    public Setting_AmbientOcclusionRadius()
    {
      options.AddMinMaxRangeValues("0", "10");
      options.AddStepSize("0.1");
    }
  }

  public class Setting_AmbientOcclusionQuality : Setting_AmbientOcclusion<AmbientOcclusionQuality>
  {
    public override string FieldName => nameof(AmbientOcclusion.quality);
  }

  public class Setting_AmbientOcclusionAmbientOnly : Setting_AmbientOcclusion<bool>
  {
    public override string FieldName => nameof(AmbientOcclusion.ambientOnly);
  }

  // TODO Enable once color picker support is added
  //public class Setting_AmbientOcclusionColor : Setting_AmbientOcclusion<UnityEngine.Color>
  //{
  //  public override string FieldName => nameof(AmbientOcclusion.color);
  //}

  // TODO Enable once HDRP support is added
  //public class Setting_AmbientOcclusionDirectLightingStrength : Setting_AmbientOcclusion<float>
  //{
  //  public override string FieldName => nameof(AmbientOcclusion.directLightingStrength);
  //}

  public class Setting_AmbientOcclusionThicknessModifier : Setting_AmbientOcclusion<float>
  {
    public override string FieldName => nameof(AmbientOcclusion.thicknessModifier);

    public Setting_AmbientOcclusionThicknessModifier()
    {
      options.AddMinMaxRangeValues("0", "2");
      options.AddStepSize("0.01");

      defaultValue = 1;
    }
  }
}