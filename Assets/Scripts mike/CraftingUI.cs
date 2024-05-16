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


    //UI Effects
    public GameObject Speedboost;
    public GameObject Speeddown;
    public GameObject CurResist;
    public GameObject CurWeakness;
    public GameObject DamegeType;

    public GameObject dashregenUP;
    public GameObject dashregenDOWN;
    public float DefaultEffectTimer;



    // other 
    public  EntityStats playerStatsScript;
    public GameObject DaMenu;
    AudioSource audioSource;
    public UIVisualise Vis;


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
            DaMenu.SetActive(false);
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
    public void Trashmethod()
    {
        trash = true;
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
                Vis.GETITOFF();

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
        if (itemVars[0]>= 1 && deligateEffect.Count<=2)
        {
        deligateEffect.Add(Effect1);
            Vis.VisualON0();
            itemVars[0]--;
        }
        else
        {
            audioSource.Play();
        }
        // Debug.Log("bruh1 added");
    }

    public void addIngredient2()
    {
        if (itemVars[2] >= 1 && deligateEffect.Count <= 2)
        {
        deligateEffect.Add(Effect2);
            Vis.VisualON2();
            itemVars[2]--;
        }
        else
        {
            audioSource.Play();
        }
        //Debug.Log("bruh2 added");
    }
    public void addIngredient3()
    {
        if (itemVars[6] >= 1 && deligateEffect.Count <= 2)
        {
            deligateEffect.Add(Effect3);
            Vis.VisualON6();
            itemVars[6]--;
        }
        else
        {
            audioSource.Play();
        }
        //  Debug.Log("bruh3 added");
    }

    public void addIngredient4()
    {
        if (itemVars[5] >= 1 && deligateEffect.Count <= 2)
        {
            deligateEffect.Add(Effect4);
            Vis.VisualON5();
            itemVars[5]--;
        }
        else
        {
            audioSource.Play();
        }
        //  Debug.Log("bruh4  added");
    }
    public void addIngredient5()
    {
        if (itemVars[4] >= 1 && deligateEffect.Count <= 2)
        {
            deligateEffect.Add(Effect5);
            Vis.VisualON4();
            itemVars[4]--;
        }
        else
        {
            audioSource.Play();
        }
        // Debug.Log("bruh5  added");
    }
    public void addIngredient6()
    {
        if (itemVars[3] >= 1 && deligateEffect.Count <= 2)
        {
            deligateEffect.Add(Effect6);
            Vis.VisualON3();
            itemVars[3]--;
        }
        else
        {
            audioSource.Play();
        }
        //  Debug.Log("bruh5  added");
    }
    public void addIngredient7()
    {
        if (itemVars[1] >= 1 && deligateEffect.Count <= 2  )
        {
            deligateEffect.Add(Effect7);
            Vis.VisualON1();
            itemVars[1]--;
        }
        else
        {
            audioSource.Play();
        }

        
            //  Debug.Log("bruh5  added");
    }

        public void Delete()
    {

        deligateEffect[0]();
        deligateEffect[1]();
        deligateEffect[2]();
        deligateEffect.Clear();
            Vis.VisualOFF0();
            trash = false;
     
    }




    

    void Effect1()//peperoni
    {
        Debug.Log("bruh1");

        playerStatsScript.SwapDamageType(damageType);
        playerStatsScript.staminaRegenSpeed = playerStatsScript.staminaRegenSpeed - 3;
        dashregenDOWN.SetActive(true);
        dashregenDOWN.transform.Find("fill").GetComponent<StatusProgressBar>().ActivateCD(DefaultEffectTimer);
        StartCoroutine(RegenDown(DefaultEffectTimer));

    }
    IEnumerator RegenDown(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerStatsScript.staminaRegenSpeed = playerStatsScript.entitySpeed + 3;
        dashregenDOWN.SetActive(false);
    }
    void Effect2()//olive 
    {
        Debug.Log("bruh2");

        Speeddown.SetActive(true);
        Speeddown.transform.Find("fill").GetComponent<StatusProgressBar>().ActivateCD(DefaultEffectTimer);


        playerStatsScript.SwapResistance(damageType2);
        playerStatsScript.entitySpeed = playerStatsScript.entitySpeed - 3;
        StartCoroutine(SpeedDebuff(DefaultEffectTimer));


    }
    IEnumerator SpeedDebuff(float delay)
    {
        yield return new WaitForSeconds(delay);
        Speeddown.SetActive(false);
        playerStatsScript.entitySpeed = playerStatsScript.entitySpeed + 3;
    }
    void Effect3()//peper
    {
        Debug.Log("bruh3");
       Speedboost.SetActive(true);
        Speedboost.transform.Find("fill").GetComponent<StatusProgressBar>().ActivateCD(DefaultEffectTimer);
        StartCoroutine(SpeedBoost(DefaultEffectTimer));
       
       playerStatsScript.entitySpeed = playerStatsScript.entitySpeed + 3;
        playerStatsScript.SwapResistance(null);
        playerStatsScript.health = playerStatsScript.health - 10;
    }
    IEnumerator SpeedBoost(float delay)
    {
        yield return new WaitForSeconds(delay);
        Speedboost.SetActive(false);
        playerStatsScript.entitySpeed = playerStatsScript.entitySpeed - 3;
    }

    void Effect4()//tomato
    {
        Debug.Log("bruh4");
        playerStatsScript.SwapResistance(damageType2);
        playerStatsScript.health += 5;
        playerStatsScript.SwapWeakness(null);

    }
    void Effect5()//cheese
    {
        Debug.Log("bruh5");
        playerStatsScript.SwapResistance(damageType);
        playerStatsScript.SwapWeakness(damageType3);
        
    }
    void Effect6()//shroom
    {
        Debug.Log("bruh6");
        playerStatsScript.health += 20;
        playerStatsScript.staminaRegenSpeed = playerStatsScript.staminaRegenSpeed - 3;
        dashregenDOWN.SetActive(true);
        dashregenDOWN.transform.Find("fill").GetComponent<StatusProgressBar>().ActivateCD(DefaultEffectTimer);
        StartCoroutine(RegenDown(DefaultEffectTimer));



    }
    void Effect7()//pinapple
    {
        Debug.Log("bruh7");
        DefaultEffectTimer += 5;
       StartCoroutine(AddTime(DefaultEffectTimer));


    }
    IEnumerator AddTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        DefaultEffectTimer -= 5;
    }

}
