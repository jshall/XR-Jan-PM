using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MushroomAttackUI : MonoBehaviour
{
    private Text text;

    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + (int)Player.HitPoints + " / " + (int)Player.MaxHitPoints;
    }
}
