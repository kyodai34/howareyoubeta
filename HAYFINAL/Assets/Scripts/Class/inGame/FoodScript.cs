using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FoodScript : MonoBehaviour
{
    [SerializeField] private GameObject eye;
    private CanvasGroup eyeCanvas;
    
    [SerializeField] private GameObject butControll;
    private ButtonControll btnCon;
    
    [SerializeField] private Camera camera;
    public GameObject POS;
    public GameObject back;

    [SerializeField] private GameObject face;
    public Button pnl;

    public GameObject myBut;
    public GameObject backtorBut;
    [SerializeField] private Button order;
    [SerializeField] private GameObject scream;
    [SerializeField] private Text textMob;

    public Text mobtext;
    public Button generalButton;

    public static bool IsScreamer = false; 
    private void Start()
    {
        btnCon = butControll.GetComponent<ButtonControll>();
        eyeCanvas = eye.GetComponent<CanvasGroup>();
        myBut.SetActive(false);
        backtorBut.SetActive(false);
    }

    public void BackFood()
    {
        StartCoroutine(CloseEyes());
        camera.transform.position = back.transform.position;
        camera.transform.rotation = back.transform.rotation;
        mobtext.text = "";
        StartCoroutine(OpenEyes());
        myBut.SetActive(false);
        backtorBut.SetActive(false);
        pnl.interactable = true;
    }

    public void FoodOrder()
    {
        StartCoroutine(ButtonOrder());
        if (TextContainer.howFood == 0)
        {
            btnCon.Dont();
            StartCoroutine(CloseEyes());
            Debug.Log("camera");
            camera.transform.position = POS.transform.position;
            camera.transform.rotation = POS.transform.rotation;
            myBut.SetActive(true);
            StartCoroutine(OpenEyes());
            TextContainer.howFood++;
            pnl.interactable = false;
            generalButton.gameObject.SetActive(false);
            myBut.SetActive(true);
            backtorBut.SetActive(true);
        }
        else
        {
            scream.SetActive(true);
            IsScreamer = true;
            TypewriterEffectWithList.lastVol = TypewriterEffectWithList.vol;
            TypewriterEffectWithList.vol = 0f;
            textMob.text = "- Хватит уходить от вопросов.";
            btnCon.Dont();
            pnl.interactable = true;
            generalButton.gameObject.SetActive(true);
            TextContainer.howFood++;
        }
    }
    
    private IEnumerator OpenEyes()
    {
        float speed = 3f;
        float time = 0f;
        while (eyeCanvas.alpha >= 0)
        {
            eyeCanvas.alpha = Mathf.Lerp(1, 0, time/speed);
            time += Time.deltaTime;
            Debug.Log(eyeCanvas.alpha);
            yield return null;
        }
        eyeCanvas.alpha = 0f;
        Debug.Log("open");
        yield break;
    }
    
    private IEnumerator CloseEyes()
    {
        float speed = 3f;
        float time = 0f;
        while (eyeCanvas.alpha <= 1)
        {
            eyeCanvas.alpha = Mathf.Lerp(0, 1, time/speed);
            time += Time.deltaTime;
            yield return null;
        }
        eyeCanvas.alpha = 1f;
        Debug.Log("close");
        yield break;
    }

    private IEnumerator ButtonOrder()
    {
        order.interactable = false;
        yield return new WaitForSeconds(3f);
        order.interactable = true;
    }
    
    public IEnumerator Screamer()
    {
        face.SetActive(true);
        yield return new WaitForSeconds(2f);
        face.SetActive(false);
    }
}
