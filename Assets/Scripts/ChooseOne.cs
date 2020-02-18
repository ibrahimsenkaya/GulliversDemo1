using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ChooseOne : MonoBehaviour
{
    float Delay = .05f;
    float DelayPlus;
    float DiffOfDelay = .5f;

    int BaseCounter = 20; //it spins 4 times to frames (9*4)

    [SerializeField] Color Green, Grey;
    [SerializeField] GameObject[] Frames;
    [SerializeField] Image[] Images;
    [SerializeField] Sprite[] Skins;
    void Awake()
    {
        Skins= ShuffleArray(Skins);
        for (int i = 0; i < Frames.Length; i++)
        {
            Images[i] = Frames[i].GetComponent<Image>();
   
        }
    
    }
    public void CallSpin()
    {
        Delay = .05f;
        int RndFrame = Random.Range(0, 8);
        DelayPlus = DiffOfDelay / (BaseCounter + RndFrame);
        print(DelayPlus);
        StartCoroutine(Spin(RndFrame, DelayPlus));
    }

    public IEnumerator Spin(int Counter,float Delayplus)
    {
        for (int i = 0; i < BaseCounter + Counter; i++)
        {
            Images[i % 9].color = Green;
            yield return new WaitForSeconds(Delay);
            print(Delay+" Delay");
            Delay += DelayPlus;
            Images[i % 9].color = Grey;
        }

        Images[(BaseCounter + Counter - 1) % 9].color = Green;
        Frames[(BaseCounter + Counter - 1) % 9].transform.GetChild(1).GetComponent<Image>().sprite = Skins[(BaseCounter + Counter - 1) % 9];


    }

    private T[] ShuffleArray<T>(T[] array)
    {
        System.Random r = new System.Random();
        for (int i = array.Length; i > 0; i--)
        {
            int j = r.Next(i);
            T k = array[j];
            array[j] = array[i - 1];
            array[i - 1] = k;
        }

        return array;
    }

}
