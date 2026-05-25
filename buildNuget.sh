#!/bin/bash
dotnet restore
dotnet pack -c Release -o ./artifacts
