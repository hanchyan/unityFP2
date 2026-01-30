using UnityEngine;

public class BuildTest : MonoBehaviour
{
    void Start()
    {
        Debug.Log("BUILD STARTED OK");
    }

    void Update()
    {
        transform.Rotate(0f, 60f * Time.deltaTime, 0f);
    }
}
