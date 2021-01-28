using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapManager : MonoBehaviour
{
    TextMeshProUGUI skor;
    public GameObject ground,ground1,ground2,ground3;
    public GameObject correctSound;
    public GameObject wrongSound;
    AudioSource correct;
    AudioSource wrong;
    private GameObject[] yanlisDizi;
    private GameObject[] dogruDizi;
    int skorSayisi;
    // Start is called before the first frame update
    void Start()
    {
        skorSayisi = 0;
        skor = GameObject.Find("Canvas/Sayac").GetComponent<TextMeshProUGUI>();
        skor.text = "0";
        correct = correctSound.GetComponent<AudioSource>();
        wrong = wrongSound.GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Cevap")
        {
            skorSayisi += 10;
            skor.text = skorSayisi.ToString();
            Destroy(other.gameObject);
            correct.Play();
            for (int i = 0; i < yanlisDizi.Length; i++)
            {
                Destroy(yanlisDizi[i]);
            }
            
        }
        else if (other.gameObject.tag=="Yanlis")
        {
            wrong.Play();
            for (int i = 0; i < yanlisDizi.Length; i++)
            {
                Destroy(yanlisDizi[i]);
            }
            for (int i = 0; i < dogruDizi.Length; i++)
            {
                Destroy(dogruDizi[i]);
            }
        }
        

        if (other.gameObject.tag== "Engel")
        {
            Instantiate(ground, new Vector3(0, 0, transform.position.z + 168f), Quaternion.identity);
        }
        else if (other.gameObject.tag == "Engel1")
        {
            Instantiate(ground1, new Vector3(0, 0, transform.position.z + 168f), Quaternion.identity);
        }
        else if (other.gameObject.tag == "Engel2")
        {
            Instantiate(ground2, new Vector3(0, 0, transform.position.z + 168f), Quaternion.identity);
        }
        else if (other.gameObject.tag == "Engel3")
        {
            Instantiate(ground3, new Vector3(0, 0, transform.position.z + 168f), Quaternion.identity);
        }
    }
    // Update is called once per frame
    void Update()
    {
        dogruDizi = GameObject.FindGameObjectsWithTag("Cevap");
        yanlisDizi= GameObject.FindGameObjectsWithTag("Yanlis");
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");
        for (int i = 0; i < grounds.Length; i++)
        {
            if (transform.position.z-5>grounds[i].transform.position.z+20)
            {
                Destroy(grounds[i]);
            }
        }
    }
}
