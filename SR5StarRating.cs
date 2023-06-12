using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using Synth.SongSelection;
using System.Reflection;
using Valve.VR.InteractionSystem;
using TMPro;

namespace SR5StarRating
{
    public class SR5StarRating : MelonMod
    {
        public Dictionary<string, string> objNames = new Dictionary<string, string>();

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            var mainMenuScenes = new List<string>()
            {
                "01.The Room",
                "02.The Void",
                "03.Roof Top",
                "04.The Planet",
                "SongSelection"
            };
            base.OnSceneWasInitialized(buildIndex, sceneName);

            if (mainMenuScenes.Contains(sceneName)) Setup();
        }

        private void Setup()
        {
            MelonLogger.Msg("Setting up...");

            try
            {
                initStrings();
                // Locate the pre-existing buttons
                SongSelectionManager ssmInstance = SongSelectionManager.GetInstance;
                FieldInfo songSelectionPanelField = ssmInstance.GetType().GetField("songSelectionPanel", BindingFlags.NonPublic | BindingFlags.Instance);
                GameObject songSelectionPanel = (GameObject)songSelectionPanelField.GetValue(ssmInstance); // [Game Scripts]/Z-Wrap/SongSelection/SelectionSongPanel

                FieldInfo songInfoControlsField = ssmInstance.GetType().GetField("songInfoControls", BindingFlags.NonPublic | BindingFlags.Instance);
                GameObject songInfoControls = (GameObject)songInfoControlsField.GetValue(ssmInstance); // [Game Scripts]/Z-Wrap/SongSelection/SelectionSongPanel/CentralPanel/Song Selection/VisibleWrap/Controls
                Transform volText = songInfoControls.transform.Find("MuteWrap/VALUE");
                Transform volDownBtnT = songInfoControls.transform.Find("MuteWrap/Arrow Down");
                Transform starIcon = songInfoControls.transform.Find("StandardButtonIcon - Favorite/Icon");

                // Delete the previous object (for runtime C# console usage)
                //Transform ratingContainerT = songInfoControls.transform.Find("sr5starrating_container");
                //if (ratingContainerT != null) { UnityEngine.Object.Destroy(ratingContainerT.gameObject); }

                // positioning and scaling vars
                float xOffset = -1.64f;
                float yOffset = 0.13f;
                float scaleFactor = 1.1f;

                // Setup the container for the new buttons
                GameObject rankContainer = new GameObject(objNames["container"]);
                rankContainer.transform.SetParent(songInfoControls.transform, false);
                rankContainer.transform.position = volDownBtnT.position + new Vector3(xOffset, yOffset, 0f);
                rankContainer.transform.localEulerAngles = Vector3.zero;

                // create text label
                GameObject rankText = GameObject.Instantiate(volText.gameObject, rankContainer.transform);
                rankText.name = objNames["label1"];
                rankText.transform.position = rankContainer.transform.position; //volDownBtnT.position + new Vector3(xOffset, yOffset, 0f);
                rankText.transform.localRotation = Quaternion.identity;
                TMP_Text text = rankText.GetComponent<TMP_Text>();
                text.SetText(objNames["cat1"]);
                text.alignment = TextAlignmentOptions.Left;
                RectTransform rt = rankText.GetComponent<RectTransform>();

                // Make first button
                xOffset = 1f;
                GameObject newButton = GameObject.Instantiate(volDownBtnT.gameObject, rankContainer.transform);
                newButton.transform.name = objNames["Lab1Btn1"];
                newButton.transform.localPosition = Vector3.zero + new Vector3(xOffset, 0f, 0f);
                newButton.SetActive(true);

                // remove old  icon
                Transform icon = newButton.transform.Find("Arrow");
                icon.SetParent(null);
                UnityEngine.Object.Destroy(icon.gameObject);

                // add new icon
                GameObject newIcon = GameObject.Instantiate(starIcon.gameObject);
                newIcon.transform.name = objNames["outerIcon"];
                newIcon.transform.SetParent(newButton.transform);
                newIcon.transform.position = newButton.transform.position;
                newIcon.transform.localScale = starIcon.localScale * scaleFactor;
                SpriteRenderer sr = newIcon.GetComponent<SpriteRenderer>();
                
                // add new icon
                GameObject newIcon2 = GameObject.Instantiate(starIcon.gameObject);
                newIcon2.transform.name = objNames["innerIcon"];
                newIcon2.transform.SetParent(newButton.transform);
                newIcon2.transform.position = newButton.transform.position;
                newIcon2.transform.localScale = starIcon.localScale;
                SpriteRenderer sr2 = newIcon2.GetComponent<SpriteRenderer>();     
                sr2.color = Color.grey;
                sr2.sortingOrder += 1; // adjust the sorting order to keep the correct icon on top

                newIcon.SetActive(true);
                newIcon2.SetActive(true);

                //
                xOffset = 0.125f;
                //
                GameObject newButton2 = GameObject.Instantiate(newButton.gameObject, rankContainer.transform);
                newButton2.transform.name = objNames["Lab1Btn2"];
                //newButton2.transform.SetParent(songInfoControls.transform);

                // Reposition fastDownButton
                newButton2.transform.position = newButton.transform.position + new Vector3(xOffset, 0f, 0f);
                newButton2.transform.localScale = newButton.transform.localScale;
                newButton2.SetActive(true);
                //
                GameObject newButton3 = GameObject.Instantiate(newButton2.gameObject, rankContainer.transform);
                newButton3.transform.name = objNames["Lab1Btn3"];
                //newButton3.transform.SetParent(songInfoControls.transform);

                // Reposition fastDownButton
                newButton3.transform.position = newButton2.transform.position + new Vector3(xOffset, 0f, 0f);
                newButton3.transform.localScale = newButton2.transform.localScale;
                newButton3.SetActive(true);
                //
                GameObject newButton4 = GameObject.Instantiate(newButton3.gameObject, rankContainer.transform);
                newButton4.transform.name = objNames["Lab1Btn4"];
                //newButton4.transform.SetParent(songInfoControls.transform);

                // Reposition fastDownButton
                newButton4.transform.position = newButton3.transform.position + new Vector3(xOffset, 0f, 0f);
                newButton4.transform.localScale = newButton3.transform.localScale;
                newButton4.SetActive(true);
                //
                GameObject newButton5 = GameObject.Instantiate(newButton4.gameObject, rankContainer.transform);
                newButton5.transform.name = objNames["Lab1Btn5"];
                //newButton5.transform.SetParent(songInfoControls.transform);

                // Reposition fastDownButton
                newButton5.transform.position = newButton4.transform.position + new Vector3(xOffset, 0f, 0f);
                newButton5.transform.localScale = newButton4.transform.localScale;
                newButton5.SetActive(true);


                // create text label
                GameObject rankText2 = GameObject.Instantiate(rankText, rankContainer.transform);
                rankText2.name = objNames["label2"];
                rankText2.transform.position = newButton5.transform.position + new Vector3(xOffset*2.7f, 0f, 0f); //volDownBtnT.position + new Vector3(xOffset, yOffset, 0f);
                rankText2.transform.localRotation = Quaternion.identity;
                TMP_Text text2 = rankText2.GetComponent<TMP_Text>();
                text2.SetText(objNames["cat2"]);
                text2.alignment = TextAlignmentOptions.Left;
                text2.fontSize = text.fontSize;
                RectTransform rt2 = rankText2.GetComponent<RectTransform>();
                rt2.sizeDelta = new Vector2(1.52f, rt.sizeDelta.y); // 1.67

                // make first button
                xOffset = 0.2f; 
                GameObject newButton6 = GameObject.Instantiate(newButton5.gameObject, rankContainer.transform);
                newButton6.transform.name = objNames["Lab2Btn1"];
                newButton6.transform.position = rankText2.transform.position + new Vector3(xOffset, 0f, 0f);
                newButton6.transform.localScale = newButton5.transform.localScale;
                newButton6.SetActive(true);

                xOffset = 0.125f;
                //
                GameObject newButton7 = GameObject.Instantiate(newButton6.gameObject, rankContainer.transform);
                newButton7.transform.name = objNames["Lab2Btn2"];
                newButton7.transform.position = newButton6.transform.position + new Vector3(xOffset, 0f, 0f);
                newButton7.transform.localScale = newButton6.transform.localScale;
                newButton7.SetActive(true);
                //
                GameObject newButton8 = GameObject.Instantiate(newButton7.gameObject, rankContainer.transform);
                newButton8.transform.name = objNames["Lab2Btn3"];
                newButton8.transform.position = newButton7.transform.position + new Vector3(xOffset, 0f, 0f);
                newButton8.transform.localScale = newButton7.transform.localScale;
                newButton8.SetActive(true);
                //
                GameObject newButton9 = GameObject.Instantiate(newButton8.gameObject, rankContainer.transform);
                newButton9.transform.name = objNames["Lab2Btn4"];
                newButton9.transform.position = newButton8.transform.position + new Vector3(xOffset, 0f, 0f);
                newButton9.transform.localScale = newButton8.transform.localScale;
                newButton9.SetActive(true);
                //
                GameObject newButton10 = GameObject.Instantiate(newButton9.gameObject, rankContainer.transform);
                newButton10.transform.name = objNames["Lab2Btn5"];
                newButton10.transform.position = newButton9.transform.position + new Vector3(xOffset, 0f, 0f);
                newButton10.transform.localScale = newButton9.transform.localScale;
                newButton10.SetActive(true);


                //GameObject songSelectionGO = GameObject.Find("SongSelection");
                //Transform scrollArrowsT = songSelectionGO.transform.Find("SelectionSongPanel/CentralPanel/Song Selection/VisibleWrap/Songs/Scroll Arrows");
                //Transform bottomButtonT = scrollArrowsT.Find("Bottom");
                //Transform topButtonT = scrollArrowsT.Find("Top");
                //Transform upButtonT = scrollArrowsT.Find("Up");
                //Transform downButtonT = scrollArrowsT.Find("Down");

                //// Add the FastScrollArrowController to "Scroll Arrows" object
                //controllerFSAC = scrollArrowsT.gameObject.AddComponent<FastScrollArrowController>();

                //// vars to manipulate button events
                //VRTK_InteractableObject_UnityEvents events = null;
                //VRTK_InteractableObject_UnityEvents persistentEvents = null;

                //// add FastDown button
                //fastDownButtonGO = MakeButton(bottomButtonT.gameObject, "FastDown", scrollArrowsT);
                //RemoveOrDisableEvents(fastDownButtonGO, ref events, ref persistentEvents);
                //persistentEvents.OnTouch.AddListener(controllerFSAC.FastScrollDownHover);
                //persistentEvents.OnUntouch.AddListener(controllerFSAC.FastScrollDownOut);
                //persistentEvents.OnUse.AddListener(controllerFSAC.FastScrollDown);
                //fastDownButtonGO.SetActive(true);

                //// add FastUp button
                //fastUpButtonGO = MakeButton(topButtonT.gameObject, "FastUp", scrollArrowsT);
                //RemoveOrDisableEvents(fastUpButtonGO, ref events, ref persistentEvents);
                //persistentEvents.OnTouch.AddListener(controllerFSAC.FastScrollUpHover);
                //persistentEvents.OnUntouch.AddListener(controllerFSAC.FastScrollUpOut);
                //persistentEvents.OnUse.AddListener(controllerFSAC.FastScrollUp);
                //fastUpButtonGO.SetActive(true);

                //// adjust the echelons on the Top and Bottom buttons
                //AdjustEchelons(bottomButtonT);
                //AdjustEchelons(topButtonT);

                //// overwrite Down events
                //RemoveOrDisableEvents(downButtonT.gameObject, ref events, ref persistentEvents);
                //persistentEvents.OnTouch.AddListener(controllerFSAC.ScrollDownHover);
                //persistentEvents.OnUntouch.AddListener(controllerFSAC.ScrollDownOut);
                //persistentEvents.OnUse.AddListener(controllerFSAC.ScrollDown);

                //// overwrite Up events
                //RemoveOrDisableEvents(upButtonT.gameObject, ref events, ref persistentEvents);
                //persistentEvents.OnTouch.AddListener(controllerFSAC.ScrollUpHover);
                //persistentEvents.OnUntouch.AddListener(controllerFSAC.ScrollUpOut);
                //persistentEvents.OnUse.AddListener(controllerFSAC.ScrollUp);

                MelonLogger.Msg("... finished setting up");
            }
            catch (NullReferenceException ex)
            {
                string stackTrace = ex.StackTrace;
                MelonLogger.Msg("Null reference exception: " + ex.Message);
                MelonLogger.Msg("Stack Trace: " + ex.StackTrace);
            }
        }

