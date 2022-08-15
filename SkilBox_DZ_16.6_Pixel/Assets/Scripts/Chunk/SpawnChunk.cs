using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChunk : MonoBehaviour
{
    [SerializeField] private GameObject _prefabsChunks; // ������ �����
    [SerializeField] private Transform _endChunk; // ������� ��������� ����� � �����
    [SerializeField] private Vector3 _posChunk; // ������� ������ ������������ �� �������� ����� ������
    [SerializeField] private List<GameObject> _chunks = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<TriggerChunk>())
        {
            if(_chunks.Count > 2)
            {
                _chunks.RemoveAt(0);
                Destroy(_chunks[0]);
            }

            _endChunk = collision.transform.parent.parent.Find("EndChunk");
            _endChunk.position += _posChunk;
            GameObject gm = Instantiate(_prefabsChunks);
            _chunks.Add(gm);

            gm.transform.position = _endChunk.position;
            Destroy(gm, 10f);
        }
    }

    private void Spawn()
    {

    }
}
