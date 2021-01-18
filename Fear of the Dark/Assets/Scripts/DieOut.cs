using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOut : MonoBehaviour
{
    public float countdown;
    public Light Light;

    private void Start()
    {
        StartCoroutine(killLight());
    }

    IEnumerator killLight()
    {
        yield return new WaitForSeconds(countdown);

        Light.enabled = !Light.enabled;

        yield return new WaitForSeconds(0.1f);

        Light.enabled = !Light.enabled;

        yield return new WaitForSeconds(0.1f);

        Light.enabled = !Light.enabled;

        yield return new WaitForSeconds(0.1f);

        Light.enabled = !Light.enabled;

        yield return new WaitForSeconds(0.1f);

        Light.enabled = !Light.enabled;
    }

}
