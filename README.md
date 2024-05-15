# Maui App + SignalR + OpenTelemetry + Prometheus + Grafana

## Overview

This repository demonstrates the integration flow from a .NET MAUI App simulating real time stocks information with SignalR Core and sending that telemetry to Prometheus and visualize the data in the Grafana visualization tool. 

The goal is to showcase how to monitor and visualize metrics from the MauiAppClient using industry-standard observability opentelemetry + prometheus + grafana tools.

## Prerequisites

- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/community/) installed.
- [Net 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) installled.
- [Prometheus](https://prometheus.io/download/) installed and configured.
- [Grafana](https://prometheus.io/docs/tutorials/visualizing_metrics_using_grafana/) installed and the prometheus datasource configured.

## Setup

1. Clone o download this repository:

   ```bash
   git clone https://github.com/camiloJaramillo5/maui-signalr-opentelemetry/
2. Optionally configure prometheus.yml that you have downloaded from [Prometheus](https://prometheus.io/download/) web page with your custom configuration (port and times). [This is](https://github.com/camiloJaramillo5/maui-signalr-opentelemetry/blob/main/prometheus.yml) a copy of the one that is used in this project.
3. Run prometheus.exe file from the same folder that you have downloaded from the web page.
4. Open and Run [SignalRServer](https://github.com/camiloJaramillo5/maui-signalr-opentelemetry/tree/main/SignalRServer) project.
5. Open, configure SignalRServer URL and run [ConsoleClientApp](https://github.com/camiloJaramillo5/maui-signalr-opentelemetry/tree/main/ConsoleAppClient) sender project.
6. Open, configure SignalRServer URL and run [MauiAppClient](https://github.com/camiloJaramillo5/maui-signalr-opentelemetry/tree/main/MauiAppClient) receiver project
7. You should see similar next results:

![image](https://github.com/camiloJaramillo5/maui-signalr-opentelemetry/assets/80411997/f1a14932-4eef-42e8-bf6d-bf08001067a4)
![image](https://github.com/camiloJaramillo5/maui-signalr-opentelemetry/assets/80411997/067a85e1-8eca-4337-b297-92c1d5fdea2b)
![image](https://github.com/camiloJaramillo5/maui-signalr-opentelemetry/assets/80411997/d1a5ccae-dd53-426a-b584-c0427998e15d)

8. And now you should see the telemetry data flowing through Prometheus http://localhost:9090/targets?search and Grafana http://localhost:3000/explore? urls:
  
  ![image](https://github.com/camiloJaramillo5/maui-signalr-opentelemetry/assets/80411997/0bf5abb0-ba1d-41f6-afde-3141a4eb76b5)

  ![image](https://github.com/camiloJaramillo5/maui-signalr-opentelemetry/assets/80411997/e6bef914-2ebd-45c1-94b9-858776968afc)

