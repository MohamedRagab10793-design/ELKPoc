# Project Title

[![.NET 8](https://img.shields.io/badge/.NET-8.0-blueviolet.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![ElasticSearch](https://img.shields.io/badge/Elasticsearch-8.13.4-orange.svg)](https://www.elastic.co/elasticsearch/)

## Overview

This project is built with C# and .NET 8, utilizing **Elasticsearch** for advanced search capabilities. The Elasticsearch instance is hosted within a Docker container, ensuring smooth integration and streamlined deployment. The project is configured to interact with Elasticsearch through the provided URL in `appsettings.json`.

## Requirements

- **.NET 8 SDK**: [Download here](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Docker**: For containerizing and running Elasticsearch locally

## Setup

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/your-repo-name.git
   cd your-repo-name

2. **Configure Elasticsearch**:
   Ensure Elasticsearch is running via Docker. Use the following command to pull and run the Elasticsearch image (version 8.13.4)

3. **Configure Application**
 Open `appsettings.json` and verify the `ElasticSearch` configuration:
  ```json
  "ElasticSearch": {
  "Url": "http://localhost:9200"
  }
  ```

Running the Project
1. **Restore Dependencies**:
 ```bash
 dotnet restore
 ```
2. **Build and Run**:
 ```bash
 dotnet run
 ```
 Usage
 Upon successful startup, the application will connect to the local Elasticsearch instance on port
 `9200`. You can interact with the Elasticsearch features through the provided endpoints or within the application interface.
