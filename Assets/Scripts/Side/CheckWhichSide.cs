using UnityEngine;

public class CheckWhichSide : MonoBehaviour
{
    [SerializeField]
    private GameObject target = null;

    [SerializeField]
    private Transform UpPoint = null;

    [SerializeField]
    private Transform DownPoint = null;

    [SerializeField]
    private Transform LeftPoint = null;

    [SerializeField]
    private Transform RightPoint = null;

    [SerializeField]
    private SideType sideType = SideType.NONE;

    enum SideType { NONE, UP, DOWN, LEFT, RIGHT, FORWARD, BACK }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            switch (sideType)
            {
                case SideType.UP:
                    target.transform.SetParent(UpPoint, true);
                    break;
                case SideType.DOWN:
                    target.transform.SetParent(DownPoint, true);
                    break;
                case SideType.LEFT:
                    target.transform.SetParent(LeftPoint, true);
                    break;
                case SideType.RIGHT:
                    target.transform.SetParent(RightPoint, true);
                    break;
            }

            target.transform.localPosition = Vector3.zero;
            target.transform.localEulerAngles = Vector3.zero;
            target.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        CheckSide();
    }

    private void CheckSide()
    {
        Vector3 hitDirection = gameObject.transform.position - target.transform.position;

        //Dot products
        float upWeight = Vector3.Dot(hitDirection, gameObject.transform.up);
        float forwardWeight = Vector3.Dot(hitDirection, gameObject.transform.forward);
        float rightWeight = Vector3.Dot(hitDirection, gameObject.transform.right);

        //We care about the absolute value only for now
        float upMag = Mathf.Abs(upWeight);
        float forwardMag = Mathf.Abs(forwardWeight);
        float rightMag = Mathf.Abs(rightWeight);

        if (upMag >= forwardMag && upMag >= rightMag)
        {
            if (upWeight > 0)
            {
                //Down
                Debug.LogError("Down");
                sideType = SideType.DOWN;
            }
            else
            {
                //UP
                Debug.LogError("Up");
                sideType = SideType.UP;
            }
        }
        else if (forwardMag >= upMag && forwardMag >= rightMag)
        {
            if (forwardWeight > 0)
            {
                //Forward
                Debug.LogError("Forward");
                sideType = SideType.FORWARD;
            }
            else
            {
                //Back
                Debug.LogError("Back");
                sideType = SideType.BACK;
            }
        }
        else
        {
            if (rightWeight > 0)
            {
                //Left
                Debug.LogError("Left");
                sideType = SideType.LEFT;
            }
            else
            {
                //Right
                Debug.LogError("Right");
                sideType = SideType.RIGHT;
            }
        }
    }
}
