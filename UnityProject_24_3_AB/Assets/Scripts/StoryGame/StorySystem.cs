using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class StorySystem : MonoBehaviour
{
    public static StorySystem instance;             //������ �̱���ȭ 

    public StoryModel currentStoryModel;
    public enum TEXTSYSTEM
    {
        DOING,
        SELECT,
        DONE
    }

    public float delay = 0.1f;                      //�� ���ڰ� ��Ÿ���µ� �ɸ��� �ð�
    public string fullText;                         //��ü ǥ���� �ؽ�Ʈ
    private string currentText = "";                //������� ǥ�õ� �ؽ�Ʈ 

    public Text textComponent;                      //Text ������Ʈ
    public Text storyIndex;                         //���� ���丮 ��ȣ

    public Image imageComponent;                    //������ �̹��� ������Ʈ

    public Button[] buttonWay = new Button[3];
    public Text[] buttonWayText = new Text[3];

    private void Awake()
    {
        instance = this; 
    }

    public void OnWayClick(int index)               //��ư�� �������� �ش� ������ index�� �޾ƿ´�. 
    {
        bool CheckEventTypeNone = false;            //�⺻���� NONE �� ���� �����̶�� �Ǵ�
        StoryModel playStoryModel = currentStoryModel;
        Debug.Log(index);

        if (playStoryModel.options[index].eventCheck.eventType == StoryModel.EventCheck.EventType.NONE) 
        {
            for(int i = 0; i < playStoryModel.options[index].eventCheck.sucessResult.Length; i++)
            {
                GameSystem.instance.ApplyChoice(currentStoryModel.options[index].eventCheck.sucessResult[i]);
                CheckEventTypeNone = true;
            }
        }

        bool CheckValue = false;

    }

  

    public void StoryModelInit()                                //���丮 �� Init 
    {
        fullText = currentStoryModel.storyText;

        storyIndex.text = currentStoryModel.storyNumber.ToString();

        for(int i = 0; i < currentStoryModel.options.Length; i++)
        {
            buttonWayText[i].text = currentStoryModel.options[i].buttonText;
        }
    }

    public void ResetShow()                                             //���� Commpont �ʱ�ȭ 
    {
        textComponent.text = "";

        for(int i = 0; i < buttonWay.Length; i++)
        {
            buttonWay[i].gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < buttonWay.Length; i++)
        {
            int wayIndex = i;       //Ŭ���� (Closure) ������ �ذ� �ϱ� ���ؼ� 
            //Ŭ���� ���� -> ���ٽ� �Ǵ� �͸� �Լ��� �ܺ� ������ ĸ���� �� �߻��ϴ� ���� 
            buttonWay[i].onClick.AddListener(() => OnWayClick(wayIndex));        //()=> OnWayClick(i) �� �������� 2 ���� ��� ��
        }

        CoShowText();
    }

    public void CoShowText()                
    {
        StoryModelInit();
        ResetShow();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()                                              //�տ� ������ ��� ������Ʈ���� Model �� �Լ��� ���ؼ� ����
    {
        if(currentStoryModel.mainImage != null) 
        {
            //Texture2D�� Sprite�� ��ȯ 
            Rect rect = new Rect(0,0, currentStoryModel.mainImage.width, currentStoryModel.mainImage.height);   //���� ���̿� �ʺ�
            Vector2 pivot = new Vector2(0.5f, 0.5f);    //��������Ʈ ��(�߽�) ����
            Sprite sprite = Sprite.Create(currentStoryModel.mainImage, rect , pivot);

            //Sprite��ȯ�� �̹����� ������Ʈ�� �ִ´�.  
            imageComponent.sprite = sprite;
        }
        else
        {
            Debug.LogError("�ؽ����� �̻��� �ִ�.");
        }

        for(int i = 0; i < fullText.Length; i++) 
        { 
            currentText = fullText.Substring(0,i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        for(int i = 0; i < currentStoryModel.options.Length; i++)
        {
            buttonWay[i].gameObject.SetActive(true);
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(delay);
    }

    
}
