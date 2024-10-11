namespace bst_binary_search_tree;

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
public class BTS
{
    private Node? root;

    public BTS()
    {
        this.root = root;
    }

    public void insertBST(int id, string element)
    {
        if (root == null)
        {
            root = new Node(id, element, null, null);
        }
        else
        {
            Node newNode = new Node(id, element, null, null);
            insert(root, newNode);
        }
    }

    private void insert(Node actual, Node newNode)
    {
        if (actual.getId() == newNode.getId())
        {
            return;
        }

        if (newNode.getId() < actual.getId())
        {
            if (actual.getLeft() == null)
            {
                actual.setLeft(newNode);
            }
            else
            {
                insert(actual.getLeft(), newNode);
            }
        }
        if (newNode.getId() > actual.getId())
        {
            if (actual.getRight() == null)
            {
                actual.setRight(newNode);
            }
            else
            {
                insert(actual.getRight(), newNode);
            }
        }
    }

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
        preFixed(root);
    }

    public Node searchBST(int id)
    {
        return search(root, id);
    }

    private Node search(Node actual, int id)
    {
        if (actual == null)
        {
            Console.WriteLine("Elemento NÃO encontrado!");
            return null;
        }
        if (actual.getId() == id)
        {
            Console.WriteLine($"Elemento {actual.getId()} encontrado!");
            return actual;
        }

        if (id < actual.getId())
        {
            return search(actual.getLeft(), id);
        }
        else
        {
            return search(actual.getRight(), id);
        }

    }
}
class Program
{
    static void Main(string[] args)
    {
        BTS a = new BTS();
        a.insertBST(88, "el");
        a.insertBST(70, "el");
        a.insertBST(75, "el");
        a.insertBST(99, "el");
        a.insertBST(110, "el");
        a.insertBST(105, "el");
        a.insertBST(119, "el");
        a.insertBST(80, "el");
        a.insertBST(67, "el");
        a.insertBST(59, "el");
        a.insertBST(72, "el");
        a.insertBST(91, "el");
        a.insertBST(90, "el");
        a.insertBST(95, "el");
        a.insertBST(69, "el");
        a.insertBST(77, "elemento adicional");

        a.printElements();
        a.searchBST(59);
    }
}
