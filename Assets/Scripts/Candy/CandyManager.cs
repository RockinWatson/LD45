using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _candies = null;

    static private CandyManager _instance = null;
    static public CandyManager Get() { return _instance; }

    private void Awake()
    {
        _instance = this;
    }

    public Candy GetCandy(Vector3 pos)
    {
        //@TODO: Instantiate candy, set position, set color?
        GameObject go = Instantiate(GetRandomCandyPrefab(), pos, Quaternion.AngleAxis(Random.Range(0f, 360f), Vector3.forward), this.transform);
        return go.GetComponent<Candy>();
    }

    private GameObject GetRandomCandyPrefab()
    {
        return _candies[Random.Range(0, _candies.Count)];
    }
}
