using System.IO;
using UnityEditor;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;

namespace Maze
{
    [CustomEditor(typeof(Waipoints))]
    public class SaveWaipoint : Editor
    {
        private static XmlSerializer serializer;
        public List<SVect3> SavingNodes = new List<SVect3>();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Waipoints Base = (Waipoints)target;

            if(serializer == null)
            {
                serializer = new XmlSerializer(typeof(SVect3[]));

            }
            if (GUILayout.Button("Сохранить"))
            {
                if (Base.nodes.Count > 0)
                {
                    foreach (Transform item in Base.nodes)
                    {
                        if (!SavingNodes.Contains(item.position))
                        {
                            SavingNodes.Add(item.position);
                        }
                    }
                }
                using (FileStream fs = new FileStream(Base.SavingPath, FileMode.Create))
                {
                    serializer.Serialize(fs, SavingNodes.ToArray());
                }
            }
        }
    }
}