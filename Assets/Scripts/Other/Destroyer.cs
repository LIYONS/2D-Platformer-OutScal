using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] float lifeTime;
    float _lifeTime;
    private void Start()
    {
        _lifeTime = Time.time + lifeTime;
    }
    private void Update()
    {
        if (Time.time > _lifeTime) DestroyObject();
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
