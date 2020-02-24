using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewTracker : MonoBehaviour
{
    [SerializeField]
    protected Camera BaseCamera;
    [SerializeField]
    private Transform TargetTransform;
    [SerializeField]
    private float PanelDepth = 0.7f;
    [SerializeField]
    private float SetAngleOffset = 10;  // degree
    [SerializeField]
    private float MovingTime = 0.4f;

    public bool TrackVerticalHeadAngle;

    private float maxAngleU;    // degree
    private float maxAngleV;    // degree

    private float coolTime = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (BaseCamera == null)
            BaseCamera = Camera.main;
        if (TargetTransform == null)
            TargetTransform = this.transform;

        maxAngleU = BaseCamera.fieldOfView / 2;
        maxAngleV = maxAngleU / BaseCamera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (coolTime >= 0)
        {
            coolTime += Time.deltaTime;
            //if (coolTime > MovingTime)
            //    coolTime = -1;

            return;
        }

        var forwardVec = BaseCamera.transform.forward;
        var toTargetVec = TargetTransform.position - BaseCamera.transform.position;

        // カメラのローカル座標とした場合のターゲットまでのベクトルを使用
        var inverseLocalCameraQot = Quaternion.Inverse(BaseCamera.transform.rotation);
        var toTargetLocalVec = inverseLocalCameraQot * toTargetVec;

        // カメラのローカル座標(forwardVec == Vector3.forwardの時を仮定して)として計算するので、
        // Vector3.forwardとtoTargetLocalVecのxz成分・yz成分の角度を計算することでカメラから見た
        // ターゲットの横方向の角度・縦方向の角度が求まる
        var angleU = Vector3.Angle(Vector3.forward,
            toTargetLocalVec.z * Vector3.forward + toTargetLocalVec.x * Vector3.right);
        angleU *= (toTargetLocalVec.x >= 0) ? 1 : -1;
        var angleV = Vector3.Angle(Vector3.forward,
            toTargetLocalVec.z * Vector3.forward + toTargetLocalVec.y * Vector3.up);
        angleV *= (toTargetLocalVec.y >= 0) ? 1 : -1;

        if (Mathf.Abs(angleU) <= maxAngleU + SetAngleOffset && Mathf.Abs(angleV) <= maxAngleV + SetAngleOffset)
            return;
        
        //Debug.Log("angle U: " + (int)angleU + "  angle V: " + (int)angleV);

        // Setting moved position angle
        float targetAngleU = angleU;
        if (angleU > maxAngleU - SetAngleOffset)
            targetAngleU = maxAngleU - SetAngleOffset;
        else if (angleU < -(maxAngleU - SetAngleOffset))
            targetAngleU = SetAngleOffset - maxAngleU;
        float targetAngleV = angleV;
        if (angleV > maxAngleV - SetAngleOffset)
            targetAngleV = maxAngleV - SetAngleOffset;
        else if (angleV < -(maxAngleV - SetAngleOffset))
            targetAngleV = SetAngleOffset - maxAngleV;

        // パネルの移動先座標を計算
        var targetPosVec = Quaternion.Euler(new Vector3(-targetAngleV, targetAngleU, 0)) * forwardVec;
        var targetPos = BaseCamera.transform.position + targetPosVec * PanelDepth;

        iTween.MoveTo(TargetTransform.gameObject, targetPos, MovingTime, "onEndMove");
        coolTime = 0;
    }

    private void onEndMove()
    {
        coolTime = -1;
    }
}
