using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerWarning : MonoBehaviour
{
    public Image customImage;
    private bool showed = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player enter");
        if (other.CompareTag("Player"))
        {
            if (!showed)
            {
                StartCoroutine(Wait());
                showed = true;
            }
        }
    }
    IEnumerator Wait()
    {
        customImage.enabled = true;
        yield return new WaitForSeconds(0.5f);
        customImage.enabled = false;
        yield return new WaitForSeconds(0.5f);
        customImage.enabled = true;
        yield return new WaitForSeconds(0.5f);
        customImage.enabled = false;
        yield return new WaitForSeconds(0.5f);
        customImage.enabled = true;
        yield return new WaitForSeconds(0.5f);
        customImage.enabled = false;
    }
}
