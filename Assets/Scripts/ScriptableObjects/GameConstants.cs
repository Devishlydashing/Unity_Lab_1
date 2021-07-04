using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "GameConstants", menuName = "ScriptableObjects/GameConstants", order = 1)]
public class GameConstants : ScriptableObject 
{
    // Basic Geometry
    public float groundDistance = -4.35f;
    // Mario basic starting values
    public int playerMaxSpeed = 100;
    public int playerMaxJumpSpeed = 7;
    public int playerDefaultForce = 35;
    public float maxOffset = 10.0f;
    public float enemyPatroltime = 2.0f;
    public float groundSurface = -1.0f;
}