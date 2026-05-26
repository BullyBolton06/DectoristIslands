using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInputs playerInputs;

    public void Start()
    {
        playerInputs = new PlayerInputs();
        
    }
}
