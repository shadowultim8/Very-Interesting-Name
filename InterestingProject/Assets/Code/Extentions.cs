using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ShadowUltimate
{
    public static partial class Extentions
    {
        public static Color SetA(this Color color, float a)
        {
            return new Color(color.r, color.g, color.b, a);
        }
        
        public static bool Chance(int chance)
        {
            if (chance > 100) chance = 100;
            int core = UnityEngine.Random.Range(1, 101);
            return core <= chance;
        }
        /// <summary>
        /// Минимальное число в массиве chances = 0, максимальное = 100.
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="chances"></param>
        /// <returns></returns>
        public static int Chance(this int[] array, int[] chances)
        {
            int max = int.MinValue;
            int maxIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                float m = 100 / chances[i];
                int core = UnityEngine.Random.Range(0, 101);
                if (core <= chances[i] && max < core * m)
                {
                    maxIndex = i;
                }
            }
            return array[maxIndex];
        }

        public static float Discriminant(float a, float b, float c)
        {
            var d = b * b - 4 * a * c;
            if (d < 0) return -1;
            if (d == 0) return (-b) / (2 * a);

            var x1 = (-b - Mathf.Sqrt(d)) / (2 * a);
            var x2 = (-b + Mathf.Sqrt(d)) / (2 * a);

            return x1 < 0 ? x2 : x1;
        }

        public static bool InLimits(this double num, double a, double b)
        {
            return num < b && num > a;
        }

        public static bool InLimits(this int num, int a, int b)
        {
            return num < b && num > a;
        }

        public static bool InLimits(this float num, float a, float b)
        {
            return num < b && num > a;
        }

        public static double Min(double[] _array)
        {
            double min = Mathf.Infinity;

            foreach(var elem in _array)
            {
                if(elem < min)
                {
                    min = elem;
                }
            }

            return min;
        }
        
        public static Transform MinDistance<T>(List<T> _list, Vector3 _currentPosition, float maxDistance = float.PositiveInfinity) where T: MonoBehaviour
        {
            if (_list.Count <= 0) return null;
            
            float minDistance = maxDistance;

            Transform res = null;

            for(int i = 0; i < _list.Count; i++)
            {
                if (_list[i] != null)
                {
                    var distance = Vector3.Distance(_list[i].transform.position, _currentPosition);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        res = _list[i].transform;
                    }
                }
                else
                {
                    Debug.LogWarning("element of array is null");
                }
            }

            return res;
        }

        public static Transform MinDistance<T>(T[] _array, Vector3 _currentPosition, float maxDistance = float.PositiveInfinity) where T: MonoBehaviour
        {
            if (_array == null) return null;
            
            float minDistance = maxDistance;

            Transform res = null;

            for(int i = 0; i < _array.Length; i++)
            {
                if (_array[i] != null)
                {
                    var distance = Vector3.Distance(_array[i].transform.position, _currentPosition);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        res = _array[i].transform;
                    }
                }
                else
                {
                    Debug.LogWarning("element of array is null");
                }
            }

            return res;
        }
        
        public static List<T> ToList<T>(this T[] _array)
        {
            List<T> res = new List<T>();
            foreach(T elem in _array)
            {
                res.Add(elem);
            }
            return res;
        }

        public static T[] ToArray<T>(this List<T> _list)
        {
            T[] res = new T[_list.Count];

            for(int i = 0; i < res.Length; i++)
            {
                res[i] = _list[i];
            }

            return res;
        }

        public static T RandomElement<T>(this T[] _array)
        {
            if (_array == null) return default(T);
            if (_array.Length == 0) return default(T);

            return _array[Random.Range(0, _array.Length)];
        }

        public static T RandomElement<T>(this List<T> _list)
        {
            return _list[UnityEngine.Random.Range(0, _list.Count)];
        }
        
        public static Quaternion LookingAt(this Transform _transform, Transform target, float speed)
        {
            var lookAt = Quaternion.LookRotation((target.position - _transform.position).normalized);

            return Quaternion.RotateTowards(_transform.rotation, lookAt, speed * Time.deltaTime);
        }

        public static Quaternion LookingAt(this Transform _transform, Vector3 target, float speed)
        {
            var lookAt = Quaternion.LookRotation((target - _transform.position).normalized);

            //return Quaternion.Euler
            //    (Mathf.SmoothDampAngle(_transform.rotation.eulerAngles.x, lookAt.eulerAngles.x, ref speed, speed * Time.deltaTime),
            //    Mathf.SmoothDampAngle(_transform.rotation.eulerAngles.y, lookAt.eulerAngles.y, ref speed, speed * Time.deltaTime),
            //    Mathf.SmoothDampAngle(_transform.rotation.eulerAngles.z, lookAt.eulerAngles.z, ref speed, speed * Time.deltaTime));

            return Quaternion.RotateTowards(_transform.rotation, lookAt, speed * Time.deltaTime);
        }

        public static Transform[] TransformsArray<T>(this T[] _component) where T: MonoBehaviour
        {
            Transform[] result = new Transform[_component.Length];

            for(int i = 0; i < result.Length; i++)
            {
                result[i] = _component[i].transform;
            }

            return result;
        }

        public static Transform[] TransformsArray<T>(this List<T> _component) where T: MonoBehaviour
        {
            Transform[] result = new Transform[_component.Count];

            for(int i = 0; i < result.Length; i++)
            {
                result[i] = _component[i].transform;
            }

            return result;
        }

        public static T2[] OtherArray<T1,T2>(this T1[] _component, bool warning = true) where T1 : Component where T2 : Component
        {
            if (_component[0].GetComponent<T2>() == null)
            {
                if(warning) Debug.LogWarning("This elements have not T2 component");
                return null;
            }

            T2[] result = new T2[_component.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = _component[i].GetComponent<T2>();
            }

            return result;
        }

        public static List<T2> OtherList<T1,T2>(this List<T1> _component) where T1 : Component where T2 : Component
        {
            if (_component[0].GetComponent<T2>() == null)
            {
                Debug.LogWarning("This elements have not T2 component");
                return null;
            }

            List<T2> result = new List<T2>();

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = _component[i].GetComponent<T2>();
            }

            return result;
        }

        public static List<T> Sum<T> (this List<T> list1, List<T> list2) where T : MonoBehaviour
        {
            List<T> res = new List<T>();

            foreach(var elem in list1)
            {
                res.Add(elem);
            }

            foreach(var elem in list2)
            {
                res.Add(elem);
            }

            return res;
        }

        public static T[] Sum<T> (this T[] array1, T[] array2) where T : MonoBehaviour
        {
            T[] res = new T[array1.Length + array2.Length];

            int i = 0;

            foreach(var elem in array1)
            {
                res[i++] = elem;
            }

            foreach(var elem in array2)
            {
                res[i++] = elem;
            }

            return res;
        }

        public static T[] SattoloShuffle<T>(this T[] array) where T : UnityEngine.Object
        {
            var i = array.Length;
            while(i > 1)
            {
                i--;
                var j = UnityEngine.Random.Range(0, i);
                Swap(ref array[j], ref array[i]);
            }
            return array;
        }

        public static T[] FindAll<T>(this T[] array, Predicate<T> predicate) where T : Component
        {
            return Array.FindAll(array, predicate);
        }

        public static void Swap<T>(ref T a, ref T b) where T : UnityEngine.Object
        {
            var swap = a;
            a = b;
            b = swap;
        }
        
        public static Vector3 SmoothStep(this Vector3 vector1, Vector3 vector2, float smooth)
        {
            return new Vector3(Mathf.SmoothStep(vector1.x, vector2.x, smooth * Time.deltaTime),
                Mathf.SmoothStep(vector1.y, vector2.y, smooth * Time.deltaTime),
                Mathf.SmoothStep(vector1.z, vector2.z, smooth * Time.deltaTime));
        }
        
        public static Vector3 RandomVector(this Vector3 vector)
        {
            return new Vector3(Random.Range(-vector.x, vector.x), 
               Random.Range(-vector.y, vector.y),
                Random.Range(-vector.z, vector.z));
        }
        public static Vector3 RandomVector(this Vector3 vector, float left, float right)
        {
            return new Vector3(Random.Range(left, right),
                Random.Range(left, right),
                Random.Range(left, right));
        }     
        
        public static Vector2 RandomVector(this Vector2 vector)
        {
            return new Vector3(Random.Range(-vector.x, vector.x),
                Random.Range(-vector.y, vector.y));
        }
        public static Vector2 RandomVector(this Vector2 vector, float left, float right)
        {
            return new Vector2(Random.Range(left, right),
                Random.Range(left, right));
        }

        public enum LockAxis { X, Y, Z, NONE }
        public enum Side { RIGHT, LEFT }

        public static Quaternion RandomQuaternoin(this Quaternion quaternion, 
            LockAxis lockAxis_1 = LockAxis.NONE, LockAxis lockAxis_2 = LockAxis.NONE)
        {
            float x = (lockAxis_1 == LockAxis.X || lockAxis_2 == LockAxis.X) ? 0 : Random.Range(-360, 360);
            float y = (lockAxis_1 == LockAxis.Y || lockAxis_2 == LockAxis.Y) ? 0 : Random.Range(-360, 360);
            float z = (lockAxis_1 == LockAxis.Z || lockAxis_2 == LockAxis.Z) ? 0 : Random.Range(-360, 360);

            return Quaternion.Euler(x, y, z);
        }

        public static float ClampAngle(float angle, float min, float max)
        {
            angle = Mathf.Repeat(angle, 360);
            min = Mathf.Repeat(min, 360);
            max = Mathf.Repeat(max, 360);
            bool inverse = false;
            var tmin = min;
            var tangle = angle;
            if (min > 180)
            {
                inverse = !inverse;
                tmin -= 180;
            }
            if (angle > 180)
            {
                inverse = !inverse;
                tangle -= 180;
            }
            var result = !inverse ? tangle > tmin : tangle < tmin;
            if (!result)
                angle = min;

            inverse = false;
            tangle = angle;
            var tmax = max;
            if (angle > 180)
            {
                inverse = !inverse;
                tangle -= 180;
            }
            if (max > 180)
            {
                inverse = !inverse;
                tmax -= 180;
            }

            result = !inverse ? tangle < tmax : tangle > tmax;
            if (!result)
                angle = max;
            return angle;
        }

        public static float[][] InverseMatrix2x2(float[][] matrix2x2)
        {
            float[][] result = new float[2][];
            for (int i = 0; i < 2; i++)
            {
                result[i] = new float[2];
            }

            float mainDiagonal = 1; // Главная диагональ
            float sideDiagonal = 1; // Побочная диагональ

            for (int i = 0; i < 2; i++)
            {
                mainDiagonal *= matrix2x2[i][i];
                sideDiagonal *= matrix2x2[i][1 - i];
            }

            float delta = mainDiagonal - sideDiagonal;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result[i][j] = matrix2x2[j][i];
                }
            }

            float[][] transparentMatrix = result;

            result[0][0] = transparentMatrix[1][1];
            result[0][1] = -transparentMatrix[1][0];
            result[1][0] = -transparentMatrix[0][1];
            result[1][1] = transparentMatrix[0][0];

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    result[i][j] *= 1 / delta;
                }
            }

            return result;
        }

        public static Vector2 MultiplyVectorToMatrix(float[][] matrix2x2, Vector2 vector)
        {
            float x = 0;
            float y = 0;

            float[] vectorMatrix = new float[2] { vector.x, vector.y };

            for (int i = 0; i < 2; i++)
            {
                x += matrix2x2[0][i] * vectorMatrix[i];
                y += matrix2x2[1][i] * vectorMatrix[i];
            }

            return new Vector2(x, y);
        }

        /// <summary>
        /// Return rotating vector on angle
        /// </summary>
        /// <param name=""></param>
        /// <param name="angle">In Degree</param>
        /// <returns></returns>
        public static Vector2 Rotate(this Vector2 vector, float angle)
        {
            float x = vector.x;
            float y = vector.y;

            vector.x = x * Mathf.Cos(Mathf.Deg2Rad * angle) - y * Mathf.Sin(Mathf.Deg2Rad * angle);
            vector.y = x * Mathf.Sin(Mathf.Deg2Rad * angle) + y * Mathf.Cos(Mathf.Deg2Rad * angle);
            return vector;
        }

        public static Vector3 mouseToWorldPoint()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}