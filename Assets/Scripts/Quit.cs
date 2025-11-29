using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    public Button quit;

    private void Start()
    {
        if (quit != null)
        {
           quit.onClick.AddListener(ClientAction);
        }
    }

    void ClientAction()
    {
        Debug.Log("Клиент нажал кнопку!");
    }
}
