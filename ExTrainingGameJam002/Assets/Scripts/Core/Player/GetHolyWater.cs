using System.Collections;
using UnityEngine;

namespace StageSystem
{
    public class GetHolyWater : MonoBehaviour
    {
        private bool Undetectable = false;

        public void UndetectableTime()
        {
            // 10秒後にUndetectableフラグをfalseにする
            StartCoroutine(StartUndetectableTimer());
        }

        private IEnumerator StartUndetectableTimer()
        {
            Undetectable = true;

            yield return new WaitForSeconds(10f);

            Undetectable = false;
        }

        public bool GetUndetectable()
        { return Undetectable; }
    }
}