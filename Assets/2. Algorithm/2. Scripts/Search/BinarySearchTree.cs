using UnityEditor.Experimental.GraphView;
using UnityEngine;


public class BinarySearchTree : MonoBehaviour
{
    public class TreeNode
    {
        public TreeNode left;
        public TreeNode right;
        public int value;

        public TreeNode(int param)
        {
            this.value = param;
        }
    }

    TreeNode root;
    private int[] arr = { 8, 3, 10, 1, 6, 14, 4, 7, 13 };

    public string pre_order = "전위 순회 : ";
    public string post_order = "후위 순회 : ";
    public string in_order = "중위 순회 : ";


    void Start()
    {
        foreach (int element in arr)
        {
            root = InsertNode(root, element);
        }

        Orders();
    }

    TreeNode InsertNode(TreeNode param_node, int param_value)
    {
        if (param_node == null)
        {
            return new TreeNode(param_value);
        }

        if (param_value < param_node.value)
            param_node.left = InsertNode(param_node.left, param_value);
        else
            param_node.right = InsertNode(param_node.right, param_value);

        return param_node;
    }

    private void Orders()
    {
        PreOrder(root);
        InOrder(root);
        PostOrder(root);

        Debug.Log(pre_order.TrimEnd(','));
        Debug.Log(post_order.TrimEnd(','));
        Debug.Log(in_order.TrimEnd(','));
    }

    /// <summary> 전위순회 </summary>
    private void PreOrder(TreeNode param_node)
    {
        if (param_node == null)
            return;

        pre_order += $" {param_node.value},";
        PreOrder(param_node.left);
        PreOrder(param_node.right);
    }

    /// <summary> 중위순회 </summary>
    private void InOrder(TreeNode param_node)
    {
        if (param_node == null)
            return;


        InOrder(param_node.left);
        in_order += $" {param_node.value},";
        InOrder(param_node.right);
    }

    /// <summary> 후위순회 </summary>
    private void PostOrder(TreeNode param_node)
    {
        if (param_node == null)
            return;


        PostOrder(param_node.left);
        PostOrder(param_node.right);
        post_order += $" {param_node.value},";
    }

}
