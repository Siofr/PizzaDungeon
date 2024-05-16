using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using UnityEngine;

public class UIVisualise : MonoBehaviour
{

    //Visual 
    public GameObject Peperoni;
    public GameObject Olive;
    public GameObject Cheese;
    public GameObject Pepper;
    public GameObject Pineapple;
    public GameObject Tomato;
    public GameObject Mushroom;
   public CraftingUI craft;
    // 0 pepperoni, 1 pineapple, 2 olive, 3 mushroom, 4 cheese, 5 tomato, 6 pepper


    public void VisualON0()
    {
        Peperoni.SetActive(true);
    }
    public void VisualON1()
    {
        Pineapple.SetActive(true);
    }
    public void VisualON2()
    {
        Olive.SetActive(true);
    }
    public void VisualON3()
    {
        Mushroom.SetActive(true);
    }
    public void VisualON4()
    {
        Cheese.SetActive(true);
    }
    public void VisualON5()
    {
        Tomato.SetActive(true);
    }
    public void VisualON6()
    {
        Pepper.SetActive(true);
    }



    public void VisualOFF0()
    {
        if (Cheese.activeInHierarchy)
        {
            craft.itemVars[4]++;
            Cheese.SetActive (false);
        }
        if (Peperoni.activeInHierarchy)
        {
            //h
            craft.itemVars[0]++;
            Peperoni.SetActive(false);
        }
        if (Pineapple.activeInHierarchy)
        {
            craft.itemVars[1]++;
            Pineapple.SetActive (false);
        }
        if (Olive.activeInHierarchy)
        {
            craft.itemVars[2]++;
            Olive.SetActive (false);
        }
        if (Mushroom.activeInHierarchy)
        {
            craft.itemVars[3]++;
            Mushroom.SetActive (false);
        }
        if (Tomato.activeInHierarchy)
        {
            craft.itemVars[5]++;
            Tomato.SetActive (false);
        }
        if (Pepper.activeInHierarchy)
        {
            craft.itemVars[6]++;
            Pepper.SetActive (false);
        }

    }
    public void GETITOFF()
    {
        Pepper.SetActive(false);
        Tomato.SetActive(false);
        Cheese.SetActive(false);
        Mushroom.SetActive(false);
        Olive.SetActive(false);
        Pineapple.SetActive(false);
        Peperoni.SetActive(false);

    }
}
