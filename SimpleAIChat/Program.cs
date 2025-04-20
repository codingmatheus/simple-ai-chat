using Amazon;
using Amazon.BedrockRuntime;
using Amazon.BedrockRuntime.Model;

try
{
    await RunChatAsync();
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
}
finally
{
    Console.WriteLine("\nExiting application...");
}

async Task RunChatAsync()
{
    var modelId = "arn:aws:bedrock:us-west-2:891377241520:inference-profile/us.anthropic.claude-3-7-sonnet-20250219-v1:0";
    RegionEndpoint region = RegionEndpoint.USWest2;
    
    var client = new AmazonBedrockRuntimeClient(region);
    var conversation = new List<Message>
    {
        // Using user role instead of system role since Bedrock API only accepts user and assistant roles
        new Message()
        {
            Role = "user",
            Content = new List<ContentBlock>
            {
                new ContentBlock()
                {
                    Text = "You are a friendly AI chat. Please acknowledge this instruction."
                }
            }
        },
        // Adding an assistant acknowledgment to complete the initial exchange
        new Message()
        {
            Role = "assistant",
            Content = new List<ContentBlock>
            {
                new ContentBlock()
                {
                    Text = "I'll be a friendly AI chat assistant. How can I help you today?"
                }
            }
        }
    };

    bool continueRunning = true;
    while (continueRunning)
    {
        try
        {
            Console.WriteLine("What can I help you with? (type 'exit' to quit)");
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
            {
                continueRunning = false;
                continue;
            }
            
            var userMessage = new Message()
            {
                Role = "user",
                Content = new List<ContentBlock>()
                {
                    new ContentBlock()
                    {
                        Text = input
                    }
                }
            };
            conversation.Add(userMessage);

            var request = new ConverseRequest()
            {
                ModelId = modelId,
                Messages = conversation,
                InferenceConfig = new InferenceConfiguration()
                {
                    MaxTokens = 2000,
                    Temperature = 0.7f,
                    TopP = 0.9f
                }
            };
            
            var response = await client.ConverseAsync(request);

            foreach (var contentMessage in response.Output.Message.Content)
            {
                var content = contentMessage.Text;
                if (!string.IsNullOrEmpty(content))
                {
                    Console.WriteLine(content);
                }
            }
        
            Console.WriteLine();
            
        }
        catch (Exception e)
        {
            Console.Error.WriteLine($"Error: {e.Message}");
            Console.WriteLine("Would you like to continue?(y/n)");
            var input = Console.ReadLine();
            var decision = input?.ToLower() ?? "n";
            if(decision != "y" && decision != "yes") continueRunning = false;
            
        }
    }
    
    Console.Write("Thanks for using Simple AI Chat!");
}
