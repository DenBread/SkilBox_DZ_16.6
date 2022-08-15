using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChunk : MonoBehaviour
{
    [SerializeField] private GameObject _prefabsChunks;
    [SerializeField] private Transform _endChunk;
    [SerializeField] private List<Transform> _allChunk;
    [SerializeField] private int _indexChunk;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<TriggerChunk>())
        {
            Debug.Log("Spawn");
            
            if(_allChunk.Count < 2)
            {
                Transform endPoint = _allChunk[_indexChunk].transform.Find("EndChunk");
                endPoint.position += new Vector3(9.6f, 0);
                GameObject gm = Instantiate(_prefabsChunks);
                gm.transform.position = endPoint.position;
                _allChunk.Add(gm.transform);
                _indexChunk++;
            }
            else
            {
                Transform endPoint = _allChunk[_indexChunk].transform.Find("EndChunk");
                endPoint.position += new Vector3(9.6f, 0);
                if (_indexChunk > 0)
                {
                    _allChunk[0].transform.position = endPoint.position;
                    _indexChunk--;
                }
                else
                {
                    _allChunk[1].transform.position = endPoint.position;
                    _indexChunk++;
                }
                
            }

        }
    }
}
