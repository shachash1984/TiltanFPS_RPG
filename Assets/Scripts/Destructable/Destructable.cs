using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Destructable : MonoBehaviour
{

    public delegate void DamageAction(float damage, Vector3 shotDirection);

    public event Action<float, Vector3> OnTakeDamage;
    public event Action OnDestruction;

    [Range(0, 1000)]
    [SerializeField]
    private int maxHP = 100;
    [Range(0, 1000)]
    [SerializeField]
    private int currentHP = 100;
    public float destructionDelay = 3f;
    public float HPRatio
    {
        get { return (float)currentHP / maxHP; }
        private set { HPRatio = value; }
    }

    private void Start()
    {
        if (currentHP > maxHP)
            currentHP = maxHP;
    }

    public bool TakeDamage(int dmg, Vector3 shotDirection)
    {
        if (dmg <= 0)
            return false;
        currentHP -= dmg;
        if (OnTakeDamage != null)
            OnTakeDamage(HPRatio, shotDirection);
        if (currentHP <= 0)
        {
            currentHP = 0;
            Destruction();
            return true;
        }
        return false;
    }

    public void Destruction()
    {
        if (OnDestruction != null)
            OnDestruction();
        if (gameObject)
            Destroy(gameObject, destructionDelay);
    }
}
