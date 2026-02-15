using UnityEngine;
using System.Collections.Generic;

public class TrashManager : MonoBehaviour
{

    private List<GameObject> trashList = new List<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddTrash(GameObject trash)
    {
        if (trash == null) return;

        trashList.Add(trash);
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
}
