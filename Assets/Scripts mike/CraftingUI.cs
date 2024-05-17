using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class CraftingUI : MonoBehaviour
{
    // deligates 
    delegate void AffectThePlayer();
    public bool MenuOpen;
    public bool trash;

    // 0 pepperoni, 1 pineapple, 2 olive, 3 mushroom, 4 cheese, 5 tomato, 6 pepper
    public int[] itemVars;
    public ChangeTypePic Changepic;

    //GunSO
    public GunScriptableObject Pistol;
    public GunScriptableObject Shotgun;


    //UI Effects
    public GameObject Speedboost;
    public GameObject Speeddown;
    public GameObject CurResist;
    public GameObject CurWeakness;
    public GameObject DamegeType;

    public GameObject FirerateUP;
    public GameObject FirerateDown;



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
        if (!trash)
        {
     Debug.Log("bruh1");

            playerStatsScript.SwapDamageType(damageType);
            Changepic.ChangePicDtype(damageType);
            playerStatsScript.staminaRegenSpeed = playerStatsScript.staminaRegenSpeed - 3;
            dashregenDOWN.SetActive(true);
            dashregenDOWN.transform.Find("fill").GetComponent<StatusProgressBar>().ActivateCD(DefaultEffectTimer);
            StartCoroutine(RegenDown(DefaultEffectTimer));
        }
       else
        {
            itemVars[0]++;
        }

    }
    IEnumerator RegenDown(float delay)
    {
        yield return new WaitForSeconds(delay);
        playerStatsScript.staminaRegenSpeed = playerStatsScript.entitySpeed + 3;
        dashregenDOWN.SetActive(false);
    }
    void Effect2()//olive 
    {
        if (!trash)
        {
            Debug.Log("bruh2");

            Speeddown.SetActive(true);
            Speeddown.transform.Find("fill").GetComponent<StatusProgressBar>().ActivateCD(DefaultEffectTimer);
            FirerateUP.transform.Find("fill").GetComponent<StatusProgressBar>().ActivateCD(DefaultEffectTimer);

            playerStatsScript.SwapResistance(damageType2);
            Changepic.ChangePicResist(damageType2);
            playerStatsScript.entitySpeed = playerStatsScript.entitySpeed - 3;
            Pistol.fireRate -= 0.20f;
            Shotgun.fireRate -= 0.20f;
            FirerateUP.SetActive(true);


            StartCoroutine(SpeedDebuff(DefaultEffectTimer));
            StartCoroutine(FireRateBuff(DefaultEffectTimer));
        }
        else
        {
            itemVars[2]++;
        }


    }
    IEnumerator FireRateBuff(float delay)
    {
        yield return new WaitForSeconds(delay);
        Pistol.fireRate += 0.20f;
        Shotgun.fireRate += 0.20f;
        FirerateUP.SetActive(false);
    }
    IEnumerator SpeedDebuff(float delay)
    {
        yield return new WaitForSeconds(delay);
        Speeddown.SetActive(false);
        playerStatsScript.entitySpeed = playerStatsScript.entitySpeed + 3;
    }
    void Effect3()//peper
    {
        if (!trash)
        {
            Debug.Log("bruh3");
            Speedboost.SetActive(true);
            Speedboost.transform.Find("fill").GetComponent<StatusProgressBar>().ActivateCD(DefaultEffectTimer);
            StartCoroutine(SpeedBoost(DefaultEffectTimer));

            playerStatsScript.entitySpeed = playerStatsScript.entitySpeed + 3;
            playerStatsScript.SwapResistance(null);
            Changepic.ChangePicResist(null);
            playerStatsScript.ChangeHealth(-10, null);
        }
        else
        {
            itemVars[6]++;
        }
    }
    IEnumerator SpeedBoost(float delay)
    {
        yield return new WaitForSeconds(delay);
        Speedboost.SetActive(false);
        playerStatsScript.entitySpeed = playerStatsScript.entitySpeed - 3;
    }

    void Effect4()//tomato
    {
        if (!trash)
        {
            Debug.Log("bruh4");
            playerStatsScript.SwapResistance(damageType2);
            playerStatsScript.health += 5;
            playerStatsScript.SwapWeakness(null);
            Changepic.ChangePicWeak(null);
            Changepic.ChangePicResist(damageType2);
        }
        else
        {
            itemVars[5]++;
        }

    }
    void Effect5()//cheese
    {
        if (!trash)
        {
            Debug.Log("bruh5");
            playerStatsScript.SwapResistance(damageType);
            playerStatsScript.SwapWeakness(damageType3);
            Changepic.ChangePicWeak(damageType3);
            Changepic.ChangePicResist(damageType);
        }
        else
        {
            itemVars[4]++;
        }
    }
    void Effect6()//shroom
    {
        if (!trash)
        {
            Debug.Log("bruh6");
            // playerStatsScript.health += 20;
            playerStatsScript.ChangeHealth(+20, null);
            playerStatsScript.staminaRegenSpeed = playerStatsScript.staminaRegenSpeed - 3;
            dashregenDOWN.SetActive(true);
            dashregenDOWN.transform.Find("fill").GetComponent<StatusProgressBar>().ActivateCD(DefaultEffectTimer);
            StartCoroutine(RegenDown(DefaultEffectTimer));
        }
        else
        {
            itemVars[3]++;
        }



    }
    void Effect7()//pinapple
    {
        if (!trash)
        {
            Debug.Log("bruh7");
            DefaultEffectTimer += 5;
            StartCoroutine(AddTime(DefaultEffectTimer));
        }
        else
        {
            itemVars[1]++;
        }


    }
    IEnumerator AddTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        DefaultEffectTimer -= 5;
    }

}