        private void initStrings()
        {
            objNames["container"] = "sr5starrating_container";
            objNames["label1"] = "sr5starrating_label1";
            objNames["label2"] = "sr5starrating_label2";
            objNames["cat1"] = "Quality";
            objNames["cat2"] = "Intensity";
            objNames["outerIcon"] = "OuterStar";
            objNames["innerIcon"] = "InnerStar";
            objNames["Lab1Btn1"] = "Cat1Rank1";
            objNames["Lab1Btn2"] = "Cat1Rank2";
            objNames["Lab1Btn3"] = "Cat1Rank3";
            objNames["Lab1Btn4"] = "Cat1Rank4";
            objNames["Lab1Btn5"] = "Cat1Rank5";
            objNames["Lab2Btn1"] = "Cat2Rank1";
            objNames["Lab2Btn2"] = "Cat2Rank2";
            objNames["Lab2Btn3"] = "Cat2Rank3";
            objNames["Lab2Btn4"] = "Cat2Rank4";
            objNames["Lab2Btn5"] = "Cat2Rank5";
        }

        private GameObject MakeButton(GameObject _buttonToClone, string _buttonName, Transform _parent)
        {
            // vars for repositioning the button
            float xOffset = -1.0f;
            float yOffset = 0.3f;
            Vector3 newPosition;

            // Clone the topButton into fastUpButton
            GameObject newButton = GameObject.Instantiate(_buttonToClone);
            newButton.transform.name = _buttonName;
            newButton.transform.SetParent(_parent);

            // Reposition fastDownButton
            newButton.transform.Translate(new Vector3(xOffset, yOffset, 0f));
            //newPosition = _buttonToClone.transform.position + _buttonToClone.transform.right * xOffset;
            //newButton.transform.position = newPosition;
            //newButton.transform.localScale = _buttonToClone.transform.localScale;

            return newButton;
        }
    }
}
