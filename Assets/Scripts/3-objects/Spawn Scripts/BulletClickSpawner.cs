using UnityEngine;
using UnityEngine.InputSystem;
public class BulletClickSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnObject;
    [SerializeField, Tooltip("The speed of the object")]
    private float objectSpeed = 80f; // מהירות הקליע
    [SerializeField]
    private InputAction clickAction; // פעולה לזיהוי לחיצה
    [SerializeField, Tooltip("The maximum distance of the ray")]
    private float maxRayDistance = 50f; // מרחק הקרן
    private void OnEnable()
    {
        clickAction.Enable();
    }
    private void OnDisable()
    {
        clickAction.Disable();
    }
    void OnValidate()
    {
         if (clickAction == null)
            clickAction = new InputAction(type: InputActionType.Button);
        if (clickAction.bindings.Count == 0)
            clickAction.AddBinding("<Mouse>/leftButton");
    }

    // Update is called once per frame
    void Update()
    {
        if (clickAction.triggered)
        {
            ShootBullet();
        }
    }
     private void ShootBullet()
    {
        print("ShootBullet function");
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity))
        {
            targetPoint = hitInfo.point; // אם הקרן פגעה במשהו
        }
        else
        {
            // אם אין פגיעה, משתמשים במיקום רחוק בכיוון הקרן
            targetPoint = ray.GetPoint(maxRayDistance);
        }

        // מחשבים כיוון מהאובייקט הנוכחי לנקודת הפגיעה
        Vector3 direction = (targetPoint - transform.position).normalized;

        // יוצרים את הקליע
        GameObject bullet = Instantiate(spawnObject, transform.position, Quaternion.identity);

        // מוסיפים לו כוח
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = direction * objectSpeed;
        }
        print("Bullet created");
    }
    void print(string message)
    {
        Debug.Log(message);
    }
}
