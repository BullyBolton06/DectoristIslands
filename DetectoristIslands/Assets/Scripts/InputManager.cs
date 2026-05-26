using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    public static InputManager instance { get; private set; }
    
    public PlayerInputs playerInputs {get; private set;}

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //right now there's only the main gameplay, eventually enabling the different control schemes will be done in more flexible way
           InitialiseInputs();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    
    private void InitialiseInputs()
    {
        playerInputs = new PlayerInputs();
        playerInputs.Detecting.Enable();
    }
    
}
