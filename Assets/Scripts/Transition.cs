using UnityEngine;
using System;
using System.Collections;

public abstract class Transition : MonoBehaviour {

    public Action callback;

    public abstract void Discard ();
}
