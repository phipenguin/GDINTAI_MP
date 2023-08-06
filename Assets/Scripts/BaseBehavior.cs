using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseBehavior : MonoBehaviour
{
    private GameObject core;
    private GameObject flag;
    [SerializeField] private bool isPlayerBase = false;

    private Collider2D collider;

    public UnityEvent<GameObject> OnHit = new UnityEvent<GameObject>();

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

        collider = GetComponent<Collider2D>();
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
            if (collision.gameObject.transform.parent.tag == "Enemy")
            {
                core.SetActive(false);
                flag.SetActive(true);
            }
        }
        else
        {
            if (collision.gameObject.transform.parent.tag == "Player")
            {
                core.SetActive(false);
                flag.SetActive(true);
            }
        }

        collider.enabled = false;

        OnHit.Invoke(this.gameObject);
    }
}