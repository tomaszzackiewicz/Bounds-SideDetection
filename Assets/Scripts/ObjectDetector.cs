using UnityEngine;

public class ObjectDetector : MonoBehaviour
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
        CheckIntersection();
        //OtherWay();
    }

    private void CheckIntersection()
    {
        Ray ray = new Ray(target.transform.position, Vector3.up);

        Debug.DrawRay(target.transform.position, Vector3.up);

        //ray.origin = gameObject.transform.InverseTransformPoint(target.transform.position);

        if (gameObject.GetComponent<MeshFilter>().sharedMesh.bounds.IntersectRay(ray))
        {
            Debug.Log("Works");
        }


        if (gameObject.GetComponent<MeshRenderer>().bounds.IntersectRay(ray))
        {
            Debug.Log("Works");
        }

    }


    Ray ray = new Ray(Vector3.zero, Vector3.up);
    float t = 10.0f;

    private void OtherWay()
    {
        // Color ray in the scene editor.
        //In the scene editor, give the ray a color
        Debug.DrawRay(Vector3.zero, Vector3.up * 1, Color.green);
        Bounds bounds = gameObject.GetComponent<Collider>().bounds;
        if (bounds.IntersectRay(ray, out t))
        {
            Debug.Log("Touched the ray " + t);
        }
    }


}
