using UnityEngine;
using System.Collections;
using System.Text;

public class MoveCanvas : MonoBehaviour
{
    private float diff_width;
    private float diff_height;

    public Transform title;
    public Transform buttons;

    // Use this for initialization
    void Start()
    {
        diff_width = Screen.width*0.20f;
        diff_height = Screen.height*0.20f + title.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        buttons.position = Vector3.Lerp(buttons.position, new Vector3(diff_width, buttons.position.y, 0),
            Time.deltaTime*1.5f);
        title.position = Vector3.Lerp(title.position, new Vector3(title.position.x, diff_height, 0),
            Time.deltaTime * 1.5f);
    }
}