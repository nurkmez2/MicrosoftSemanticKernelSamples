using Microsoft.Agents.CopilotStudio.Client;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Agents.Copilot;
using System.Threading.Tasks;

#pragma warning disable
namespace ConnectCopilotStudio
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, Copilot Studio Agents!!!");

            string appClientId = "";
            string tenantId = "";
            string appClientSecret = "";


            CopilotStudioConnectionSettings connectionSettings = new(tenantId, appClientId, appClientSecret);

            connectionSettings.EnvironmentId = "";
            connectionSettings.SchemaName = "";

            CopilotClient copilotClient = CopilotStudioAgent.CreateClient(connectionSettings);
            
            CopilotStudioAgent copilotStudioAgent = new(copilotClient);            

            await foreach(ChatMessageContent chatMessage in copilotStudioAgent.InvokeAsync("trip to Germany"))
            {
                Console.WriteLine(chatMessage.Content);
            }

            Console.Read();
        }
    }
}
