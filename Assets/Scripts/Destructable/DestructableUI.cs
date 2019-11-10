using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Destructable))]
public class DestructableUI : MonoBehaviour
{

    public Slider slider;
    public Transform canvas;
    private Destructable destructable;



    private void Awake()
    {
        destructable = GetComponent<Destructable>();

        if (!canvas)
            canvas = slider.transform.parent;
        slider.value = slider.maxValue;
    }

    private void OnEnable()
    {
        destructable.OnTakeDamage += UpdateHPValue;
    }

    private void OnDisable()
    {
        destructable.OnTakeDamage -= UpdateHPValue;
    }

    void UpdateHPValue(float newHP, Vector3 shotDir)
    {
        slider.value = newHP;
        canvas.LookAt(shotDir);
    }

}
