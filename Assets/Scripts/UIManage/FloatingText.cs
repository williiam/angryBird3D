using UnityEngine;

public class FloatingText : MonoBehaviour
{
    private bool _isScalingDown;

    void Start()
    {
        transform.localScale = new Vector3(0, 0, transform.localScale.z);
    }

    void Update()
    {
        if (transform.localScale.x <= 0 && _isScalingDown)
        {
            Destroy(gameObject);
        }

        if (_isScalingDown)
        {
            transform.localScale -= new Vector3(1, 1, 0) * Time.deltaTime * 2f;
        }
        else
        {
            transform.localScale += new Vector3(1, 1, 0) * Time.deltaTime * 1.5f;
            if (transform.localScale.x >= 0.75f)
            {
                _isScalingDown = true;
            }
        }
    }

    public void UpdateText(string text, Color color)
    {
        GetComponent<TextMesh>().text = text;
        GetComponent<TextMesh>().color = color;
    }
}