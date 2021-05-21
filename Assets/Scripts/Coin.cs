using UnityEngine;


public class CoinSpin : MonoBehaviour
{
    public 
    void Update()
    {
        this.transform.GetChild(0).Rotate(new Vector3(0, 60 * Time.deltaTime, 0), Space.Self);
    }

}
