using System;
using System.Collections;
using System.Text.RegularExpressions;
using Data;
using Model;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Presenter : MonoBehaviour
{
    private const string UrlPattern =
        "^https?:\\/\\/(?:www\\.)?[-a-zA-Z0-9@:%._\\+~#=]{1,256}\\.[a-zA-Z0-9()]{1,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$";

    [SerializeField] private TextMeshProUGUI _idText;
    [SerializeField] private RawImage _photoImage;
    [SerializeField] private TextMeshProUGUI _postsText;
    [SerializeField] private TextMeshProUGUI _followerText;
    [SerializeField] private TextMeshProUGUI _followingText;
    [SerializeField] private TextMeshProUGUI _nameText;

    private PersonWhoShouldKnow[] _peopleWhoShouldKnow;
    private StoryHighlight[] _stories;

    private MainDataSource _dataSource;
    private Repository _repository;

    private void Awake()
    {
        _repository = new();
    }

    private void Start()
    {
        _dataSource = _repository.LoadMainDataSource();
        _dataSource.Follower.Subscribe(Observer.Create<int>(
            onNext: follower => { _followerText.text = follower.ToString(); })
        );
        _dataSource.PhotoUrl.Subscribe(onNext: (s => StartCoroutine(LoadImage(s))));
    }

    private IEnumerator LoadImage(string url)
    {
        yield return GetTexture(url);
    }

    private IEnumerator GetTexture(string url)
    {
        if (!Regex.Match(url, UrlPattern).Success) yield break;

        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            _photoImage.texture = myTexture;
        }
    }
}