using System.Collections;
using System.Collections.Generic;
using Model;
using UniRx;
using UnityEngine;

namespace Data
{
    public class Repository
    {
        public MainDataSource LoadMainDataSource()
        {
            var followers = Observable
                .FromCoroutineValue<int>(GetFollowers)
                .ToReactiveProperty();

            var following = Observable
                .FromCoroutineValue<int>(GetFollowers)
                .ToReactiveProperty();

            var posts = Observable
                .FromCoroutineValue<int>(GetFollowers)
                .ToReactiveProperty();

            var userName = Observable
                .FromCoroutineValue<string>(NameFromServer)
                .ToReactiveProperty();

            var id = Observable
                .FromCoroutineValue<string>(NameFromServer)
                .ToReactiveProperty();

            var photoUrl = Observable
                .FromCoroutineValue<string>(LoadPhotoUrlFromServer)
                .ToReactiveProperty();

            return new MainDataSource(
                follower: followers,
                following: following,
                posts: posts,
                name: userName,
                id: id,
                photoUrl: photoUrl
            );
        }

        public IEnumerator<int> GetFollowers()
        {
            new WaitForSecondsRealtime(3);
            yield return 3;
        }

        public IEnumerator NameFromServer()
        {
            yield return "loading,...";
            yield return new WaitForSeconds(3);
            yield return "Kim";
        }

        public IEnumerator LoadPhotoUrlFromServer()
        {
            yield return "";
            yield return new WaitForSeconds(0.5f);
            yield return
                "https://images.pexels.com/photos/2913125/pexels-photo-2913125.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=2";
        }
    }
}