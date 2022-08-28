FROM mcr.microsoft.com/dotnet/runtime:3.1
COPY bin/Release/netcoreapp3.1/publish .
ENTRYPOINT ["dotnet", "Comms.RabbitMq.Producer.dll"]

#docker build -t myserviceimage .
#docker run myserviceimage