using UnityEngine;

namespace shark
{
    class cman
    {
        static public bool between(float x, float y, float r){
            return x > y && x < r;
        }
        static public Vector3 getPoint()
        {
            Vector3 x = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            x.x = Mathf.Clamp(x.x, 0, 1);
            x.y = Mathf.Clamp(x.y, 0, 1);
            x = Camera.main.ViewportToWorldPoint(x);
            x.z = 0;
            return x;
        }
    }
}
