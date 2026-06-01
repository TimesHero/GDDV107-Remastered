using UnityEngine;

public class OrbitPoint : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject centerPoint;
    void Update()
    {
        transform.RotateAround(centerPoint.transform.position, new Vector3(0,1,1), rotationSpeed * Time.deltaTime);
    }
}
