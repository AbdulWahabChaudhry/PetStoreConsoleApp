#	PetStoreConsole

This C# console application calls the [Pet Store API](https://petstore.swagger.io/) to fetch a list of pets **with status=available**, then prints them grouped by Category. Within each Category, the pets are sorted in **reverse alphabetical order** by name.

## How to Run Locally

1. **Install .NET 8.0** (if not already installed).
2. Clone this repository (or copy these files into a local folder).
3. Navigate to the root directory in your terminal: cd path/to/PetStoreConsole
4. Run the project: dotnet run --project ./PetStoreConsole/PetStoreConsole.csproj
5. Run the tests: dotnet test ./PetStoreConsole.Tests/PetStoreConsole.Tests.csproj 
 


##	Enterprise Readiness

To make this application enterprise-ready, consider the following steps:

Authentication and Authorization: Secure endpoints with OAuth2 or similar protocols if hitting protected APIs.

Configuration Management: Store API URLs and credentials in a secure configuration (e.g., Azure Key Vault, AWS Parameter Store, or environment variables).

Logging and Monitoring: Implement a robust logging framework (e.g., Serilog, NLog) and integrate with a monitoring solution (AppInsights, Splunk, etc.).

Error Handling: Add retry policies, circuit breakers (e.g., Polly) and graceful degradation when external APIs fail or time out.

CI/CD Pipeline: Automate builds, tests, code coverage, and deployments via GitHub Actions, Azure DevOps, or other CI/CD pipelines.

Containerization: Package the application as a Docker container for consistent deployment across environments.

Scalability: For high-volume usage, consider load balancing, caching strategies, and a scalable infrastructure (Kubernetes or serverless solutions).

## ChatGPT Transcript

This chat was initially used to generate an accurate prompt by providing the tech test document as part of the basic prompt: https://chatgpt.com/share/67ea6bab-3474-8007-afd8-dafa24978648
Using the prompt generated from the above, a more accurate and detailed response was obtained : https://chatgpt.com/share/67ea6b34-b408-8007-adb0-f395fe50fab9
