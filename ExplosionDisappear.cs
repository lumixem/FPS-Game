﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionZnikanie : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(KillKamikazeExplosion());
    }

    IEnumerator KillKamikazeExplosion()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }
}
