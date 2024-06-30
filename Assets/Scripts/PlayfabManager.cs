using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayfabManager : MonoBehaviour

{
    [Header("UI")]
    public Text messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Upload");
    }


    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password too short! Must be at least 6 characters";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {

            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        }; PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
      //  messageText.text = "Registered and logged in";
        StartCoroutine(WaitForSceneLoad());
    }
    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);

    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "7AA23"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset e-mail sent";
    }
    void OnLoginSuccess(LoginResult result)
    {
      //  messageText.text = "Logged in!";
        Debug.Log("Successful log in");
        GetCharacters();
        StartCoroutine(WaitForSceneLoad());
    }
    public void GetCharacters()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Login()
    {
      //  var request = new LoginWithCustomIDRequest
      // {
      //      CustomId = SystemInfo.deviceUniqueIdentifier,
      //      CreateAccount = true
      //  };
      //  PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
      //
      //  void OnSuccess(LoginResult result)
      //  {
      //      Debug.Log("Login successful/account create");
      //  }

        void OnError(PlayFabError error)
        {
            Debug.Log("Error while login/account create");
            Debug.Log(error.GenerateErrorReport());
        }
    }
}
