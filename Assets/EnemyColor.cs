using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColor : MonoBehaviour
{
    private GameObject parent;

    private void Start()
    {
        parent = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if(other.gameObject.tag == "Player")
        {
            print("ChangeColor!!");
            other.gameObject.GetComponent<MeshRenderer>().material.color = parent.gameObject.GetComponent<MeshRenderer>().material.color;
            other.gameObject.GetComponent<PlayerController>().colors.Enqueue(parent.gameObject.GetComponent<MeshRenderer>().material.color);
        }
        */
        if (other.gameObject.tag == "Attack")
        {
            print("Playerに攻撃された!!");
            parent.gameObject.GetComponent<EnemyController>().TakeDamage(1000);
        }
    }
}
