using UnityEngine;
using System.Collections.Generic;

public class TrashManager : MonoBehaviour
{

    private List<GameObject> trashList = new List<GameObject>();
    public GameObject[] enemyFishes;
    public GameObject[] underwaterImages;
    private int totalTrashCreated = 0;

    public int trashLowMaxThreshold = 8;
    public int trashMedMaxThreshold = 15;
    public Color lowColor;

    public Color medColor;
    public Color highColor;

    public void AddTrash(GameObject trash)
    {
        if (trash == null) return;

        trashList.Add(trash);
        totalTrashCreated += 1;
    }

    public void DestroyTrash(GameObject trash)
    {
        if (!trashList.Contains(trash)) return;

        trashList.Remove(trash);
        Destroy(trash);
    }

    public void DestroyTrash(int index)
    {
        if (index < 0 || index >= trashList.Count) return;

        GameObject trashToDestroy = trashList[index];
        trashList.RemoveAt(index);
        Destroy(trashToDestroy);
    }

    public GameObject GetTrash(int index)
    {
        if (index < 0 || index >= trashList.Count) return null;

        return trashList[index];
        
    }

    public int TrashListSize()
    {
        return trashList.Count;
    }

    public void UpdateLevelByTrashAmount()
    {

        //update ocean background color too

        if (totalTrashCreated < trashLowMaxThreshold)
        {
            // set to low difficulty; friendly fish
            UpdateEnemyFishDifficulty(EnemyFish.PollutionLevel.Low);

        } else if (totalTrashCreated < trashMedMaxThreshold)
        {
            // set to medium difficulty
            UpdateEnemyFishDifficulty(EnemyFish.PollutionLevel.Medium);
        } else
        {
            // set to hard difficulty
            UpdateEnemyFishDifficulty(EnemyFish.PollutionLevel.High);
        }
    }

    private void UpdateEnemyFishDifficulty(EnemyFish.PollutionLevel difficulty)
    {
        for (int i = 0; i < enemyFishes.Length; i++)
        {
            if (!enemyFishes[i].GetComponent<EnemyFish>().setPollutionLevel(difficulty))
                Debug.Log("Failed to update fish " + i);
        }
    }

    private void UpdateUnderwaterImage(EnemyFish.PollutionLevel difficulty, GameObject imageObject)
    {
        SpriteRenderer sr = imageObject.GetComponent<SpriteRenderer>();
        switch (difficulty)
        {
            case EnemyFish.PollutionLevel.Low:
                break;
            case EnemyFish.PollutionLevel.Medium:
                break;
            case EnemyFish.PollutionLevel.High:
                break;

        }
        
    }
}
