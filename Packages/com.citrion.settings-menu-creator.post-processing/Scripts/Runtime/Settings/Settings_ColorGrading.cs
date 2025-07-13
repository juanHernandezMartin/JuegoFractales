using CitrioN.Common;
using UnityEngine.Rendering.PostProcessing;
using CustomDisplayName = System.ComponentModel.DisplayNameAttribute;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(810)]
  [MenuPath("Post Processing/Color Grading")]
  public abstract class Setting_ColorGrading<T1> : Setting_PostProcessing<T1, ColorGrading>
  {
    //public override string RuntimeName => base.RuntimeName.Replace("Color Grading ", "");
  }

  [MenuOrder(810)]
  [MenuPath("Post Processing/Color Grading")]
  public class Setting_ColorGradingActive : Setting_PostProcessing_Direct<bool, ColorGrading>
  {
    public override string FieldName => nameof(ColorGrading.active);
  }

  public class Setting_ColorGradingEnabled : Setting_ColorGrading<bool>
  {
    public override string FieldName => nameof(ColorGrading.enabled);
  }

  public class Setting_ColorGradingMode : Setting_ColorGrading<GradingMode>
  {
    public override string FieldName => nameof(ColorGrading.gradingMode);

    public Setting_ColorGradingMode()
    {
      defaultValue = GradingMode.HighDefinitionRange;
    }
  }

  // Requires LDR
  [CustomDisplayName("Color Grading LDR LUT Contribution")]
  public class Setting_ColorGradingLDRLUTContribution : Setting_ColorGrading<float>
  {
    public override string RuntimeName => "Color Grading LDR LUT Contribution";

    public override string EditorName => "Color Grading LDR LUT Contribution";

    public override string FieldName => nameof(ColorGrading.ldrLutContribution);

    public Setting_ColorGradingLDRLUTContribution()
    {
      options.AddMinMaxRangeValues("0", "1");
      options.AddStepSize("0.01");
      options.AddOneHundredMultiplierAndPercent();

      defaultValue = 1;
    }
  }

  // Requires LDR
  public class Setting_ColorGradingBrigthness : Setting_ColorGrading<float>
  {
    public override string FieldName => nameof(ColorGrading.brightness);

    public Setting_ColorGradingBrigthness()
    {
      options.AddMinMaxRangeValues("-100", "100");
      options.AddStepSize("1");
    }
  }

  // Requires HDR
  public class Setting_ColorGradingToneMapping : Setting_ColorGrading<Tonemapper>
  {
    public override string FieldName => nameof(ColorGrading.tonemapper);

    public Setting_ColorGradingToneMapping()
    {
      options.Clear();
      options.Add(new StringToStringRelation("None", "None"));
      options.Add(new StringToStringRelation("Neutral", "Neutral"));
      options.Add(new StringToStringRelation("ACES", "ACES"));
      options.Add(new StringToStringRelation("Custom", "Custom"));
    }
  }

  // Requires HDR
  public class Setting_ColorGradingPostExposure : Setting_ColorGrading<float>
  {
    public override string FieldName => nameof(ColorGrading.postExposure);

    public Setting_ColorGradingPostExposure()
    {
      options.AddMinMaxRangeValues("-7", "3");
      options.AddStepSize("0.1");
    }
  }

  public class Setting_ColorGradingContrast : Setting_ColorGrading<float>
  {
    public override string FieldName => nameof(ColorGrading.contrast);

    public Setting_ColorGradingContrast()
    {
      options.AddMinMaxRangeValues("-100", "100");
      options.AddStepSize("1");
    }
  }

  public class Setting_ColorGradingHueShift : Setting_ColorGrading<float>
  {
    public override string FieldName => nameof(ColorGrading.hueShift);

    public Setting_ColorGradingHueShift()
    {
      options.AddMinMaxRangeValues("-180", "180");
      options.AddStepSize("1");
    }
  }

  public class Setting_ColorGradingSaturation : Setting_ColorGrading<float>
  {
    public override string FieldName => nameof(ColorGrading.saturation);

    public Setting_ColorGradingSaturation()
    {
      options.AddMinMaxRangeValues("-100", "100");
      options.AddStepSize("1");
    }
  }

  public class Setting_ColorGradingTemperature : Setting_ColorGrading<float>
  {
    public override string FieldName => nameof(ColorGrading.temperature);

    public Setting_ColorGradingTemperature()
    {
      options.AddMinMaxRangeValues("-100", "100");
      options.AddStepSize("1");
    }
  }

  public class Setting_ColorGradingTint : Setting_ColorGrading<float>
  {
    public override string FieldName => nameof(ColorGrading.tint);

    public Setting_ColorGradingTint()
    {
      options.AddMinMaxRangeValues("-100", "100");
      options.AddStepSize("1");
    }
  }
}