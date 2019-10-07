using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WindRandSpawner : MonoBehaviour
    {
        //Collect Houses
        public GameObject[] Winds;

        //Object Pooling
        private List<GameObject> _windPool;
        public int WindAmountTotal;
        public int WindAmountSingle;

        //Time to spawn
        public float waitForNextMax;
        public float countDown;

        //X Range
        public float xMin;
        public float xMax;

        //Y Range
        public float yMin;
        public float yMax;

        [SerializeField]
        private float _windSpeed = 3.0f;
        public float GetWindSpeed()
        {
            return _windSpeed;
        }

        static private WindRandSpawner _singleton = null;
        static public WindRandSpawner Get()
        {
            return _singleton;
        }

        private void Awake()
        {
            _singleton = this;
        }

        void Start()
        {
            _windPool = new List<GameObject>();
            foreach (var wind in Winds)
            {
                for (int j = 0; j < WindAmountSingle; j++)
                {
                    GameObject obj = Instantiate(wind);
                    obj.SetActive(false);
                    _windPool.Add(obj);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                SpawnWind();
                countDown = waitForNextMax;
            }
        }

        void SpawnWind()
        {
            if (_windPool != null)
            {
                GameObject gameObj = _windPool[Random.Range(0, _windPool.Count)];
                if (!gameObj.activeInHierarchy)
                {
                    gameObj.transform.position = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), -5);
                    gameObj.SetActive(true);
                }
            }
            else
            {
                Debug.Log("Add Wind to the WindRandSpawner Script you DumbAss!!!!");
            }
        }
    }
}
