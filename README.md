Repo for creating Resume template using QuestPDF

This apps creates PDF resumes by using a template engine and  allows convenient creation of a single page PDF resume by simply editing text if using a word processor does not give consistent formatting.

Example:

Input: JSON
``` json
{"Contact":{"Name":"Steve Jobsfinder","Email":"sjobsfinder@crapple.com","Phone":"123-456-7890","Linkedin":"https://linkedin.com/in/steve-jobsfinder","Github":"https://github.com/sjobsfinder"},

"Education":{"Education":[{"Name":"Northsouthern University","Degree":"B.S. Marketing","GraduationDate":"May 1990"},{"Name":"Southnorthern University","Degree":"M.S. Finance","GraduationDate":"May 1992"}]},

"Experience":{"Experiences":[{"Company":"Crapple","Role":"Founder/CEO","StartDate":"Jan 1976","EndDate":"Sep 1985","Tasks":["task 1","task 2","task 3"]},{"Company":"Flixar","Role":"Founder/CEO","StartDate":"May 1986","EndDate":"May 2006","Tasks":["task 1","task 2","task 3"]}]},"Skills":{"Skills":{"Design":"calligraphy , UX , UI","Management":"yelling, controlling, authoritarian","Communication":"simple, innovative, wow"}},

"Projects":{"Projects":{"Crapple cryPhone":"lead designer on an overpriced touch screen smartphone that will make your wallet bleed and bring you to tears","Crapple cryPad":"lead designer of a tablet that\u0027s actually an overpriced brick"}}}
```

Output PDF Resume

[PDF](resume.example1.pdf)

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