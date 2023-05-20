
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using Utils;

namespace Controller
{
    public class ConnectionRestController : MonoBehaviour,  
        IConnectionRestApi,
        IApplicationPrediction<string> {
        private void Start() {
            StartCoroutine(CheckInternetConnection());
        }


        /**
         * Check if the internet is connected to the mobile.
         */
        public IEnumerator CheckInternetConnection() {
            var unityWebRequest = new UnityWebRequest("http://www.google.com");
            yield return unityWebRequest.SendWebRequest();

            var isConnected = CheckReturnedRequest(unityWebRequest.error);
            SwitchActions(ref isConnected);
        }

        /**
         * switch between methods regarding the internet connection.
         */
        private void SwitchActions(ref bool isConnected) {
            if (isConnected)
            {
                StartUi();
            }
            else
            {
                StopUi();
            }
        }
        /**
         * Will inactivate all the UI buttons, loadings in case of the internet connection is not available.
         */
        private static void StopUi() {
            //should return connection error message.
        }

        /**
         * Will activate all the UI buttons, loadings in case of the internet connection is available.
         */
        private static void StartUi() {
            throw new System.NotImplementedException();
        }

        /**
         * check if the string is null
         */
        public bool CheckReturnedRequest(string s) {
            return  s != null;
        }
    }
}