using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterPanel : YLBasePanel
{
    private Text promptText;
    private InputField usernameInputFilded;
    private InputField passwordInputFilded;
    private InputField repasswordInputFilded;
    private InputField nicknameInputFilded;

    public Button registerButton;
    public Button backButton;

    private void Awake()
    {
        promptText = transform.Find("Bg/PromptText").GetComponent<Text>();
        usernameInputFilded = transform.Find("Bg/UserrnameInputField").GetComponent<InputField>();
        passwordInputFilded = transform.Find("Bg/PasswordInputField").GetComponent<InputField>();
        repasswordInputFilded = transform.Find("Bg/RePasswordInputField").GetComponent<InputField>();
        nicknameInputFilded = transform.Find("Bg/NicknameInputField").GetComponent<InputField>();
        registerButton = transform.Find("Bg/RegisterButton").GetComponent<Button>();
        backButton = transform.Find("Bg/BackButton").GetComponent<Button>();


    }
    protected override void Start()
    {
        base.Start();
        registerButton.onClick.AddListener(RegisterButtonClick);
        backButton.onClick.AddListener(BackButtonClick);
    }
    /// <summary>
    /// 注册按钮点击事件
    /// </summary>
    private void RegisterButtonClick()
    {
        if (usernameInputFilded.text == null || usernameInputFilded.text.Length == 0)
        {
            SetPromptText("用户名不能为空", Color.red);
        }
        else if (passwordInputFilded.text == null || passwordInputFilded.text.Length == 0)
        {
            SetPromptText("密码不能为空", Color.red);
        }
        else if (passwordInputFilded.text != repasswordInputFilded.text)
        {
            SetPromptText("两次密码不一致", Color.red);
        }
        else if (nicknameInputFilded.text.Length == 0 || nicknameInputFilded == null)
        {
            SetPromptText("昵称不能为空", Color.red);
        }
        else
        {
            int ret = YLDataManager.Instance.Register(usernameInputFilded.text, passwordInputFilded.text, nicknameInputFilded.text);
            if (ret == 0)
            {
                SetPromptText("注册成功", Color.blue);
            }
            else
            {
                SetPromptText("用户名已存在", Color.red);
            }
        }
    }
    /// <summary>
    /// 设置提示
    /// </summary>
    /// <param name="message"></param>
    /// <param name="color"></param>
    private void SetPromptText(string message,Color color)
    {
        promptText.text = message;
        promptText.color = color;
    }
    /// <summary>
    /// 返回按钮点击事件
    /// </summary>
    private void BackButtonClick()
    {
        YLUIManager.Instance.ClosePanel<RegisterPanel>();
    }
}
