using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMan : MonoBehaviour
{
    public GameObject firstGroupOriginal;
    private FirstEnGroup currentGroup;
    private int groupsCount = 0;

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
            if(groupsCount == 3) {
                SceneManager.LoadSceneAsync(SceneIDS.winSceneID);
            } else {
                CreateNewGroup(); 
                groupsCount++;
            }
        }
    }

    void CreateNewGroup() {
        GameObject newGroup = Instantiate(firstGroupOriginal);   
        newGroup.transform.position = transform.position;
        currentGroup = newGroup.GetComponent<FirstEnGroup>();
    }
}
