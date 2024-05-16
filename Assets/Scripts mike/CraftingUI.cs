using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class CraftingUI : MonoBehaviour
{
    // deligates 
    delegate void AffectThePlayer();
    public bool MenuOpen;
    public bool trash;

    // 0 pepperoni, 1 pineapple, 2 olive, 3 mushroom, 4 cheese, 5 tomato, 6 pepper
    public int[] itemVars;
    
    //Items vars
    public int peperoni;
    public int pineapple;
    public int olive;
    public int mushroom;
    public int cheese;
    public int tomato;
    public int pepper;

    




    // other 
    public  EntityStats playerStatsScript;
    public GameObject DaMenu;
    AudioSource audioSource;

    [Header("DamageTypes")]
    [SerializeField] private DamageType damageType;
    [SerializeField] private DamageType damageType2;
    [SerializeField] private DamageType damageType3;

    public TMP_Text DebugList;


    List<AffectThePlayer> deligateEffect = new List<AffectThePlayer>(3);

    private void Awake()
    {
       // playerStatsScript = GetComponent<EntityStats>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        

        // debug needs to be set to a button. a method with callback context 
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (!MenuOpen)
            {
                MenuOpen = true;
                DaMenu.SetActive(true);
                
            }
            else
            {
                MenuOpen = false;
                DaMenu.SetActive(false);
            }
        }
        if (!MenuOpen)
        {
            MenuOpen = false;
        }

        // debug list
        foreach (AffectThePlayer item  in deligateEffect)
        {
            Debug.Log(item.ToString());
        }

        string result = "List contents: ";
        foreach (AffectThePlayer item in deligateEffect)
        {
            result += item.ToString() + ", ";
        }
       // Debug.Log(result);
        DebugList.text = result;

    }

    public void Menu(InputAction.CallbackContext context)
    {
        if (!MenuOpen)
        {
            MenuOpen = true;
            DaMenu.SetActive(true);
            
        }
        else
        {
            MenuOpen = false;
            DaMenu.SetActive(false);
        }
        
    }
    public void Create()
    {
        
            if (deligateEffect.Count <= 2)
            {
                Debug.Log("Not 3 ingedients selected");
            
                audioSource.Play();
            
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

    public void addIngredient1()
    {
        if (peperoni >= 1)
        {
        deligateEffect.Add(Effect1);
        }
        else
        {
            audioSource.Play();
        }
        // Debug.Log("bruh1 added");
    }

    public void addIngredient2()
    {
        if (olive >= 1)
        {
        deligateEffect.Add(Effect2);

        }
        else
        {
            audioSource.Play();
        }
        //Debug.Log("bruh2 added");
    }
    public void addIngredient3()
    {
        if (pepper >= 1)
        {
            deligateEffect.Add(Effect3);
        }
        else
        {
            audioSource.Play();
        }
        //  Debug.Log("bruh3 added");
    }

    public void addIngredient4()
    {
        if (tomato >= 1)
        {
            deligateEffect.Add(Effect4);
        }
        else
        {
            audioSource.Play();
        }
        //  Debug.Log("bruh4  added");
    }
    public void addIngredient5()
    {
        if (cheese >= 1)
        {
            deligateEffect.Add(Effect5);
        }
        else
        {
            audioSource.Play();
        }
        // Debug.Log("bruh5  added");
    }
    public void addIngredient6()
    {
        if (mushroom >= 1)
        {
            deligateEffect.Add(Effect6);
        }
        else
        {
            audioSource.Play();
        }
        //  Debug.Log("bruh5  added");
    }
    public void addIngredient7()
    {
        if (pineapple >= 1)
        {
            deligateEffect.Add(Effect7);
        }
        else
        {
            audioSource.Play();
        }

        
            //  Debug.Log("bruh5  added");
    }

        public void Delete()
    {
        for (int i = 0; i < deligateEffect.Count; i++)
        {
           // deligateEffect.Remove(deligateEffect[i]);
            deligateEffect.Clear();
        }
    }




    // removal is currently not right cus you can dupe them kinda 

    void Effect1()
    {
        if (!trash)
        {
        Debug.Log("bruh1");
        itemVars[0]--; 
        playerStatsScript.health = 10;
        }
        else
        {
            // 0 pepperoni, 1 pineapple, 2 olive, 3 mushroom, 4 cheese, 5 tomato, 6 pepper
            itemVars[0]++;
            
        }
    }

    void Effect2()
    {
        Debug.Log("bruh2");
        itemVars[2]--;
        playerStatsScript.health = playerStatsScript.health - 5;
        
    }

    void Effect3()
    {
        Debug.Log("bruh3");
        itemVars[6]--;
       playerStatsScript.entitySpeed = playerStatsScript.entitySpeed + 3;
        playerStatsScript.SwapResistance(damageType2);
    }

    void Effect4()
    {
        Debug.Log("bruh4");
        itemVars[5]--;
        playerStatsScript.SwapResistance(damageType);
    }
    void Effect5()
    {
        Debug.Log("bruh5");
        itemVars[4]--;
        
    }
    void Effect6()
    {
        Debug.Log("bruh6");
        itemVars[3]--;

    }
    void Effect7()
    {
        Debug.Log("bruh7");
        itemVars[1]--;

    }

}
