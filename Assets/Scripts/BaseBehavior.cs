using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseBehavior : MonoBehaviour
{
    private GameObject core;
    private GameObject flag;
    [SerializeField] private bool isPlayerBase = false;

    public UnityEvent<Collider2D> OnHit = new UnityEvent<Collider2D>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if (isPlayerBase && this.gameObject.transform.GetChild(i).name == "PlayerCore")
                core = this.gameObject.transform.GetChild(i).gameObject;
            else if (isPlayerBase && this.gameObject.transform.GetChild(i).name == "EnemyFlag")
                flag = this.gameObject.transform.GetChild(i).gameObject;

            else if (!isPlayerBase && this.gameObject.transform.GetChild(i).name == "EnemyCore")
                core = this.gameObject.transform.GetChild(i).gameObject;
            else if (!isPlayerBase && this.gameObject.transform.GetChild(i).name == "PlayerFlag")
                flag = this.gameObject.transform.GetChild(i).gameObject;
        }

        core.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with " + collision.name);

        if (isPlayerBase)
        {
            if (collision.name == "EnemyTank")
            {
                core.SetActive(false);
                flag.SetActive(true);
            }
        }
        else
        {
            if (collision.name == "PlayerTank")
            {
                core.SetActive(false);
                flag.SetActive(true);
            }
        }

        OnHit.Invoke(collision);
    }
}
