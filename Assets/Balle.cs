using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle
{
    int numeroBalle;
    
    public int NumeroBalle
    {
        get => numeroBalle;
        set
        {
            numeroBalle = value;
        }
    }
    public Balle(int numeroBalle)
    {
        NumeroBalle = numeroBalle;
    }
}
