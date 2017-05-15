using System;
/**
 * Tree keeps  all clients
 * Search is O(logn)
 */
class BinarySearchTree
{
    //root
    protected TreeNode<Client> root { get; set; }
    //add return boolean variable
    protected bool addReturn;
    int sizeBinary;

    //Defaılt constructor
    public BinarySearchTree()
    {
        sizeBinary = 0;
        this.root = null;
    }

    //inset a client
    public bool Insert(Client item)
    {
        this.root = Insert(item, this.root);
        return addReturn;
    }

    //make empty
    public void MakeEmpty()
    {
        this.root = null;
    }
    //is empty
    public bool IsEmpty()
    {
        return this.root == null;
    }

    //added a client to binary tree, if client not exist in tree.
    private TreeNode<Client> Insert(Client item, TreeNode<Client> localRoot)
    {
        //added a new client
        if (localRoot == null)
        {
            addReturn = true;
            ++sizeBinary; //increase size
            return new TreeNode<Client>(item);
        }
        //compare the clients id
        int comp = (int.Parse(item.Clientid) as IComparable).CompareTo(int.Parse(localRoot.Element.Clientid));
        
        //ifcomp equal zero, this client exist
        if (comp == 0)
        {
            addReturn = false;
            localRoot.Element.add(item.NewSongid); //add diff song
            return localRoot;
        }
        //ifcomp less then zero, continue left tree 
        else if ( comp < 0)
        {
            localRoot.Left = Insert(item, localRoot.Left);
            return localRoot;
        }
        //ifcomp more then zero, continue rigt tree 
        else
        {
            localRoot.Right = Insert(item, localRoot.Right);
            return localRoot;
        }
    }
    // tostring
    public override string ToString()
    {
        return this.root.ToString();
    }
    //size
    public int size()
    {
        return sizeBinary;
    }

    //create a array and send to preOrder funtion to fill 
    public int[] playingDiffSongUsers()
    {
        int s = size();
        int[] numOfClients = new int[s];
        for (int i = 0; i < s; ++i)
        {
            numOfClients[i] = 0;
        }
        preOrderTraverse(root, numOfClients);

        return numOfClients;

    }
    //traverse tree as preorder
    //This function counts different songs with the same number of songs, and fill array.
    private void preOrderTraverse(TreeNode<Client> localRoot, int[] numOfClients)
    {
        if (localRoot == null)
            return;// numOfClients;

        numOfClients[localRoot.Element.sizeSong()] += 1;
     
        preOrderTraverse(localRoot.Left, numOfClients);
        preOrderTraverse(localRoot.Right, numOfClients);
        //return numOfClients;
    }
    //display the array
    //thus finish the process.
    public void display()
    {
        int[] temp = playingDiffSongUsers();

        Console.WriteLine("DISTINCT_PLAY_COUNT  " + "CLIENT_COUNT");


         for (int i = 0; i < temp.Length; ++i)
         {
            if(temp[i] != 0)
             Console.WriteLine("\t"+i + "\t\t"+temp[i]);
         }
    }
}
