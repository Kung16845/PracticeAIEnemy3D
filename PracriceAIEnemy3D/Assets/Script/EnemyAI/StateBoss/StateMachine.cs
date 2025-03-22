using System;
using UnityEngine;

public class StateMachine : ScriptableObject
{   
    public string stateName;
    public virtual void EnterState(Enemy enemyBoss) { }
    public virtual void UpdateState(Enemy enemyBoss) { }
    public virtual void ExitState(Enemy enemyBoss) { }
}
