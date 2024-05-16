using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private int itemIndex;
    [SerializeField] private float magnetRange;
    [SerializeField] private float magnetPower;

    [SerializeField] private CraftingUI craftingUI;
    public GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= magnetRange)
        {
            transform.position = Vector3.Lerp(transform.position, player.transform.position, magnetPower * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            craftingUI.itemVars[itemIndex]++;
            gameObject.SetActive(false);
        }
    }
}
