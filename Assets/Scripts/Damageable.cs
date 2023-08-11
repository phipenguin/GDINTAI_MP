using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public int maxHP = 3;
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
    public UnityEvent<GameObject> OnDead;

    // Start is called before the first frame update
    void Start()
    {
        Health = maxHP;
    }

    void Update()
    {
        if (Health <= 0)
        {
            GameManager.Instance.UpdateValues(this.gameObject);
            Dead();
        }
    }

    public void Hit()
    {
        Health--;
        OnHit.Invoke();
    }

    public void Dead()
    {
        OnDead.Invoke(this.gameObject);

        Health = maxHP;
    }
}
