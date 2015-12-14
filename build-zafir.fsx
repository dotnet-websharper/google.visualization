#load "tools/includes.fsx"
open IntelliFactory.Build

let bt =
    BuildTool().PackageId("Zafir.Google.Visualization")
        .VersionFrom("Zafir")
        .WithFSharpVersion(FSharpVersion.FSharp30)
        .WithFramework(fun fw -> fw.Net40)

let main =
    bt.Zafir.Library("WebSharper.Google.Visualization")
        .SourcesFromProject()

let test =
    bt.Zafir.HtmlWebsite("WebSharper.Google.Visualization.Tests")
        .SourcesFromProject()
        .References(fun r ->
            [
                r.Project main
                r.NuGet("Zafir.Html").Reference()
            ])

bt.Solution [
    main
    test

    bt.NuGet.CreatePackage()
        .Configure(fun c ->
            { c with
                Title = Some "Zafir.Google.Visualization-2013.08.27"
                LicenseUrl = Some "http://websharper.com/licensing"
                ProjectUrl = Some "https://github.com/intellifactory/websharper.google.visualization"
                Description = "Zafir Extensions for Google Visualization 2013.08.27"
                RequiresLicenseAcceptance = true })
        .Add(main)

]
|> bt.Dispatch
