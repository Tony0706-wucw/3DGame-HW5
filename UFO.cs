
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
