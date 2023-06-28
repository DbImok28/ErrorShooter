using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DamageSrceen : MonoBehaviour
{

    [Header("Events")]

    public GameObject RedScreen;
    public HealthComponent HealthComponenthealth;

    public float DisplayTime;

    public Coroutine HideDamageScreenCoroutineHandle { get; private set; }

    private void Start()
    {
        //оепедекюрэ

        //HealthComponenthealth.OnTakeDamage.AddListener(ShowDamageScreen);
    }
    public void ShowDamageScreen(float x)
    {
        HideDamageScreenCoroutineHandle = StartCoroutine(HideDamageScreenCoroutine());
    }

    private IEnumerator HideDamageScreenCoroutine()
    {
        RedScreen.SetActive(true);
        yield return new WaitForSeconds(DisplayTime);
        HideDamageScreen();
    }
    
    public void HideDamageScreen()
    {
        RedScreen.SetActive(false);
    }
}
