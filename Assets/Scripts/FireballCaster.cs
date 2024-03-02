using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballCaster : MonoBehaviour
{
    public FireBall fireballPrefab;
    public Transform fireballSourceTransfrom;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(fireballPrefab, fireballSourceTransfrom.position, fireballSourceTransfrom.rotation); ;
        }
    }
}
