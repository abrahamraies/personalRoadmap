class Program
{
    static void Main()
    {
        int[] stack = { 1, 2, 3, 4, 5 };

        // Push Operation
        Console.WriteLine("Enter the number to add to the stack:");
        int numToAdd = int.Parse(Console.ReadLine());

        int[] newStackArray = new int[stack.Length + 1];
        stack.CopyTo(newStackArray, 0);
        newStackArray[^1] = numToAdd; // Add at the last position
        stack = newStackArray;

        Console.WriteLine("Number added to the stack!");

        // Pop Operation
        Console.WriteLine("Enter the number to remove from the stack:");
        if (stack.Length == 0)
        {
            Console.WriteLine("The stack is empty!");
        }
        else
        {
            int numToRemove = int.Parse(Console.ReadLine());
            if (!stack.Contains(numToRemove))
            {
                Console.WriteLine("Number not found in the stack.");
            }
            else
            {
                stack = stack.Where(x => x != numToRemove).ToArray();
                Console.WriteLine($"Number {numToRemove} removed from the stack!");
            }
        }

        // View Top Element
        if (stack.Length > 0)
        {
            Console.WriteLine("The current top element is: " + stack[^1]);
        }
        else
        {
            Console.WriteLine("The stack is empty!");
        }

        // Check if Stack is Empty
        Console.WriteLine(stack.Length == 0 ? "The stack is empty." : "The stack has elements.");

        // Search a Number
        Console.WriteLine("Enter a number to search in the stack:");
        int numberToSearch = int.Parse(Console.ReadLine());
        Array.Sort(stack);
        int index = BinarySearch(stack, numberToSearch);
        Console.WriteLine(index == -1
            ? "The number is not in the stack."
            : $"The number is at index: {index}");
    }

    static int BinarySearch(int[] sortedArray, int target)
    {
        int left = 0, right = sortedArray.Length - 1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (sortedArray[mid] == target) return mid;
            if (sortedArray[mid] < target) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }
}
