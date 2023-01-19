using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet0Pivot : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1) * 180 * Time.deltaTime);
    }
}
