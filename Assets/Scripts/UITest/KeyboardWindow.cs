using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardWindow : GenericWindow
{
    //public Button[] quartyButton;
    public Button cancelButton;
    public Button deleteButton;
    public Button acceptButton;

    public TextMeshProUGUI inputField;
    public GameObject rootKeyboard;

    private readonly StringBuilder headerstring = new StringBuilder();

    public int maxCharacter = 7;
    private float timer = 0f;
    private float cursorDelay = 0.5f;
    private bool blink;

    private void Awake()
    {
        cancelButton.onClick.AddListener(Cancel);
        deleteButton.onClick.AddListener(Delete);
        acceptButton.onClick.AddListener(Accept);
        //Typing();
        //StartCoroutine(Cursor());

        var keys = rootKeyboard.GetComponentsInChildren<Button>();
        foreach (var key in keys)
        {
            var text = key.GetComponentInChildren<TextMeshProUGUI>();
            key.onClick.AddListener(() => Onkey(text.text));
        }
    }

    private void Update()
    {
        timer += Time.time;
        if (timer > cursorDelay)
        {
            blink = !blink;
            timer = 0f;
        }
        UpdateInputField();
    }

    public override void Open()
    {
        headerstring.Clear();
        timer = 0f;
        blink = false;
        base.Open();
        UpdateInputField();
    }


    public void Onkey(string key)
    {
        if (headerstring.Length < maxCharacter)
        {
            headerstring.Append(key);
            UpdateInputField();
        }
    }

    private void UpdateInputField()
    {
        bool showCursor = headerstring.Length < maxCharacter && !blink;
        if (showCursor)
        {
            headerstring.Append('_');
        }
        inputField.SetText(headerstring);
        if (showCursor)
        {
            headerstring.Length -= 1;
        }
    }

    private void Cancel()
    {
        headerstring.Clear();
        UpdateInputField();
        //header.text = string.Empty;
    }
    private void Delete()
    {
        if (headerstring.Length > 0)
        {
            headerstring.Length -= 1;
        }
        inputField.text = headerstring.ToString();
        UpdateInputField();
    }
    public void Accept()
    {
        windowManager.Open(2);
    }

    //private void Typing()
    //{
    //    for (int i = 0; i < quartyButton.Length; i++)
    //    {
    //        TextMeshProUGUI text = quartyButton[i].GetComponentInChildren<TextMeshProUGUI>();

    //        quartyButton[i].onClick.AddListener(() =>
    //        { headerstring.Append(text.text); header.text = headerstring.ToString(); });

    //    }
    //}

    //private IEnumerator Cursor()
    //{
    //    bool showCursor = true;
    //    while (true)
    //    {
    //        if (showCursor)
    //        {
    //            header.text = headerstring.ToString() + "_";
    //        }
    //        else
    //        {
    //            header.text = headerstring.ToString();

    //        }

    //        showCursor = !showCursor;

    //        yield return new WaitForSeconds(0.3f);
    //    }

    //}
}
