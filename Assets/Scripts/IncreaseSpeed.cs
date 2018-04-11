using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSpeed : MonoBehaviour
{

    public void IncreaseProjectileSpeed()
    {

        if (Time.timeScale == 1f)
            Time.timeScale = 2f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void DecreaseProjectileSpeed()
    {
        if (Time.timeScale == 2f)
            Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
}
