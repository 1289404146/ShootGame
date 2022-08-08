using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LoginPanel : YLBasePanel
{
    private InputField usernameInputField;
    private InputField passwordInputField;
    private Button loginButton;
    private Button registerButton;
    private Text promptText;


    private void Awake()
    {
        usernameInputField = transform.Find("Bg/UsernameInputField").GetComponent<InputField>();
        passwordInputField = transform.Find("Bg/PasswordInputField").GetComponent<InputField>();
        loginButton = transform.Find("Bg/LoginButton").GetComponent<Button>();
        registerButton = transform.Find("Bg/RegisterButton").GetComponent<Button>();
        promptText = transform.Find("Bg/PromptText").GetComponent<Text>();
        usernameInputField.text = "yy";
        passwordInputField.text = "yy";
    }
    protected override void Start()
    {
        base.Start();
        loginButton.onClick.AddListener(LoginButtonClick);
        registerButton.onClick.AddListener(RegisterButtonClick);
    }
    /// <summary>
    /// 登录按钮点击事件
    /// </summary>
    private void RegisterButtonClick()
    {
        YLUIManager.Instance.OpenPanel<RegisterPanel>();
    }
    /// <summary>
    /// 注册按钮点击事件
    /// </summary>
    private void LoginButtonClick()
    {
        if (usernameInputField.text == null || usernameInputField.text.Length == 0)
        {
            SetPromptText("用户名不能为空", Color.red);
        }
        else if (passwordInputField.text == null || passwordInputField.text.Length == 0)
        {
            SetPromptText("密码不能为空", Color.red);
        }
        else
        {
            int ret = YLDataManager.Instance.Login(usernameInputField.text, passwordInputField.text);
            if(ret == 0)
            {
                SetPromptText("登陆成功",Color.blue);
                YLSingleton<Login>.Instance.DeIntialize();
                YLScenesManager.Instance.LoadScene(SceneType.Main);
            }
            else if (ret == -1)
            {
                SetPromptText("用户名不存在", Color.red);
            }
            else
            {
                SetPromptText("用户名或者密码错误", Color.red);
            }
        }
    }
    /// <summary>
    /// 设置提示
    /// </summary>
    /// <param name="message"></param>
    /// <param name="color"></param>
    private void SetPromptText(string message, Color color)
    {
        promptText.text = message;
        promptText.color = color;
    }
}
