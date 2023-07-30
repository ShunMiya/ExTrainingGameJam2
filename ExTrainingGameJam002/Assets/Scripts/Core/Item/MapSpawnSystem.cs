using System.Collections.Generic;
using UnityEngine;

namespace StageSystem.Map
{
    public class MapSpawnSystem : MonoBehaviour
    {
        [SerializeField] private MapFactory mapFactory;
        [SerializeField] private List<Transform> mapList;

        private void Start()
        {
            // mapListが空でない場合、ランダムに一つの要素を選択してmapFactory.MapCreateに渡す
            if (mapList.Count > 0)
            {
                int randomIndex = Random.Range(0, mapList.Count);
                Transform selectedMap = mapList[randomIndex];
                mapFactory.MapCreate(selectedMap.position, transform.parent);
            }

            Destroy(gameObject);
        }
    }
}