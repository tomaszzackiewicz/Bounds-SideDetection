using UnityEngine;

public class IntersectionDetector : MonoBehaviour
{
    [SerializeField]
    private GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.GetComponent<Collider>().bounds.Intersects(target.GetComponent<Collider>().bounds))
        //{
        //    Debug.Log("Intersection");
        //}

        if (gameObject.GetComponent<MeshRenderer>().bounds.Intersects(target.GetComponent<MeshRenderer>().bounds))
        {
            Debug.Log("Intersection");
        }
    }


}
