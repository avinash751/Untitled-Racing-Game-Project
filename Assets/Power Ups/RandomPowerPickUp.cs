using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using System;

public class RandomPowerPickUp : MonoBehaviour
{
    
    public GameObject PowerUPButton;

    [Header(" Power UP randomiser info")]
    public float PowerUpDuration;
    public float PowerUpTimer;
    public bool TimeConfirmed;
    public bool PowerUPActivated;
    int PowerUpNumber;
    public float UpdateFrequency;
    bool RunOnce;


    public delegate void EnemyDiceEvent();
    public EnemyDiceEvent EnemyEvent;



    private void Update()
    {
        StartCoroutine(RunPowerUpTillNextOne());
        UpdateTime();
    }

   
    public void RandomizePowerUp()
    {
        
        if(!PowerUPActivated)
        {
            DisableButtonObject(PowerUPButton, false);
            ReversePowerUpChanges();
            PowerUpNumber = Random.Range(1, 7);
            Debug.Log("power up randomiser started");
            switch (PowerUpNumber)
            {
                case 1:
                    RunEventOnceWithChanges(IncreaseHealth,1);
                    break;                               
                case 2:                                    
                    RunEventOnceWithChanges(DecresseHealth,1);
                    break;
                case 3:
                    RunEventOnceWithChanges(IncreaseDamage,1);
                    break;
                case 4:
                    RunEventOnceWithChanges(DecreaseDamage,1);
                    break;
                case 5:
                    RunEventOnceWithChanges(IncreaseSpawnRate,1);
                    break;
                case 6:
                    RunEventOnceWithChanges(EnableCollisionWithEnemies);
                    break;

                default:
                    break;
            }
            TimeConfirmed = false;
            PowerUPActivated = true;
        }
    }

    IEnumerator RunPowerUpTillNextOne() // it will continue to call existing event till the next event randomisation
    {
        if (PowerUPActivated && PowerUpTimer <= PowerUpDuration && !RunOnce)
        {
            EnemyEvent();
            RunOnce = true;
            yield return new WaitForSeconds(UpdateFrequency);
            RunOnce = false;
            Debug.Log("all power up info updated ");
        }
        if (PowerUPActivated && PowerUpTimer > PowerUpDuration)
        {
            PowerUPActivated = false;
            DisableButtonObject(PowerUPButton, true);
        }
    }

    void UpdateTime()
    {
        PowerUpTimer += Time.deltaTime;
    }

    public void IncreaseHealth()  // call a power up function  or specify a powerup here
    {
        Debug.Log(" inc health");
    }
    public void DecresseHealth() // call a power up function  or specify a powerup here
    {
        Debug.Log(" Dec health");
    }

    public void IncreaseDamage()// call a power up function  or specify a powerup here
    {
        Debug.Log(" inc Damage");
    }

    public void DecreaseDamage()// call a power up function  or specify a powerup here
    {
        Debug.Log(" Dec  Damage");
    }

    public void IncreaseSpawnRate()// call a power up function  or specify a powerup here
    {
        Debug.Log("inc spawn");
    }

    public void EnableCollisionWithEnemies()// call a power up function  or specify a powerup here
    {
        Debug.Log("enable collsion");
    }


    public void ReversePowerUpChanges()// call a power up function  or specify a powerup here
    {
        PowerUpTimer = 0;
        Debug.Log("chnages Reversed");

    }


    void RunEventOnceWithChanges(EnemyDiceEvent RandomEvent)
    {
        EnemyEvent = RandomEvent;
        RandomEvent();
    }
    void RunEventOnceWithChanges<T>(EnemyDiceEvent RandomEvent, T SpecifyChange)
    {
        EnemyEvent = RandomEvent;
        RandomEvent();
    }
    void RunEventOnceWithChanges<T1, T2>(EnemyDiceEvent RandomEvent, T1 SpecifyChange, T2 SpecifyChange2)
    {
        EnemyEvent = RandomEvent;
        RandomEvent();
    }

    void DisableButtonObject(GameObject GameButton,bool enable)
    {
       GameButton.SetActive(enable);
    }

    float RequiredTimeTOPlayAnEnemyEvent()
    {

        if (!TimeConfirmed)
        {
            TimeConfirmed = true;
            PowerUPActivated = false;
            PowerUpDuration = +PowerUpTimer;
            return PowerUpDuration;
        }
        return PowerUpDuration;
    }
}
