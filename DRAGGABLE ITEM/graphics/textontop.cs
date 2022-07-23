using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class textontop : MonoBehaviour
{
    //[SerializeField]
    public string Text;
    public Canvas c;
    public Color TextColor = Color.white;
    [SerializeField]
    Font font;
    [SerializeField]
    bool bestFitText = false;
    //[SerializeField]
    [Range(1, 160)]
    public int fontSize = 14;
    Text p;
    SpriteRenderer r;

    void render()
    {
        if (p != null)
        {
            Vector3 n = r.transform.localScale;
            p.rectTransform.sizeDelta = new Vector2(n.x * .4f - 4, n.y * .5f - 2);
            Vector2 _p = Camera.main.WorldToViewportPoint(transform.position);
            if(!shark.cman.between(_p.x, 0, 1) || !shark.cman.between(_p.y, 0, 1)){
                Destroy(p.gameObject);
                p=null;
                return;
            }
            p.transform.position = _p * c.renderingDisplaySize;
            p.text = Text;
            p.fontSize = fontSize;
            p.color = TextColor;
        }
        else
        {
            if (c == null)
            {
                Debug.Log("Canvas not Assigned!");
                return;
            }

            GameObject go = new GameObject(string.Format("{0}.text", gameObject.name), typeof(RectTransform));
            go.transform.SetParent(c.transform, false);
            p = go.AddComponent<Text>();
            p.font = font;
            p.alignment = TextAnchor.MiddleCenter;
            p.resizeTextForBestFit = bestFitText;
            render();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<SpriteRenderer>();
        render();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        render();
    }
}
