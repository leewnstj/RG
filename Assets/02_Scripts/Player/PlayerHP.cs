using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] Slider Hpbar;
    public float PlayerCurrentHP;
    public float PlayerMaxHP;

    float imsi;

    private void Start()
    {
        imsi = PlayerCurrentHP / PlayerMaxHP;
    }

    private void Update()
    {
        Hp();
        if(PlayerCurrentHP <= 0)
        {
            Debug.Log("DEAD");
        }
    }

    private void Hp()
    {
        Hpbar.value = Mathf.Lerp(Hpbar.value, imsi, Time.deltaTime * 10);
    }
}
