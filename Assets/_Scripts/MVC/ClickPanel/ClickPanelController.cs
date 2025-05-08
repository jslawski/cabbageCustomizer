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

    private bool _isDragging = false;

    private bool _clicked = false;

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
            this._clicked = true;
            this.UpdateModelValuesWithMousePosition();
        }
        else
        {
            this.UpdateModelValuesWithSliderPositions();
        }

        this._view.UpdateView();

        this._settingsPanelController.UpdateAttributeSetting();

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
        float xSliderValue = Mathf.Lerp(this._view.xSlider.minValue, this._view.xSlider.maxValue, transposedMousePosition.x);
        float ySliderValue = Mathf.Lerp(this._view.ySlider.minValue, this._view.ySlider.maxValue, transposedMousePosition.y);
        
        this._model.UpdateValues(xSliderValue, ySliderValue);
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

        float scaledXTranspose = xTranspose / this._mainCanvas.scaleFactor;
        float scaledYTranspose = yTranspose / this._mainCanvas.scaleFactor;

        scaledXTranspose = Mathf.Clamp(scaledXTranspose, 0.0f, 1.0f);
        scaledYTranspose =  Mathf.Clamp(scaledYTranspose, 0.0f, 1.0f);

        return new Vector2(scaledXTranspose, scaledYTranspose); 
    }

    public void UpdateAttributeWithSlider()
    {
        if (this._isDragging == true)
        {
            return;
        }

        if (this._clicked == true)
        {
            this._clicked = false;
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
