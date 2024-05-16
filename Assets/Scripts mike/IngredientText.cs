using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IngredientText : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text2;
    public TMP_Text text3;
    public TMP_Text text4;
    public TMP_Text text5;
    public TMP_Text text6;
    public TMP_Text text7;
   public  CraftingUI ints;


    // Start is called before the first frame update
    void Start()
    {
        ints = GetComponent<CraftingUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text1.text = ints.peperoni.ToString();
        text2.text = ints.pepper.ToString();
        text3.text = ints.olive.ToString();
        text4.text = ints.pineapple.ToString();
        text5.text = ints.mushroom.ToString();
        text6.text = ints.tomato.ToString();
        text7.text = ints.cheese.ToString();
    }
}
