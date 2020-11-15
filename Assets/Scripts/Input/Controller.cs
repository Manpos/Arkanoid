using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class Controller : MonoBehaviour
{
    public abstract void Left();

    public abstract void Right();

    public abstract void Up();
    
    public abstract void Down();

    public abstract void Pause();
}
