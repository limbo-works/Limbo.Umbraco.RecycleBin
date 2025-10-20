@echo off
dotnet build src/Limbo.Umbraco.RecycleBin --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget