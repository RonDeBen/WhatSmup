using UnityEngine;
using UnityEditor;
using System.Collections;
class ViewSnap{
    [MenuItem("View/Front View #1")]
    static void FrontView(){
       GetSceneView().orthographic=true;
       GetSceneView().LookAt(GetSceneView().pivot,Quaternion.LookRotation(Vector3.back));
    }    
        [MenuItem("View/Back View #2")]
    static void BackView(){
       GetSceneView().orthographic=true;
       GetSceneView().LookAt(GetSceneView().pivot,Quaternion.LookRotation(Vector3.forward));
    }
    [MenuItem("View/Right View #3")]
    static void RightView(){
       GetSceneView().orthographic=true;
       GetSceneView().LookAt(GetSceneView().pivot,Quaternion.LookRotation(Vector3.left));
    }
    [MenuItem("View/Left View #4")]
    static void LeftView(){
       GetSceneView().orthographic=true;
       GetSceneView().LookAt(GetSceneView().pivot,Quaternion.LookRotation(Vector3.right));
    }
    [MenuItem("View/Top View #5")]
    static void TopView(){
       GetSceneView().orthographic=true;
       GetSceneView().LookAt(GetSceneView().pivot,Quaternion.LookRotation(Vector3.down));
    }
    [MenuItem("View/Bottom View #6")]
    static void BottomView(){
       GetSceneView().orthographic=true;
       GetSceneView().LookAt(GetSceneView().pivot,Quaternion.LookRotation(Vector3.up));
    }
    [MenuItem("View/Perspective View #7")]
    static void PerspectiveView(){
       GetSceneView().orthographic=!GetSceneView().orthographic;
    }
    static SceneView GetSceneView(){
       SceneView activeSceneView=null;
       if(SceneView.lastActiveSceneView!=null)activeSceneView=SceneView.lastActiveSceneView;
       else if(SceneView.sceneViews.Count!=0)activeSceneView=(SceneView.sceneViews[0] as SceneView);
       return activeSceneView;
    }
}
