using CitrioN.Common;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using static UnityEngine.Rendering.PostProcessing.PostProcessLayer;

namespace CitrioN.SettingsMenuCreator.PostProcessing
{
  [MenuOrder(890)]
  [MenuPath("Post Processing/Layer")]
  public abstract class Setting_PostProcessingLayer<T1> : Setting_Generic_Reflection_Field_Unity<T1, PostProcessLayer>
  {
    public override string EditorNamePrefix => "[PP]";

    [SerializeField]
    protected bool cacheCamera = false;

    [SerializeField]
    protected bool cacheLayer = false;

    protected bool isCameraCached = false;
    protected bool isLayerCached = false;

    // TODO Should some initialization method reset this?
    // like on game start?
    protected Camera camera;

    protected PostProcessLayer layer;

    public virtual Camera Cam
    {
      get
      {
        if (isCameraCached) { return camera; }
        else
        {
          var cam = Camera.main;
          if (cacheCamera)
          {
            camera = cam;
          }
          return cam;
        }
      }
    }

    public virtual PostProcessLayer Layer
    {
      get
      {
        if (isLayerCached) { return layer; }
        else
        {
          var l = FindPostProcessLayer();
          if (cacheLayer)
          {
            layer = l;
          }
          return l;
        }
      }
    }

    public override bool StoreValueInternally => false;

    protected virtual PostProcessLayer FindPostProcessLayer()
    {
      var camera = Cam;
      var layer = camera != null ? camera.GetComponent<PostProcessLayer>() : null;
      if (layer == null)
      {
#if UNITY_2023_1_OR_NEWER
        layer = GameObject.FindAnyObjectByType<PostProcessLayer>();
#else
        layer = GameObject.FindObjectOfType<PostProcessLayer>();
#endif
      }
      return layer;
    }

    public override object GetObject(SettingsCollection settings)
    {
      var l = Layer;
      if (l == null)
      {
        ConsoleLogger.LogWarning($"No post processing layer found for {GetType().Name}");
      }
      return l;
    }
  }

  public class Setting_AntiAliasingMode : Setting_PostProcessingLayer<Antialiasing>
  {
    public override string FieldName => nameof(PostProcessLayer.antialiasingMode);

    public Setting_AntiAliasingMode()
    {
      options.Clear();
      options.Add(new StringToStringRelation("None", "Disabled"));
      options.Add(new StringToStringRelation("FastApproximateAntialiasing", "Fast Approximate (FXAA)"));
      options.Add(new StringToStringRelation("SubpixelMorphologicalAntialiasing", "Subpixel Morphological (SMAA)"));
      options.Add(new StringToStringRelation("TemporalAntialiasing", "Temporal (TAA)"));
    }
  }

  [System.ComponentModel.DisplayName("Stop NaN Propagation")]
  public class Setting_StopNaNPropagation : Setting_PostProcessingLayer<bool>
  {
    public override string RuntimeName => "Stop NaN Propagation";

    public override string EditorName => "Stop NaN Propagation";

    public override string FieldName => nameof(PostProcessLayer.stopNaNPropagation);
  }

  public class Setting_DirectlyToCameraTarget : Setting_PostProcessingLayer<bool>
  {
    public override string FieldName => nameof(PostProcessLayer.finalBlitToCameraTarget);

    public Setting_DirectlyToCameraTarget()
    {
      defaultValue = false;
    }
  }

  // TODO Enable if multi selection input element and layermask support is added
  //public class VolumeLayerSetting : PostProcessingLayerSetting<LayerMask>
  //{
  //  public override string FieldName => nameof(PostProcessLayer.volumeLayer);
  //}

  public class Setting_BreakBeforeColorGrading : Setting_PostProcessingLayer<bool>
  {
    public override string FieldName => nameof(PostProcessLayer.breakBeforeColorGrading);

    public Setting_BreakBeforeColorGrading()
    {
      defaultValue = false;
    }
  }

  // TODO Look into adding the fog related settings
}