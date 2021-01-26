using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    private PoolID ID => PoolID.PowerUp;
    protected abstract void ActivatePowerUp();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Respawn"))
        {
            if (other.CompareTag("Player"))
                ActivatePowerUp();

            PoolManager.Instance.AddToPool(ID, gameObject);
        }
    }
}