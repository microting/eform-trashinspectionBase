#!/bin/bash

dotnet add Microting.eFormTrashInspectionBase/Microting.eFormTrashInspectionBase.csproj package Microting.eForm

EFORM_VERSION=`dotnet list package | grep 'Microting.eForm ' | cut -c54-60`
COMMIT_MESSAGE="Updating"$'\n'"- Microting.eForm to ${EFORM_VERSION}"

git add .
git commit -m "$COMMIT_MESSAGE"
