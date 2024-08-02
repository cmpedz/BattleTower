using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttributes : MonoBehaviour
{
    // Start is called before the first frame update
    public SoldierScriptableObject soldierData;

    private float currentHealth;

    private float currentDefence;

    private float currentSpeedAttack;

    private float currentSpeed;

    private float currentDam;

    void Start()
    {

        this.soldierData = GetComponent<SoldierDataController>().SoliderData;

        GetComponent<Animator>().runtimeAnimatorController = soldierData.animatorController;

        GetComponent<SpriteRenderer>().sprite = soldierData.sprite;

        currentHealth = soldierData.soldierHealth;

        currentDam = soldierData.dam;

        currentDefence = soldierData.defence;

        currentSpeed = soldierData.speed;

        currentSpeedAttack = soldierData.speedAttack;
        
    }


    public void setCurrentHealth(float health)
    {
        this.currentHealth = health;
    }

    public float getCurrentHealth()
    {
        return this.currentHealth;
    }

    public void setCurrentDefence(float defence)
    {
        this.currentDefence = defence;
    }

    public float getCurrentDefence()
    {
        return this.currentDefence;
    }

    public void setCurrentAttackSpeed(float AttackSpeed)
    {
        this.currentSpeedAttack = AttackSpeed;
    }

    public float getCurrentAttackSpeed()
    {
        return this.currentSpeedAttack;
    }

    public void setCurrentDam(float dam)
    {
        this.currentDam = dam;
    }

    public float getCurrentDam()
    {
        return this.currentDam;
    }

    public void setCurrentSpeed(float speed)
    {
        this.currentSpeed = speed;
    }

    public float getCurrentSpeed()
    {
        return this.currentSpeed;
    }



}
