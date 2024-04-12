using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PizzaCraftInputs : MonoBehaviour
{
    //deligate define 
    delegate void AffectThePlayer();
    delegate void RenderIngredient();
    public bool MenuOpen;


    //UI stuff
    public GameObject DaMenu;
    public GameObject Ingredient1;
    public GameObject Ingredient2;
    public GameObject Ingredient3;
    public GameObject Ingredient4;

    //Input stuff and entity
    public PlayerInputs playerInputs;
    private EntityStats playerStatsScript;
    private PlayerController playerController;
    private InputAction menu;

    [Header("DamageTypes")]
    [SerializeField] private DamageType damageType;
    [SerializeField] private DamageType damageType2;
    [SerializeField] private DamageType damageType3;



    List<AffectThePlayer> deligateEffect = new List<AffectThePlayer>(3);
    List<RenderIngredient> DelegateRender = new List<RenderIngredient>(3);
    private void Awake()
    {
        playerInputs = new PlayerInputs();
        playerStatsScript = GetComponent<EntityStats>();
        playerController = GetComponent<PlayerController>();
        menu = playerInputs.Player.Menu;
        menu.Enable();
    }


    private void Update()
    {
        /*
        if (Input.GetKeyUp(KeyCode.E))
        {

            if (!MenuOpen)
            {
                MenuOpen = true;
                DaMenu.SetActive(true);
                playerInputs.Disable();
            }
            else
            {
                MenuOpen = false;
                DaMenu.SetActive(false);
                playerInputs.Enable();
            }



        }
        */
        if (MenuOpen)
        {
            CreateList();
        }
        if (!MenuOpen)
        {
            MenuOpen = false;
            DaMenu.SetActive(false);
        }





        //Enter to activate the pizzer
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
    public void Menu(InputAction.CallbackContext context)
    {
       

            if (!MenuOpen)
            {
                MenuOpen = true;
                DaMenu.SetActive(true);
                playerInputs.Disable();
            }
            else
            {
                MenuOpen = false;
                DaMenu.SetActive(false);
                playerInputs.Enable();
            }
        if (MenuOpen)
        {
            CreateList();
        }
    }
    void CreateList()
    {

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            deligateEffect.Add(Effect1);
            DelegateRender.Add(Render1);
            // RenderToping();

        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            deligateEffect.Add(Effect2);
            DelegateRender.Add(Render2);
            // RenderToping();
        }

        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            deligateEffect.Add(Effect3);
            DelegateRender.Add(Render3);
            // RenderToping();
        }

        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            deligateEffect.Add(Effect4);
            DelegateRender.Add(Render4);
            // RenderToping();
        }


        //removes latest thing from the array(sets to null)
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            for (int i = 0; i < deligateEffect.Count; i++)
            {
                deligateEffect.Remove(deligateEffect[i]);
            }

            for (int i = 0; i < DelegateRender.Count; i++)
            {
                DelegateRender[i]();
                DelegateRender.Remove(DelegateRender[i]);

            }
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

    void Render1()
    {
        if (!Ingredient1)
        {

            Ingredient1.SetActive(true);
        }
        else
        {
            Ingredient1.SetActive(false);
        }

    }
    void Render2()
    {
        if (!Ingredient2)
        {
            Ingredient2.SetActive(true);
        }
        else
        {
            Ingredient2.SetActive(false);
        }
    }
    void Render3()
    {
        if (!Ingredient3)
        {
            Ingredient3.SetActive(true);
        }
        else
        {
            Ingredient3.SetActive(false);
        }
    }
    void Render4()
    {
        if (!Ingredient4)
        {
            Ingredient4.SetActive(true);
        }
        else
        {
            Ingredient4.SetActive(false);
        }
    }

    void RenderToping()
    {
        for (int i = 0; i < DelegateRender.Count; i++)
        {
            DelegateRender[i]();
        }
    }
}

