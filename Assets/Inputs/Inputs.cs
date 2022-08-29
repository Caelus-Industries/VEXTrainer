using System.Linq;

using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    [Tooltip("Input action asset connected to the input action manager.")]
    public InputActionAsset inputActions;
    private static InputActionMap axes, buttons;

    public static float LX { get { return axes.FindAction("LX").ReadValue<float>(); } }
    public static float LY { get { return axes.FindAction("LY").ReadValue<float>(); } }
    public static float RX { get { return axes.FindAction("RX").ReadValue<float>(); } }
    public static float RY { get { return axes.FindAction("RY").ReadValue<float>(); } }

    private void Awake()
    {
        axes = inputActions.FindActionMap("Axes");
        axes.Enable();

        buttons = inputActions.FindActionMap("Buttons");
        buttons.Enable();
    }
}
