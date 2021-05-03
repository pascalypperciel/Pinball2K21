using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
[CustomEditor(typeof(MissionManager))]
public class MissionListEditor : Editor
{
    MissionManager manager;
    SerializedObject getTarget;
    SerializedProperty Liste;
    int listSize;

    List<bool> newShowFoldout = new List<bool>();
    bool showfold;

    void OnEnable()
    {
        manager = (MissionManager)target;
        getTarget = new SerializedObject(manager);
        Liste = getTarget.FindProperty("missionList");
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        getTarget.Update();

        //List size
        EditorGUILayout.LabelField("Mission List Size");
        listSize = Liste.arraySize;
        listSize = EditorGUILayout.IntField("List Size", listSize);

        if(listSize != Liste.arraySize)
        {
            while(listSize > Liste.arraySize)
            {
                Liste.InsertArrayElementAtIndex(Liste.arraySize);
            }

            while (listSize < Liste.arraySize)
            {
                Liste.DeleteArrayElementAtIndex(Liste.arraySize - 1);

            }
        }
        //show fold 
        while(newShowFoldout.Count > Liste.arraySize)
        {
            newShowFoldout.RemoveAt(newShowFoldout.Count - 1);
        }

        while (newShowFoldout.Count < Liste.arraySize)
        {
            newShowFoldout.Add(true);
        }

        //bouton pour rajouter missions
        if (GUILayout.Button("Rajouter nouvelle mission"))
        {
            manager.missionList.Add(new Mission());
        }

        //Afficher contenu
        for (int i = 0; i < Liste.arraySize; i++)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.BeginVertical(GUI.skin.box);
            newShowFoldout[i] = EditorGUILayout.Foldout(newShowFoldout[i], "Mission" + (i + 1));

            SerializedProperty myListRef = Liste.GetArrayElementAtIndex(i);
            SerializedProperty myId = myListRef.FindPropertyRelative("missionId");
            SerializedProperty myDescription = myListRef.FindPropertyRelative("description");

            SerializedProperty myActive = myListRef.FindPropertyRelative("active");
            SerializedProperty myPermanentActive = myListRef.FindPropertyRelative("permanentActive");
            SerializedProperty myComplete = myListRef.FindPropertyRelative("missionComplete");

            SerializedProperty myRestart = myListRef.FindPropertyRelative("restartOnNextBall");
            SerializedProperty myStopOnEnd = myListRef.FindPropertyRelative("stopOnBallEnd");
            SerializedProperty myResetOnComplete = myListRef.FindPropertyRelative("resetOnComplete");
            SerializedProperty myTriggerMultiball = myListRef.FindPropertyRelative("canTriggerMultiball");

            SerializedProperty myTimeToComplete = myListRef.FindPropertyRelative("timeToComplete");

            SerializedProperty myScore = myListRef.FindPropertyRelative("score");
            SerializedProperty myQuantiteToComplete = myListRef.FindPropertyRelative("quantiteToComplete");
            SerializedProperty myActuelQuantite = myListRef.FindPropertyRelative("actuelQuantite");

            //Montrer contenu
            if (newShowFoldout[i])
            {
                EditorGUILayout.PropertyField(myId);
                EditorGUILayout.PropertyField(myDescription);

                EditorGUILayout.PropertyField(myActive);
                EditorGUILayout.PropertyField(myPermanentActive);
                EditorGUILayout.PropertyField(myComplete);

                EditorGUILayout.PropertyField(myRestart);
                EditorGUILayout.PropertyField(myStopOnEnd);
                EditorGUILayout.PropertyField(myResetOnComplete);
                EditorGUILayout.PropertyField(myTriggerMultiball);

                EditorGUILayout.PropertyField(myTimeToComplete);

                EditorGUILayout.PropertyField(myScore);
                EditorGUILayout.PropertyField(myQuantiteToComplete);
                EditorGUILayout.PropertyField(myActuelQuantite);
            }

            //supprimer bouton pour missions
            if(GUILayout.Button("Supprimer mission"))
            {
                Liste.DeleteArrayElementAtIndex(i);
            }

            EditorGUI.indentLevel--;
            EditorGUILayout.EndVertical();
            EditorGUILayout.Separator();
        }

        getTarget.ApplyModifiedProperties();
    }
}
