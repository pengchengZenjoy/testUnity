using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginPanel : PanelBase,IMsgReceiver
{

    private Button closeBtn;

    private Image testImg;

    private Text progressTxt;

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

        MsgDispatcher.GetInstance().Subscribe(GameEvents.Msg_ShowLoadingContent, this);
        MsgDispatcher.GetInstance().Subscribe(GameEvents.Msg_DownloadProgress, this);
        MsgDispatcher.GetInstance().Subscribe(GameEvents.Msg_DownloadFinish, this);

        Transform skinTrans = skin.transform;
        closeBtn = skinTrans.Find("CloseBtn").GetComponent<Button>();

        closeBtn.onClick.AddListener(OnCloseClick);

        testImg = skinTrans.Find("TestImage").GetComponent<Image>();
        progressTxt = skinTrans.Find("Progress").GetComponent<Text>();
        
        UpdateVersionManager.Instance.CheckVersion((bool needUpdate) => {
            UpdateAssetManager.Instance.CheckAsset(() => {
                progressTxt.text = "已经是最新资源";
                MsgDispatcher.GetInstance().Fire(GameEvents.Msg_DownloadFinish);
            });
        });
    }
    #endregion

    public bool OnMsgHandler(string msgName, params object[] args) {
        switch (msgName) {
            case GameEvents.Msg_ShowLoadingContent:
                progressTxt.text = (string)args[0];
                break;
            case GameEvents.Msg_DownloadProgress:
                progressTxt.text = (string)args[0];
                break;
            case GameEvents.Msg_DownloadFinish: {
                    AssetManager.Instance.InitMode(GameConfigs.LoadAssetMode);

                    progressTxt.text = "资源更新完成";
                }
                break;
        }
        return true;
    }

    public void OnCloseClick()
    {
        //Close();
        Sprite sp = AssetManager.Instance.LoadAsset<Sprite>(GameConfigs.GetSpritePath("button_green"));
        testImg.sprite = sp;
    }
}