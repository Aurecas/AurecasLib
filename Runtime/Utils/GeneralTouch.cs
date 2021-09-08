using UnityEngine;

namespace AurecasLib.Utils {
    public static class GeneralTouch {
        static Vector3 lastMousePos;

        public static Touch GetTouch(int index) {

            if (index == 0) {
                if (Input.GetMouseButtonDown(0)) {
                    Touch touch = new Touch() {
                        deltaTime = Time.deltaTime,
                        fingerId = 0,
                        position = Input.mousePosition,
                        deltaPosition = Input.mousePosition - lastMousePos,
                        phase = TouchPhase.Began,
                    };
                    return touch;
                }
                else if (Input.GetMouseButtonUp(0)) {
                    Touch touch = new Touch() {
                        deltaTime = Time.deltaTime,
                        fingerId = 0,
                        position = Input.mousePosition,
                        deltaPosition = Input.mousePosition - lastMousePos,
                        phase = TouchPhase.Ended,
                    };
                    return touch;
                }
                else if (Input.GetMouseButton(0)) {
                    Touch touch = new Touch() {
                        deltaTime = Time.deltaTime,
                        fingerId = 0,
                        position = Input.mousePosition,
                        deltaPosition = Input.mousePosition - lastMousePos,
                        phase = Input.mousePosition == lastMousePos ? TouchPhase.Stationary : TouchPhase.Moved,
                    };
                    return touch;
                }
                else {
                    return Input.GetTouch(index);
                }
            }
            else {
                return Input.GetTouch(index - GetMouseTouches());
            }

        }

        static int GetMouseTouches() {
            if (Input.GetMouseButton(0)) return 1;
            return 0;
        }

        public static int GetTouchCount() {
            return Input.touchCount + GetMouseTouches();
        }
    }
}