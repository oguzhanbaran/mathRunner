using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject targetPlayer;
    public GameObject correctCube;
    public GameObject wrongCube1;
    public GameObject wrongCube2;
    TextMeshProUGUI correctAnswer;
    TextMeshProUGUI wrongAnswer1;
    TextMeshProUGUI wrongAnswer2;
    TextMeshProUGUI question;
    private float questionSpawnTime;
    

    void Start()
    {
        question = GameObject.Find("Canvas/Soru").GetComponent<TextMeshProUGUI>();
        correctAnswer = correctCube.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        wrongAnswer1 = wrongCube1.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        wrongAnswer2 = wrongCube2.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        questionSpawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] cevapDizi = GameObject.FindGameObjectsWithTag("Cevap");
        GameObject[] yanlisCevapDizi = GameObject.FindGameObjectsWithTag("Yanlis");
        if (Time.time>questionSpawnTime)
        {
            questionSpawnTime += 5f;
            Invoke("CreateQuestion",0f);
        }
        for (int i = 0; i < cevapDizi.Length; i++)
        {
            if (targetPlayer.transform.position.z-4f>cevapDizi[i].transform.position.z)
            {
                question.text = "";
                Destroy(cevapDizi[i]);
            }
        }
        for (int i = 0; i < yanlisCevapDizi.Length; i++)
        {
            if (targetPlayer.transform.position.z - 10f > yanlisCevapDizi[i].transform.position.z)
            {
                Destroy(yanlisCevapDizi[i]);
            }
        }

    }
    void CreateQuestion()
    {
        List<float> positionX = new List<float>() { -2.99f, 0f, 2.99f };
         List<int> mesafeArray = new List<int>() { 30,37,44};
        int randomMesafe= Random.Range(0, 3);
        int randomMesafe2 = Random.Range(0, 2);
        int random1 = Random.Range(0, 3);
        int random2 = Random.Range(0, 2);
        int x = Random.Range(1, 10);
        int y = Random.Range(1, 10);
        int yanlisCevap1 = (Random.Range(x, 11) * Random.Range(1, y));
        int yanlisCevap2 = (Random.Range(x, 11) * Random.Range(1, y));
        question.text = x.ToString() + "x" + y.ToString()+"=?";
        while (yanlisCevap1==x*y || yanlisCevap2==x*y || yanlisCevap1==yanlisCevap2)
        {
            yanlisCevap1= (Random.Range(1, 11) * Random.Range(1, 11));
            yanlisCevap2 = (Random.Range(1, 11) * Random.Range(1, 11));
        }
        wrongAnswer1.text = yanlisCevap1.ToString();
        wrongAnswer2.text = yanlisCevap2.ToString();
        correctAnswer.text = (x * y).ToString();
        Instantiate(correctCube, new Vector3(positionX[random1], 1, targetPlayer.transform.position.z + mesafeArray[randomMesafe]), Quaternion.identity);
        positionX.RemoveAt(random1);
        mesafeArray.RemoveAt(randomMesafe);
        Instantiate(wrongCube1, new Vector3(positionX[random2], 1, targetPlayer.transform.position.z + mesafeArray[randomMesafe2]), Quaternion.identity);
        positionX.RemoveAt(random2);
        mesafeArray.RemoveAt(randomMesafe2);
        Instantiate(wrongCube2, new Vector3(positionX[0], 1, targetPlayer.transform.position.z + mesafeArray[0]), Quaternion.identity);
        

    }
}
