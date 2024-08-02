using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SoldierMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Transform attackPoint;

    [SerializeField] private SoldierScriptableObject soldierData;

    private Animator animator;

    private LayerMask objectAttack;

    private bool isMoved = false;

    private SoldierAttackController attackController;

    void Start()
    {
        this.soldierData = GetComponent<SoldierDataController>().SoliderData;

        animator = GetComponent<Animator>();

        objectAttack = soldierData.objectAttack;

        attackController = GetComponent<SoldierAttackController>();

        flipSprite();
    }

    private void flipSprite()
    {
        Vector3 newScale = new Vector3(transform.localScale.x * soldierData.direction, transform.localScale.y, transform.localScale.z);

        transform.localScale = newScale;
    }

    // Update is called once per frame
    void Update()
    {
        detectEnemy();
    }

    void FixedUpdate()
    {
        moveControl();
    }

    private void detectEnemy()
    {

            Collider2D enemy = Physics2D.OverlapCircle(attackPoint.position, soldierData.rangeAttack, objectAttack);

            if (enemy != null)
            {
                //change soldier status into idle
                Debug.Log("detect enemy!");

                animator.SetInteger("ChangeMove", 0);

                isMoved = false;


                //change soldier status into attack
                if (Time.time - attackController.SpeedAttack > 1/ GetComponent<SoldierAttributes>().getCurrentAttackSpeed())
                {
                    attackController.SpeedAttack = Time.time;
                 
                    animator.SetTrigger("AttackFlag");

                    attackController.IsAttacking = true;

                }


                //attack enemy

                AnimatorStateInfo animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

                if (animatorStateInfo.IsName("Soldier_basicAttack"))
                {
                    Debug.Log("attack enemy");
                    attackController.attackEnemy(enemy, animatorStateInfo);
                    
            }

          

            }
            else
            {
                //change soldier status into run
                animator.SetInteger("ChangeMove", 1);
                isMoved = true;
            }
        

        
    }



    private void moveControl()
    {
        if (isMoved)
        {
            transform.Translate(Vector2.right * soldierData.direction * 
                GetComponent<SoldierAttributes>().getCurrentSpeed() * Time.fixedDeltaTime);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, soldierData.rangeAttack);
        }
    }


}
