using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelController : MonoBehaviour
{
    
    public float fuelcount = 100f;
        private void Update()
    {
        if (PlayerContoller.Instance.hand == 2 && Input.GetKey(KeyCode.E))
        {
            fuelcount -= 5 * Time.deltaTime;
            fuelcount = Mathf.Clamp(fuelcount, 0f, 100f);
            UiManager.instance.Fuel(fuelcount);

            
        }
    }
}
