using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerCombat : MonoBehaviour
{
    [SerializeField] private float attackDelay = 0.3f;

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            Attack();
        }
    }

    private void Attack()
    {
        
    }
}
