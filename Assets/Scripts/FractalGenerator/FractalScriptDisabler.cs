using UnityEngine;

public class FractalScriptDisabler : MonoBehaviour
{
    public Dragable leftDragable;
    public Dragable rightDragable;
    public JoinHandles joinHandles;

    public void DisableFractalScripts()
    {
        leftDragable.enabled = false;
        rightDragable.enabled = false;
        joinHandles.enabled = false;
    }

    public void EnableFractalScripts()
    {
        leftDragable.enabled = true;
        rightDragable.enabled = true;
        joinHandles.enabled = true;
    }

}
