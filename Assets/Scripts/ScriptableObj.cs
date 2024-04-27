using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Character", menuName ="Create Character")]
public class Scobj : ScriptableObject
{
    // Start is called before the first frame update
    public int CardNo;
    public String cardName, cardJob, cardInfo;
    public Sprite CharacterFoto;
    
}
