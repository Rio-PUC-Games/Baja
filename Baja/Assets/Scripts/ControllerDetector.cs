﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Luminosity.IO;

public class ControllerDetector : MonoBehaviour
{
    private int numControllers = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if(Input.GetJoystickNames().Length != numControllers) UpdateControllers();   
    }

    void UpdateControllers(){
        numControllers = Input.GetJoystickNames().Length;
        if(numControllers > 0){
            string name = Input.GetJoystickNames()[0]; //guarda nome do controle 1
            if(name.ToLower().Contains("xbox one")){ //checa se é controle do xbox one (o ToLower é pra evitar problemas com case sensitive)
                InputManager.SetControlScheme("XboxOne", PlayerID.One);
            }
            else if(name.ToLower().Contains("playstation 4")){ //checa se é controle do xbox one (o ToLower é pra evitar problemas com case sensitive)
                InputManager.SetControlScheme("PS4", PlayerID.One);
            }
            else{ //se não for, usa o esquema de xbox/ps3
                InputManager.SetControlScheme("PS3/XBOX360", PlayerID.One);
            }
        }
        else{ //não há controles conectados
            InputManager.SetControlScheme("Teclado", PlayerID.One);
        }
    }
}