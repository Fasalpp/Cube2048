using TMPro;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public int value = 2;

    public TextMeshPro valueText;

    private void Start()
    {
        UpdateValue();
    }

    void UpdateValue()
    {
        if (valueText != null)valueText.text = value.ToString();

        float scale = 1f + Mathf.Log(value, 2) * 0.2f;
        transform.localScale = Vector3.one * scale;
    }


    private void OnCollisionEnter(Collision collision)
    {
        
            Cube cube = collision.gameObject.GetComponent<Cube>();

            if(cube != null && value == cube.value)
            {
                value = value * 2;
                UpdateValue();
                Destroy(cube.gameObject);
            }
        
    }
}
