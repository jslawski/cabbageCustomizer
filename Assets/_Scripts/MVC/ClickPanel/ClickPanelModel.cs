using UnityEngine;

public class ClickPanelModel : MonoBehaviour
{
    [HideInInspector]
    public bool xLocked = false;
    [HideInInspector]
    public bool yLocked = false;
    public float xValue = 0.0f;
    public float yValue = 0.0f;

    public void UpdateValues(float xValue, float yValue)
    {
        if (this.xLocked == false)
        {
            this.xValue = xValue;
        }

        if (this.yLocked == false)
        {
            this.yValue = yValue;
        }
    }
}
