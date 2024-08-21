using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class CSI_rendomSpwonItem : MonoBehaviour
{
    public GameObject[] GameObjects;
    [SerializeField]private ItemSpawnSO[] data;
    private void Awake()
    {
        StartCoroutine(ItemSpawnCo());
    }

    IEnumerator ItemSpawnCo()
    {
        float time = Random.Range(7f, 9f);
        yield return new WaitForSeconds(time);
        
        int Data_count = Random.Range(0, data.Length);
        float x = Random.Range(data[Data_count].xPos.x,data[Data_count].xPos.y);

        int a = Random.Range(0, GameObjects.Length);

        GameObject b= Instantiate(GameObjects[a]);

        b.transform.position = new Vector2(x, 0);

        StartCoroutine(ItemSpawnCo());
    }
}
