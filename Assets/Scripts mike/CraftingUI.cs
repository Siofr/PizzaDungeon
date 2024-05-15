using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingUI : MonoBehaviour
{
    // deligates 
    delegate void AffectThePlayer();
    public bool MenuOpen;


    // other 
    private EntityStats playerStatsScript;


    [Header("DamageTypes")]
    [SerializeField] private DamageType damageType;
    [SerializeField] private DamageType damageType2;
    [SerializeField] private DamageType damageType3;


    List<AffectThePlayer> deligateEffect = new List<AffectThePlayer>(3);

    private void Awake()
    {
        playerStatsScript = GetComponent<EntityStats>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return) && MenuOpen)
        {
            if (deligateEffect.Count <= 2)
            {
                Debug.Log("Not 3 ingedients selected");
            }
            else
            {
                deligateEffect[0]();
                deligateEffect[1]();
                deligateEffect[2]();
                MenuOpen = false;

                for (int i = 0; i < deligateEffect.Count; i++)
                {
                    deligateEffect.Remove(deligateEffect[i]);
                    deligateEffect.Remove(deligateEffect[i]);
                    deligateEffect.Remove(deligateEffect[i]);
                }
            }
        }
    }

    public void addIngredient1()
    {
        deligateEffect.Add(Effect1);
    }

    public void addIngredient2()
    {
        deligateEffect.Add(Effect2);
    }
    public void addIngredient3()
    {
        deligateEffect.Add(Effect3);
    }

    public void addIngredient4()
    {
        deligateEffect.Add(Effect4);
    }

    public void Delete()
    {
        for (int i = 0; i < deligateEffect.Count; i++)
        {
           // deligateEffect.Remove(deligateEffect[i]);
            deligateEffect.Clear();
        }
    }





    void Effect1()
    {
        Debug.Log("bruh1");
        playerStatsScript.health = 10;
    }

    void Effect2()
    {
        Debug.Log("bruh2");
        playerStatsScript.health = playerStatsScript.health - 5;
    }

    void Effect3()
    {
        Debug.Log("bruh3");
        playerStatsScript.entitySpeed = playerStatsScript.entitySpeed + 3;
        playerStatsScript.SwapResistance(damageType2);
    }

    void Effect4()
    {
        Debug.Log("bruh4");
        playerStatsScript.SwapResistance(damageType);
    }

}
