using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("ChangeColor!!");
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
