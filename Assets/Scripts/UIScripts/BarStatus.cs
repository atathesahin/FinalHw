using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarStatus : MonoBehaviour
{
    [SerializeField] private Image bar;

    public void SetState(float current, float max)
    {

        var state = current;
        bar.fillAmount = current / max;
        if (state < 0f)
        {
            state = 0f;
            
        }
        //bar.transform.localScale = new Vector3(state, 1f, 1f);
    }
}
