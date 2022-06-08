using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]float minScale = .8f;
    [SerializeField]float maxScale = 1.2f;
    [SerializeField]float rotationOffset = 100f;
    Transform myT;
    Vector3 randomRotation;

    void Awake()
    {
        myT = transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        //random size
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);

        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);

        myT.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
        myT.Rotate(randomRotation * Time.deltaTime);
    }
}
