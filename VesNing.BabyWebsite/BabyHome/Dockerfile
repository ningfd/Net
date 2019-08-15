FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /usr/local/app/babyhome
EXPOSE 8080

FROM base AS final
WORKDIR /usr/local/app/babyhome
COPY  . /usr/local/app/babyhome
ENTRYPOINT ["dotnet", "UI.dll"]
