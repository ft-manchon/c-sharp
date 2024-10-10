namespace binary_tree;

public class Node
{
    private int id;
    private string element;
    private Node? left;
    private Node? right;

    public Node(int id, string element, Node left, Node right)
    {
        this.id = id;
        this.element = element;
        this.left = left;
        this.right = right;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public int getId()
    {
        return this.id;
    }

    public void setElement(string element)
    {
        this.element = element;
    }

    public string getElement()
    {
        return element;
    }

    public void setLeft(Node left)
    {
        this.left = left;
    }

    public Node getLeft()
    {
        return left;
    }

    public void setRight(Node right)
    {
        this.right = right;
    }

    public Node getRight()
    {
        return right;
    }
}

public class BinaryTree
{
    private Node? root;

    public BinaryTree()
    {
        this.root = root;
    }

    public void insertElement(int id, string element)
    {
        Node newNode = new Node(id, element, null, null);

        if (root == null)
        {
            root = newNode;
        }
        else
        {
            Node actual = root;
            Node parent;

            while (true)
            {
                parent = actual;

                if (id < actual.getId())
                {
                    actual = actual.getLeft();

                    if (actual == null)
                    {
                        parent.setLeft(newNode);
                        return;
                    }
                }
                else
                {
                    actual = actual.getRight();

                    if (actual == null)
                    {
                        parent.setRight(newNode);
                        return;
                    }
                }
            }
        }
    }

    // caminhamento pela árvore

    private void preFixed(Node actual)
    {
        if (actual != null)
        {
            Console.WriteLine("Id: " + actual.getId() + " Elemento: " + actual.getElement());
            preFixed(actual.getLeft());
            preFixed(actual.getRight());
        }
    }

    private void postFixed(Node actual)
    {
        if (actual != null)
        {
            postFixed(actual.getLeft());
            postFixed(actual.getRight());
            Console.WriteLine("Id: " + actual.getId() + " Elemento: " + actual.getElement());
        }
    }

    private void inFixed(Node actual)
    {
        if (actual != null)
        {
            inFixed(actual.getLeft());
            Console.WriteLine("Id: " + actual.getId() + " Elemento: " + actual.getElement());
            inFixed(actual.getRight());
        }
    }

    public void printElements()
    {
        inFixed(root);
    }

    private int calcHeight(Node actual, int h)
    {
        if (actual != null)
        {
            int e, d;
            e = calcHeight(actual.getLeft(), h) + 1;
            d = calcHeight(actual.getRight(), h) + 1;

            if (e > d)
            {
                return h + e;
            }
            else
            {
                return h + d;
            }
        }
        return h;
    }

    public int treeHeight()
    {
        int h = 0;
        return calcHeight(root, h);
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree b = new BinaryTree();

        b.insertElement(10, "A");
        b.insertElement(5, "B");
        b.insertElement(15, "C");
        b.insertElement(2, "D");
        b.insertElement(7, "E");
        b.insertElement(12, "F");
        b.insertElement(6, "G");
        b.insertElement(8, "H");
        b.insertElement(3, "adicional");

        b.printElements();
    }
}
