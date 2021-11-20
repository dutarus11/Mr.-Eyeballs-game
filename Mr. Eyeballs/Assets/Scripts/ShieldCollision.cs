using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollision : MonoBehaviour
{
    public GameObject shieldObj;
   
    GameObject obj;
    int damage = 1;
       
      
    void OnTriggerEnter(Collider other)
    {
        // Minus Enemy Health 
        if (other.tag == "Enemy")
        {                       
            other.gameObject.GetComponent<EnemyController>().hitPoints -= damage;          
        }
    }
}
