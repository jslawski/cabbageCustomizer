using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickPanelController : MonoBehaviour, IPointerClickHandler, IDragHandler
{
    private ClickPanelModel _model;

    public Vector2 _panelOrigin;
    public Vector2 _panelDimensions;

    private Canvas _mainCanvas;

    private void Awake()
    {
        this._model = GetComponent<ClickPanelModel>();
        this._mainCanvas = GetComponentInParent<Canvas>();        
    }

    private void Start()
    {
        this.SetupPanelValues();
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
        this.UpdateModelValues();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.UpdateModelValues();
    }

    private void UpdateModelValues()
    {
        Vector2 transposedMousePosition = this.GetTransposedMousePosition();

        this._model.UpdateValues(transposedMousePosition.x, transposedMousePosition.y);
    }

    //Returns the mouse's current position in "Click Panel Space"
    //The X and Y values are between 0 and 1
    private Vector2 GetTransposedMousePosition()
    {       
        float xTranspose = (Input.mousePosition.x - this._panelOrigin.x) / this._panelDimensions.x;
        float yTranspose = (Input.mousePosition.y - this._panelOrigin.y) / this._panelDimensions.y;

        //Handle cases where player drags outside of the panel
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

        return new Vector2(xTranspose / this._mainCanvas.scaleFactor, yTranspose / this._mainCanvas.scaleFactor);
    }
}
