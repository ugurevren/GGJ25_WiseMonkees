using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
   // yapay zekaya yazdirdim yarin halletcez
   private bool isGrounded;
   private Rigidbody rb;
   private float jumpForce = 5f;
   // 31
   
   //write jump script here
   void Jump()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
      {
         rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
         isGrounded = false;
      }
   }
}
