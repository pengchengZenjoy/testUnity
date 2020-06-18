using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginPanel : PanelBase
{

    private Button closeBtn;

    private Image testImg;

    #region 生命周期
    public override void Init(params object[] args)
    {
        base.Init(args);
        skinPath = "LoginPanel";
        layer = PanelLayer.Panel;
    }

    public override void OnShowing()
    {
        base.OnShowing();
        Transform skinTrans = skin.transform;
        closeBtn = skinTrans.Find("CloseBtn").GetComponent<Button>();

        closeBtn.onClick.AddListener(OnCloseClick);

        testImg = skinTrans.Find("TestImage").GetComponent<Image>();

        AssetManager.Instance.InitMode(GameConfigs.LoadAssetMode);
    }
    #endregion

    public void OnCloseClick()
    {
        //Close();
        Sprite sp = AssetManager.Instance.LoadAsset<Sprite>(GameConfigs.GetSpritePath("button_green"));
        testImg.sprite = sp;
    }
}