@echo off
dotnet build src/Limbo.Umbraco.RecycleBin --configuration Debug /t:rebuild /t:pack -p:BuildTools=1 -p:PackageOutputPath=c:/nuget