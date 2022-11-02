**编写一个简单的自定义 Component，用自定义组件定义几种飞碟，做成预制**
•参考官方手册 https://docs.unity3d.com/ScriptReference/Editor.html
•实现自定义组件，编辑并赋予飞碟一些属性  

---

![img](https://images0.cnblogs.com/blog2015/450977/201506/161855352327081.jpg)

为一个组件添加自己自定义的编辑器内容

```c#
[CustomEditor(typeof(ShowArea))]
```

Editor.OnInspectorGUI

通过实现该函数来制作自定义的Inspector面板。

![img](https://img-blog.csdnimg.cn/208c984c21c14fec9b61178e7c37840f.png?x-oss-process=image/watermark,type_ZHJvaWRzYW5zZmFsbGJhY2s,shadow_50,text_Q1NETiBA5LiA5Y-q5a2m5Lmg55qE5bCP6bif,size_20,color_FFFFFF,t_70,g_se,x_16)

```c#
    Vector3 startPosition = EditorGUILayout.Vector3Field("StartPosition",UFO.startPosition); //文本，数值域
    UFO.startPosition = startPosition;
```

----

**结果展示**

```c#
//UFO.cs
using UnityEngine;

namespace HitUFO
{
    public class UFO : MonoBehaviour
    {
        public int score = 0; //设置飞碟得分
        public static Vector3 startPosition = new Vector3(0, 0, 0); //设置初始位置
        public static Vector3 startSpeed = new Vector3(1, 1, 0); //设置初始速度
        public static Vector3 localScale = new Vector3(1, 1, 1); //设置缩放比例
        private int Left_or_Right;

        public Vector3 GetSpeed()
        {
            //向左还是向右运动
            Vector3 v = startSpeed;
            v.x *= Left_or_Right; 
            return v;
        }

        public void SetSide(int lr,float dy)
        {
            Vector3 v = startPosition;
            v.x *= lr;
            v.y += dy;
            transform.position = v;
            Left_or_Right = lr;
        }

        public void SetLocalScale(float x,float y,float z)
        {
            Vector3 lc = localScale;
            lc.x *= x;
            lc.y *= y;
            lc.z *= z;
            transform.localScale = lc;
        }
    }
}
```

```c#
//SetGui.cs
using UnityEngine;
using UnityEditor;

namespace HitUFO{
[CustomEditor(typeof(UFO))]
public class SetGui : Editor //继承editor类
{
    public override void OnInspectorGUI()
    {
        var target = (UFO)serializedObject.targetObject; //获取对象

        EditorGUILayout.Space(); //空行
        Vector3 startPosition = EditorGUILayout.Vector3Field("StartPosition",UFO.startPosition); //文本，数值域
        UFO.startPosition = startPosition;

        EditorGUILayout.Space();
        Vector3 startSpeed = EditorGUILayout.Vector3Field("StartSpeed",UFO.startSpeed);
        UFO.startSpeed = startSpeed;

        EditorGUILayout.Space();
        Vector3 localScale = EditorGUILayout.Vector3Field("LocalScale",UFO.localScale);
        UFO.localScale = startPosition;        
    }
}
}
```

![image-20221018161841951](C:\Users\tony0706\AppData\Roaming\Typora\typora-user-images\image-20221018161841951.png)



