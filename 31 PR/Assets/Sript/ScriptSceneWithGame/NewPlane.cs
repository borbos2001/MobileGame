using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlane : MonoBehaviour
{
    [SerializeField] private GamaMenager _gamaMenager;
    [SerializeField] private TimeToDie _toDie;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "End")
        {
            _gamaMenager.Generation();
            _toDie.PlusTime();


        }
    }
}
