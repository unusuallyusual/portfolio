using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTalking : MonoBehaviour
{
    [SerializeField] private GameObject talk_1;
    [SerializeField] private GameObject talk_2;
    [SerializeField] private GameObject talk_3;
    [SerializeField] private Image hp;

    private Color hpColor;
    private HealthObj healthObj;

    private void Awake()
    {
        healthObj = GetComponent<HealthObj>();
    }
    private void FixeUpdate()
    {
        if (hpColor != hp.color)
            if (hp.color == Color.yellow)
            {
                IsTalking(talk_1);
                hpColor = hp.color;
            }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Scarecrow"))
            IsTalking(talk_2);

        if (other.gameObject.CompareTag("VillageScarecrow"))
            IsTalking(talk_3);
    }
    public async void IsTalking(GameObject talk)
    {
        if (gameObject && healthObj.CurrentHealth > 0)
        {
            talk.SetActive(true);
            await Task.Delay(4000);
            if (gameObject && healthObj.CurrentHealth > 0)
                talk.SetActive(false);
        }
    }
}
