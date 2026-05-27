using UnityEngine;

public class DebrisRandomizer : MonoBehaviour
{
    [Header("Debris Randomization")]
    [SerializeField] private float positionOffset = 1f;
    [SerializeField] private float minSpin = -100f;
    [SerializeField] private float maxSpin = 100f;

    //stores the rotation speed for each debris sprite
    private float[] spinSpeeds;

    private void Start()
    {
        //grabs the nexted children
        spinSpeeds = new float[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            //grabs the indexed child and randomizes its position to keep things interesting
            Transform child = transform.GetChild(i);
            
            float offsetX = Random.Range(-positionOffset, positionOffset);
            float offsetY = Random.Range(-positionOffset, positionOffset);
            
            // modifies relative to the parent instead of world or screen space
            child.localPosition += new Vector3(offsetX, offsetY, 0f);
            
            spinSpeeds[i] = Random.Range(minSpin, maxSpin);
        }
    }

    private void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //ensures rotation speed is consistent, regardless of framerate
            transform.GetChild(i).Rotate(0f, 0f, spinSpeeds[i] * Time.deltaTime);
        }
    }
}