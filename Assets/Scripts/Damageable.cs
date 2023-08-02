using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public int maxHP = 1;
    [SerializeField] private int currentHP;

    public int Health
    {
        get { return currentHP; }
        set
        {
            currentHP = value;
        }
    }

    public UnityEvent OnHit;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void Hit()
    {
        currentHP = 0;
        OnHit.Invoke();
    }
}
