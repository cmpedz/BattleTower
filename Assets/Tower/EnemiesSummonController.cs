
using UnityEngine;

public class EnemiesSummonController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LevelScriptableObject towerData;

    private int quatitiesEnemiesType = 1;

    private float timeSummonEnemy;

    private float timeSummonEnemyCount;

    private float timeCreateNewTypeEnemy;

    private float timeDecreaseTimeSummonEnemy;

    [SerializeField] private GameObject soldierForm;

    private TowerController towerController;


    void Start()
    {

        timeCreateNewTypeEnemy = Time.time;

        timeDecreaseTimeSummonEnemy = Time.time;

        timeSummonEnemy = towerData.maxTimeSummonEnemy;

        timeSummonEnemyCount = Time.time - timeSummonEnemy;

        towerController = GetComponent<TowerController>();


    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - timeSummonEnemyCount > timeSummonEnemy)
        {
            summonEnemies();
            timeSummonEnemyCount = Time.time;
        }

        createNewEnemyType();

        decreaseTimeSummonEnemy();
        
    }


    private void summonEnemies()
    {
        int enemyType = Random.Range(0, quatitiesEnemiesType);

        GameObject enemy = Instantiate(soldierForm);

        enemy.GetComponent<SoldierDataController>().SoliderData = towerData.enemiesType[enemyType];

        enemy.SetActive(true);

        enemy.transform.position = towerController.getPositionSummon();

        //set order in layer for displaying suitablely

        int orderInLayer = (int)(enemy.transform.position.y * -1000);

        enemy.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;

    }

    private void decreaseTimeSummonEnemy()
    {
        if(Time.time - timeDecreaseTimeSummonEnemy > towerData.timeWaitToDecreaseTimeSummonEnemy)
        {
            

            timeDecreaseTimeSummonEnemy = Time.time;

            timeSummonEnemy -= towerData.timeSummonEnemyDecreaseAmount;

            Debug.Log("decrease time summon enemy");

            if (timeSummonEnemy < towerData.minTimeSummonEnemy)
            {
                
                timeSummonEnemy = towerData.minTimeSummonEnemy;
            }
        }
    }

    private void createNewEnemyType()
    {
        if(Time.time - timeCreateNewTypeEnemy > towerData.timeSummonNewType)
        {
           if( quatitiesEnemiesType < towerData.enemiesType.Count)
           {
                Debug.Log("summon new type");
                quatitiesEnemiesType++ ;
                timeCreateNewTypeEnemy = Time.time;
           }
        }
    }

    
}
