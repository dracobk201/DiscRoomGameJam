using UnityEngine;

public class RedirectWeb : MonoBehaviour
{
    [SerializeField] private StringReference webUrl = null;

    public void OpenWeb()
    {
        Application.OpenURL(webUrl.Value);
    }
}
