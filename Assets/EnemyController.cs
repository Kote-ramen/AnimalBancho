using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyStatus status;

    // Start is called before the first frame update
    void Start()
    {
        status = GetComponent<EnemyStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        status.SetDamage(damage);
    }
}
