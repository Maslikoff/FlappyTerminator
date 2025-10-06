using System;
using UnityEngine.SceneManagement;

public class EndScreen : Window
{
    public event Action RestartButtonClicked;

    public override void Close()
    {
        WindowsGroup.alpha = 0;
        ActionButton.interactable = false;
    }

    public override void Open()
    {
        WindowsGroup.alpha = 1;
        ActionButton.interactable = true;
    }

    protected override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
        ClearAllBulletsBeforeRestart();
    }

    private void ClearAllBulletsBeforeRestart()
    {
        Bullet[] bullets = FindObjectsOfType<Bullet>();

        if (bullets.Length == 0)
            return;

        foreach (Bullet bullet in bullets)
            Destroy(bullet.gameObject);
    }
}