using CitrioN.Common;
using CitrioN.Common.Editor;
using UnityEditor;

namespace CitrioN.SettingsMenuCreator.PostProcessing.Editor
{
  [InitializeOnLoad]
  public static class PostProcessingLayerDialogPopup
  {
    private const string POST_PROCESSING_LAYER_NAME = "PostProcessing";

    //static PostProcessingLayerDialogPopup()
    //{
    //  if (EditorApplication.isPlaying) { return; }
    //  if (!LayerUtilities.IsLayerInProject(POST_PROCESSING_LAYER_NAME))
    //  {
    //    ShowPostProcessingLayerDialog();//
    //  }
    //}

    [MenuItem("Tools/CitrioN/Settings Menu Creator/Dependencies/Add Post Processing Layer")]
    private static void ShowPostProcessingLayerDialog()
    {
      DialogUtilities.DisplayDialog($"Add Post Processing Layer?",
        $"It is recommended to use a dedicated layer on your post processing volumes for better performance.\n" +
        $"Would you like to add a new layer called '{POST_PROCESSING_LAYER_NAME}' to your project?",
        "Add Layer", "Don't Add", () => LayerUtilities.AddLayerToProject(POST_PROCESSING_LAYER_NAME), null);
    }
  }
}