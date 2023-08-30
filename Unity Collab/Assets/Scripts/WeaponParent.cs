using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public SpriteRenderer characterRenderer, weaponRenderer;
    public Vector2 PointerPosition { get; set; }
    private Weapon weapon;
    public Animator animator;
    private bool attackBlocked;
    public float delay = 0.3f;
    public bool WeaponRotationStopped { get; private set; }

    private void Awake()
    {
        weapon = GetComponentInChildren<Weapon>();
    }

    private void AttackFinished()
    {
        WeaponRotationStopped = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (WeaponRotationStopped) 
            return;
    }

    public void PerformAnAttack()
    {
        if (weapon == null)
        {
            Debug.LogError("Weapon is null", gameObject);
            return;
        }
        WeaponRotationStopped = true;
    }

    public void Attack()
    {
        if (attackBlocked)
            return;
        animator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(DelayAttack());
    }

    private IEnumerator DelayAttack() 
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}

