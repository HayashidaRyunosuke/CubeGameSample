using UnityEngine;

namespace CubeGameSample
{
    [RequireComponent(typeof(BoxCollider))]
    public class CubeBehaviour : MonoBehaviour
    {
        public bool IsTrigger
        {
            get { return true; }
        }

        private BoxCollider _boxCollider;
        
        public BoxCollider BoxCol
        {
            get
            {
                if (!_boxCollider) _boxCollider = GetComponent<BoxCollider>();
                return _boxCollider;
            }
        }

        public Vector3 UpperRightBackCornerPos
        {
            get
            {
                return new Vector3(transform.position.x - transform.localScale.x/2,transform.position.y + transform.localScale.y/2,transform.position.z + transform.localScale.z/2);
            }
        }
        public Vector3 LowerLeftFrontCornerPos
        {
            get
            {
                return new Vector3(transform.position.x + transform.localScale.x/2,transform.position.y - transform.localScale.y/2,transform.position.z - transform.localScale.z/2);
            }
        }

        public static void SetRight(CubeBehaviour root,CubeBehaviour child)
        {
            child.gameObject.transform.position = new Vector3(root.UpperRightBackCornerPos.x - root.gameObject.transform.localScale.x/2,root.UpperRightBackCornerPos.y - root.gameObject.transform.localScale.y/2,root.UpperRightBackCornerPos.z - root.gameObject.transform.localScale.z/2);   
        }
        
        public static void SetLeft(CubeBehaviour root,CubeBehaviour child)
        {
            child.gameObject.transform.position = new Vector3(root.LowerLeftFrontCornerPos.x + root.gameObject.transform.localScale.x/2,root.LowerLeftFrontCornerPos.y + root.gameObject.transform.localScale.y/2,root.LowerLeftFrontCornerPos.z + root.gameObject.transform.localScale.z/2);   
        }
        
        public static void SetFront(CubeBehaviour root,CubeBehaviour child)
        {
            child.gameObject.transform.position = new Vector3(root.gameObject.transform.position.x,root.gameObject.transform.position.y,root.UpperRightBackCornerPos.z + root.gameObject.transform.localScale.z/2);   
        }
        
        public static void SetBack(CubeBehaviour root,CubeBehaviour child)
        {
            child.gameObject.transform.position = new Vector3(root.gameObject.transform.position.x,root.gameObject.transform.position.y,root.LowerLeftFrontCornerPos.z - root.gameObject.transform.localScale.z/2);   
        }
        
        public static void SetUpper(CubeBehaviour root,CubeBehaviour child)
        {
            child.gameObject.transform.position = new Vector3(root.gameObject.transform.position.x,root.UpperRightBackCornerPos.y + root.gameObject.transform.localScale.y/2,root.gameObject.transform.position.z);   
        }
        
        public static void SetLower(CubeBehaviour root,CubeBehaviour child)
        {
            child.gameObject.transform.position = new Vector3(root.gameObject.transform.position.x,root.LowerLeftFrontCornerPos.y - root.gameObject.transform.localScale.y/2,root.gameObject.transform.position.z);   
        }
        
    }
}