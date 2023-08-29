using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricPlayerCombat : MonoBehaviour
{
    [SerializeField] private float attackDelay = 0.3f;
    public bool isAttacking;

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1)){
            Attack();
            isAttacking = true;
        } else {
            isAttacking = false;
        }
    }

    private void Attack()
    {
        
    }
}
