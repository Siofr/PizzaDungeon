using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTypePic : MonoBehaviour
{

    public GameObject CurResist;
    public GameObject CurWeakness;
    public GameObject DamegeType;

    public Sprite Poison;
    public Sprite Phys;
    public Sprite Fire;
    public Sprite None;

    [Header("DamageTypes")]
    [SerializeField] private DamageType damageType;
    [SerializeField] private DamageType damageType2;
    [SerializeField] private DamageType damageType3;
    private DamageType h;

    public void ChangePicResist(DamageType type)
    {
        h = type;
        
        if ( h = damageType)
        {
            CurResist.GetComponent<Image>().sprite = Phys;
        }
        if (h = damageType2)
        {
            CurResist.GetComponent<Image>().sprite = Poison;
        }
        if (h = damageType3)
        {
            CurResist.GetComponent<Image>().sprite = Fire;
        }
        if (h = null)
        {
            CurResist.GetComponent<Image>().sprite = None;
        }

    }
    public void ChangePicWeak(DamageType Type)
    {
        h = Type;
        if (h = damageType)
        {
            CurWeakness.GetComponent<Image>().sprite = Phys;
        }
        if (h = damageType2)
        {
            CurWeakness.GetComponent<Image>().sprite = Poison;
        }
        if (h = damageType3)
        {
            CurWeakness.GetComponent<Image>().sprite = Fire;
        }
        if (h = null)
        {
            CurWeakness.GetComponent<Image>().sprite = None;
        }

    }
    public void ChangePicDtype(DamageType Type)
    {
        h = Type;
        if (h = damageType)
        {
            DamegeType.GetComponent<Image>().sprite = Phys;
        }
        if (h = damageType2)
        {
            DamegeType.GetComponent<Image>().sprite = Poison;
        }
        if (h  = damageType3)
        {
            DamegeType.GetComponent<Image>().sprite = Fire;
        }
        

    }
}
