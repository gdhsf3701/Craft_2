using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingMove : MonoBehaviour
{
    bool noOpen = true;

    float closeBorderLeftX = -110;
    float closeBorderRightX = 114;
    
    float openBorderLeftX = -820;
    float openBorderRightX = 829;

    [SerializeField]
    private GameObject SettingPanel;

    [SerializeField]
    private RectTransform SettingBorderLeft,SettingBorderRight, SettingBack;

    [SerializeField] SoundSO scrollDown, scrollOpen, SettingBGM;

    SoundPlayer BGMPlayer;

    private BgmManger bgmManger;

    private void Awake()
    {
        bgmManger = BgmManger.Instance;
        SettingPanel.SetActive(false);
        SettingBack.localScale = new Vector3(1,8,0);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnOffSetting();
        }
    }

    public void OnOffSetting()
    {
        DOTween.KillAll();
        if (noOpen)
        {
            SettingOpen();
            noOpen = false;
        }
        else if (!noOpen)
        {
            SettingClose();
            noOpen = true;
        }
    }
    private void Start()
    {
        
    }
    private void SettingOpen()
    {
        Sequence seq = DOTween.Sequence().SetUpdate(true);
        Time.timeScale = 0;

        SoundPlayer scrollPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        SoundPlayer soundPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        BGMPlayer = PoolManager.Instance.Pop("SoundPlayer") as SoundPlayer;
        scrollPlayer.PlaySound(scrollDown);
        seq.Append(transform.DOLocalMoveY(-970, 1.5f)).SetEase(Ease.Linear);
        seq.AppendInterval(0.3f);

        seq.Append(transform.DOLocalMoveY(-950, 0.15f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-990, 0.175f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-950, 0.2f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-990, 0.225f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-950, 0.25f)).SetEase(Ease.OutExpo);
        seq.Append(transform.DOLocalMoveY(-990, 0.275f)).SetEase(Ease.OutExpo);
        bgmManger.BGMStop();

        seq.AppendCallback(()=> SettingPanel.SetActive(true));
        seq.Join(SettingBorderLeft.DOAnchorPosX(openBorderLeftX, 0.75f)).SetEase(Ease.Linear);
        seq.Join(SettingBorderRight.DOAnchorPosX(openBorderRightX, 0.75f)).SetEase(Ease.Linear);
        seq.Join(SettingBack.DOScaleX(15, 0.75f)).SetEase(Ease.Linear);
        soundPlayer.PlaySound(scrollOpen);
        BGMPlayer.PlaySound(SettingBGM);
    }
    private void SettingClose()
    {
        Sequence seq = DOTween.Sequence();

        Time.timeScale = 1;

        seq.Append(SettingBorderLeft.DOAnchorPosX(closeBorderLeftX, 0.75f)).SetEase(Ease.Linear);
        seq.Join(SettingBorderRight.DOAnchorPosX(closeBorderRightX, 0.75f)).SetEase(Ease.Linear);
        seq.Join(SettingBack.DOScaleX(1, 0.75f)).SetEase(Ease.Linear);
        BGMPlayer.StopAndGoToPool();
        seq.AppendCallback(() => SettingPanel.SetActive(false));
        seq.Append(transform.DOLocalMoveY(162, 1.5f)).SetEase(Ease.OutSine);
        bgmManger.BGMStart();

    }
    public void GoStart()
    {
        Time.timeScale = 1;
        print(1);
        SceneManager.LoadScene(SceneName.Start);
    }
}
