using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMan : MonoBehaviour
{
    public GameObject firstGroupOriginal;
    public GameObject ramGroupOriginal;
    private GroupBase currentGroup;
    private int groupsCount = 0;
    private EnemyGroupType[] groupTypes = { EnemyGroupType.baseGroup, EnemyGroupType.ramGroup }; 

    void Start()
    {
       CreateNewGroup();
       groupsCount++;
    }

    
    void Update()
    {
        if(currentGroup != null && currentGroup.isAlive == false)
        {
            Destroy(currentGroup.gameObject);
            if(groupsCount == groupTypes.Length) {
                SceneManager.LoadSceneAsync(SceneIDS.winSceneID);
            } else {
                CreateNewGroup(); 
                groupsCount++;
            }
        }
    }

    void CreateNewGroup() {
        if(groupTypes[groupsCount]==EnemyGroupType.baseGroup)
        {
            GameObject newGroup = Instantiate(firstGroupOriginal);   
            newGroup.transform.position = transform.position;
            currentGroup = newGroup.GetComponent<FirstEnGroup>();
        }
        else if(groupTypes[groupsCount]==EnemyGroupType.ramGroup)
        {
            GameObject newGroup = Instantiate(ramGroupOriginal);   
            newGroup.transform.position = transform.position;
            currentGroup = newGroup.GetComponent<RamEnemyGroup>();
        }
    }
}
