using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // สำหรับ UI

public class SceneChanger : MonoBehaviour
{
    public string sceneName; // กำหนดชื่อฉากที่ต้องการเปลี่ยนผ่าน Inspector

    void Start()
    {
        // ตรวจสอบว่ามีปุ่มอยู่ใน GameObject หรือไม่
        Button btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(ChangeScene);
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
