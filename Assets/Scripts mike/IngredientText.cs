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
        text1.text = ints.itemVars[0].ToString();
        text2.text = ints.itemVars[6].ToString();
        text3.text = ints.itemVars[2].ToString();
        text4.text = ints.itemVars[1].ToString();
        text5.text = ints.itemVars[3].ToString();
        text6.text = ints.itemVars[5].ToString();
        text7.text = ints.itemVars[6].ToString();
    }
}
