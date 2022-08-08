using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : YLUnitySingleton<GameManager>,IBaseManager
{
    private GameObject playerPrefab;
    private Player player;
    public bool isGameOver { get; set; }
    /// <summary>
    /// 怪物的名字
    /// </summary>
    string[] enemyname = { "Hellephant", "ZomBear", "ZomBunny" };
    List<GameObject> enemyPrefabList;
    List<GameObject> enemyList;
    private Transform birthPoints;
    public void Initailize()
    {
        enemyList = new List<GameObject>();
        enemyPrefabList = new List<GameObject>();
        birthPoints = GameObject.Find("BirthPoints").transform;
        GetAllEnemyPrefab();
        CreatePlayer();
        StartCoroutine("CreateEnemy");
    }
    public void CreatePlayer()
    {
        playerPrefab = Resources.Load<GameObject>("Game/Player");
        player = GameObject.Instantiate(playerPrefab).AddComponent<Player>();
        player.name = "Player";
        FollowCamera followCamera = Camera.main.gameObject.AddComponent<FollowCamera>();
        followCamera.SetTarget(player.transform);
        isGameOver = false;
    }
    void GetAllEnemyPrefab()
    {

        for (int i = 0; i < enemyname.Length; i++)
        {
            GameObject prefab = Resources.Load<GameObject>("Game/" + enemyname[i]);
            enemyPrefabList.Add(prefab);
        }
    }
    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            int prefabIndex = Random.Range(0, enemyPrefabList.Count);
            //出生点
            int birthPointIndex = Random.Range(0, birthPoints.childCount);
            GameObject enemy = GameObject.Instantiate(enemyPrefabList[prefabIndex], birthPoints.GetChild(birthPointIndex).position, birthPoints.GetChild(birthPointIndex).rotation );
            enemy.name = enemyPrefabList[prefabIndex].name;
            enemyList.Add(enemy);
            yield return new WaitForSeconds(2+Random.Range(0,1.5f));
        }
    }

    public void Deinitialize()
    {
        StopCoroutine("CreateEnemy");
        foreach (var item in enemyList)
        {
            Destroy(item);
        }
        Destroy(player);
        enemyList.Clear();
        enemyPrefabList.Clear();
    }
    public void GameOver()
    {
        if (isGameOver)
        {
            StopCoroutine("CreateEnemy");
        }
        //弹出结束面板
    }
    public void UseEquip(Equip equip)
    {
        player.AddEquip(equip);
    }
    private void Update()
    {
        GameOver();
    }

}
