using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
// using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PizzaCrafting : MonoBehaviour
{
    //deligate define 
    delegate void AffectThePlayer();
    delegate void RenderIngredient();
    public bool MenuOpen;


    //UI stuff
    public Canvas DaMenu;
    public GameObject Ingredient1;
    public GameObject Ingredient2;
    public GameObject Ingredient3;
    public GameObject Ingredient4;




    List<AffectThePlayer> deligateEffect = new List<AffectThePlayer>(3);
    List<RenderIngredient> DelegateRender = new List<RenderIngredient>(3);
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {

            if (!MenuOpen)
            {
                MenuOpen = true;
                DaMenu.enabled = true;
            }
            else
            {
                MenuOpen = false;
                DaMenu.enabled = false;
            }
            
            

        }
        if (MenuOpen)
        {
            CreateList();
        }
        if (!MenuOpen)
        {
            MenuOpen = false;
            DaMenu.enabled = false;
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
            }
            

        }
    }
    private void Start()
    {
        
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

    }

    void Effect2()
    {
        Debug.Log("bruh2");
    }

    void Effect3()
    {
        Debug.Log("bruh3");
    }

    void Effect4()
    {
        Debug.Log("bruh4");

    }

    void Render1()
    {
        if (!Ingredient1.active)
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
        if (!Ingredient2.active)
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
        if (!Ingredient3.active)
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
        if (!Ingredient4.active)
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
