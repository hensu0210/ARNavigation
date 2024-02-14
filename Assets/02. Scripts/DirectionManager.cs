using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/// <summary>
/// Naver Cloud Platform�� Maps�� Directions5 API�� Directions5 JSON ��û
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
        string apiRequestURL = baseurl + $"?start={myPoint}&goal={destination}&option={"�������̸�"}";

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
