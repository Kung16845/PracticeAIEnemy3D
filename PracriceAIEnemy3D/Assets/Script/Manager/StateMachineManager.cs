using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateMachineManager : MonoBehaviour
{   
    [SerializeReference]
    public List<StateMachine> All_state_Machines = new List<StateMachine>();

    public StateMachine GetStateEnemyByName(string name)
    {   
        Debug.Log(All_state_Machines.FirstOrDefault(state => state.stateName == name).stateName);
        return All_state_Machines.FirstOrDefault(state => state.stateName == name);
    }    

}
