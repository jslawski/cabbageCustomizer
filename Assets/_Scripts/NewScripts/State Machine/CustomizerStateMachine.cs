using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizerStateMachine : MonoBehaviour
{
    public CustomizerState currentState;

    // Start is called before the first frame update
    void Start()
    {
        this.currentState = new AttributeTypeState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
