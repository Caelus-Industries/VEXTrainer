using UnityEngine;

public class BotController : MonoBehaviour
{
    [Header("Vehicle Components")]
    [Tooltip("Defines the Hinge Joints connected to the wheel objects.")]
    public HingeJoint[] wheels = new HingeJoint[4];
    [Tooltip("The Rigidbody the wheels are connected to.")]
    public Transform body;
    [Header("Motor Properties")]
    [Tooltip("Defines what proportion of motor torque should be applied to turning."), Range(0f, 1f)]
    public float turnPower = 1;
    [Tooltip("Defines the torque of the motor train.")]
    public float motorTorque = 10000;
    [Tooltip("Defines the multiplier for the motor velocity.")]
    public float speed = 50;

    private float[] xOffset;

    private void Awake()
    {
        JointMotor motor = new JointMotor();
        motor.force = motorTorque;
        motor.targetVelocity = 0;

        xOffset = new float[wheels.Length];

        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].motor = motor;
            wheels[i].useMotor = true;
            xOffset[i] = wheels[i].gameObject.transform.localPosition.x;
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            JointMotor motor = wheels[i].motor;
            motor.targetVelocity = Inputs.LY * speed - CalculateTurnValue(i);
            wheels[i].motor = motor;
        }
    }

    private float CalculateTurnValue(int i)
    {
        if (xOffset[i] > 0) { return Inputs.RX * speed * turnPower; }
        if (xOffset[i] < 0) { return -Inputs.RX * speed * turnPower; }
        return 0;
    }
}
