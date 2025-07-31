using UnityEngine;

public class JoinHandles : MonoBehaviour
{
    public Transform rightHandler;
    public Transform LeftHandler;
    public Transform parentTransform;
    private float scaleMult;

    // Start is called before the first frame update
    public void Start()
    {
        Vector3 posToMove = transform.position;
        posToMove.y = ( rightHandler.position.y + LeftHandler.position.y) / 2;
        transform.position = posToMove;
    }

    // Update is called once per frame
    public void Update()
    {
        scaleMult = 1/parentTransform.localScale.x;
        Vector3 posToMove = transform.position;
        posToMove.x = ( rightHandler.position.x + LeftHandler.position.x) / 2;
        transform.position = posToMove;

        Vector3 posToMoveY = transform.position;
        posToMoveY.y = ( rightHandler.position.y + LeftHandler.position.y) / 2;
        transform.position = posToMoveY;

        transform.right = rightHandler.position - transform.position;
        transform.eulerAngles = new Vector3(0, 0, transform.rotation.eulerAngles.z);

        Vector3 scaleToSet = transform.localScale;
        scaleToSet.x = Vector3.Distance(rightHandler.position, LeftHandler.position ) * scaleMult;
        transform.localScale = scaleToSet;
    }
}
