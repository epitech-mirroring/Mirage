using System.Collections.Generic;
using UnityEngine;

public class Mirror_nb_gestion
{
    private int total = 0;

    private int index;

    public List<GameObject> mirrors;

    void Start()
    {
        while (total < 4) {
            index = Random.Range(0, mirrors.Count);
            mirrors[index].SetActive(true);
            mirrors.RemoveAt(index);
            total++;
        }
    }

}
