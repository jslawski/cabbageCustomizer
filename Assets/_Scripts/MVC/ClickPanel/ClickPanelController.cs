using CharacterCustomizer;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickPanelController : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    private ClickPanelModel _model;
    private ClickPanelView _view;

    public Vector2 _panelOrigin;
    public Vector2 _panelDimensions;

    private Canvas _mainCanvas;

    [SerializeField]
    private SettingsPanelController _settingsPanelController;

    public bool _isDragging = false;

    private void Awake()
    {
        this._model = GetComponent<ClickPanelModel>();
        this._view = GetComponent<ClickPanelView>();
        this._mainCanvas = GetComponentInParent<Canvas>();
    }

    private void Start()
    {
        this.SetupPanelValues();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) == true)
        {
            this._isDragging = false;
        }
    }

    private void SetupPanelValues()
    {           
        RectTransform panelTransform = GetComponent<RectTransform>();

        Vector3[] worldCorners = new Vector3[4];

        panelTransform.GetWorldCorners(worldCorners);

        this._panelOrigin = new Vector2(worldCorners[0].x, worldCorners[0].y);
        this._panelDimensions = new Vector2(panelTransform.rect.width, panelTransform.rect.height);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerPress.name == "ClickPanel")
        {
            this.UpdateModelValuesWithMousePosition();
        }
        else
        {
            this.UpdateModelValuesWithSliderPositions();
        }

        this._settingsPanelController.UpdateAttributeSetting();

        this._view.UpdateView();

        this._isDragging = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.UpdateModelValuesWithMousePosition();

        this._settingsPanelController.UpdateAttributeSetting();

        this._view.UpdateView();

        this._isDragging = true;
    }

    private void UpdateModelValuesWithMousePosition()
    {
        Vector2 transposedMousePosition = this.GetTransposedMousePosition();
        float clampedX = Mathf.Clamp(transposedMousePosition.x, this._view.xSlider.minValue, this._view.xSlider.maxValue);
        float clampedY = Mathf.Clamp(transposedMousePosition.y, this._view.ySlider.minValue, this._view.ySlider.maxValue);
        
        this._model.UpdateValues(clampedX, clampedY);
    }

    private void UpdateModelValuesWithSliderPositions()
    { 
        this._model.UpdateValues(this._view.xSlider.value, this._view.ySlider.value);
    }

    //Returns the mouse's current position in "Click Panel Space"
    private Vector2 GetTransposedMousePosition()
    {       
        float xTranspose = ((Input.mousePosition.x - this._panelOrigin.x) / (this._panelDimensions.x));
        float yTranspose = ((Input.mousePosition.y - this._panelOrigin.y) / (this._panelDimensions.y));

        //Handle cases where player drags outside of the panel
        //Do I need this?
        if (xTranspose < 0.0f)
        {
            xTranspose = 0.0f;
        }
        if (xTranspose > 1.0f)
        {
            xTranspose = 1.0f;
        }
        
        if (yTranspose < 0.0f)
        {
            yTranspose = 0.0f;
        }
        if (yTranspose > 1.0f)
        {
            yTranspose = 1.0f;
        }

        float finalXTranspose = (xTranspose / this._mainCanvas.scaleFactor) - Mathf.Abs(this._view.xSlider.minValue);
        float finalYTranspose = (yTranspose / this._mainCanvas.scaleFactor) - Mathf.Abs(this._view.ySlider.minValue);

        return new Vector2(finalXTranspose, finalYTranspose); 
    }

    public void UpdateAttributeWithSlider()
    {
        if (this._isDragging == true)
        {
            return;
        }

        if (this._settingsPanelController.lastAttributeType != MasterController.instance.GetCurrentAttributeType())
        {
            this._settingsPanelController.lastAttributeType = MasterController.instance.GetCurrentAttributeType();
            return;
        }

        if (this._settingsPanelController.gameObject.activeSelf == true)
        {
            this.UpdateModelValuesWithSliderPositions();
            this._settingsPanelController.UpdateAttributeSetting();
        }
    }
}
