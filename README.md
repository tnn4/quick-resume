Repo for creating Resume template using QuestPDF

Create new visual studio console project 

Install QuestPDF from nuget

```cs

// Package Manager
Install-Package QuestPDF

// .NET CLI
dotnet add package QuestPDF

// Package reference in .csproj file
<PackageReference Include="QuestPDF" Version="2022.6.0" />
```

More details: https://www.questpdf.com/getting-started.html#what-to-expect

Before pushing to git repository, make sure you clean build artifacts:

At root directory:

`dotnet clean`

### TODO
- output JSON
- read JSON