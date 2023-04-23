using UnityEngine;

public class HitInfo : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        GameObject bullet = GameObject.FindWithTag("Bullet");

        if (!bullet) return;

        if (gameObject.GetComponent<MeshRenderer>().bounds.Intersects(bullet.GetComponent<MeshRenderer>().bounds))
        {
            Debug.Log("Intersection");
            GameObject.Destroy(bullet);
        }
    }


}
