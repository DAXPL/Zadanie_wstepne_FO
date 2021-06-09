using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    [Tooltip("UI dialogu")]
    [SerializeField] private Transform dialogBox;
    [Tooltip("TMP na imie")]
    [SerializeField] private TextMeshProUGUI name_t;
    [Tooltip("TMP na tresc dialogu")]
    [SerializeField] private TextMeshProUGUI content_t;

    [Header("FILES")]
    [Tooltip("Plik z dialogiem w formacie XML")]
    [SerializeField] private TextAsset xmlFile_raw;


    private ReaderXML reader;
    private string[] listaDialogow;
    private int cur_cont_id;
    private string NPCname, content;

    private void Start()
    {
        dialogBox.gameObject.SetActive(false);
        reader = gameObject.GetComponent<ReaderXML>();
        reader.LoadxmlRAW(xmlFile_raw);
    }
    public void StartNewDialog()
    {
        dialogBox.gameObject.SetActive(true);
        cur_cont_id = -1;
        Next();
    }
    public void Next()
    {
        cur_cont_id++;
        XmlNode node = reader.SpecyficNode(cur_cont_id);
        if(node != null)
        {
            NPCname = node.ChildNodes[0].InnerXml;
            content = node.ChildNodes[1].InnerXml;

            name_t.text = NPCname;
            content_t.text = content;
        }
        else
        {
            EndDialogue();
        }
        
    }
    private void EndDialogue()
    {
        name_t.text = "";
        content_t.text = "";
        dialogBox.gameObject.SetActive(false);
    }
}
