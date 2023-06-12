using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [field: SerializeField]
    public ItemObject InventoryItem { get; private set; }

    [field: SerializeField]
    public int Quantity { get; set; } = 1;

    [SerializeField]
    private AudioSource audioSource;
    private float duration = 0.3f;

    public int potionID;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = InventoryItem.ItemImg;
        if (GlobalVariableStorage.isPotionCollected(potionID))
        {
            Destroy(this.gameObject);
        }
    }

    public void DestroyItem()
    {
        GetComponent<Collider2D>().enabled = false;
        StartCoroutine(AnimateItemPickup());
        // audioSource.Play();
        // Invoke("destroyobj", 0.5f);
    }

    public void destroyobj()
    {
        Destroy(gameObject);
    }

    private IEnumerator AnimateItemPickup()
    {
        audioSource.Play();
        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.zero;
        float currentTime = 0;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            transform.localScale = 
                Vector3.Lerp(startScale, endScale, currentTime / duration);
            yield return null;
        }
        Destroy(gameObject);
        GlobalVariableStorage.potionCollected(potionID);
    }
}
