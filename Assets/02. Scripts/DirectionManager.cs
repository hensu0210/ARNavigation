using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Naver Cloud Platform의 Maps중 Directions5 API에 Directions5 JSON 요청
/// </summary>
public class DirectionManager : MonoBehaviour
{
    [SerializeField] string baseurl = "https://naveropenapi.apigw.ntruss.com/map-direction/v1/driving";
    [SerializeField] string clientID = "";
    [SerializeField] string clientSecret = "";
    [SerializeField] string myPoint = "";
    [SerializeField] string destination = "";

    IEnumerator Start()
    {
        string apiRequestURL = baseurl + $"?start={myPoint}&goal={destination}&option={"목적지이름"}";

        UnityWebRequest request = UnityWebRequest.Get(apiRequestURL);
        request.SetRequestHeader("X-NCP-APIGW-API-KEY-ID", clientID);
        request.SetRequestHeader("X-NCP-APIGW-API-KEY", clientSecret);

        yield return request.SendWebRequest();

        switch (request.result)
        {
            case UnityWebRequest.Result.Success:
                break;
            case UnityWebRequest.Result.ConnectionError:
                yield break;
            case UnityWebRequest.Result.ProtocolError:
                yield break;
            case UnityWebRequest.Result.DataProcessingError:
                yield break;
                break;

        }

        if (request.isDone)
        {
            string json = request.downloadHandler.text;

            print(json);
        }

    }
}
