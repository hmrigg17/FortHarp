using UnityEngine;
using System;
using System.Collections;

public abstract class Transition : MonoBehaviour {

    // Public Variables
    // The function to be called after the transition is completed
    public Action callback;

    
    // Abstract Functions
    public abstract void Discard ();
}
