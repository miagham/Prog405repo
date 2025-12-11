namespace TodoPOCO
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta; 
            await TypeWriter("POCO Todo Assignment\n");


            TodoItem item = new TodoItem
            {
                Title = "Stub Work by Mia\n",

                Description = "Think about SRP Single Respoibility Princiapal and Open Closed in out design\n",

            };

            await TypeWriter($"Title: {item.Title}");

            await TypeWriter($"Description: {item.Description}");

        }
        static async Task TypeWriter(string text, int delay = 100)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                await Task.Delay(delay);
            }
        }
    }
}
