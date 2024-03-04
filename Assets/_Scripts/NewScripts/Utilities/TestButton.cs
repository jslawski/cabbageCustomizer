using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField]
    private PanelButton _panelButton;
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            this._panelButton.Reveal();
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            this._panelButton.Hide();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            this._panelButton.EnableButton();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            this._panelButton.DisableButton(true);
        }
    }
}
