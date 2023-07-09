using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject ScoreBoard;
    public GameObject PauseButton;
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject StartPanel;

    public void StartPanelShow(){ StartPanel.SetActive(true); }
    public void StartPanelHide(){ StartPanel.SetActive(false); }

    public void GameOverPanelShow(){ GameOverPanel.SetActive(true); }

    public void PausePanelShow(){ PausePanel.SetActive(true); }
    public void PausePanelHide(){ PausePanel.SetActive(false); }

    public void ScoreBoardShow(){ ScoreBoard.SetActive(true); }
    public void ScoreBoardHide(){ ScoreBoard.SetActive(false); }


}
