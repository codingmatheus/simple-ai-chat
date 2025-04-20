# SimpleAIChat

A lightweight .NET console application for interacting with Amazon Bedrock's Claude 3 Sonnet model.

## Overview

SimpleAIChat is a minimalist chat application that connects to Amazon Bedrock's Claude 3 Sonnet model, allowing users to have interactive conversations with the AI through a simple command-line interface.

## Features

- Direct integration with Amazon Bedrock Runtime API
- Conversation history management
- Configurable inference parameters (temperature, max tokens, etc.)
- Simple console-based user interface
- Error handling with graceful recovery options

## Prerequisites

- .NET 9.0 SDK or later
- AWS account with access to Amazon Bedrock
- Proper AWS credentials configured on your machine
- Access to Claude 3 Sonnet model in Amazon Bedrock

## Getting Started

### Installation

1. Clone the repository:
   ```
   git clone https://github.com/yourusername/simple-ai-chat.git
   cd simple-ai-chat/dev/dotnet
   ```

2. Build the project:
   ```
   dotnet build
   ```

3. Run the application:
   ```
   dotnet run --project SimpleAIChat
   ```

### AWS Configuration

Ensure your AWS credentials are properly configured with access to Amazon Bedrock. You can set up credentials using:

- AWS CLI: `aws configure`
- Environment variables
- AWS credentials file (`~/.aws/credentials`)

## Usage

1. Start the application
2. Type your message and press Enter
3. The AI will respond to your message
4. Continue the conversation or type 'exit' to quit

## Project Structure

```
SimpleAIChat/
├── Program.cs          # Main application logic
├── SimpleAIChat.csproj # Project file with dependencies
├── docs/               # Documentation
└── media/              # Media assets
```

## Dependencies

- AWSSDK.BedrockRuntime - For interacting with Amazon Bedrock
- AWSSDK.Core - Core AWS SDK functionality
- AWSSDK.SSO - AWS Single Sign-On support
- AWSSDK.SSOOIDC - AWS SSO OpenID Connect support

## Configuration

The application uses the following default settings:

- Model: Claude 3 Sonnet
- Region: US West 2 (Oregon)
- Max Tokens: 2000
- Temperature: 0.7
- Top P: 0.9

You can modify these settings in the `Program.cs` file.

## Error Handling

The application includes basic error handling for common issues:
- Network connectivity problems
- API rate limiting
- Invalid inputs
- Authentication failures

## License

[Specify your license here]

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Acknowledgements

- Amazon Web Services for providing the Bedrock API
- Anthropic for developing the Claude model

---

For more information about Amazon Bedrock, visit the [official documentation](https://docs.aws.amazon.com/bedrock/).
