using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void Add_score();

public delegate void End_game();


public class Administrator_game : Singleton<Administrator_game>
{
    public Add_score D_Add_score;

    public End_game D_End_game;
}
