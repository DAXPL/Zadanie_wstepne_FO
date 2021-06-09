using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml;
using UnityEngine;


public class ReaderXML : MonoBehaviour
{
    private TextAsset xmlFile_raw;
    private XmlNodeList NodeList;
    public void LoadxmlRAW(TextAsset raw)
    {
        parseXML(raw.text);
    }
    private void parseXML(string data)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(new StringReader(data));

        string pattern = "//Dialog//wpis";
        NodeList = doc.SelectNodes(pattern);
    }
    public XmlNode SpecyficNode(int id)
    {
        if (id >= NodeList.Count) return null;
        return NodeList[id];
    }

}
