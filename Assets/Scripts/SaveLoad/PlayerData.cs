using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int highScore;
    public int coins;

    public override string ToString()
    {
        return $"{highScore} {coins}";
    }
}
