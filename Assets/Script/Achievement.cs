using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement : MonoBehaviour {

	public static Achievement instance;

	[Header("UI")]
	public GameObject MainMenuUI;
	public GameObject AchievementUI;

	[Header("Achievements")]
	public GameObject Level;
	public GameObject LevelComplete, Kill, KillComplete, Headshot, HeadshotComplete, BossKill, BossKillComplete;

	[Header("Sliders")]
	public Slider LevelSlider;
	public Slider KillSlider, HeadshotSlider, BossKillSlider;

	[Header("Texts")]
	public Text LevelAchievementTxt;
	public Text LevelProgressTxt, LevelRewardTxt;
	public Text KillAchievementTxt, KillProgressTxt, KillRewardTxt;
	public Text HeadshotAchievementTxt, HeadshotProgressTxt, HeadshotRewardTxt;
	public Text BossProgressTxt;

	[Header("ClaimBtns")]
	public Button LevelClaimBtn;
	public Button KillClaimBtn, HeadshotClaimBtn, BossKillClaimBtn;

	int LevelAchievement, KillAchievement,HeadshotAchievement;

	void Awake()
	{
		instance = this;
	}

	void Start () 
	{
		init ();
		SetAchievements ();
	}

	void init()
	{
		Level.SetActive (true);
		LevelComplete.SetActive (false);
		Kill.SetActive (true);
		KillComplete.SetActive (false);
		Headshot.SetActive (true);
		HeadshotComplete.SetActive (false);
		BossKill.SetActive (true);
		BossKillComplete.SetActive (false);
	}

	public void SetAchievements()
	{
		LocalData data = DatabaseManager.Instance.GetLocalData();
		if (data != null)
		{

			Debug.Log("Test");
			switch (data.LevelAchievement)
			{
				case 0:
					LevelAchievement = 10;
					ClaimBtnEnable();
					LevelAchievementTxt.text = "Reach at Level 10";
					LevelProgressTxt.text = "(" + data.Level + "/10)";
					LevelRewardTxt.text = "Get 500 coins";
					LevelSlider.maxValue = LevelAchievement;
					LevelSlider.value = data.Level;
					break;
				case 1:
					LevelAchievement = 25;
					ClaimBtnEnable();
					LevelAchievementTxt.text = "Reach at Level 25";
					LevelProgressTxt.text = "(" + data.Level + "/25)";
					LevelRewardTxt.text = "Get 1000 coins";
					LevelSlider.maxValue = LevelAchievement;
					LevelSlider.value = data.Level;
					break;
				case 2:
					LevelAchievement = 50;
					ClaimBtnEnable();
					LevelAchievementTxt.text = "Reach at Level 50";
					LevelProgressTxt.text = "(" + data.Level + "/50)";
					LevelRewardTxt.text = "Get 3000 coins";
					LevelSlider.maxValue = LevelAchievement;
					LevelSlider.value = data.Level;
					break;
				case 3:
					Level.SetActive(false);
					LevelComplete.SetActive(true);
					break;
			}
			switch (data.KillAchievement)
			{
				case 0:
					KillAchievement = 50;
					ClaimBtnEnable();
					KillAchievementTxt.text = "Kill 50 Enemies";
					KillProgressTxt.text = "(" + data.AchievementKill + "/50)";
					KillRewardTxt.text = "Get 100 coins";
					KillSlider.maxValue = KillAchievement;
					KillSlider.value = data.AchievementKill;
					break;
				case 1:
					KillAchievement = 150;
					ClaimBtnEnable();
					KillAchievementTxt.text = "Kill 150 Enemies";
					KillProgressTxt.text = "(" + data.AchievementKill + "/150)";
					KillRewardTxt.text = "Get 300 coins";
					KillSlider.maxValue = KillAchievement;
					KillSlider.value = data.AchievementKill;
					break;
				case 2:
					KillAchievement = 300;
					ClaimBtnEnable();
					KillAchievementTxt.text = "Kill 300 Enemies";
					KillProgressTxt.text = "(" + data.AchievementKill + "/300)";
					KillRewardTxt.text = "Unlock Cold Steel 4 Edge Star";
					KillSlider.maxValue = KillAchievement;
					KillSlider.value = data.AchievementKill;
					break;
				case 3:
					Kill.SetActive(false);
					KillComplete.SetActive(true);
					break;
			}
			switch (data.HeadshotAchievement)
			{
				case 0:
					HeadshotAchievement = 25;
					ClaimBtnEnable();
					HeadshotAchievementTxt.text = "25 Headshots";
					HeadshotProgressTxt.text = "(" + data.AchievementHeadshot + "/25)";
					HeadshotRewardTxt.text = "Get 50 coins";
					HeadshotSlider.maxValue = HeadshotAchievement;
					HeadshotSlider.value = data.AchievementHeadshot;
					break;
				case 1:
					HeadshotAchievement = 50;
					ClaimBtnEnable();
					HeadshotAchievementTxt.text = "50 Headshots";
					HeadshotProgressTxt.text = "(" + data.AchievementHeadshot + "/50)";
					HeadshotRewardTxt.text = "Get 100 coins";
					HeadshotSlider.maxValue = HeadshotAchievement;
					HeadshotSlider.value = data.AchievementHeadshot;
					break;
				case 2:
					HeadshotAchievement = 100;
					ClaimBtnEnable();
					HeadshotAchievementTxt.text = "100 Headshots";
					HeadshotProgressTxt.text = "(" + data.AchievementHeadshot + "/100)";
					HeadshotRewardTxt.text = "Unlock Ninja Cap";
					HeadshotSlider.maxValue = HeadshotAchievement;
					HeadshotSlider.value = data.AchievementHeadshot;
					break;
				case 3:
					Headshot.SetActive(false);
					HeadshotComplete.SetActive(true);
					break;
			}
			switch (data.BossKillAchievement)
			{
				case 0:
					ClaimBtnEnable();
					BossProgressTxt.text = "(" + (int)(data.Level / 3) + "/10)";
					BossKillSlider.value = (int)(data.Level / 3);
					break;
				case 1:
					BossKill.SetActive(false);
					BossKillComplete.SetActive(true);
					break;
			}

		}
	}

	void ClaimBtnEnable()
	{
		if (Achievement.instance.LevelSlider.value >= Achievement.instance.LevelSlider.maxValue)
			LevelClaimBtn.GetComponent<Button> ().interactable = true;
		else
			LevelClaimBtn.GetComponent<Button> ().interactable = false;

		if (Achievement.instance.KillSlider.value >= Achievement.instance.KillSlider.maxValue)
			KillClaimBtn.GetComponent<Button> ().interactable = true;
		else
			KillClaimBtn.GetComponent<Button> ().interactable = false;

		if (Achievement.instance.HeadshotSlider.value >= Achievement.instance.HeadshotSlider.maxValue)
			HeadshotClaimBtn.GetComponent<Button> ().interactable = true;
		else
			HeadshotClaimBtn.GetComponent<Button> ().interactable = false;

		if (Achievement.instance.BossKillSlider.value >= Achievement.instance.BossKillSlider.maxValue)
			BossKillClaimBtn.GetComponent<Button> ().interactable = true;
		else
			BossKillClaimBtn.GetComponent<Button> ().interactable = false;
	}

	public void ClaimBtn(int index)
	{
		LocalData data = DatabaseManager.Instance.GetLocalData();
		if (data != null)
		{
			switch (index)
			{
				case 0:
					if (data.Level >= LevelAchievement)
					{
						audioManager.instance.PlaySound("Click");
						if (data.LevelAchievement == 0)
						{
							data.coins += 500;
							data.LevelAchievement = 1;
							Web3_UIManager.Instance.SetCoinText();
							DatabaseManager.Instance.UpdateData(data);
							SetAchievements();
						}
						else if (data.LevelAchievement == 1)
						{
							data.coins += 1000;
							data.LevelAchievement = 2;
							Web3_UIManager.Instance.SetCoinText();
							DatabaseManager.Instance.UpdateData(data);
							SetAchievements();
						}
						else if (data.LevelAchievement == 2)
						{
							data.coins += 3000;
							data.LevelAchievement = 3;
							Web3_UIManager.Instance.SetCoinText();
							DatabaseManager.Instance.UpdateData(data);
							SetAchievements();
						}
					}
					break;
				case 1:
					if (data.AchievementKill >= KillAchievement)
					{
						audioManager.instance.PlaySound("Click");
						if (data.KillAchievement == 0)
						{
							data.coins += 100;
							Web3_UIManager.Instance.SetCoinText();
							data.AchievementKill = 0;							
							data.KillAchievement=1;
							SetAchievements();
							DatabaseManager.Instance.UpdateData(data);
						}
						else if (data.KillAchievement == 1)
						{
							data.coins += 300;
							Web3_UIManager.Instance.SetCoinText();
							data.AchievementKill = 0;
							data.KillAchievement = 2;							
							SetAchievements();
							DatabaseManager.Instance.UpdateData(data);
						}
						else if (data.KillAchievement == 2)
						{
							data.ColdSteel4EdgeStar = 1;
							data.AchievementKill = 0;
							data.KillAchievement =3;
							SetAchievements();
							DatabaseManager.Instance.UpdateData(data);
						}
					}
					break;
				case 2:
					if (data.AchievementHeadshot >= HeadshotAchievement)
					{
						audioManager.instance.PlaySound("Click");
						if (data.HeadshotAchievement == 0)
						{
							data.coins += 50;
							Web3_UIManager.Instance.SetCoinText();

							data.AchievementHeadshot = 0;
							data.HeadshotAchievement = 1;
							

							SetAchievements();
							DatabaseManager.Instance.UpdateData(data);
						}
						else if (data.HeadshotAchievement == 1)
						{
							data.coins += 100;
							Web3_UIManager.Instance.SetCoinText();

							data.AchievementHeadshot = 0;
							data.HeadshotAchievement = 2;

							
							SetAchievements();
							DatabaseManager.Instance.UpdateData(data);
						}
						else if (data.HeadshotAchievement == 2)
						{
							data.NinjaCap = 1;
							data.AchievementHeadshot = 0;
							data.HeadshotAchievement = 3;
							
							SetAchievements();
							DatabaseManager.Instance.UpdateData(data);
						}
					}
					break;
				case 3:
					if (data.Level >= 30)
					{
						audioManager.instance.PlaySound("Click");
						if (data.BossKillAchievement == 0)
						{
							data.coins += 2500;
							Web3_UIManager.Instance.SetCoinText();

							data.BossKillAchievement = 1;
							SetAchievements();
							DatabaseManager.Instance.UpdateData(data);
						}
					}
					break;
			}
			HomeUIManager.insta.checkAchievement();
		}
	}

	public void BackBtn()
	{
		audioManager.instance.PlaySound ("Click");
		MainMenuUI.SetActive (true);
		AchievementUI.SetActive (false);
	}

}
