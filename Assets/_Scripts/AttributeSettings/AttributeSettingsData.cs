[System.Serializable]
public class AttributeSettingsData
{
    public string name = "";
    public float horPos = 0.0f;
    public float verPos = 0.0f;
    public float scaleX = 1.0f;
    public float scaleY = 1.0f;
    public float rot = 0.0f;
    public int dep = 0;
    public int[] colors;
    public bool flipX = false;
    public bool flipY = false;

    public AttributeSettingsData()
    {
        this.name = "";
        this.horPos = 0.0f;
        this.verPos = 0.0f;
        this.scaleX = 1.0f;
        this.scaleY = 1.0f;
        this.rot = 0.0f;
        this.dep = 0;
        this.colors = new int[3];
        this.flipX = false;
        this.flipY = false;
    }

    public AttributeSettingsData(AttributeSettingsData dataToCopy)
    {
        this.name = dataToCopy.name;
        this.horPos = dataToCopy.horPos;
        this.verPos = dataToCopy.verPos;
        this.scaleX = dataToCopy.scaleX;
        this.scaleY = dataToCopy.scaleY;
        this.rot = dataToCopy.rot;
        this.dep = dataToCopy.dep;
        this.colors = dataToCopy.colors;
        this.flipX = dataToCopy.flipX;
        this.flipY = dataToCopy.flipY;
    }
}